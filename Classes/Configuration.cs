

namespace Animation
{
    public class Configuration : IConfiguration
    {
        public int NumberOfParticles { get; set; }

        public int FramesIntervalInMiliseconds { get; set; }

        public int RoomWidthMeters { get; set; }

        public int RoomHeightMeters { get; set; }
    }
}
