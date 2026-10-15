
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaseballEquipmentApp.Models;
using BaseballEquipmentApp.Data;

public class BaseballEquipmentsController : Controller
{
    private readonly AppDbContext _context;

    public BaseballEquipmentsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: BASEBALLEQUIPMENTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.BaseballEquipments.ToListAsync());
    }

    // GET: BASEBALLEQUIPMENTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var baseballequipment = await _context.BaseballEquipments
            .FirstOrDefaultAsync(m => m.Id == id);
        if (baseballequipment == null)
        {
            return NotFound();
        }

        return View(baseballequipment);
    }

    // GET: BASEBALLEQUIPMENTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: BASEBALLEQUIPMENTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Category,Price,Stock")] BaseballEquipment baseballequipment)
    {
        if (ModelState.IsValid)
        {
            _context.Add(baseballequipment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(baseballequipment);
    }

    // GET: BASEBALLEQUIPMENTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var baseballequipment = await _context.BaseballEquipments.FindAsync(id);
        if (baseballequipment == null)
        {
            return NotFound();
        }
        return View(baseballequipment);
    }

    // POST: BASEBALLEQUIPMENTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Category,Price,Stock")] BaseballEquipment baseballequipment)
    {
        if (id != baseballequipment.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(baseballequipment);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaseballEquipmentExists(baseballequipment.Id))
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
        return View(baseballequipment);
    }

    // GET: BASEBALLEQUIPMENTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var baseballequipment = await _context.BaseballEquipments
            .FirstOrDefaultAsync(m => m.Id == id);
        if (baseballequipment == null)
        {
            return NotFound();
        }

        return View(baseballequipment);
    }

    // POST: BASEBALLEQUIPMENTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var baseballequipment = await _context.BaseballEquipments.FindAsync(id);
        if (baseballequipment != null)
        {
            _context.BaseballEquipments.Remove(baseballequipment);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BaseballEquipmentExists(int? id)
    {
        return _context.BaseballEquipments.Any(e => e.Id == id);
    }
}
