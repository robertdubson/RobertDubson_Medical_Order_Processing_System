using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IGeneticAlgorithm
    {
        public IPopulation InitializePopulation();

        public float EvaluatePopulation(IPopulation _population);

        public IPopulation Crossingover();

        public IPopulation Mutation(); 
    }
}
