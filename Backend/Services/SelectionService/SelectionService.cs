using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Dtos;
using Backend.Helpers;
using Backend.Models.Enums;
using Backend.Repository.SelectionRepo;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Backend.Services.SelectionService
{
    public class SelectionService:ISelectionService
    {
        private readonly ISelectionRepository _selectionRepository;
        private readonly IMapper _mapper;
        public SelectionService(ISelectionRepository selectionRepository, IMapper mapper)
        {
            _selectionRepository = selectionRepository;
            _mapper = mapper;
        }
        public async Task<PagedList<GetSelectionsDto>> GetAllSelections(UserParams userParams)
        {
            var query=_selectionRepository.GetAllSelections();
            query = FilterSelections.FilterData(query, userParams.filterSelections);
            query = SelectionsSorting.SortBy(query, userParams.OrderBy);
            var selections = query.ProjectTo<GetSelectionsDto>(_mapper.ConfigurationProvider);
            return await PagedList<GetSelectionsDto>.CreateAsync(selections, userParams.PageNumber, userParams.pageSize);
        }
        public async Task<GetSelectionDto> GetSelectionById(int id)
        {
            var selection= await _selectionRepository.GetSelectionById(id);
            return _mapper.Map<GetSelectionDto>(selection);
            
        }

    }
}
