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

        public ReceiptSolution GetSolution(int maxIterations=100) 
        {
            ReceiptPopulation receiptPopulation = (ReceiptPopulation)InitializePopulation();
            
            while (maxIterations!=0 & _cityGenes.Count!=0 & _companyGenes.Count!=0 & _factoryGenes.Count!=0) 
            {
                receiptPopulation = (ReceiptPopulation)Crossingover(receiptPopulation);
                receiptPopulation = (ReceiptPopulation)Mutation(receiptPopulation);
                maxIterations--;
            }

            return (ReceiptSolution)receiptPopulation.GetTheBestSolution();
        }

        public IPopulation InitializePopulation(int chromosomeCount=50)
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

                List<int> idsForRemove = new List<int>();

                foreach (CityGene citygene in _cityGenes) 
                {
                    if (_factoryGenes.FindAll(gene => gene.GetFactory().CityID == citygene.GetCity().ID).Count==0) 
                    {
                        idsForRemove.Add(citygene.GetCity().ID);
                    }
                }


                foreach (int id in idsForRemove) 
                {
                    CityGene geneForDeletion = _cityGenes.Find(gene => gene.GetCity().ID==id);
                    _cityGenes.Remove(geneForDeletion);
                }

                int cityIndex = randCity.Next(_cityGenes.Count);

                CityGene selectedCityGene = _cityGenes[cityIndex];

                //if (_cityGenes.Count != 0) 
                //{
                //    _cityGenes.RemoveAt(cityIndex);
                //}

                List<FactoryGene> possibleFactories = _factoryGenes.FindAll(gene => gene.GetFactory().CityID == selectedCityGene.GetCity().ID);

                int factoryIndex = randFactory.Next(possibleFactories.Count);

                FactoryGene selectedFactory = possibleFactories[factoryIndex];

                //if (_factoryGenes.Count != 0) 
                //{
                //    _factoryGenes.Remove(selectedFactory);
                //}

                int companyIndex = randCompany.Next(_companyGenes.Count);

                DeliveryCompanyGene selectedCompany = _companyGenes[companyIndex];

                //if (_companyGenes.Count != 0) 
                //{
                //    _companyGenes.RemoveAt(companyIndex);
                //}

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

            IChromosome firstParent = population.GetTheBestSolution();

            population.RemoveChromosome(firstParent);

            ReceiptPopulation castedpopulation = (ReceiptPopulation)population;

            IChromosome secondParent = population.GetRandomChromosome();

            if (castedpopulation.GetChromosomeWithSameCity((ReceiptSolution)firstParent)!=null) 
            {
                secondParent = castedpopulation.GetChromosomeWithSameCity((ReceiptSolution)firstParent);
            }

            ReceiptSolution child = Mating((ReceiptSolution)firstParent, (ReceiptSolution)secondParent);

            population.AddChromosome(child);

            population.AddChromosome(firstParent);

            population.RemoveChromosome(secondParent);

            return population;
        }

        public IPopulation Mutation(IPopulation population)
        {
            Random rand = new Random();

            int countOfMutants = rand.Next(population.GetChromosomes().Count);

            for (int i=0; i <= countOfMutants; i++) 
            {
                Random randChromosome = new Random();

                int chIndex = randChromosome.Next(population.GetChromosomes().Count);

                ReceiptSolution selectedChromosome = (ReceiptSolution)population.GetChromosomes()[chIndex];

                List<FactoryGene> possibleFactories = _factoryGenes.FindAll(gene => gene.GetFactory().CityID == selectedChromosome.CityGene.GetCity().ID & gene.GetFactory() != selectedChromosome.FactoryGene.GetFactory());

                Random randFactory = new Random();

                int factoryIndex = randFactory.Next(possibleFactories.Count);

                FactoryGene selectedFactoryGene = possibleFactories[factoryIndex];

                List<DeliveryCompanyGene> possibleCompanies = _companyGenes.FindAll(gene => gene.GetCompany() != selectedChromosome.CompanyGene.GetCompany()); 
                
                Random randCompany = new Random();

                int companyIndex = randCompany.Next(possibleCompanies.Count);

                DeliveryCompanyGene selectedCompany = possibleCompanies[companyIndex];

                selectedChromosome.CompanyGene = selectedCompany;

                population.RemoveChromosome(selectedChromosome);

                selectedChromosome.FactoryGene = selectedFactoryGene;

                population.AddChromosome(selectedChromosome);

                //_factoryGenes.RemoveAt(factoryIndex);

                //_companyGenes.RemoveAt(companyIndex);

            }

            return population;
            
        }

    }
}
