using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using FACTURA_EVALUACION.Models;


public class DetalleFacturasController : Controller
{
    private readonly AppDbContext _context;

    public DetalleFacturasController(AppDbContext context)
    {
        _context = context;
    }

    // GET: DetalleFacturas
    public async Task<IActionResult> Index()
    {
        return View(await _context.DetallesFacturas.ToListAsync());
    }

    // GET: DetalleFacturas/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DetalleFacturas/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(DetalleFactura detalleFactura)
    {
        if (ModelState.IsValid)
        {
            _context.Add(detalleFactura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(detalleFactura);
    }

    // GET: DetalleFacturas/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var detalleFactura = await _context.DetallesFacturas.FindAsync(id);
        if (detalleFactura == null)
        {
            return NotFound();
        }
        return View(detalleFactura);
    }

    // POST: DetalleFacturas/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, DetalleFactura detalleFactura)
    {
        if (id != detalleFactura.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(detalleFactura);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleFacturaExists(detalleFactura.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(detalleFactura);
    }

    // GET: DetalleFacturas/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var detalleFactura = await _context.DetallesFacturas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (detalleFactura == null)
        {
            return NotFound();
        }

        return View(detalleFactura);
    }

    // POST: DetalleFacturas/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var detalleFactura = await _context.DetallesFacturas.FindAsync(id);
        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<DetalleFactura> entityEntry = _context.DetallesFacturas.Remove(detalleFactura);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DetalleFacturaExists(int id)
    {
        return _context.DetallesFacturas.Any(e => e.Id == id);
    }
}