namespace crudapi.Repositories
{
    public interface IUser
    {
        Task<Model.User> AuthenticateUserAsync(string username, string password);
    }
}
