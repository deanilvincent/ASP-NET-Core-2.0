using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreTest.Models;

namespace AspNetCoreTest.Controllers
{
    public class TestDetailsController : Controller
    {
        private readonly TestDbContext _context;

        public TestDetailsController(TestDbContext context)
        {
            _context = context;
        }

        // GET: TestDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.TestDetails.ToListAsync());
        }

        // GET: TestDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDetails = await _context.TestDetails
                .SingleOrDefaultAsync(m => m.TestId == id);
            if (testDetails == null)
            {
                return NotFound();
            }

            return View(testDetails);
        }

        // GET: TestDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TestId,Status")] TestDetails testDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testDetails);
        }

        // GET: TestDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDetails = await _context.TestDetails.SingleOrDefaultAsync(m => m.TestId == id);
            if (testDetails == null)
            {
                return NotFound();
            }
            return View(testDetails);
        }

        // POST: TestDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TestId,Status")] TestDetails testDetails)
        {
            if (id != testDetails.TestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestDetailsExists(testDetails.TestId))
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
            return View(testDetails);
        }

        // GET: TestDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDetails = await _context.TestDetails
                .SingleOrDefaultAsync(m => m.TestId == id);
            if (testDetails == null)
            {
                return NotFound();
            }

            return View(testDetails);
        }

        // POST: TestDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testDetails = await _context.TestDetails.SingleOrDefaultAsync(m => m.TestId == id);
            _context.TestDetails.Remove(testDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestDetailsExists(int id)
        {
            return _context.TestDetails.Any(e => e.TestId == id);
        }
    }
}
