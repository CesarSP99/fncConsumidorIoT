using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace fncConsumidorIoT.Models
{
    class ModelParcial
    {
        [Key]
        public int messageId { get; set; }
        [Required]
        public string estudiante { get; set; }
        [Required]
        public double temperatura { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime fecha { get; set; }
        [Required]
        public string hora { get; set; }
    }
}
