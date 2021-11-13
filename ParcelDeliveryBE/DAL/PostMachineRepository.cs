using Microsoft.EntityFrameworkCore;
using ParcelDeliveryBE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelDeliveryBE.DAL
{
    public class PostMachineRepository : GenericRepository<PostMachine>
    {
        private readonly DbSet<PostMachine> _dbSet;

        public PostMachineRepository(DataContext dataContext)
            : base(dataContext)
        {
            _dbSet = dataContext.PostMachines;
        }

        public override async Task<List<PostMachine>> GetAllAsync()
        {
            return await _dbSet.OrderBy(pm => pm.City)
                .Include(pm => pm.Parcel)
                .ToListAsync();

        }

    }
}

