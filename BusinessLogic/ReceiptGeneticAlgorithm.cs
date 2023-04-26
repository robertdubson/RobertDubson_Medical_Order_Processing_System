using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class ReceiptGeneticAlgorithm : IGeneticAlgorithm
    {
        List<CityGene> _cityGenes;

        List<FactoryGene> _factoryGenes;

        List<DeliveryCompanyGene> _companyGenes;

        MedicalProduct _selectedProduct;

        
        public ReceiptGeneticAlgorithm(MedicalProduct selectedProduct, CityGeneGenerator cityGeneGenerator, FactoryGeneGenerator factoryGeneGenerator, DeliveryCompanyGeneGenerator deliveryCompanyGeneGenerator)
        {
            _cityGenes = cityGeneGenerator.GenerateGenes();

            _companyGenes = deliveryCompanyGeneGenerator.GenerateGenes();

            _factoryGenes = factoryGeneGenerator.GenerateGenes();

            _selectedProduct = selectedProduct;
        }

        public IPopulation InitializePopulation(int chromosomeCount=10)
        {
            int solutionsCount = _cityGenes.Count * _factoryGenes.Count * _companyGenes.Count;

            int countOfIterations = chromosomeCount;

            List<IChromosome> initializedChromosomes = new List<IChromosome>();

            if (solutionsCount < chromosomeCount) 
            {
                countOfIterations = solutionsCount;
            }

            for (int i = 0; i < countOfIterations; i++) 
            {               

                Random randCity = new Random();

                Random randFactory = new Random();

                Random randCompany = new Random();

                int cityIndex = randCity.Next(_cityGenes.Count);

                CityGene selectedCityGene = _cityGenes[cityIndex];

                if (_cityGenes.Count != 0) 
                {
                    _cityGenes.RemoveAt(cityIndex);
                }

                int factoryIndex = randFactory.Next(_factoryGenes.Count);

                FactoryGene selectedFactory = _factoryGenes[factoryIndex];

                if (_factoryGenes.Count != 0) 
                {
                    _factoryGenes.RemoveAt(factoryIndex);
                }

                int companyIndex = randCompany.Next(_companyGenes.Count);

                DeliveryCompanyGene selectedCompany = _companyGenes[companyIndex];

                if (_companyGenes.Count != 0) 
                {
                    _companyGenes.RemoveAt(companyIndex);
                }

                initializedChromosomes.Add(new ReceiptSolution(selectedCityGene, selectedFactory, selectedCompany));

            }

            return new ReceiptPopulation(initializedChromosomes);

        }


        public ReceiptSolution Mating(ReceiptSolution firstParent, ReceiptSolution secondParent) 
        {
            List<ReceiptSolution> potentialChildren = new List<ReceiptSolution>();

            potentialChildren.Add(new ReceiptSolution(firstParent.CityGene, secondParent.FactoryGene, secondParent.CompanyGene));

            potentialChildren.Add(new ReceiptSolution(secondParent.CityGene, firstParent.FactoryGene, firstParent.CompanyGene));

            potentialChildren.Add(new ReceiptSolution(secondParent.CityGene, firstParent.FactoryGene, secondParent.CompanyGene));

            potentialChildren.Add(new ReceiptSolution(firstParent.CityGene, secondParent.FactoryGene, firstParent.CompanyGene));

            potentialChildren.Add(new ReceiptSolution(secondParent.CityGene, secondParent.FactoryGene, firstParent.CompanyGene));

            potentialChildren.Add(new ReceiptSolution(firstParent.CityGene, firstParent.FactoryGene, secondParent.CompanyGene));

            Random rand = new Random();

            int index = rand.Next(potentialChildren.Count);

            ReceiptSolution selectedChild = potentialChildren[index];

            foreach (ReceiptSolution rs in potentialChildren) 
            {
                if (selectedChild.CalculateFitness() < rs.CalculateFitness()) 
                {
                    selectedChild = rs;

                }
            }

            return selectedChild;
        }

        public IChromosome Mating(IChromosome firstParent, IChromosome secondParent) 
        {

            int iterationNumber = 0;

            List<IChromosome> potentialChildren = new List<IChromosome>();
            
            foreach (IGene fgene in firstParent.GetGenes()) 
            {
                foreach (IGene sgene in secondParent.GetGenes()) 
                {
                    List<IGene> newGenes = secondParent.GetGenes();

                    newGenes.Add(fgene);

                    newGenes.Remove(sgene);

                    potentialChildren.Add(new ReceiptSolution(newGenes));

                    newGenes = firstParent.GetGenes();

                    newGenes.Remove(fgene);

                    newGenes.Add(sgene);

                    potentialChildren.Add(new ReceiptSolution(newGenes));

                    iterationNumber++;
                }
            }

            Random rand = new Random();

            int index = rand.Next();

            IChromosome selectedChild = potentialChildren[index];

            foreach (IChromosome ch in potentialChildren) 
            {
                if (selectedChild.CalculateFitness() < ch.CalculateFitness()) 
                {
                    selectedChild = ch;
                }
            }

            return selectedChild;
        }

        public IPopulation Crossingover(IPopulation population)
        {
            throw new NotImplementedException();
        }

        public IPopulation Mutation(IPopulation population)
        {
            throw new NotImplementedException();
        }

        public IPopulation Selection(IPopulation population)
        {
            throw new NotImplementedException();
        }
    }
}
