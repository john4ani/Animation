using System.Collections.Generic;

namespace Animation
{
    public interface IDataRepository
    {
        IEnumerable<SimulationResult> GetSimulationResults();
        void AddSimulationResult(SimulationResult result);
        void Save();
    }
}