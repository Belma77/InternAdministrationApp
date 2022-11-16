using Abp.Extensions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Dtos;
using Backend.ExceptionHandlers;
using Backend.Helpers;
using Backend.Models;
using Backend.Models.Enums;
using Backend.Repository.AppRepo;
using Backend.Repository.SelectionRepo;
using Backend.Repository.UserRepo;
using Backend.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Backend.Services.SelectionService
{
    public class SelectionService : ISelectionService
    {
        private readonly ISelectionRepository _selectionRepository;
        private readonly IMapper _mapper;
        private IApplicationRepository _applicationRepo;
        private IHttpContextAccessor _contextAccessor;
        private IUserService _userService;

        public SelectionService(ISelectionRepository selectionRepository, IMapper mapper, IApplicationRepository applicationRepo,
            IHttpContextAccessor contextAccessor, IUserService userService)
        {
            _selectionRepository = selectionRepository;
            _mapper = mapper;
            _applicationRepo = applicationRepo;
            _contextAccessor = contextAccessor;
            _userService = userService;
        }

        public async Task<PagedList<GetSelectionsDto>> GetAllSelections(UserParams userParams)
        {
            var query = _selectionRepository.GetAllSelections();
            query = FilterSelections.ExtentQueryWithFilter(query, userParams.filterSelections);
            query = SelectionsSorting.SortBy(query, userParams.OrderBy);
            var selections = query.ProjectTo<GetSelectionsDto>(_mapper.ConfigurationProvider);
            return await PagedList<GetSelectionsDto>.CreateAsync(selections, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<GetSelectionDto> GetSelectionById(int id)
        {
            var selection = await _selectionRepository.GetSelectionById(id);
            return _mapper.Map<GetSelectionDto>(selection);
        }

        public async Task<GetSelectionsDto> AddSelection(AddSelectionDto addSelection)
        {
            var selection = _mapper.Map<Selection>(addSelection);
            selection.CreatedAt = DateTime.Now;
            await _selectionRepository.AddSelection(selection);
            return _mapper.Map<GetSelectionsDto>(selection);
        }

        public async Task<GetSelectionDto> EditSelection(EditSelectionDto editSelection)
        {

            var selection = await _selectionRepository.GetSelectionById(editSelection.SelectionId);

            if (selection == null)
                throw new NotFoundException("Selection not found");

            selection.Name = editSelection.Name;
            selection.Description = editSelection.Description;
            selection.StartDate = (DateTime)editSelection.StartDate;
            selection.EndDate = (DateTime)(editSelection.EndDate);
           

            selection.EditedAt = DateTime.Now;

           var edited= await _selectionRepository.EditSelection(selection);

            return _mapper.Map<GetSelectionDto>(edited);
        }

        public async Task<GetSelectionDto> AddApplicantsToSelection(int selectionId, int applicationId)
        {

            var selection = await _selectionRepository.GetSelectionById(selectionId);
            var app = await _applicationRepo.GetById(applicationId);

            if (selection == null)
                throw new NotFoundException("Selection not found");

            if (app == null)
                throw new NotFoundException("Application not found");

            if (selection.Applications.Any(x => x.Id == applicationId))
                throw new NotFoundException("Applicant already added to selection");

            selection.Applications.Add(app);
            app.Status = StatusEnum.Inselection;
            await _selectionRepository.EditSelection(selection);

            return _mapper.Map<GetSelectionDto>(selection);
        }

        public async Task<GetSelectionDto> RemoveApplicantToSelection(int selectionId, int applicationId)
        {
            var selection = await _selectionRepository.GetSelectionById(selectionId);
            var app = await _applicationRepo.GetById(applicationId);

            if (selection == null)
                throw new NotFoundException("Selection not found");

            if (app == null)

                throw new NotFoundException("Application not found");

            if (!selection.Applications.Any(x => x.Id == applicationId))
                throw new NotFoundException("Applicant isn't in selection");

            app.Status = StatusEnum.Completed;
            var selectionDto = await _selectionRepository.RemoveApplicant(selection, app);

            return _mapper.Map<GetSelectionDto>(selectionDto);
        }


    }
}
