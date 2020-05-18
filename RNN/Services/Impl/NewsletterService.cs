using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using RNN.Data;
using RNN.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Services.Impl
{
    public class NewsletterService : INewsletterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INewsletterRepository _repo;

        public NewsletterService(
            IUnitOfWork unitOfWork,
            INewsletterRepository repo)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task AddNewsletter(string email)
        {
            if (_repo
                .FindBy(e => e.Email.Equals(email))
                .FirstOrDefault() == null)
            {
                await _repo.Create(new Models.Newsletter()
                {
                    Email = email,
                    AddedOn = DateTime.Now
                });

                await _unitOfWork.Commit();
            }
        }
    }
}
