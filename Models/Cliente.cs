using FACTURA_EVALUACION.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturaApp.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo válido")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(15, ErrorMessage = "El teléfono no puede tener más de 15 caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(200, ErrorMessage = "La dirección no puede tener más de 200 caracteres")]
        public string Direccion { get; set; }

        // Relación con Factura (un Cliente puede tener varias Facturas)
        public ICollection<Factura>? Facturas { get; set; }
    }
}
