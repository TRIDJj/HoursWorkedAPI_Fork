using HoursWorkedAPI.DBData.Database;

namespace HoursWorkedAPI.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ApplicationContext _context;

        protected BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        protected void Save()
        {
            _context.SaveChanges();
        }
    }
}