using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentaService.API.Data.Entities
{
    public class DetailService
    {

        public int ID { get; set; }

        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal Value { get; set; }

        [Display(Name = "Descuento")]
        public int Discount { get; set; }
    }
}
