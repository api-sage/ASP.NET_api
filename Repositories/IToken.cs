namespace crudapi.Repositories
{
    public interface IToken
    {
        Task<string> GenerateToken(Model.User client);
    }
}
