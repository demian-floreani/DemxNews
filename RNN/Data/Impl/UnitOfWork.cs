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
        private RNNContext _context { get; set; }
        private IDbContextTransaction transaction { get; set; }

        public UnitOfWork(RNNContext context)
        {
            _context = context;
        }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        //public void CommitTransaction()
        //{
        //    _entryRepository.Database.CommitTransaction();
        //}

        public async Task Commit()
        {

            await _context.SaveChangesAsync();
        }

        public RNNContext GetContext()
        {
            return _context;
        }
    }
}
