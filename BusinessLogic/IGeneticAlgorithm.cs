using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IGeneticAlgorithm
    {
        public IPopulation InitializePopulation();

        public double EvaluatePopulation(IPopulation _population);

        public IChromosome Selection(IPopulation _population);

        public IChromosome Crossingover(IPopulation _population); // choose the leader of all the chromosomes on current sample

        public IChromosome Mutation(IPopulation _population);  // randomly change the same product of other supplier 
    }
}
