using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Animation
{
    public class AnimationManager : IAnimationManager
    {
        private readonly int _numberOfParticles;
        private int _numberOfIterations;

        private readonly int _roomWidth; //px
        private readonly int _roomHeight; //px

        private const int _width = 10; //px
        private const int _height = 10; //px

        public static int Scale = 50; // 1m = 50 px        

        private List<IParticle> _particlesList ;
        private IDataRepository _dataRepository;

        private int _lastSimulationId = 0, _lastParticleId = 0;

        public AnimationManager(IConfiguration configuration) 
            : this(configuration.NumberOfParticles, 20, configuration.RoomWidthMeters * Scale, configuration.RoomHeightMeters * Scale)
        { }

        public AnimationManager(int numberOfParticles, int numberOfIterations, int roomWidth, int roomHeight)
        {
            _numberOfParticles = numberOfParticles;
            _numberOfIterations = numberOfIterations;

            _roomWidth = roomWidth;
            _roomHeight = roomHeight;

            //in a real app this whould be injected
            _dataRepository = new DataRepository(new SimulationResultContext());
            var particleFactory = new ParticleFactory();

            _particlesList = particleFactory.CreatePartclesList(_numberOfParticles, _roomWidth, _roomHeight).ToList();

            var existingSimultationResults = _dataRepository.GetSimulationResults();

            if (existingSimultationResults.Count() > 0)
                _lastSimulationId = _dataRepository.GetSimulationResults().Last().SimulationId;
        }

        public void MoveParticles()
        {
            for (int i = 0; i < _particlesList.Count - 1; i++)
            {
                for (int j = i + 1; j < _particlesList.Count; j++)
                {
                    _particlesList[i].UpdateSpeed(_particlesList[j], Scale);
                    _particlesList[j].Move(_roomWidth, _roomHeight, _width, _height);
                }
                _particlesList[i].Move(_roomWidth, _roomHeight, _width, _height);

                //save this step to DB
                _dataRepository.AddSimulationResult(new SimulationResult {
                    X = _particlesList[i].X,
                    Y = _particlesList[i].Y,
                    SimulationId = ++_lastSimulationId,
                    ParticleId = ++_lastParticleId                    
                });
            }

            //save last particle info too
            _dataRepository.AddSimulationResult(new SimulationResult
            {
                X = _particlesList[_particlesList.Count - 1].X,
                Y = _particlesList[_particlesList.Count - 1].Y,
                SimulationId = ++_lastSimulationId,
                ParticleId = ++_lastParticleId
            });
            _dataRepository.Save();
            //_numberOfIterations--;
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
    }
}
