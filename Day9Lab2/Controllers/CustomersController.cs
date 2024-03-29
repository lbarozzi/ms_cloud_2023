﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day9Lab2.Models;

namespace Day9Lab2.Controllers
{
    public class CustomersController : Controller
    {
        private readonly Datacontext _context;

        public CustomersController(Datacontext context)
        {
            _context = context;
        }

        public IActionResult PopolateDB() {
            string[] Nome = { "Uno", "Due", "Tre", "Quattro" };
            //Clean DB
            _context.Customers.RemoveRange(_context.Customers);
            _context.SaveChanges(); 
            //Add new ITEMS 
            for(int i = 0; i < 75; i++) {
                Customer pippo = new Customer() {
                    FullName = Nome[i % Nome.Length],
                    City = "Torino",
                    Address = $"Via le mani dalle tasche {i}",
                    Country = "Italy",
                    PostalCode = $"{i + 10110}",
                    Email = $"test{i}@test.com",
                    Phone = $"555-551-{i}",
                    IsActive = i % 2 == 0,
                    IsBlacklisted = i % 7 == 0,
                    VAT=$"IT0123456{i}",
                    PictureName="img.jpg"
                };
                _context.Customers.Add(pippo);
            }
            _context.SaveChanges();
            //GoTo HOME!
            return RedirectToAction("Index");
        }
        
        public IActionResult ActiveOnly() {
            //Method
            var CustomersActive = _context.Customers
                                    .Where(x => x.IsActive)
                                    .ToList();
            //*/
            /*/Query
            var c_a = (from customer in _context.Customers
                       where customer.IsActive
                       select customer
                     ).ToList();

            //*/
            return View("/Views/Customers/Index.cshtml",CustomersActive);
        }

        //TODO: View Customer blacklisted orderby ID descending
        public IActionResult Blacklisted() {
            return View("/Views/Customers/Index.cshtml",
                from customer in _context.Customers
                where customer.IsBlacklisted
                orderby customer.ID descending
                select customer
                );
        }

        public IActionResult Get10() {
            var ten_value = _context.Customers
                    .Skip(0)
                    .Take(10);
            var query_ten = (from cust in _context.Customers
                             select cust)
                             .Skip(0)
                             .Take(10);
            return View("/Views/Customers/Index.cshtml", query_ten);
        }


        // GET: Customers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Customers.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,VAT,FullName,Email,Phone,Address,City,PostalCode,Country,IsActive,IsBlacklisted,PictureName")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,VAT,FullName,Email,Phone,Address,City,PostalCode,Country,IsActive,IsBlacklisted,PictureName")] Customer customer)
        {
            if (id != customer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.ID))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'Datacontext.Customers'  is null.");
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
          return _context.Customers.Any(e => e.ID == id);
        }
    }
}
