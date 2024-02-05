using E_commerceAPi.Domain.Entities.Cross;

namespace E_commerceAPi.Domain.Entities
{
    public class User
    {
        public User()
        {
            User_Role_Crosses = new();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public List<User_Role_Cross> User_Role_Crosses { get; set; }
    }
}
