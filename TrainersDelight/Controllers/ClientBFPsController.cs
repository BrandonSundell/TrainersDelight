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
    public class ClientBFPsController : Controller
    {
        private readonly TrainersDelightContext _context;

        public ClientBFPsController(TrainersDelightContext context)
        {
            _context = context;
        }

        // GET: ClientBFPs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientBFPs.ToListAsync());
        }

        // GET: ClientBFPs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientBFP = await _context.ClientBFPs
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (clientBFP == null)
            {
                return NotFound();
            }

            return View(clientBFP);
        }

        // GET: ClientBFPs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientBFPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,BFP,DateOfMessurment")] ClientBFP clientBFP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientBFP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientBFP);
        }

        // GET: ClientBFPs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientBFP = await _context.ClientBFPs.FindAsync(id);
            if (clientBFP == null)
            {
                return NotFound();
            }
            return View(clientBFP);
        }

        // POST: ClientBFPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,BFP,DateOfMessurment")] ClientBFP clientBFP)
        {
            if (id != clientBFP.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientBFP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientBFPExists(clientBFP.ClientId))
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
            return View(clientBFP);
        }

        // GET: ClientBFPs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientBFP = await _context.ClientBFPs
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (clientBFP == null)
            {
                return NotFound();
            }

            return View(clientBFP);
        }

        // POST: ClientBFPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientBFP = await _context.ClientBFPs.FindAsync(id);
            _context.ClientBFPs.Remove(clientBFP);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientBFPExists(int id)
        {
            return _context.ClientBFPs.Any(e => e.ClientId == id);
        }
    }
}
