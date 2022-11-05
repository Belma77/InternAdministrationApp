using AutoMapper;
using Backend.Dtos;
using Backend.Models.Enums;
using Backend.Repository.SelectionRepo;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<List<GetSelectionDto>> GetAllSelections()
        {
            var selections=await _selectionRepository.GetAllSelections();
            return _mapper.Map<List<GetSelectionDto>>(selections);
        }
    }
}
