using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicamentContext
{
    public class DataPharmaceuticalForm
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Habilitado { get; set; }
    }
}
