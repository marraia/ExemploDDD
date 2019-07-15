using FM.Exemplo.Domain.Core;

namespace FM.Exemplo.Domain.Entities
{
    public class User : Entity
    {
        public User() { }
        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public void AddPassword(string password)
        {
            Password = PasswordHasher.Hash(password);
        }
    }
}
