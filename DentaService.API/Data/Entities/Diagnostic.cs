using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentaService.API.Data.Entities
{
    public class Diagnostic
    {

        public int ID { get; set; }

        [Display(Name = "Observacion")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de 100 carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Remark { get; set; }

    }
}
