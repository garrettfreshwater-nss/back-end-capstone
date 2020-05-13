using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bluegrass.Models.SpeciesViewModels;
using BluegrassPetCare.Data;
using BluegrassPetCare.Models;
using BluegrassPetCare.Models.PetViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BluegrassPetCare.Controllers
{

    public class SpeciesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SpeciesController(ApplicationDbContext ctx, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = ctx;
        }
        // GET: Species
        public async Task<ActionResult> Index()
    {
        var user = await GetCurrentUserAsync();

            var species = _context.Species;
           
        return View(species);
    }

    // GET: Species/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: Species/Create
    public async Task<ActionResult> Create()
    {
        var user = await GetCurrentUserAsync();
        var species = await _context.Species
           .Where(sp => sp.UserId == user.Id).ToListAsync();

        var viewModel = new SpeciesCreateViewModel();
        viewModel.Species = species;
        return View(viewModel);
    }

    // POST: Species/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(Species Species)
    {
        try
        {
            var species = new Species
            {
               SpeciesType = Species.SpeciesType
            };
            var user = await GetCurrentUserAsync();
            species.UserId = user.Id;

            _context.Species.Add(species);
            await _context.SaveChangesAsync();

            // TODO: Add insert logic here

            return RedirectToPage("/Account/Manage/Species", new { area = "Identity" });
        }
        catch
        {
            return View();
        }
    }

    // GET: Species/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: Species/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            // TODO: Add update logic here

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: Species/Delete/5
    public async Task<ActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var species = await _context.Species
            .FirstOrDefaultAsync(pt => pt.SpeciesId == id);
        if (species == null)
        {
            return NotFound();
        }

        return View(species);

    }

    // POST: Species/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
        var species = await _context.Species.FindAsync(id);
        _context.Species.Remove(species);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index","Species");
    }
    private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
}
}