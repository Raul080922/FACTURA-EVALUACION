using FACTURA_EVALUACION.Models;
using FacturaApp.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Factura> Facturas { get; set; }
    public DbSet<DetalleFactura> DetallesFacturas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<MetodoPago> MetodosPago { get; set; }
    public DbSet<Vendedor> Vendedores { get; set; }
    public object DetalleFactura { get; internal set; }
}
