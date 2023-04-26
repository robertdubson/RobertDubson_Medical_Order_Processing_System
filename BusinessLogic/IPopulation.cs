using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IPopulation
    {
        public List<IChromosome> GetChromosomes();

        public IChromosome GetTheBestSolution();

        public void RemoveChromosome(IChromosome chromosome);

        public void AddChromosome(IChromosome chromosome);

        public IChromosome GetRandomChromosome();        
        
    }
}
