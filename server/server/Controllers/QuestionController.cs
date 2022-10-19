using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public QuestionController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Question
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Questions.Include(q => q.Course).Include(q => q.CourseSection);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Question/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Course)
                .Include(q => q.CourseSection)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Question/Create
        public IActionResult Create(int courseSectionId)
        {
            ViewData["CourseSectionId"] = courseSectionId;
            return View();
        }

        // POST: Question/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,QuestionText,Position,CourseSectionId")] Question question)
        {
            if (ModelState.IsValid)
            {
                var courseSection = await _context.CourseSections.FindAsync(question.CourseSectionId);
                var course = await _context.Courses.FindAsync(courseSection.CourseID);
                question.CourseID = course.CourseID;

                courseSection.Questions.Add(question);
                _context.Update(courseSection);

                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "CourseSection", new { id = question.CourseSectionId });
            }

            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", question.CourseID);
            ViewData["CourseSectionId"] = new SelectList(_context.CourseSections, "CourseSectionID", "CourseSectionID",
                question.CourseSectionId);
            return View(question);
        }

        // GET: Question/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", question.CourseID);
            ViewData["CourseSectionId"] = new SelectList(_context.CourseSections, "CourseSectionID", "CourseSectionID",
                question.CourseSectionId);
            return View(question);
        }

        // POST: Question/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,QuestionText,Position,CourseSectionId,CourseID")]
            Question question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
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

            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", question.CourseID);
            ViewData["CourseSectionId"] = new SelectList(_context.CourseSections, "CourseSectionID", "CourseSectionID",
                question.CourseSectionId);
            return View(question);
        }

        // GET: Question/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Course)
                .Include(q => q.CourseSection)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Questions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Questions'  is null.");
            }

            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return (_context.Questions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}