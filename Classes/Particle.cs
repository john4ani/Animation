using System;

namespace Animation
{
    public class Particle : IParticle
    {        
        private int _x, _y;   // Position - px

        private int _vx , _vy; // Velocity - in px.

        private bool _pozitivCharge; //pozitive or negative charge

        private double _charge; // μC

        private double _weight; //Kg

        public Particle(int x, int y, double charge, double weight, bool pozitivCharge)
        {   
            _x = x;
            _y = y;

            _charge = charge;
            _weight = weight;

            _pozitivCharge = pozitivCharge;
        }

        public int X => _x;

        public int Y => _y;

        public double Velocity { get; set; }

        public bool PozitivCharge => _pozitivCharge;

        public double Charge => _charge / 1000000; // from μC in C // (_pozitivCharge? +_charge : - _charge) -?!?

        public double Weight => _weight;

        public void AjustXSpeed(double speed, int time = 1)
        {
            _vx = (int)speed * time;
        }

        public void AjustYSpeed(double speed, int time = 1)
        {
            _vy = (int)speed * time;
        }

        public void UpdateSpeed(IParticle otherParticle, int scale, int time = 1)
        {
            var particlesDistanceInMeters = PhysicsHelper.PixelsToMetersDistance(X, Y, otherParticle.X, otherParticle.Y, scale);
            var force = PhysicsHelper.AttractionForce(Charge, otherParticle.Charge, particlesDistanceInMeters);

            var accelerationFirstParticle = force / Weight;
            Velocity += accelerationFirstParticle * time;
            var alfaAngle1 = Math.Atan((double)(otherParticle.Y - Y) / (otherParticle.X - X)) * (180 / Math.PI);
            
            var vx1 = Velocity * Math.Cos(alfaAngle1);
            var vy1 = Velocity * Math.Sin(alfaAngle1);
            AjustXSpeed(vx1 * scale , time);
            AjustYSpeed(vy1 * scale, time);

            var accelerationSecondParticle = force / otherParticle.Weight;            
            otherParticle.Velocity += accelerationSecondParticle * time;
            var alfaAngle2 = Math.Atan((double)(X - otherParticle.X) / Math.Sqrt(Math.Pow(X - otherParticle.X , 2) + Math.Pow(Y - otherParticle.Y, 2))) * (180 / Math.PI);
                        
            var vx2 = otherParticle.Velocity * Math.Cos(alfaAngle2);
            var vy2 = otherParticle.Velocity * Math.Sin(alfaAngle2);
            otherParticle.AjustXSpeed(vx2 * scale, time);
            otherParticle.AjustYSpeed(vy2 * scale, time);
        }

        public void Move(int roomWidth, int roomHeight, int width, int height)
        {
            _x += _vx;
            if (_x < 10)
            {
                _vx = -_vx;
            }
            else if (_x + width > roomWidth)
            {
                _vx = -_vx;
            }

            _y += _vy;
            if (_y < 10)
            {
                _vy = -_vy;
            }
            else if (_y + height > roomHeight)
            {
                _vy = -_vy;
            }
        }
    }
}
