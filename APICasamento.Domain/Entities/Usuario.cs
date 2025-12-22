using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICasamento.Domain.Entities
{
    public class Usuario
    {
        public string Id { get; }
        public string Email { get; }

        public Usuario(string id, string email)
        {
            Id = id;
            Email = email;
        }
    }
}
