﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarCenter.Data;
using CarCenter.Models;
using CarCenter.Models.ViewModels;

namespace CarCenter.Controllers
{
    public class NotasController : Controller
    {
        private readonly CarCenterContext _context;

        public NotasController(CarCenterContext context)
        {
            _context = context;
        }

        // GET: Notas
        public async Task<IActionResult> Index()
        {
            var carCenterContext = _context.Nota.Include(n => n.Carro).Include(n => n.Comprador).Include(n => n.Vendedor);
            return View(await carCenterContext.ToListAsync());
        }

        // GET: Notas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota
                .Include(n => n.Carro)
                .Include(n => n.Comprador)
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // GET: Notas/Create
        public IActionResult Create()
        {
            //ViewData["CarroId"] = new SelectList(_context.Carro, "Id", "Id");
            // ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id");
            //ViewData["VendedorId"] = new SelectList(_context.Vendedor, "Id", "Id");
            NotaViewModel notaViewModel = new NotaViewModel();
            notaViewModel.Carros = _context.Carro.ToList();
            notaViewModel.Clientes = _context.Cliente.ToList();
            notaViewModel.Vendedores = _context.Vendedor.ToList();
            return View(notaViewModel);
        }

        // POST: Notas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(NotaViewModel notaVM)
        {

            _context.Add(notaVM.Nota);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Notas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota.FindAsync(id);
            if (nota == null)
            {
                return NotFound();
            }
            NotaViewModel notaViewModel = new NotaViewModel();
            notaViewModel.Carros = _context.Carro.ToList();
            notaViewModel.Clientes = _context.Cliente.ToList();
            notaViewModel.Vendedores = _context.Vendedor.ToList();
            notaViewModel.Nota = nota;
            return View(notaViewModel);
        }

        // POST: Notas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Nota nota)
        {
            if (id != nota.Id)
            {
                return NotFound();
            }

            try
                {
                    _context.Update(nota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaExists(nota.Id))
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

        // GET: Notas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nota == null)
            {
                return NotFound();
            }

            var nota = await _context.Nota
                .Include(n => n.Carro)
                .Include(n => n.Comprador)
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nota == null)
            {
                return Problem("Entity set 'CarCenterContext.Nota'  is null.");
            }
            var nota = await _context.Nota.FindAsync(id);
            if (nota != null)
            {
                _context.Nota.Remove(nota);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaExists(int id)
        {
          return (_context.Nota?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
