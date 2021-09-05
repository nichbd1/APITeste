namespace ApiTeste.Models.Requests
{
    public class PullRequestRequest
    {
        public string FromBranch { get; set; }
        public string ToBranch { get; set; }
        public string Message { get; set; }
        public int UsuarioId { get; set; }
    }
}
