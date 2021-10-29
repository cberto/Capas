using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CapaPrincipal.Models
{
    public class ProveedorModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Se debe ingresar una razón social")]
        [StringLength(50, ErrorMessage = "Ha superado el límite de Caracteres.")]
        [Display(Name = "Razon Social")]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage = "Se debe ingresar un nombre fantasia")]
        [StringLength(50, ErrorMessage = "Ha superado el límite de Caracteres.")]
        [Display(Name = "Nombre Fantasia")]
        public string NombreFantasia { get; set; }

        [Required(ErrorMessage = "No se ha ingresado un cuit")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Solo se puede recibir números.")]
        public int Cuit { get; set; }

        [Required(ErrorMessage = "Se debe ingresar un Codigo Postal")]
        [StringLength(10, ErrorMessage = "Ha superado el límite de Caracteres.")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Solo se puede recibir números")]
        public string CodigoPostal { get; set; }

        [Required(ErrorMessage = "Se debe ingresar un telefono")]
        [StringLength(10, ErrorMessage = "Ha superado el límite de Caracteres.")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Sólo se deben ingresar números")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "No se ingreso ningun Email")]
        [StringLength(255, ErrorMessage = "Ha superado el límite de Caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "No se selecciono ninguna de Razon Social")]
        public string CodigoIva { get; set; }

        [Display(Name = "Descripcion IVA")]
        public string DescripcionIva { get; set; }

        [Required(ErrorMessage = "No se ingreso ningun Contacto")]
        [StringLength(200, ErrorMessage = "No se aceptan contactos tan largos.")]
        public string Contacto { get; set; }
    }
}