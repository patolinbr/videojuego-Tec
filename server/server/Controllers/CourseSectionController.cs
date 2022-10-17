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
    public class CourseSectionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CourseSectionController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CourseSection
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CourseSections.Include(c => c.Course).Include(c => c.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CourseSection/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CourseSections == null)
            {
                return NotFound();
            }

            var courseSection = await _context.CourseSections
                .Include(c => c.Course)
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.CourseSectionID == id);
            if (courseSection == null)
            {
                return NotFound();
            }

            return View(courseSection);
        }

        // GET: CourseSection/Create
        public IActionResult Create(int courseID)
        {
            ViewData["courseID"] = courseID;
            return View();
        }

        // POST: CourseSection/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseSectionID,Title,Description,Content,CourseID")] CourseSection courseSection)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                courseSection.IdentityUserID = user.Id;
                _context.Add(courseSection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", courseSection.CourseID);
            ViewData["IdentityUserID"] = new SelectList(_context.Users, "Id", "Id", courseSection.IdentityUserID);
            return View(courseSection);
        }

        // GET: CourseSection/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CourseSections == null)
            {
                return NotFound();
            }

            var courseSection = await _context.CourseSections.FindAsync(id);
            if (courseSection == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", courseSection.CourseID);
            ViewData["IdentityUserID"] = new SelectList(_context.Users, "Id", "Id", courseSection.IdentityUserID);
            return View(courseSection);
        }

        // POST: CourseSection/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseSectionID,Title,Description,Content,CourseID,IdentityUserID")] CourseSection courseSection)
        {
            if (id != courseSection.CourseSectionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseSectionExists(courseSection.CourseSectionID))
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
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", courseSection.CourseID);
            ViewData["IdentityUserID"] = new SelectList(_context.Users, "Id", "Id", courseSection.IdentityUserID);
            return View(courseSection);
        }

        // GET: CourseSection/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CourseSections == null)
            {
                return NotFound();
            }

            var courseSection = await _context.CourseSections
                .Include(c => c.Course)
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.CourseSectionID == id);
            if (courseSection == null)
            {
                return NotFound();
            }

            return View(courseSection);
        }

        // POST: CourseSection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CourseSections == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CourseSections'  is null.");
            }
            var courseSection = await _context.CourseSections.FindAsync(id);
            if (courseSection != null)
            {
                _context.CourseSections.Remove(courseSection);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseSectionExists(int id)
        {
          return (_context.CourseSections?.Any(e => e.CourseSectionID == id)).GetValueOrDefault();
        }
    }
}
