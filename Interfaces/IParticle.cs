using System.Drawing;

namespace Animation
{
    public interface IParticle
    {
        int X { get; }
        int Y { get; }

        //Point Location { get; }

        double Velocity { get; set; }

        bool PozitivCharge { get; }

        double Charge { get; }        
        double Weight { get; }
        

        void UpdateSpeed(IParticle otherParticle, int scale, int time = 1);
        void Move(int roomWidth, int roomHeight, int width, int height);

        void AjustXSpeed(double secondParticleXAcceleration, int time = 1);
        void AjustYSpeed(double secondParticleYAcceleration, int time = 1);
    }
}