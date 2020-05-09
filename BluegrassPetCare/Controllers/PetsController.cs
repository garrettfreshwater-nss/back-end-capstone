using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BluegrassPetCare.Data;
using BluegrassPetCare.Models;
using BluegrassPetCare.Models.PetViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BluegrassPetCare.Controllers
{
    public class PetsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public PetsController(ApplicationDbContext ctx, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = ctx;
        }


        // GET: Pets
        public async Task<ActionResult> Index(string searchString, string breedSearchString)
        {



            if (searchString != null)
            {
                var pet = await _context.Pet
                    .Where(p => p.Name.Contains(searchString))
                    .Include(p => p.Breed)
                    .ToListAsync();

                return View(pet);
            }
            else
            {
                var pet = await _context.Pet
                    .Include(p => p.Breed)
                    .ToListAsync();

                return View(pet);
            }
        }
            

            // GET: MenuItems/Details/5
            public async Task<ActionResult> Details(int id)
        {
            var pet = await _context.Pet
                .FirstOrDefaultAsync(p => p.PetId == id);

            var viewModel = new PetDetailViewModel()
            {
                Pet = new Pet()
            };

            viewModel.Pet.PetId = pet.PetId;
            viewModel.Pet.Name = pet.Name;
            viewModel.Pet.Color = pet.Color;
            viewModel.Pet.ImagePath = pet.ImagePath;
            viewModel.Pet.Birthday = pet.Birthday;
            viewModel.Pet.Breed = pet.Breed;
            viewModel.Pet.Sex = pet.Sex;
            viewModel.Pet.CurrentMedications = pet.CurrentMedications;
            viewModel.Pet.OngoingProblems = pet.OngoingProblems;


            return View(viewModel);
        }

        // GET: Pets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PetDetailViewModel petDetailViewModel)
        {
            try
            {
                var pet = new Pet
                {
                    Name = petDetailViewModel.Pet.Name,
                    Birthday = petDetailViewModel.Pet.Birthday,
                    Color = petDetailViewModel.Pet.Color,
                    Species = petDetailViewModel.SpeciesId,
                    Breed = petDetailViewModel.BreedId,
                    Sex = petDetailViewModel.SexId,
                    OngoingProblems = petDetailViewModel.Pet.OngoingProblems,
                    CurrentMedications = petDetailViewModel.Pet.CurrentMedications,
                    IsSpayedOrNeutered = petDetailViewModel.Pet.IsSpayedOrNeutered
                };

                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images");
                if (petDetailViewModel.ImageFile != null)
                {
                    var fileName = Guid.NewGuid().ToString() + petDetailViewModel.ImageFile.FileName;
                    pet.ImagePath = fileName;
                    using (var fileStream = new FileStream(Path.Combine(uploadPath, fileName), FileMode.Create))
                    {
                        await petDetailViewModel.ImageFile.CopyToAsync(fileStream);
                    }
                }

                _context.Pet.Add(pet);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuItems/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var pet = await _context.Pet.FirstOrDefaultAsync(p => p.PetId == id);

            return View(pet);
        }

        // POST: MenuItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Pet pet)
        {
            try
            {
                var petPet = new Pet()
                {
                    PetId = pet.PetId,
                    Name = pet.Name,
                    Color = pet.Color,
                    ImagePath = pet.ImagePath,
                    IsSpayedOrNeutered = pet.IsSpayedOrNeutered,
                    CurrentMedications = pet.CurrentMedications,
                    OngoingProblems = pet.OngoingProblems
                };

                _context.Pet.Update(petPet);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pets/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pets/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}