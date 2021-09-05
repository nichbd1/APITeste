namespace ApiTeste.Models.Responses
{
    public class PullRequestResponse
    {
        public int Id { get; set; }
        public string FromBranch { get; set; }
        public string ToBranch { get; set; }
        public string Message { get; set; }
        public int UsuarioId { get; set; }
        public int RepositorioId { get; set; }
    }
}
