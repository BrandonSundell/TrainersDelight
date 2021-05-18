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
    public class ClientWeightsController : Controller
    {
        private readonly TrainersDelightContext _context;

        public ClientWeightsController(TrainersDelightContext context)
        {
            _context = context;
        }

        // GET: ClientWeights
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientWeights.ToListAsync());
        }

        // GET: ClientWeights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientWeight = await _context.ClientWeights
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (clientWeight == null)
            {
                return NotFound();
            }

            return View(clientWeight);
        }

        // GET: ClientWeights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientWeights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,WeightInPounds,DateOfMessurment")] ClientWeight clientWeight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientWeight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientWeight);
        }

        // GET: ClientWeights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientWeight = await _context.ClientWeights.FindAsync(id);
            if (clientWeight == null)
            {
                return NotFound();
            }
            return View(clientWeight);
        }

        // POST: ClientWeights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,WeightInPounds,DateOfMessurment")] ClientWeight clientWeight)
        {
            if (id != clientWeight.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientWeight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientWeightExists(clientWeight.ClientId))
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
            return View(clientWeight);
        }

        // GET: ClientWeights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientWeight = await _context.ClientWeights
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (clientWeight == null)
            {
                return NotFound();
            }

            return View(clientWeight);
        }

        // POST: ClientWeights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientWeight = await _context.ClientWeights.FindAsync(id);
            _context.ClientWeights.Remove(clientWeight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientWeightExists(int id)
        {
            return _context.ClientWeights.Any(e => e.ClientId == id);
        }
    }
}
