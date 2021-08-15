using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notes.Controllers.Common;
using Notes.UseCases.Notes.Commands.CreateNote;
using Notes.UseCases.Notes.Commands.DeleteNoteById;
using Notes.UseCases.Notes.Commands.UpdateNote;
using Notes.UseCases.Notes.Queries.GetNoteById;
using Notes.UseCases.Notes.Queries.GetNotesPageByUser;

namespace Notes.Controllers
{
    public class NoteController: BaseApiController
    {
        /// <summary>
        /// Получить все записки текущего пользователя.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("notes")]
        public async Task<IActionResult> GetNotes(string searchWords = null, int? pageNumber = null, int? pageSize = null)
        {
            var response = await Mediator.Send(new GetNotesPageByUserQuery()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                SearchWords = searchWords
            });
            
            return Ok(response);
        }
        
        /// <summary>
        /// Получить записку.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("notes/{id}")]
        public async Task<IActionResult> GetNote(Guid id)
        {
            var response = await Mediator.Send(new GetNoteByIdQuery() { NoteId = id });
            
            return Ok(response);
        }
        
        /// <summary>
        /// Создать записку.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, Route("notes")]
        public async Task<IActionResult> CreateNote(CreateNoteCommand command)
        {
            var response = await Mediator.Send(command);
            
            return Ok(response);
        }
        
        /// <summary>
        /// Обновить записку.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut, Route("notes")]
        public async Task<IActionResult> UpdateNote(UpdateNoteCommand command)
        {
            var response = await Mediator.Send(command);
            
            return Ok(response);
        }
        
        /// <summary>
        /// Удалить записку.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("notes/{id:guid}")]
        public async Task<IActionResult> DeleteNote(Guid id)
        {
            var response = await Mediator.Send(new DeleteNoteByIdCommand() { Id = id });
            
            return Ok(response);
        }
    }
}