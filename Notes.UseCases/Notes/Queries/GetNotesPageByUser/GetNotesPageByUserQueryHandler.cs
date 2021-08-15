using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Notes.Application.Interfaces;
using Notes.Application.Wrappers;
using Notes.Domain;

namespace Notes.UseCases.Notes.Queries.GetNotesPageByUser
{
    public class GetNotesPageByUserQueryHandler: IRequestHandler<GetNotesPageByUserQuery, 
        PagedResponse<IEnumerable<GetNotesPageByUserViewModel>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        
        private const int PageSizeDefault = 100;
        
        public GetNotesPageByUserQueryHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Note, GetNotesPageByUserViewModel>();
            });

            _context = context;
            _mapper = config.CreateMapper();
            _currentUserService = currentUserService;
        }
        
        public async Task<PagedResponse<IEnumerable<GetNotesPageByUserViewModel>>> Handle(GetNotesPageByUserQuery request, CancellationToken cancellationToken)
        {
            var pageNumber = request.PageNumber ?? 1;
            var pageSize = request.PageSize ?? PageSizeDefault;
            
            var userId = _currentUserService.UserId;

            IQueryable<Note> notesQuery = _context.Notes;
            
            notesQuery = notesQuery.Where(note => note.UserId == userId);
            
            if (request.SearchWords != null)
            {
                notesQuery = notesQuery.Where(note => 
                    EF.Functions.ILike(note.Name, $"%{request.SearchWords}%") || 
                    EF.Functions.ILike(note.Text, $"%{request.SearchWords}%"));
            }

            notesQuery = notesQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            var notesCount = await _context.Notes.CountAsync();
            var notes = await notesQuery.ToListAsync();

            var response = new PagedResponse<IEnumerable<GetNotesPageByUserViewModel>>(
                _mapper.Map<IEnumerable<GetNotesPageByUserViewModel>>(notes),
                pageNumber,
                pageSize,
                notesCount);

            return response;
        }
    }
}