using DataLayer.Context;
using DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.IServices;

namespace ServiceLayer.Services
{
    public class FormListService : IFormListService
    {
        private readonly AppDbContext _context;

        public FormListService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<FormList>> GetFormsAsync()
        {
            return await _context.Forms.ToListAsync();
        }

        public async Task<FormList> GetFormByIdAsync(int id)
        {
            var form = await _context.Forms.FirstOrDefaultAsync(x => x.Id == id);
            return await _context.Forms.Include(x => x.FormFields).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateFormAsync(FormList form)
        {
            _context.Forms.Add(form);
            await _context.SaveChangesAsync();
        }
    }
}
