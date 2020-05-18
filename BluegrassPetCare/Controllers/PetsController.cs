using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BluegrassPetCare.Data;
using BluegrassPetCare.Models;
using BluegrassPetCare.Models.PetViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
        public async Task<ActionResult> Index(string searchString, string petSearchString)
        {

            var user = await GetCurrentUserAsync();


            if (user.IsVeterinarian == false)
            {
                var userPets = await _context.Pet
                        .Include(p => p.Breed)
                        .Include(p => p.Sex)
                        .Include(p => p.Species)
                        .Include(p => p.Notes)
                        .Where(p => p.UserId == user.Id)
                        .ToListAsync();
                return View(userPets);
            }
            else if (user.IsVeterinarian == true)
            {
                var userPets = await _context.Pet
                            .Include(p => p.Breed)
                            .Include(p => p.Sex)
                            .Include(p => p.Species)
                            .Include(p => p.Notes)
                            .ToListAsync();
                return View(userPets);
            }


            else if (searchString != null)
            {
                var pet = await _context.Pet.Where(p => p.UserId == user.Id)
                    .Where(p => p.Name.Contains(searchString))
                    .Include(p => p.Breed)
                    .Include(p => p.Sex)
                    .Include(p => p.Species)
                    .Include(p => p.Notes)
                    .ToListAsync();

                return View(pet);
            }
            else
                {
               

                var pet = await _context.Pet.Where(p => p.UserId == user.Id)
                    .Include(p => p.Breed)
                    .Include(p => p.Sex)
                    .Include(p => p.Species)
                    .Include(p => p.Notes)
                .ToListAsync();
                return View(pet);

                
            }
            
        }
            

            // GET: Pets/Details/5
            public async Task<ActionResult> Details(int id)
        {
            var pet = await _context.Pet
                .Include(p => p.Breed)
                .Include(p => p.Sex)
                .Include(p => p.Species)
                .Include(p => p.Notes)
                .FirstOrDefaultAsync(p => p.PetId == id);

            var viewModel = new PetDetailViewModel()
            {
                Pet = new Pet()
            };

            viewModel.Pet.PetId = pet.PetId;
            viewModel.Pet.UserId = pet.UserId;
            viewModel.Pet.Name = pet.Name;
            viewModel.Pet.Color = pet.Color;
            viewModel.Pet.ImagePath = pet.ImagePath;
            viewModel.Pet.Birthday = pet.Birthday;
            viewModel.Breed = pet.Breed;
            viewModel.Sex = pet.Sex;
            viewModel.Species = pet.Species;
            viewModel.Pet.Notes = pet.Notes;
            viewModel.Pet.CurrentMedications = pet.CurrentMedications;
            viewModel.Pet.OngoingProblems = pet.OngoingProblems;
            viewModel.Pet.IsSpayedOrNeutered = pet.IsSpayedOrNeutered;



            return View(viewModel);
        }

        // GET: Pets/Create
        public async Task<ActionResult> CreateAsync()
        {
            var breedTypes = await _context.Breed
               .Select(b => new SelectListItem() { Text = b.BreedName, Value = b.BreedId.ToString() })
               .ToListAsync();
            var speciesTypes = await _context.Species
                .Select(s => new SelectListItem() { Text = s.SpeciesType, Value = s.SpeciesId.ToString() })
                .ToListAsync();
            var sexTypes = await _context.Sex
               .Select(s => new SelectListItem() { Text = s.SexType, Value = s.SexId.ToString() })
               .ToListAsync();
            var viewmodel = new PetDetailViewModel();
            viewmodel.SpeciesTypeOptions = speciesTypes;
            viewmodel.BreedTypeOptions = breedTypes;
            viewmodel.SexTypeOptions = sexTypes;
            return View(viewmodel);

        }

        // POST: Pets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PetDetailViewModel petDetailViewModel)
        {
            try
            {
                var user = await GetCurrentUserAsync();


                var pet = new Pet
                {
                    UserId = user.Id,
                    Name = petDetailViewModel.Pet.Name,
                    Birthday = petDetailViewModel.Pet.Birthday,
                    Color = petDetailViewModel.Pet.Color,
                    SpeciesId = petDetailViewModel.Pet.SpeciesId,
                    BreedId = petDetailViewModel.Pet.BreedId,
                    SexId = petDetailViewModel.Pet.SexId,
                    OngoingProblems = petDetailViewModel.Pet.OngoingProblems,
                    CurrentMedications = petDetailViewModel.Pet.CurrentMedications,
                    IsSpayedOrNeutered = petDetailViewModel.Pet.IsSpayedOrNeutered,
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


                pet.UserId = user.Id;
                _context.Pet.Add(pet);
                await _context.SaveChangesAsync();

             

                ViewData["petCreated"] = ("Your Pet has been Created.");
                ViewData["petId"] = pet;
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }

        // GET: Pets/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var pet = await _context.Pet
               .Include(p => p.Breed)
               .Include(p => p.Sex)
               .Include(p => p.Species)
               .Include(p => p.Notes)
               .FirstOrDefaultAsync(p => p.PetId == id);

            var viewModel = new PetDetailViewModel()
            {
                Pet = new Pet()
            };

            viewModel.Pet.PetId = pet.PetId;
            viewModel.Pet.UserId = pet.UserId;
            viewModel.Pet.Name = pet.Name;
            viewModel.Pet.Color = pet.Color;
            viewModel.Pet.ImagePath = pet.ImagePath;
            viewModel.Pet.Birthday = pet.Birthday;
            viewModel.Pet.BreedId = pet.BreedId;
            viewModel.Pet.SexId = pet.SexId;
            viewModel.Pet.SpeciesId = pet.SpeciesId;
            viewModel.Pet.CurrentMedications = pet.CurrentMedications;
            viewModel.Pet.OngoingProblems = pet.OngoingProblems;
            viewModel.Pet.IsSpayedOrNeutered = pet.IsSpayedOrNeutered;
           

            var breedTypes = await _context.Breed
               .Select(b => new SelectListItem() { Text = b.BreedName, Value = b.BreedId.ToString() })
               .ToListAsync();
            var speciesTypes = await _context.Species
                .Select(s => new SelectListItem() { Text = s.SpeciesType, Value = s.SpeciesId.ToString() })
                .ToListAsync();
            var sexTypes = await _context.Sex
               .Select(s => new SelectListItem() { Text = s.SexType, Value = s.SexId.ToString() })
               .ToListAsync();
           
            viewModel.SpeciesTypeOptions = speciesTypes;
            viewModel.BreedTypeOptions = breedTypes;
            viewModel.SexTypeOptions = sexTypes;
            



            return View(viewModel);
        }

        // POST: Pets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PetDetailViewModel petDetailViewModel)
        {
            try
            {
                var editPet = await _context.Pet
                    .FirstOrDefaultAsync(p => p.PetId == id);
                editPet.Name = petDetailViewModel.Pet.Name;
                editPet.Birthday = petDetailViewModel.Pet.Birthday;
                editPet.Color = petDetailViewModel.Pet.Color;
                editPet.OngoingProblems = petDetailViewModel.Pet.OngoingProblems;
                editPet.CurrentMedications = petDetailViewModel.Pet.CurrentMedications;
                editPet.IsSpayedOrNeutered = petDetailViewModel.Pet.IsSpayedOrNeutered;
                editPet.SpeciesId = petDetailViewModel.Pet.SpeciesId;
                editPet.BreedId = petDetailViewModel.Pet.BreedId;
                editPet.SexId = petDetailViewModel.Pet.SexId;


                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images");
                if (petDetailViewModel.ImageFile != null)
                {
                    var fileName = Guid.NewGuid().ToString() + petDetailViewModel.ImageFile.FileName;
                    editPet.ImagePath = fileName;
                    using (var fileStream = new FileStream(Path.Combine(uploadPath, fileName), FileMode.Create))
                    {
                        await petDetailViewModel.ImageFile.CopyToAsync(fileStream);
                    }
                }

                _context.Pet.Update(editPet);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet
                .FirstOrDefaultAsync(p => p.PetId == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);

        }

        // POST: Pets/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var pet = await _context.Pet.FindAsync(id);
            _context.Pet.Remove(pet);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Pets");
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}