using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RicardoPrueba2.Models;

namespace RicardoPrueba2.Controllers
{
    public class ColaboradorsController : Controller
    {
        private readonly AppDbContext _context;

        public ColaboradorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Colaboradors
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Colaboradores.Include(c => c.Departamento);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Colaboradors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Colaboradores == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaboradores
                .Include(c => c.Departamento)
                .FirstOrDefaultAsync(m => m.Rut == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // GET: Colaboradors/Create
        public IActionResult Create()
        {
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "DepartamentoId");
            return View();
        }

        // POST: Colaboradors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rut,Nombres,Apellidos,Direccion,Comuna,Telefono,Correo,FechaContratacion,ContratoIndefinido,DepartamentoId")] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaborador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "DepartamentoId", colaborador.DepartamentoId);
            return View(colaborador);
        }

        // GET: Colaboradors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Colaboradores == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaboradores.FindAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "DepartamentoId", colaborador.DepartamentoId);
            return View(colaborador);
        }

        // POST: Colaboradors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Rut,Nombres,Apellidos,Direccion,Comuna,Telefono,Correo,FechaContratacion,ContratoIndefinido,DepartamentoId")] Colaborador colaborador)
        {
            if (id != colaborador.Rut)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaborador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradorExists(colaborador.Rut))
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
            ViewData["DepartamentoId"] = new SelectList(_context.Departamentos, "DepartamentoId", "DepartamentoId", colaborador.DepartamentoId);
            return View(colaborador);
        }

        // GET: Colaboradors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Colaboradores == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaboradores
                .Include(c => c.Departamento)
                .FirstOrDefaultAsync(m => m.Rut == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // POST: Colaboradors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Colaboradores == null)
            {
                return Problem("Entity set 'AppDbContext.Colaboradores'  is null.");
            }
            var colaborador = await _context.Colaboradores.FindAsync(id);
            if (colaborador != null)
            {
                _context.Colaboradores.Remove(colaborador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradorExists(string id)
        {
          return _context.Colaboradores.Any(e => e.Rut == id);
        }
    }
}
