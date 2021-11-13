using Microsoft.EntityFrameworkCore;
using ParcelDeliveryBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelDeliveryBE.DAL
{
    public class ParcelRepository : GenericRepository<Parcel>
    {
        private readonly DbSet<Parcel> _dbSet;

        public ParcelRepository(DataContext dataContext)
            : base(dataContext)
        {
            _dbSet = dataContext.Parcels;
        }

        public override async Task<List<Parcel>> GetAllAsync()
        {
            return await _dbSet.OrderByDescending(p => p.WeightInKg).ToListAsync();

        }


    }
}
