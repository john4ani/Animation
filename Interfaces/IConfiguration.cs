namespace Animation
{
    public interface IConfiguration
    {
        int FramesIntervalInMiliseconds { get; set; }
        int NumberOfParticles { get; set; }
        int RoomHeightMeters { get; set; }
        int RoomWidthMeters { get; set; }
    }
}