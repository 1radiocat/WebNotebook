using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebNotebook.Domain;
using WebNotebook.Models;

namespace WebNotebook.Controllers
{
    public class RecordsController : Controller
    {
        private readonly AppDbContext _context;

        public RecordsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Records
        public async Task<IActionResult> Index(string searchString, string recordCompany)
        {

            //Поиск контакта по имени
            var records = from m in _context.Records
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                records = records.Where(s => s.Name.Contains(searchString));
            }

            //Поиск контакта по компании
            IQueryable<string> ownerQuery = from m in _context.Records
                                            orderby m.Company
                                            select m.Company;

            if (!string.IsNullOrEmpty(recordCompany))
            {
                records = records.Where(x => x.Company == recordCompany);
            }

            var recordCompanyVM = new RecordCompanyViewModel
            {
                Companies = new SelectList(await ownerQuery.Distinct().ToListAsync()),
                Records = await records.ToListAsync()
            };

            return View(recordCompanyVM);

        }

        // GET: Records/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.Records
                .FirstOrDefaultAsync(m => m.Id == id);
            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }

        // GET: Records/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Records/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Phone,Email,BirthDate,Company,Comment,Id")] Record record)
        {
            if (ModelState.IsValid)
            {
                _context.Add(record);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(record);
        }

        // GET: Records/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.Records.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }

        // POST: Records/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Phone,Email,BirthDate,Company,Comment,Id")] Record record)
        {
            if (id != record.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(record);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecordExists(record.Id))
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
            return View(record);
        }

        // GET: Records/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.Records
                .FirstOrDefaultAsync(m => m.Id == id);
            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }

        // POST: Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var record = await _context.Records.FindAsync(id);
            _context.Records.Remove(record);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecordExists(int id)
        {
            return _context.Records.Any(e => e.Id == id);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
    }
}
