using System.ComponentModel.DataAnnotations;

namespace DentaService.API.Data.Entities
{
    public class DetailService
    {

        public int ID { get; set; }

        [Display(Name = "Metodo de Pago")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string PaymentMethod { get; set; }

    }
}
