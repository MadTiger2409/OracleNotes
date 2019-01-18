using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OracleNotes.Data.Commands.Note;
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
                return View();
            }
            catch (InternalSystemException ex)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult List()
        {
            var notes = _noteService.GetAll();

            return View(notes);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
