using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DentaService.API.Data.Entities
{
    public class Shedule
    {

        public int ID { get; set; }

        [Display(Name = "Fecha")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener mas de 30 carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Date { get; set; }

        [Display(Name = "Campus")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener mas de 30 carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Campus { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
