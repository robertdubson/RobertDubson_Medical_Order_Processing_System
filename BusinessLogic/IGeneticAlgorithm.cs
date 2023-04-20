using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IGeneticAlgorithm
    {
        public ISample InitializePopulation();

        public double EvaluatePopulation(ISample _population);

        public ISample Selection(ISample _population);

        public ISample Crossingover(ISample _population); // choose the leader of all the chromosomes on current sample

        public ISample Mutation(ISample _population);  // randomly change the same product of other supplier 
    }
}
