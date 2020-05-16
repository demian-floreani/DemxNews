using Microsoft.EntityFrameworkCore.Storage;
using RNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Data
{
    public interface IUnitOfWork
    {
        Task<IDbContextTransaction> BeginTransaction();
        Task Commit();
        RNNContext GetContext();
    }
}
