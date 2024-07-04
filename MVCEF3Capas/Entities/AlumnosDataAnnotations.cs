using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Entities
{

    [MetadataType(typeof(AlumnosDataAnnotations))]
    public partial class Alumnos
    {

    }
    public class AlumnosDataAnnotations
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "Solo se permiten letras y espacios.")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Solo se permiten letras y espacios.")]
        public string primerApellido { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Solo se permiten letras y espacios.")]
        public string segundoApellido { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo electrónico inválido")]
        public string correo { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Número de teléfono inválido")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = false)]
        [RangeDate("31/12/2000","01/01/1900",ErrorMessage ="Formato incorrecto no debe ser una fecha menor a {2} o mayor a {1}")]
        public DateTime fechaNacimiento { get; set; }


        [Required(ErrorMessage = "La CURP es obligatoria")]
        [RegularExpression(@"^[A-Za-z]{4}[0-9]{6}[HhMm][A-Za-z]{5}[0-9]{2}$", ErrorMessage = "La CURP no tiene el formato correcto")]
        public string curp { get; set; }

        [Required(ErrorMessage = "El sueldo mensual es obligatorio")]
        [Range(10000, 40000, ErrorMessage = "El sueldo debe estar entre 10,000 y 40,000")]
        public decimal sueldoMensual { get; set; }

        [Required(ErrorMessage = "El estado de origen es obligatorio")]
        public int idEstadoOrigen { get; set; }

        [Required(ErrorMessage = "El estatus es obligatorio")]
        public int idEstatus { get; set; }
    }
}
