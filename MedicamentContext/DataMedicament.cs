using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicamentContext
{
    public class DataMedicament
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Concentracion { get; set; }
        public int IdFormaFamamaceutica { get; set; }
        public float Precio { get; set; }
        public int Stock { get; set; }
        public string? Presentacion { get; set; }
        public int Habilitado { get; set; }
    }
}
