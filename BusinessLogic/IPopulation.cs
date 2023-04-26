using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IPopulation
    {
        public List<IChromosome> GetChromosomes();

        public IChromosome GetTheBestSolution();
    }
}
