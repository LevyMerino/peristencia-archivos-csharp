using MedicamentContext;

namespace PresentacionFarmaceutica.Models
{
    public class PresentationEditMedicament
    {
        public List<DataMedicament>? medicaments { get; set; }
        public List<DataPharmaceuticalForm>? pharmaceuticalForms { get; set; }

        public PresentationEditMedicament()
        {
            medicaments = new List<DataMedicament>();
            pharmaceuticalForms = new List<DataPharmaceuticalForm>();
        }
    }
}
