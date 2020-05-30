

using System;
using System.Collections.Generic;

namespace Animation
{
    public class ParticleFactory : IParticleFactory
    {
        public IParticle CreateParticle(int x, int y, double charge, double weight, bool pozitivCharge)
        {
            return new Particle(x, y, charge, weight, pozitivCharge);
        }

        public IEnumerable<IParticle> CreatePartclesList(int particlesCount, int roomWidth, int roomHeight)
        {
            var random = new Random();

            for (int i = 0; i < particlesCount; i++)
            {
                yield return CreateParticle(x: random.Next(5, roomWidth - 10),
                                                 y: random.Next(5, roomHeight - 10),
                                                 charge: (double)random.Next(8, 12) / 10,
                                                 weight: (double)random.Next(7, 12) / 100,
                                                 pozitivCharge: random.NextDouble() > 0.5);
            }
        }

        public IEnumerable<Particle2> CreatePartcles2List(int particlesCount, int roomWidth, int roomHeight)
        {
            var random = new Random();

            for (int i = 0; i < particlesCount; i++)
            {
                yield return new Particle2(x: random.Next(5, roomWidth - 10),
                                                 y: random.Next(5, roomHeight - 10),
                                                 charge: (double)random.Next(8, 12) / 10,
                                                 weight: (double)random.Next(7, 12) / 100,
                                                 pozitivCharge: random.NextDouble() > 0.5);
            }
        }
    }
}
