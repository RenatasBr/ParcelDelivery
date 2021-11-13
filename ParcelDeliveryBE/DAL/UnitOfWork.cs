using System.Threading.Tasks;

namespace ParcelDeliveryBE.DAL
{
    public class UnitOfWork
    {
        private readonly DataContext _context;

        public PostMachineRepository PostMachines { get; }
        public ParcelRepository Parcels { get; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            PostMachines = new PostMachineRepository(_context);
            Parcels = new ParcelRepository(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
