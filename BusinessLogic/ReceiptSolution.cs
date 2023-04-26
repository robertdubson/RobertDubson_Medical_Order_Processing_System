using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class ReceiptSolution : IChromosome
    {

        List<IGene> _genes;
        
        public ReceiptSolution(List<IGene> genes) 
        {

            _genes = genes;

        }

        public double CalculateFitness()
        {

            double sum = 0;

            _genes.ForEach(gene => sum += gene.CalculateRank());

            double fitness = sum / _genes.Count;

            return fitness;
        }

        public List<IGene> GetGenes()
        {
            return _genes;
        }
    }
}
