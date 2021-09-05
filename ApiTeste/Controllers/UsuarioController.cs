using ApiTeste.Models.Entities;
using ApiTeste.Models.Requests;
using ApiTeste.Models.Responses;
using ApiTeste.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;
        private readonly ITipoUsuarioService _tipoUsuarioService;
        private readonly IPullRequestService _pullRequestService;

        public UsuarioController(
            ILogger<UsuarioController> logger,
            IMapper mapper,
            IUsuarioService usuarioService,
            ITipoUsuarioService tipoUsuarioService,
            IPullRequestService pullRequestService)
        {
            _logger = logger;
            _mapper = mapper;
            _usuarioService = usuarioService;
            _tipoUsuarioService = tipoUsuarioService;
            _pullRequestService = pullRequestService;
        }

        [HttpGet("/[controller]/{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var usuario = _usuarioService.Find(email);

            var response = new UsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Telefone = usuario.Telefone,
                TipoUsuarioId = usuario.TipoUsuarioId
            };

            return await Task.FromResult(Ok(response));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = _usuarioService.FindAll();

            var response = new List<UsuarioResponse>();
            foreach (var usuario in usuarios)
            {
                response.Add(new UsuarioResponse
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    DataNascimento = usuario.DataNascimento,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                    Telefone = usuario.Telefone,
                    TipoUsuarioId = usuario.TipoUsuarioId
                });
            }

            return await Task.FromResult(Ok(response));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]UsuarioRequest usuarioRequest)
        {
            var usuario = _mapper.Map<Usuario>(usuarioRequest);
            _usuarioService.Add(usuario);

            var response = new UsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Telefone = usuario.Telefone,
                TipoUsuarioId = usuario.TipoUsuarioId
            };

            return await Task.FromResult(Created(Request.Path.Value, response));
        }

        [HttpPut("/[controller]/{idUsuario}")]
        public async Task<IActionResult> Update([FromBody]UsuarioRequest usuarioRequest, int idUsuario)
        {
            var usuario = _usuarioService.FindById(idUsuario);

            if (usuario != null)
                usuario = _usuarioService.Update(usuarioRequest, usuario);

            var response = new UsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Telefone = usuario.Telefone,
                TipoUsuarioId = usuario.TipoUsuarioId
            };

            return await Task.FromResult(Ok(response));
        }

        [HttpDelete("/[controller]/{idUsuario}")]
        public async Task<IActionResult> Delete(int idUsuario)
        {
            var usuario = _usuarioService.FindById(idUsuario);

            if (usuario != null)
                usuario = _usuarioService.Delete(usuario);

            var response = new UsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Telefone = usuario.Telefone,
                TipoUsuarioId = usuario.TipoUsuarioId
            };

            return await Task.FromResult(Ok(response));
        }

        [HttpPost("/[controller]/tipo")]
        public async Task<IActionResult> Create([FromBody]TipoUsuarioRequest tipoUsuarioRequest)
        {
            var usuarioRequisitante = _usuarioService.Find(tipoUsuarioRequest.Email);
            if (usuarioRequisitante == null)
                throw new Exception("Você não está autenticado.");

            var tipoUsuarioRequisitante = _tipoUsuarioService.FindById(usuarioRequisitante.TipoUsuarioId);
            if (tipoUsuarioRequisitante.Nome != "Admin")
                throw new Exception("Você não está autorizado a criar tipos de usuários.");

            var tipoUsuario = _mapper.Map<TipoUsuario>(tipoUsuarioRequest);
            _tipoUsuarioService.Add(tipoUsuario);

            var response = new TipoUsuarioResponse
            {
                Id = tipoUsuario.Id,
                Nome = tipoUsuario.Nome,
                Descricao = tipoUsuario.Descricao
            };

            return await Task.FromResult(Created(Request.Path.Value, response));
        }

        [HttpGet("/[controller]/{idUsuario}/pullrequests")]
        public async Task<IActionResult> GetPullRequests(int idUsuario)
        {
            if (!_usuarioService.Exists(idUsuario)) return await Task.FromResult(BadRequest("O usuário informado não existe."));
            var pullRequests = _pullRequestService.FindByUsuario(idUsuario);

            if (pullRequests.Count == 0)
                throw new Exception("Usuário ainda não fez nenhum Pull Request.");

            var response = new List<PullRequestResponse>();
            foreach (var pullRequest in pullRequests)
            {
                response.Add(new PullRequestResponse
                {
                    Id = pullRequest.Id,
                    FromBranch = pullRequest.FromBranch,
                    ToBranch = pullRequest.ToBranch,
                    Message = pullRequest.Message,
                    UsuarioId = pullRequest.UsuarioId,
                    RepositorioId = pullRequest.RepositorioId
                });
            }

            return await Task.FromResult(Ok(response));
        }
    }
}
