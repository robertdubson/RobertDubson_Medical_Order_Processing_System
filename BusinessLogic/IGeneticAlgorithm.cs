using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IGeneticAlgorithm
    {
        public IPopulation InitializePopulation(int chromosomeCount);

        public IPopulation Selection(IPopulation population);

        public IPopulation Crossingover(IPopulation population); // choose the leader of all the chromosomes on current sample

        public IPopulation Mutation(IPopulation population);  // randomly change the same product of other supplier 
    }
}
