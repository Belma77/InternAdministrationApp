using AutoMapper;
using Backend.Data;
using Backend.Dtos;
using Backend.Helpers;
using Backend.Models;
using Backend.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.AppRepo
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ApplicationRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public IQueryable<Applications> GetAll(UserParams userParams)
        {
            var query = _dataContext.Applications.AsQueryable();
            return query;

        }
        public async Task<Applications> GetById(int id)
        {
            return await _dataContext.Applications.
                Include(x => x.Selections).
                Include(y => y.Comments).
                ThenInclude(y=>y.User).
                FirstOrDefaultAsync(x => x.Id == id);

        }
        public async Task Update(Applications application)
        {
            _dataContext.Applications.Update(application);
            await _dataContext.SaveChangesAsync();

        }
        public async Task Add(Applications app)
        {
            app.Status = Status.Applied;
            _dataContext.Applications.Add(app);
            await _dataContext.SaveChangesAsync();

            app.Status = Status.Applied;
            _dataContext.Applications.Add(app);
            await _dataContext.SaveChangesAsync();
        }
    }
}
