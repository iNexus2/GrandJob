﻿namespace HireMe.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HireMe.Core.Helpers;
    using HireMe.Entities.Enums;
    using HireMe.Entities.Models;

    public interface IResumeService
    {
        Task<OperationResult> Create(string title, string jobTitle, string fileid, int jobId, User user);
        Task<int> CreateAsGuest(string title, string fileid, string email, int jobId, string jobTitle);
        Task<int> CreateFast(string title, string fileid, int jobId, string lastAppliedJob, User user);

        Task<OperationResult> Update(int id, string lastAppliedJob);
        Task<OperationResult> Delete(int id);
        Task<OperationResult> Archive(Resume entity);
        Task<OperationResult> DeleteAllBy(User user);

        IAsyncEnumerable<Resume> GetAllBy(User user);
        IAsyncEnumerable<Resume> GetAllReceived(int jobId, ResumeType type);

        Task<int> GetAllCount(User user);
        IQueryable<Resume> GetAllAsNoTracking();

        Task<bool> AddRating(Resume entity, double rating);
        Task<Resume> GetByIdAsync(int id);
        Task<bool> IsResumeExists(string email, int jobId, string title);

    }
}
