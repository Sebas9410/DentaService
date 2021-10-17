using System.ComponentModel.DataAnnotations;

namespace DentaService.API.Data.Entities
{
    public class Equipment
    {
        public int ID { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de 50 carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Description { get; set; }
    }
}
