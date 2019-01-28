using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OracleNotes.Data.Commands.Note;
using OracleNotes.Data.Models;
using OracleNotes.Data.Services.Interfaces;
using OracleNotes.Extensions.Exceptions;
using OracleNotes.Models;

namespace OracleNotes.Controllers
{
    public class HomeController : Controller
    {
        private readonly INoteService _noteService;

        public HomeController(INoteService noteService)
        {
            _noteService = noteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateNoteCommand command)
        {
            try
            {
                await _noteService.AddAsync(command);
                return RedirectToAction("List", "Home");
            }
            catch (InternalSystemException ex)
            {
                return View();
            }
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var notes = _noteService.GetAll();

            return View(notes);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _noteService.DeleteAsync(id);
                return RedirectToAction("List", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("List", "Home");
            }
        }

        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            //try
            //{
                var note = _noteService.Get(id);
                return View(note);
            //}
            //catch (Exception)
            //{
            //    return RedirectToAction("List", "Home");
            //}
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(Note note)
        {
            try
            {
                await _noteService.UpdateAsync(note);
                return RedirectToAction("List", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("List", "Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
