namespace UBC_Gerenciador_de_Alunos_API.Services
{
    public interface IAuthService
    {
        Task<string> Authenticate(string username, string password);
    }
}
