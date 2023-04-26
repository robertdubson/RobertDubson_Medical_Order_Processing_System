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

        public IChromosome GetTheBestSolution() 
        {
            var randomIndex = new Random();

            int index = randomIndex.Next(_chromosomes.Count);

            IChromosome theBestSolution = _chromosomes[index];

            if (_chromosomes.Count != 0) 
            {
                foreach (IChromosome chr in _chromosomes)
                {
                    if (chr.CalculateFitness() > theBestSolution.CalculateFitness())
                    {
                        theBestSolution = chr;
                    }
                }

            }

            return theBestSolution;
        }
    }
}
