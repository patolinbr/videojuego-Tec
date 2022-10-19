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
    public class AnswerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnswerController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Answer/Create
        public IActionResult Create(int questionId)
        {
            ViewData["QuestionID"] = questionId;
            return View();
        }

        // POST: Answer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnswerID,Text,Correct,QuestionID")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(answer);
                await _context.SaveChangesAsync();
                var found_question = await _context.Questions.FindAsync(answer.QuestionID);
                return RedirectToAction("Details", "CourseSection", new { id = found_question.CourseSectionId });
            }

            ViewData["QuestionID"] = new SelectList(_context.Questions, "Id", "Id", answer.QuestionID);
            var question = await _context.Questions.FindAsync(answer.QuestionID);
            return RedirectToAction("Details", "CourseSection", new { id = question.CourseSectionId });
        }

        // GET: Answer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Answers == null)
            {
                return NotFound();
            }

            var answer = await _context.Answers.FindAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            ViewData["QuestionID"] = new SelectList(_context.Questions, "Id", "Id", answer.QuestionID);
            return View(answer);
        }

        // POST: Answer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnswerID,Text,Correct,QuestionID")] Answer answer)
        {
            if (id != answer.AnswerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(answer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnswerExists(answer.AnswerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Edit", "Question", new { id = answer.QuestionID });
            }

            ViewData["QuestionID"] = new SelectList(_context.Questions, "Id", "Id", answer.QuestionID);
            return RedirectToAction("Edit", "Question", new { id = answer.QuestionID });
        }

        // GET: Answer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Answers == null)
            {
                return NotFound();
            }

            var answer = await _context.Answers
                .Include(a => a.Question)
                .FirstOrDefaultAsync(m => m.AnswerID == id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // POST: Answer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Answers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Answers'  is null.");
            }

            var answer = await _context.Answers.FindAsync(id);
            if (answer != null)
            {
                _context.Answers.Remove(answer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", "Question", new { id = answer.QuestionID });
        }

        private bool AnswerExists(int id)
        {
            return (_context.Answers?.Any(e => e.AnswerID == id)).GetValueOrDefault();
        }
    }
}