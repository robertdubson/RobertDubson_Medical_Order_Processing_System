using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace BusinessLogic
{
    public class ReceiptPopulation : IPopulation
    {

        List<IChromosome> _chromosomes;

        public ReceiptPopulation(List<IChromosome> chromosomes) 
        {
            _chromosomes = chromosomes;
        }

        public void AddChromosome(IChromosome chromosome)
        {
            _chromosomes.Add(chromosome);
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

        public void RemoveChromosome(IChromosome chromosome)
        {
            _chromosomes.Remove(chromosome);
        }

        public ReceiptSolution GetChromosomeWithSameCity(ReceiptSolution bestChromosome) 
        {
            List<ReceiptSolution> candidates = new List<ReceiptSolution>();

            candidates = _chromosomes.ToList().Select(ch => (ReceiptSolution)ch).ToList().FindAll(ch => ch.CityGene == bestChromosome.CityGene);

            if (candidates.Count != 0)
            {
                var randomIndex = new Random();

                int index = randomIndex.Next(candidates.Count);

                ReceiptSolution bestCandidate = candidates[index];

                foreach (ReceiptSolution solution in candidates)
                {
                    if (bestCandidate.CalculateFitness() < solution.CalculateFitness())
                    {
                        bestCandidate = solution;
                    }
                }

                return bestCandidate;
            }
            else 
            {
                return null;
            }
            
        }

        public IChromosome GetRandomChromosome() 
        {
            Random rand = new Random();

            int index = rand.Next(_chromosomes.Count);

            return _chromosomes[index];
        }

        
    }
}
