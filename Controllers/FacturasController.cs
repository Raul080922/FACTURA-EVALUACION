using FACTURA_EVALUACION.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class FacturasController : Controller
{
    private readonly AppDbContext _context;

    public FacturasController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Facturas
    public async Task<IActionResult> Index()
    {
        return View(await _context.Facturas.ToListAsync());
    }

    // GET: Facturas/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Facturas/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Factura factura)
    {
        if (ModelState.IsValid)
        {
            _context.Add(factura); // Añadir la factura al contexto
            await _context.SaveChangesAsync(); // Guardar los cambios de forma asincrónica
            return RedirectToAction(nameof(Index));
        }
        return View(factura);
    }

    // GET: Facturas/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var factura = await _context.Facturas.FindAsync(id);
        if (factura == null)
        {
            return NotFound();
        }
        return View(factura);
    }

    // POST: Facturas/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Factura factura)
    {
        if (id != factura.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(factura);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(factura.Id))
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
        return View(factura);
    }

    private bool FacturaExists(int id)
    {
        throw new NotImplementedException();
    }

    // GET: Facturas/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var factura = await _context.Facturas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (factura == null)
        {
            return NotFound();
        }

        return View(factura);
    }

    // POST: Facturas/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var factura = await _context.Facturas.FindAsync(id);  // Buscar la factura en el contexto
        if (factura == null)
        {
            return NotFound(); // Si no se encuentra la factura, devolver NotFound
        }

        _context.Facturas.Remove(factura);  // Eliminar la factura del contexto
        await _context.SaveChangesAsync();  // Guardar los cambios de forma asincrónica
        return RedirectToAction(nameof(Index));  // Redirigir a la lista de facturas
    }

}