using System.Drawing;

namespace Animation
{
    public class Particle2 //: IParticle
    {        
        public Point Location { get; set; }

        public Point NextPosition;

        private int _vx , _vy; // Velocity - in px.

        private bool _pozitivCharge; //pozitive or negative charge

        private double _charge; // μC

        private double _weight; //Kg

        public Particle2(int x, int y, double charge, double weight, bool pozitivCharge)
        {
            Location = new Point(x, y);

            _charge = charge;
            _weight = weight;

            _pozitivCharge = pozitivCharge;
        }

        public int X => Location.X;

        public int Y => Location.Y;
        
        public Vector Velocity;

        public bool PozitivCharge => _pozitivCharge;

        public double Charge => _charge / 1000000; // from μC in C

        public double Weight => _weight;
               
        
    }
}
