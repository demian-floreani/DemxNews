using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Data.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        private RNNContext _entryRepository { get; set; }
        private IDbContextTransaction transaction { get; set; }

        public UnitOfWork(RNNContext context)
        {
            _entryRepository = context;
        }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await _entryRepository.Database.BeginTransactionAsync();
        }

        //public void CommitTransaction()
        //{
        //    _entryRepository.Database.CommitTransaction();
        //}

        public async Task Commit()
        {

            await _entryRepository.SaveChangesAsync();
        }
    }
}
