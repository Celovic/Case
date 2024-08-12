using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IFormListService
    {
        Task<List<FormList>> GetFormsAsync();
        Task<FormList> GetFormByIdAsync(int id);
        Task CreateFormAsync(FormList form);
    }
}
