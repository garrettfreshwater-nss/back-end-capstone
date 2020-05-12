using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BluegrassPetCare.Data;
using BluegrassPetCare.Models;
using BluegrassPetCare.Models.NoteViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BluegrassPetCare.Controllers
{
    public class NotesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public NotesController(ApplicationDbContext ctx, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = ctx;
        }


        // GET: Notes
        public async Task<ActionResult> Index(string searchString, string TitleSearchString)
        {



            if (searchString != null)
            {
                var note = await _context.Note
                    .Where(n => n.Title.Contains(searchString))
                    .Include(n => n.Pet)
                    .ToListAsync();

                return View(note);
            }
            else
            {
                var note = await _context.Note
                    .Include(n => n.Pet)
                    .ToListAsync();

                return View(note);
            }
        }
            

            // GET: Notes/Details/5
            public async Task<ActionResult> Details(int id)
        {
            var note = await _context.Note
                .Include(n => n.PetId)
                .Include(n => n.UserId)
                .FirstOrDefaultAsync(n => n.NoteId == id);

            var viewModel = new NoteDetailViewModel()
            {
                Note = new Note()
            };

            viewModel.Note.NoteId = note.NoteId;
            viewModel.Note.UserId = note.UserId;
            viewModel.Note.Title = note.Title;
            viewModel.Note.UploadPath = note.UploadPath;
            viewModel.Note.DateAdded = note.DateAdded;
            viewModel.Note.Description = note.Description;
            viewModel.Note.PetId = note.PetId;

            return View(viewModel);
        }

        // GET: Notes/Create
        public async Task<ActionResult> CreateAsync()
        {
            var petTypes = await _context.Pet
               .Select(b => new SelectListItem() { Text = b.Name, Value = b.PetId.ToString() })
               .ToListAsync();
            var viewModel = new NoteDetailViewModel();
            viewModel.PetsTypeOptions = petTypes;
            return View(viewModel);

        }

        // POST: Notes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NoteDetailViewModel noteDetailViewModel)
        {
            try
            {

                var user = await GetCurrentUserAsync();

                var note = new Note
                {
                    UserId = user.Id,
                    NoteId = noteDetailViewModel.Note.NoteId,
                    Title = noteDetailViewModel.Note.Title,
                    DateAdded = noteDetailViewModel.Note.DateAdded,
                    Description = noteDetailViewModel.Note.Description,
                    PetId = noteDetailViewModel.Note.PetId
            };


                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\pdfs");
                if (noteDetailViewModel.ImageFile != null)
                {
                    var fileName = Guid.NewGuid().ToString() + noteDetailViewModel.ImageFile.FileName;
                    note.UploadPath = fileName;
                    using (var fileStream = new FileStream(Path.Combine(uploadPath, fileName), FileMode.Create))
                    {
                        await noteDetailViewModel.ImageFile.CopyToAsync(fileStream);
                    }
                }

                _context.Note.Add(note);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Notes/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var note = await _context.Note
                .Include(p => p.Pet)
                .FirstOrDefaultAsync(n => n.NoteId == id);


            var viewModel = new NoteDetailViewModel()
            {
                Note = new Note()
            };


            viewModel.Note.NoteId = note.NoteId;
            viewModel.Note.UserId = note.UserId;
            viewModel.Note.Title = note.Title;
            viewModel.Note.Description = note.Description;
            viewModel.Note.UploadPath = note.UploadPath;
            viewModel.Note.PetId = note.PetId;
            

            var petTypes = await _context.Pet
               .Select(b => new SelectListItem() { Text = b.Name, Value = b.PetId.ToString() })
               .ToListAsync();
           

            viewModel.PetsTypeOptions = petTypes;
            return View(viewModel);


        }

        // POST: Notes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, NoteDetailViewModel noteDetailViewModel)
        {
            try
            {

                var editNote = await _context.Note
                    .FirstOrDefaultAsync(p => p.NoteId == id);
                editNote.Title = noteDetailViewModel.Note.Title;
                editNote.DateAdded = noteDetailViewModel.Note.DateAdded;
                editNote.Description = noteDetailViewModel.Note.Description;
                editNote.PetId = noteDetailViewModel.Note.PetId;


                //var petNote = new Note()
                //{
                //    NoteId = noteDetailViewModel.Note.NoteId,
                //    Title = noteDetailViewModel.Note.Title,
                //    DateAdded = noteDetailViewModel.Note.DateAdded,
                //    Description = noteDetailViewModel.Note.Description,
                //    PetId = noteDetailViewModel.Note.PetId
                //};

                _context.Note.Update(editNote);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Notes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Note
                .FirstOrDefaultAsync(n => n.NoteId == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);

        }

        // POST: Notes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var note = await _context.Pet.FindAsync(id);
            _context.Pet.Remove(note);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}