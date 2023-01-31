using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicamentContext
{
    public class DataUser
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? Usuario { get; set; }
        public string? Password { get; set; }
        public int IdPerfil { get; set; }
        public int Estatus { get; set; }
    }
}
