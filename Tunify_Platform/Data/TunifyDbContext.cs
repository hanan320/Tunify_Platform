using Microsoft.EntityFrameworkCore;
namespace Tunify_Platform.Data
{
    public class TunifyDbContext :DbContext
    {
        public TunifyDbContext (DbContextOptions options) :base(options)
        {

        }

    }
}
