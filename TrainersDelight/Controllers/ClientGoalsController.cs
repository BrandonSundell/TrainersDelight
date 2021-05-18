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
    public class ClientGoalsController : Controller
    {
        private readonly TrainersDelightContext _context;

        public ClientGoalsController(TrainersDelightContext context)
        {
            _context = context;
        }

        // GET: ClientGoals
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientGoals.ToListAsync());
        }

        // GET: ClientGoals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGoals = await _context.ClientGoals
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (clientGoals == null)
            {
                return NotFound();
            }

            return View(clientGoals);
        }

        // GET: ClientGoals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientGoals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,Goals,DateOfMessurment")] ClientGoals clientGoals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientGoals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientGoals);
        }

        // GET: ClientGoals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGoals = await _context.ClientGoals.FindAsync(id);
            if (clientGoals == null)
            {
                return NotFound();
            }
            return View(clientGoals);
        }

        // POST: ClientGoals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,Goals,DateOfMessurment")] ClientGoals clientGoals)
        {
            if (id != clientGoals.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientGoals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientGoalsExists(clientGoals.ClientId))
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
            return View(clientGoals);
        }

        // GET: ClientGoals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGoals = await _context.ClientGoals
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (clientGoals == null)
            {
                return NotFound();
            }

            return View(clientGoals);
        }

        // POST: ClientGoals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientGoals = await _context.ClientGoals.FindAsync(id);
            _context.ClientGoals.Remove(clientGoals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientGoalsExists(int id)
        {
            return _context.ClientGoals.Any(e => e.ClientId == id);
        }
    }
}
