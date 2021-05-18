using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainersDelight.Data;
using TrainersDelight.Models;

namespace TrainersDelight
{
    public class ClientBMIsController : Controller
    {
        private readonly TrainersDelightContext _context;

        public ClientBMIsController(TrainersDelightContext context)
        {
            _context = context;
        }

        // GET: ClientBMIs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientBMIs.ToListAsync());
        }

        // GET: ClientBMIs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientBMI = await _context.ClientBMIs
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (clientBMI == null)
            {
                return NotFound();
            }

            return View(clientBMI);
        }

        // GET: ClientBMIs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientBMIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,BMI,DateOfMessurment")] ClientBMI clientBMI)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientBMI);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientBMI);
        }

        // GET: ClientBMIs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientBMI = await _context.ClientBMIs.FindAsync(id);
            if (clientBMI == null)
            {
                return NotFound();
            }
            return View(clientBMI);
        }

        // POST: ClientBMIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,BMI,DateOfMessurment")] ClientBMI clientBMI)
        {
            if (id != clientBMI.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientBMI);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientBMIExists(clientBMI.ClientId))
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
            return View(clientBMI);
        }

        // GET: ClientBMIs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientBMI = await _context.ClientBMIs
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (clientBMI == null)
            {
                return NotFound();
            }

            return View(clientBMI);
        }

        // POST: ClientBMIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientBMI = await _context.ClientBMIs.FindAsync(id);
            _context.ClientBMIs.Remove(clientBMI);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientBMIExists(int id)
        {
            return _context.ClientBMIs.Any(e => e.ClientId == id);
        }
    }
}
