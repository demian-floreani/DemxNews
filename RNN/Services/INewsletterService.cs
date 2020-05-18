using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Services
{
   public interface INewsletterService
    {
        Task AddNewsletter(string email);
    }
}
