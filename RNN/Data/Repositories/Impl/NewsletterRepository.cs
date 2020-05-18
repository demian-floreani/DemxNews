using RNN.Data.Impl;
using RNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Data.Repositories.Impl
{
    public class NewsletterRepository : Repository<Newsletter>, INewsletterRepository
    {
        public NewsletterRepository(IUnitOfWork uow) : base(uow) { }
    }
}
