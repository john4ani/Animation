

using System;
using System.Collections.Generic;
using System.Linq;

namespace Animation
{
    public class DataRepository : IDataRepository, IDisposable
    {
        SimulationResultContext _dbContext;

        public DataRepository(SimulationResultContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<SimulationResult> GetSimulationResults()
        {
            return _dbContext.SimulationResults.OrderBy((element) => element.SimulationResultId).ToList();
        }

        public void AddSimulationResult(SimulationResult result)
        {
            _dbContext.SimulationResults.Add(result);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        #region IDisposable        

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
