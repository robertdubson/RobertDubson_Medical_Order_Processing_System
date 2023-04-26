using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class ReceiptSolution : IChromosome
    {

        List<IGene> _genes;

        public CityGene CityGene { get; }

        public FactoryGene FactoryGene { get; }

        public DeliveryCompanyGene CompanyGene { get; }
   
        public ReceiptSolution(List<IGene> genes) 
        {

            _genes = genes;

        }

        public ReceiptSolution(CityGene cityGene, FactoryGene factoryGene, DeliveryCompanyGene companyGene) 
        {
            CityGene = cityGene;

            FactoryGene = factoryGene;

            CompanyGene = companyGene;

            _genes = new List<IGene>();

            _genes.Add(cityGene);

            _genes.Add(factoryGene);

            _genes.Add(companyGene);

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
