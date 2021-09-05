using ApiTeste.Database;
using ApiTeste.Models.Entities;
using ApiTeste.Models.Requests;
using ApiTeste.Models.Responses;
using ApiTeste.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RepositorioController : ControllerBase
    {
        private readonly ILogger<RepositorioController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepositorioService _repositorioService;
        private readonly IPullRequestService _pullRequestService;
        private readonly IUsuarioService _usuarioService;

        public RepositorioController(ILogger<RepositorioController> logger, IMapper mapper, IRepositorioService repositorioService, IPullRequestService pullRequestService, IUsuarioService usuarioService)
        {
            _logger = logger;
            _mapper = mapper;
            _repositorioService = repositorioService;
            _pullRequestService = pullRequestService;
            _usuarioService = usuarioService;
        }

        [HttpGet("/[controller]/{idRepositorio}")]
        public async Task<IActionResult> Get(int idRepositorio)
        {
            var repositorio = _repositorioService.FindById(idRepositorio);

            var response = new RepositorioResponse
            {
                Id = repositorio.Id,
                DataCriacao = repositorio.DataCriacao,
                Descricao = repositorio.Descricao,
                Nome = repositorio.Nome,
                UsuarioId = repositorio.UsuarioId,
                QuantidadeLikes = repositorio.QuantidadeLikes,
                MediaDeLikesPorDia = Math.Round(repositorio.RetornaMediaDeLikesPorDia(), 2)
            };

            return await Task.FromResult(Ok(response));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var repositorios = _repositorioService.FindAll();

            var response = new List<RepositorioResponse>();
            foreach (var repositorio in repositorios)
            {
                response.Add(new RepositorioResponse
                {
                    Id = repositorio.Id,
                    DataCriacao = repositorio.DataCriacao,
                    Descricao = repositorio.Descricao,
                    Nome = repositorio.Nome,
                    UsuarioId = repositorio.UsuarioId,
                    QuantidadeLikes = repositorio.QuantidadeLikes,
                    MediaDeLikesPorDia = Math.Round(repositorio.RetornaMediaDeLikesPorDia(), 2)
                });
            }

            return await Task.FromResult(Ok(response));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RepositorioRequest repositorioRequest)
        {
            var repositorio = _mapper.Map<Repositorio>(repositorioRequest);
            _repositorioService.Add(repositorio);

            var response = new RepositorioResponse
            {
                Id = repositorio.Id,
                Descricao = repositorio.Descricao,
                Nome = repositorio.Nome,
                UsuarioId = repositorio.UsuarioId
            };

            return await Task.FromResult(Created(Request.Path.Value, response));
        }

        [HttpPut("/[controller]/{idRepositorio}")]
        public async Task<IActionResult> Update([FromBody]RepositorioRequest repositorioRequest, int idRepositorio)
        {
            var repositorio = _repositorioService.FindById(idRepositorio);

            if (repositorio != null)
                repositorio = _repositorioService.Update(repositorioRequest, repositorio);

            var response = new RepositorioResponse
            {
                Id = repositorio.Id,
                Descricao = repositorio.Descricao,
                Nome = repositorio.Nome,
                UsuarioId = repositorio.UsuarioId
            };

            return await Task.FromResult(Ok(response));
        }

        [HttpDelete("/[controller]/{idRepositorio}")]
        public async Task<IActionResult> Delete(int idRepositorio)
        {
            var repositorio = _repositorioService.FindById(idRepositorio);

            if (repositorio != null)
                repositorio = _repositorioService.Delete(repositorio);

            var response = new RepositorioResponse
            {
                Id = repositorio.Id,
                Descricao = repositorio.Descricao,
                Nome = repositorio.Nome,
                UsuarioId = repositorio.UsuarioId
            };

            return await Task.FromResult(Ok(response));
        }

        [HttpPost("/[controller]/{idRepositorio}/pullrequest")]
        public async Task<IActionResult> CreatePullRequest([FromBody] PullRequestRequest pullRequestRequest, int idRepositorio)
        {
            try
            {
                if (!_repositorioService.Exists(idRepositorio)) return await Task.FromResult(BadRequest("O repositório informado não existe."));
                if (!_usuarioService.Exists(pullRequestRequest.UsuarioId)) return await Task.FromResult(BadRequest("O usuário informado não existe."));
                var pullRequest = _mapper.Map<PullRequest>(pullRequestRequest);
                pullRequest.RepositorioId = idRepositorio;
                _pullRequestService.Add(pullRequest);

                var response = new PullRequestResponse
                {
                    Id = pullRequest.Id,
                    FromBranch = pullRequest.FromBranch,
                    ToBranch = pullRequest.ToBranch,
                    Message = pullRequest.Message,
                    UsuarioId = pullRequest.UsuarioId,
                    RepositorioId = pullRequest.RepositorioId

                };
                return await Task.FromResult(Ok(response));
            }
            catch(Exception ex)
            {
                if(ex is ArgumentException )
                {
                    return await Task.FromResult(BadRequest(ex.Message));
                }
                else
                {
                    return await Task.FromResult(StatusCode(500));
                }
            }
        }

        [HttpGet("/[controller]/{idRepositorio}/pullrequest")]
        public async Task<IActionResult> GetPullRequest(int idRepositorio)
        {
            var pullrequests = _pullRequestService.FindByRepository(idRepositorio);

            var response = new List<PullRequestResponse>();
            foreach (var pullrequest in pullrequests)
            {
                response.Add(new PullRequestResponse
                {
                    Id = pullrequest.Id,
                    FromBranch = pullrequest.FromBranch,
                    ToBranch = pullrequest.ToBranch,
                    Message = pullrequest.Message,
                    UsuarioId = pullrequest.UsuarioId,
                    RepositorioId = pullrequest.RepositorioId
                });
            }
            return await Task.FromResult(Ok(response));
        }
    }
}
