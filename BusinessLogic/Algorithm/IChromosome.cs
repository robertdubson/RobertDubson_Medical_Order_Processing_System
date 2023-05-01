using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IChromosome
    {
        public double CalculateFitness();

        public List<IGene> GetGenes();

        public void CopyGenes(IChromosome chromosome);
    }
}
