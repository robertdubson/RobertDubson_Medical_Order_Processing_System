using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IGeneticAlgorithm
    {
        public IChromosome InitializePopulation();

        public double EvaluatePopulation(IChromosome _population);

        public IChromosome Selection(IChromosome _population);

        public IChromosome Crossingover(IChromosome _population); // choose the leader of all the chromosomes on current sample

        public IChromosome Mutation(IChromosome _population);  // randomly change the same product of other supplier 
    }
}
