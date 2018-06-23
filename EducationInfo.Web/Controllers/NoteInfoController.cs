using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EducationInfo.Core.Entities;
using EducationInfo.Infrastructure;
using EducationInfo.Core.Services;
using EducationInfo.Core;

namespace EducationInfo.Web.Controllers
{
    public class NoteInfoController : Controller
    {
        //private readonly EducationInfoContext _context;
        private readonly INoteInfoService noteInfoService;
        private readonly ICourseService courseService;
        private readonly IUnitOfWork unitOfWork;

        public NoteInfoController(IUnitOfWork unitOfWork, INoteInfoService noteInfoService, ICourseService courseService)
        {
            this.unitOfWork = unitOfWork;
            this.noteInfoService = noteInfoService;
            this.courseService = courseService;
        }

        // GET: NoteInfo
        public async Task<IActionResult> Index()
        {
            var notes = await noteInfoService.GetAll(); //_context.NoteInfo.Include(n => n.Course);
            return View(notes);
        }
        
        // GET: NoteInfo/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noteInfo = noteInfoService.GetById(id);                
            if (noteInfo == null)
            {
                return NotFound();
            }

            return View(noteInfo);
        }

        // GET: NoteInfo/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(courseService.GetAll(), "Id", "Title");
            return View();
        }

        // POST: NoteInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,NoteLocation,CourseId,CreateDate,PublishDate,IsPublish")] NoteInfo noteInfo)
        {
            if (ModelState.IsValid)
            {
                noteInfoService.Add(noteInfo);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(courseService.GetAll(), "Id", "Title", noteInfo.CourseId);
            return View(noteInfo);
        }
        /*
        // GET: NoteInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noteInfo = await _context.NoteInfo.SingleOrDefaultAsync(m => m.Id == id);
            if (noteInfo == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title", noteInfo.CourseId);
            return View(noteInfo);
        }

        // POST: NoteInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,NoteLocation,CourseId,CreateDate,PublishDate,IsPublish")] NoteInfo noteInfo)
        {
            if (id != noteInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noteInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteInfoExists(noteInfo.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title", noteInfo.CourseId);
            return View(noteInfo);
        }

        // GET: NoteInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noteInfo = await _context.NoteInfo
                .Include(n => n.Course)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (noteInfo == null)
            {
                return NotFound();
            }

            return View(noteInfo);
        }

        // POST: NoteInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noteInfo = await _context.NoteInfo.SingleOrDefaultAsync(m => m.Id == id);
            _context.NoteInfo.Remove(noteInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteInfoExists(int id)
        {
            return _context.NoteInfo.Any(e => e.Id == id);
        }
        */
    }
}
