namespace FACTURA_EVALUACION.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public int VendedorId { get; set; }
        public int MetodoPagoId { get; set; }
        public ICollection<DetalleFactura> Detalles { get; set; }
    }
}

