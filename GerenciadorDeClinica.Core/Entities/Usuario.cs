using System.Security.Principal;

namespace GerenciadorDeClinica.Core.Entities
{
    public class Usuario
    {
        public Usuario(string email, string passwordHash)
        {
            Email = email;
            PasswordHash = passwordHash;
        }
        public int Id { get; private set; }
        public string Email { get; private set; } 
        public string PasswordHash { get; private set; } 

        public void UpdatePassword( string passwordHash)
        {
            
            PasswordHash = passwordHash;
        }

    }
}
