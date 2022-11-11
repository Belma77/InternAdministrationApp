using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Dtos;
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
            query = FilterSelections.FilterData(query, userParams.filterSelections);
            query = SelectionsSorting.SortBy(query, userParams.OrderBy);
            var selections = query.ProjectTo<GetSelectionsDto>(_mapper.ConfigurationProvider);
            return await PagedList<GetSelectionsDto>.CreateAsync(selections, userParams.PageNumber, userParams.pageSize);
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
        public async Task<GetSelectionsDto> EditSelection(int id, AddSelectionDto addSelection)
        {

            var selection = await _selectionRepository.GetSelectionById(id);
            if (selection == null)
                throw new Exception("Selection not found");
            selection.Name = addSelection.Name;
            selection.Description = addSelection.Description;
            selection.StartDate = addSelection.StartDate;
            selection.EndDate = addSelection.EndDate;
            selection.EditedAt = DateTime.Now;
            await _selectionRepository.EditSelection(selection);
            return _mapper.Map<GetSelectionsDto>(selection);
        }
        public async Task<GetSelectionDto> AddApplicantsToSelection(int selectionId, int applicationId)
        {
            var selection = await _selectionRepository.GetSelectionById(selectionId);
            var app = await _applicationRepo.GetById(applicationId);
            if (selection == null)
                throw new Exception("Selection not found");
            if (app == null)
                throw new Exception("Application not found");
            if (selection.Applications.Any(x => x.Id == applicationId))
                throw new Exception("Applicant already added to selection");
            selection.Applications.Add(app);
            app.Status = Status.Inselection;
            await _selectionRepository.EditSelection(selection);
             return _mapper.Map<GetSelectionDto>(selection);
        }
        public async Task<GetSelectionDto>RemoveApplicantToSelection(int selectionId, int applicationId)
        {
            var selection=await _selectionRepository.GetSelectionById(selectionId);
            var app = await _applicationRepo.GetById(applicationId);
            if (selection == null)
                throw new Exception("Selection not found");
            if (app == null)
                throw new Exception("Application not found");
            if (!selection.Applications.Any(x => x.Id == applicationId))
                throw new Exception("Applicant isn't in selection");
            app.Status = Status.Completed;
            var selectionDto= await _selectionRepository.RemoveApplicant(selection, app);
            return _mapper.Map<GetSelectionDto>(selectionDto);
        }
        public async Task<GetSelectionDto> AddCommentToSelection(int selectionId, string comment)
        {
            var selection = await _selectionRepository.GetSelectionById(selectionId);
            Console.WriteLine(selection);
            if (selection == null)
                throw new Exception("Selection not found");
            string username = _contextAccessor.HttpContext.User.Identity.Name;
            var user = await _userService.GetByUsername(username);
            var commentModel = new Comment();
            commentModel.User = user;
            commentModel.Description = comment;
            selection.Comments.Add(commentModel);
            await _selectionRepository.EditSelection(selection);
            return _mapper.Map<GetSelectionDto>(selection);
        }

    }
}
