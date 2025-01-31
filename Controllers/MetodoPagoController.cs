using FACTURA_EVALUACION.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class MetodoPagoController : Controller
{
    private readonly AppDbContext _context;

    public MetodoPagoController(AppDbContext context)
    {
        _context = context;
    }

    // GET: MetodoPago
    public async Task<IActionResult> Index()
    {
        return View(await _context.MetodosPago.ToListAsync());
    }

    // GET: MetodoPago/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MetodoPago/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre")] MetodoPago metodoPago)
    {
        if (ModelState.IsValid)
        {
            _context.Add(metodoPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(metodoPago);
    }

    // GET: MetodoPago/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var metodoPago = await _context.MetodosPago.FindAsync(id);
        if (metodoPago == null) return NotFound();

        return View(metodoPago);
    }

    // POST: MetodoPago/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] MetodoPago metodoPago)
    {
        if (id != metodoPago.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(metodoPago);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetodoPagoExists(metodoPago.Id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(metodoPago);
    }

    // GET: MetodoPago/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var metodoPago = await _context.MetodosPago.FirstOrDefaultAsync(m => m.Id == id);
        if (metodoPago == null) return NotFound();

        return View(metodoPago);
    }

    // POST: MetodoPago/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var metodoPago = await _context.MetodosPago.FindAsync(id);
        _context.MetodosPago.Remove(metodoPago);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MetodoPagoExists(int id)
    {
        return _context.MetodosPago.Any(e => e.Id == id);
    }
}