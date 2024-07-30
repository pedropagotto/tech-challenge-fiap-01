using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class ConctactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ConctactRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IList<Contact>> FilterByRegion(string Ddd) => await _context.Contacts.Where(c => c.Ddd == Ddd).ToListAsync();
    }
}
