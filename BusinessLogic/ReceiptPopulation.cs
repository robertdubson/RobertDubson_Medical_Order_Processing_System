using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class ReceiptPopulation : IPopulation
    {

        List<IChromosome> _chromosomes;

        public ReceiptPopulation(List<IChromosome> chromosomes) 
        {
            _chromosomes = chromosomes;
        }

        public List<IChromosome> GetChromosomes()
        {
            return _chromosomes;
        }
    }
}
