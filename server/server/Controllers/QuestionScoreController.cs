using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Controllers
{
    public class QuestionScoreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionScoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuestionScore
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.QuestionScore.Include(q => q.Course).Include(q => q.CourseSection).Include(q => q.IdentityUser).Include(q => q.Question);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: QuestionScore/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.QuestionScore == null)
            {
                return NotFound();
            }

            var questionScore = await _context.QuestionScore
                .Include(q => q.Course)
                .Include(q => q.CourseSection)
                .Include(q => q.IdentityUser)
                .Include(q => q.Question)
                .FirstOrDefaultAsync(m => m.QuestionScoreID == id);
            if (questionScore == null)
            {
                return NotFound();
            }

            return View(questionScore);
        }

        // GET: QuestionScore/Create
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID");
            ViewData["CourseSectionID"] = new SelectList(_context.CourseSections, "CourseSectionID", "CourseSectionID");
            ViewData["IdentityUserID"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["QuestionID"] = new SelectList(_context.Questions, "Id", "Id");
            return View();
        }

        // POST: QuestionScore/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionScoreID,AnswerTime,IdentityUserID,QuestionID,CourseSectionID,CourseID,Score")] QuestionScore questionScore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionScore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", questionScore.CourseID);
            ViewData["CourseSectionID"] = new SelectList(_context.CourseSections, "CourseSectionID", "CourseSectionID", questionScore.CourseSectionID);
            ViewData["IdentityUserID"] = new SelectList(_context.Users, "Id", "Id", questionScore.IdentityUserID);
            ViewData["QuestionID"] = new SelectList(_context.Questions, "Id", "Id", questionScore.QuestionID);
            return View(questionScore);
        }

        // GET: QuestionScore/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.QuestionScore == null)
            {
                return NotFound();
            }

            var questionScore = await _context.QuestionScore.FindAsync(id);
            if (questionScore == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", questionScore.CourseID);
            ViewData["CourseSectionID"] = new SelectList(_context.CourseSections, "CourseSectionID", "CourseSectionID", questionScore.CourseSectionID);
            ViewData["IdentityUserID"] = new SelectList(_context.Users, "Id", "Id", questionScore.IdentityUserID);
            ViewData["QuestionID"] = new SelectList(_context.Questions, "Id", "Id", questionScore.QuestionID);
            return View(questionScore);
        }

        // POST: QuestionScore/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestionScoreID,AnswerTime,IdentityUserID,QuestionID,CourseSectionID,CourseID,Score")] QuestionScore questionScore)
        {
            if (id != questionScore.QuestionScoreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionScore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionScoreExists(questionScore.QuestionScoreID))
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
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", questionScore.CourseID);
            ViewData["CourseSectionID"] = new SelectList(_context.CourseSections, "CourseSectionID", "CourseSectionID", questionScore.CourseSectionID);
            ViewData["IdentityUserID"] = new SelectList(_context.Users, "Id", "Id", questionScore.IdentityUserID);
            ViewData["QuestionID"] = new SelectList(_context.Questions, "Id", "Id", questionScore.QuestionID);
            return View(questionScore);
        }

        // GET: QuestionScore/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.QuestionScore == null)
            {
                return NotFound();
            }

            var questionScore = await _context.QuestionScore
                .Include(q => q.Course)
                .Include(q => q.CourseSection)
                .Include(q => q.IdentityUser)
                .Include(q => q.Question)
                .FirstOrDefaultAsync(m => m.QuestionScoreID == id);
            if (questionScore == null)
            {
                return NotFound();
            }

            return View(questionScore);
        }

        // POST: QuestionScore/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.QuestionScore == null)
            {
                return Problem("Entity set 'ApplicationDbContext.QuestionScore'  is null.");
            }
            var questionScore = await _context.QuestionScore.FindAsync(id);
            if (questionScore != null)
            {
                _context.QuestionScore.Remove(questionScore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionScoreExists(int id)
        {
          return (_context.QuestionScore?.Any(e => e.QuestionScoreID == id)).GetValueOrDefault();
        }
    }
}
