using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeClinica.Application.Models.InputModels
{
    internal class CreateUsuarioInputModel
    {
        public string Email { get;  set; }
        public string PasswordHash { get;  set; }
    }
}
