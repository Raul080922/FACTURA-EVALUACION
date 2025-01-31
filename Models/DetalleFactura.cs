namespace FACTURA_EVALUACION.Models
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
