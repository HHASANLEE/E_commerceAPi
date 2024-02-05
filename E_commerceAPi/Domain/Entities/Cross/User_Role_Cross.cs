namespace E_commerceAPi.Domain.Entities.Cross
{
    public class User_Role_Cross
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public User user { get; set; }
        public Role role { get; set; }
    }
}
