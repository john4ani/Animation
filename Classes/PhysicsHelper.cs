
using System;

namespace Animation
{
    public class PhysicsHelper
    {
        private static readonly double Ke = 9 * Math.Pow(10, 9);

        public static double PixelsToMetersDistance(int x1, int y1, int x2, int y2, int scale) =>
            Math.Sqrt((Math.Pow(Math.Abs(x1 - x2), 2) + Math.Pow(Math.Abs(y1 - y2), 2))) / scale;

        public static double AttractionForce(double firstParticleCharge, double secondParticleCharge, double distaceInMeters) => 
            (Ke * firstParticleCharge * secondParticleCharge) / Math.Pow(distaceInMeters, 2);
    }
}
