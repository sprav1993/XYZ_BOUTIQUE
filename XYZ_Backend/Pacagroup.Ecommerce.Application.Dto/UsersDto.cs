using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ.BOUTIQUE.Application.Dto
{
    public class UsersDto
    {
        public int usuario_id { get; set; }
        public string codigo_trabajador { get; set; }
        public string nombre { get; set; }
        public string correo_electronico { get; set; }
        public string telefono { get; set; }
        public string puesto { get; set; }
        public string password { get; set; }
        public int rol_id { get; set; }
        public string rol { get; set; }
        public string Token { get; set; }
    }
}
