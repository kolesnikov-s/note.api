using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notes.Database.PostgreSQL;
using Notes.Domain;
using Notes.UseCases.Notes.Queries.GetNotesByUser;
using Notes.Web.Models;

namespace Notes.Web.Controllers
{
    public class NoteController: BaseApiController
    {
        // private readonly ApplicationDbContext _context;
        //
        // public NoteController(ApplicationDbContext context)
        // {
        //     _context = context;
        // }
        
        /// <summary>
        /// Получить все записки текущего пользователя.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("notes")]
        public async Task<IActionResult> GetNotes()
        {
            // var userId = GetCurrentUserId();
            
            // var notes = await _context.Notes
            //     .Where(n => n.UserId == userId)
            //     .ToListAsync();
            //
            // var response = new Response<IEnumerable<Note>>(notes);

            var response = await Mediator.Send(new GetNotesByUserIdQuery());
            
            return Ok(response);
        }
        
        // /// <summary>
        // /// Создать записку.
        // /// </summary>
        // /// <param name="request"></param>
        // /// <returns></returns>
        // [HttpPost, Route("notes")]
        // public async Task<IActionResult> CreateNote(NoteViewModel request)
        // {
        //     var userId = GetCurrentUserId();
        //     
        //     var note = new Note()
        //     {
        //         Name = request.Name,
        //         Text = request.Text,
        //         DateUpdated = DateTime.UtcNow,
        //         UserId = userId
        //     };
        //
        //     await _context.Notes.AddAsync(note);
        //     await _context.SaveChangesAsync();
        //
        //     var response = new Response<Guid>(note.Id);
        //     
        //     return Ok(response);
        // }
        //
        // /// <summary>
        // /// Обновить записку.
        // /// </summary>
        // /// <param name="id"></param>
        // /// <param name="request"></param>
        // /// <returns></returns>
        // [HttpPut, Route("notes")]
        // public async Task<IActionResult> UpdateNote(NoteViewModel request)
        // {
        //     var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == request.Id);
        //
        //     if (note == null)
        //         return NotFound();
        //
        //     note.Name = request.Name;
        //     note.Text = request.Text;
        //     note.DateUpdated = DateTime.UtcNow;
        //
        //     await _context.SaveChangesAsync();
        //
        //     var response = new Response<Guid>(note.Id);
        //     
        //     return Ok(response);
        // }
        //
        // /// <summary>
        // /// Удалить записку.
        // /// </summary>
        // /// <param name="id"></param>
        // /// <returns></returns>
        // [HttpDelete, Route("notes/{id:guid}")]
        // public async Task<IActionResult> DeleteNote(Guid id)
        // {
        //     var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);
        //
        //     if (note == null)
        //         return NotFound();
        //
        //     _context.Notes.Remove(note);
        //     await _context.SaveChangesAsync();
        //
        //     var response = new Response<Guid>(note.Id);
        //     
        //     return Ok(response);
        // }
    }
}