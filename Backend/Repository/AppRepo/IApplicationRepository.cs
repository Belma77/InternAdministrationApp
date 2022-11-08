using Backend.Dtos;
using Backend.Helpers;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Repository.AppRepo
{
    public interface IApplicationRepository
    {
        public IQueryable<Applications> GetAll(UserParams userParams);
        Task<Applications> GetById(int id);
        Task Update(Applications application);
        Task Add(Applications app);
    }
}
