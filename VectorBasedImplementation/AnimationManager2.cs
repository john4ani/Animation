using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Animation
{
    public class AnimationManager2 : IAnimationManager
    {
        private readonly int _numberOfParticles;
        private int _numberOfIterations;

        private readonly int _roomWidth; //px
        private readonly int _roomHeight; //px

        private const int _width = 10; //px
        private const int _height = 10; //px

        public static int Scale = 50; // 1m = 50 px        

        private List<Particle2> _particlesList ;
        private IDataRepository _dataRepository;

        private int _lastSimulationId = 0, _lastParticleId = 0;

        public AnimationManager2(IConfiguration configuration) 
            : this(configuration.NumberOfParticles, 20, configuration.RoomWidthMeters * Scale, configuration.RoomHeightMeters * Scale)
        { }

        public AnimationManager2(int numberOfParticles, int numberOfIterations, int roomWidth, int roomHeight)
        {
            _numberOfParticles = numberOfParticles;
            _numberOfIterations = numberOfIterations;

            _roomWidth = roomWidth;
            _roomHeight = roomHeight;

            //in a real app this whould be injected
            _dataRepository = new DataRepository(new SimulationResultContext());
            var particleFactory = new ParticleFactory();

            _particlesList = particleFactory.CreatePartcles2List(_numberOfParticles, _roomWidth, _roomHeight).ToList();

            var existingSimultationResults = _dataRepository.GetSimulationResults();

            if (existingSimultationResults.Count() > 0)
                _lastSimulationId = _dataRepository.GetSimulationResults().Last().SimulationId;
        }

        public void MoveParticles()
        {
            foreach(var currentParticle in _particlesList)
            {
                // express the node's current position as a vector, relative to the origin
                Vector currentPosition = new Vector(CalcDistance(Point.Empty, currentParticle.Location), GetBearingAngle(Point.Empty, currentParticle.Location));
                Vector netForce = new Vector(0, 0);

                foreach (var otherParticle in _particlesList)
                {
                    if (otherParticle != currentParticle)
                    {
                        var atract = currentParticle.PozitivCharge != otherParticle.PozitivCharge;
                        netForce += CalcForce(currentParticle.Location, otherParticle.Location, atract);
                    }
                }

                // apply net force to node velocity
                currentParticle.Velocity = currentParticle.Velocity + netForce; // * damping;

                // apply velocity to node position
                currentParticle.Location = (currentPosition + currentParticle.Velocity).ToPoint();

                var speed = currentParticle.Velocity.ToPoint();
                //save this step to DB
                _dataRepository.AddSimulationResult(new SimulationResult
                {
                    X = currentParticle.X,
                    Y = currentParticle.Y,
                    SimulationId = ++_lastSimulationId,
                    ParticleId = ++_lastParticleId,
                    SpeedX = speed.X,
                    SpeedY = speed.Y
                });
            }

            _dataRepository.Save();
            _numberOfIterations--;
        }

        public void DrawOn(Graphics graphics)
        {
            foreach (var particle in _particlesList)
            {
                graphics.FillEllipse(particle.PozitivCharge ? Brushes.Red : Brushes.Blue, particle.X, particle.Y, _width, _height);
                graphics.DrawEllipse(Pens.Black, particle.X, particle.Y, _width, _height);
            }
        }

        public bool AnimationEnded()
        {
            return _numberOfIterations <= 0;
        }

        /// <summary>
        /// Calculates the distance between two points.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        /// <returns>The pixel distance between the two points.</returns>
        public static int CalcDistance(Point a, Point b)
        {
            double xDist = (a.X - b.X);
            double yDist = (a.Y - b.Y);
            return (int)Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2));
        }

        /// <summary>
        /// Calculates the bearing angle from one point to another.
        /// </summary>
        /// <param name="start">The node that the angle is measured from.</param>
        /// <param name="end">The node that creates the angle.</param>
        /// <returns>The bearing angle, in degrees.</returns>
        private double GetBearingAngle(Point start, Point end)
        {
            Point half = new Point(start.X + ((end.X - start.X) / 2), start.Y + ((end.Y - start.Y) / 2));

            double diffX = (double)(half.X - start.X);
            double diffY = (double)(half.Y - start.Y);

            if (diffX == 0) diffX = 0.001;
            if (diffY == 0) diffY = 0.001;

            double angle;
            if (Math.Abs(diffX) > Math.Abs(diffY))
            {
                angle = Math.Tanh(diffY / diffX) * (180.0 / Math.PI);
                if (((diffX < 0) && (diffY > 0)) || ((diffX < 0) && (diffY < 0))) angle += 180;
            }
            else
            {
                angle = Math.Tanh(diffX / diffY) * (180.0 / Math.PI);
                if (((diffY < 0) && (diffX > 0)) || ((diffY < 0) && (diffX < 0))) angle += 180;
                angle = (180 - (angle + 90));
            }

            return angle;
        }

        private const double REPULSION_CONSTANT = 10000;

        /// <summary>
        /// Calculates the repulsion force between any two nodes in the diagram space.
        /// </summary>
        /// <param name="x">The node that the force is acting on.</param>
        /// <param name="y">The node creating the force.</param>
        /// <returns>A Vector representing the repulsion force.</returns>
        private Vector CalcForce(Point x, Point y, bool atract)
        {
            int proximity = Math.Max(CalcDistance(x, y), 1);

            // Coulomb's Law: F = k(Qq/r^2)
            double force = atract ? (REPULSION_CONSTANT / Math.Pow(proximity, 2)) : -(REPULSION_CONSTANT / Math.Pow(proximity, 2));
            double angle = GetBearingAngle(x, y);

            return new Vector(force, angle);
        }
    }
}
