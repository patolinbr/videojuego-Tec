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
    public class CourseSectionScoreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseSectionScoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CourseSectionScore
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CourseSectionScores.Include(c => c.Course).Include(c => c.CourseSection).Include(c => c.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CourseSectionScore/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CourseSectionScores == null)
            {
                return NotFound();
            }

            var courseSectionScore = await _context.CourseSectionScores
                .Include(c => c.Course)
                .Include(c => c.CourseSection)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CourseSectionScoreID == id);
            if (courseSectionScore == null)
            {
                return NotFound();
            }

            return View(courseSectionScore);
        }

        // GET: CourseSectionScore/Create
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID");
            ViewData["CourseSectionID"] = new SelectList(_context.CourseSections, "CourseSectionID", "CourseSectionID");
            ViewData["IdentityUserID"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: CourseSectionScore/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseSectionScoreID,AnswerTime,IdentityUserID,CourseSectionID,CourseID,Score")] CourseSectionScore courseSectionScore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseSectionScore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", courseSectionScore.CourseID);
            ViewData["CourseSectionID"] = new SelectList(_context.CourseSections, "CourseSectionID", "CourseSectionID", courseSectionScore.CourseSectionID);
            ViewData["IdentityUserID"] = new SelectList(_context.Users, "Id", "Id", courseSectionScore.IdentityUserID);
            return View(courseSectionScore);
        }

        // GET: CourseSectionScore/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CourseSectionScores == null)
            {
                return NotFound();
            }

            var courseSectionScore = await _context.CourseSectionScores.FindAsync(id);
            if (courseSectionScore == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", courseSectionScore.CourseID);
            ViewData["CourseSectionID"] = new SelectList(_context.CourseSections, "CourseSectionID", "CourseSectionID", courseSectionScore.CourseSectionID);
            ViewData["IdentityUserID"] = new SelectList(_context.Users, "Id", "Id", courseSectionScore.IdentityUserID);
            return View(courseSectionScore);
        }

        // POST: CourseSectionScore/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseSectionScoreID,AnswerTime,IdentityUserID,CourseSectionID,CourseID,Score")] CourseSectionScore courseSectionScore)
        {
            if (id != courseSectionScore.CourseSectionScoreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseSectionScore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseSectionScoreExists(courseSectionScore.CourseSectionScoreID))
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
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", courseSectionScore.CourseID);
            ViewData["CourseSectionID"] = new SelectList(_context.CourseSections, "CourseSectionID", "CourseSectionID", courseSectionScore.CourseSectionID);
            ViewData["IdentityUserID"] = new SelectList(_context.Users, "Id", "Id", courseSectionScore.IdentityUserID);
            return View(courseSectionScore);
        }

        // GET: CourseSectionScore/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CourseSectionScores == null)
            {
                return NotFound();
            }

            var courseSectionScore = await _context.CourseSectionScores
                .Include(c => c.Course)
                .Include(c => c.CourseSection)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CourseSectionScoreID == id);
            if (courseSectionScore == null)
            {
                return NotFound();
            }

            return View(courseSectionScore);
        }

        // POST: CourseSectionScore/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CourseSectionScores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CourseSectionScores'  is null.");
            }
            var courseSectionScore = await _context.CourseSectionScores.FindAsync(id);
            if (courseSectionScore != null)
            {
                _context.CourseSectionScores.Remove(courseSectionScore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseSectionScoreExists(int id)
        {
          return (_context.CourseSectionScores?.Any(e => e.CourseSectionScoreID == id)).GetValueOrDefault();
        }
    }
}
