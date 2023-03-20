namespace crudapi.Repositories
{
    public class UserImplementation : IUser
    {
        private readonly List<Model.User> ApiUsers = new List<Model.User>()
        {
            new Model.User()
            {
                Id = Guid.NewGuid(),
                UserName= "paulafolabi",
                EmailAddress="afolad100@gmail.com",
                FirstName="Paul",
                LastName="Afolabi",
                Password="asdf;lkj",
                Roles=new List<string> ()
                {
                    "Developer",
                    "reader",
                    "writer"
                }
            }
        };
        public async Task<Model.User> AuthenticateUserAsync(string username, string password)
        {
            Model.User Client = ApiUsers
                .Find(
                x => x.UserName.ToLower() == username.ToLower() 
                && x.Password == password);

            if(Client != null )
            {
                return Client;
            }

            return null;
        }
    }
}
