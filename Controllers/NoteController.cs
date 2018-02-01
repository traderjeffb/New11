using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Microsoft.AspNet.Identity;
using New11.Models;
using New11.Services;

namespace New11.Web.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userId);
            var model = service.GetNotes();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NoteCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateNoteService();

            if (service.CreateNote(model))
            {
                TempData["SaveResult"] = "Your Note was Created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Note could not be created.");

            return View(model);
        }

        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {

            var service = CreateNoteService();
            var model = service.GetNotesById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateNoteService();
            var detail = service.GetNotesById(id);
            var model =
                new NoteEdit
                {
                    NoteId = detail.NoteId,
                    Title = detail.Title,
                    Content = detail.Content
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateNote(int id, NoteEdit model)
        {

            if (!ModelState.IsValid) return View(model);

            if (model.NoteId != id)
            {
             ModelState.AddModelError("", "ID mismatch");
                return View(model);
            }

            var service = CreateNoteService();
            

             if (service.UpdateNote(model))
            {
            TempData["SaveResult"] = "Your Note was updated";
                return RedirectToAction("Index");
            }
            

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {

            var service = CreateNoteService();
            var model = service.GetNotesById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]

        Public ActionResult DeletePost(int id)
        {
            RedirectToAction("Indax");
        }
    }
}