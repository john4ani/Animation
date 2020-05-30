
using System.Data.Entity;

namespace Animation
{
    public class SimulationResultContext : DbContext
    {
        public DbSet<SimulationResult> SimulationResults { get; set; }        
    }
}
