
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Animation
{
    public class SimulationResult
    {
        [Key]
        [Column(Order = 0)]
        public long SimulationResultId { get; set; }

        [Column(Order = 1)]
        public int SimulationId { get; set; }

        [Column(Order = 2)]
        public int ParticleId { get; set; }

        [Column(Order = 3)]
        public int X { get; set; }

        [Column(Order = 4)]
        public int Y { get; set; }

        [Column(Order = 5)]
        public int SpeedX { get; set; }

        [Column(Order = 6)]
        public int SpeedY { get; set; }
    }
}
