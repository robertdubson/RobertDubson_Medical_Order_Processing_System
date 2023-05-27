using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class AlgorithmLogger 
    {
        public List<string> LogList { get; set; }

        public AlgorithmLogger()
        {
            LogList = new List<string>();
        }

        public void Log(string command) 
        {
            LogList.Add(command);
        }

        public string FormChromosomeString(ReceiptSolution solution) 
        {
            return "City: " + solution.CityGene.GetCity().CityName + "; City Rank: " + solution.CityGene.CalculateRank() + "; Factory: " + solution.FactoryGene.GetFactory().ID + "; Factory Rank: " + solution.FactoryGene.CalculateRank() + "; Delivery Company: " + solution.CompanyGene.GetCompany().Name + "; Company Rank:" + solution.CompanyGene.CalculateRank() + "; TOTAL RANK: " + solution.CalculateFitness() + "; ";
        }
    }

    public class ReceiptGeneticAlgorithm : IGeneticAlgorithm
    {
        List<CityGene> _cityGenes;

        List<FactoryGene> _factoryGenes;

        List<DeliveryCompanyGene> _companyGenes;

        MedicalProduct _selectedProduct;

        AlgorithmLogger _logger;

        public AlgorithmLogger Logger { get => _logger; set => _logger = value; }
        
        public ReceiptGeneticAlgorithm(MedicalProduct selectedProduct, CityGeneGenerator cityGeneGenerator, FactoryGeneGenerator factoryGeneGenerator, DeliveryCompanyGeneGenerator deliveryCompanyGeneGenerator)
        {
            _cityGenes = cityGeneGenerator.GenerateGenes();

            _companyGenes = deliveryCompanyGeneGenerator.GenerateGenes();

            _factoryGenes = factoryGeneGenerator.GenerateGenes();

            _selectedProduct = selectedProduct;

            _logger = new AlgorithmLogger();

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

            _logger.Log("SOLUTION: " + _logger.FormChromosomeString((ReceiptSolution)receiptPopulation.GetTheBestSolution()));

            return (ReceiptSolution)receiptPopulation.GetTheBestSolution();
        }

        public IPopulation InitializePopulation(int chromosomeCount=50)
        {
            int solutionsCount = _cityGenes.Count * _factoryGenes.Count * _companyGenes.Count;

            int countOfIterations = chromosomeCount;

            List<IChromosome> initializedChromosomes = new List<IChromosome>();

            _logger.Log("Initial Population: ");

            

            if (solutionsCount < chromosomeCount) 
            {
                countOfIterations = solutionsCount;
            }

            for (int i = 0; i < countOfIterations; i++) 
            {

                string chromosomeString = "Chromosome: ";

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

                chromosomeString += i +"; City: "+selectedCityGene.GetCity().CityName + "; Rank: " + selectedCityGene.CalculateRank();

                //if (_cityGenes.Count != 0) 
                //{
                //    _cityGenes.RemoveAt(cityIndex);
                //}

                List<FactoryGene> possibleFactories = _factoryGenes.FindAll(gene => gene.GetFactory().CityID == selectedCityGene.GetCity().ID);

                int factoryIndex = randFactory.Next(possibleFactories.Count);

                FactoryGene selectedFactory = possibleFactories[factoryIndex];

                chromosomeString += "; Factory" + selectedFactory.GetFactory().ID + "; Rank: " + selectedFactory.CalculateRank();

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

                chromosomeString += "; Delivery Company: " + selectedCompany.GetCompany().Name + "; Rank:" + selectedCompany.CalculateRank() + "; ";

                ReceiptSolution currentSolution = new ReceiptSolution(selectedCityGene, selectedFactory, selectedCompany);


                initializedChromosomes.Add(currentSolution);

                chromosomeString += "TOTAL RANK: " + currentSolution.CalculateFitness() + "; ";

                _logger.Log(chromosomeString);

            }

            return new ReceiptPopulation(initializedChromosomes);

        }


        public ReceiptSolution Mating(ReceiptSolution firstParent, ReceiptSolution secondParent) 
        {
            _logger.Log("Crossing over: ");

            List<ReceiptSolution> potentialChildren = new List<ReceiptSolution>();

            ReceiptSolution child = new ReceiptSolution(firstParent.CityGene, secondParent.FactoryGene, secondParent.CompanyGene);

            _logger.Log("Potential child: City: " + child.CityGene.GetCity().CityName + "; City Rank: " + child.CityGene.CalculateRank() + "; Factory: " + child.FactoryGene.GetFactory().ID + "; Factory Rank: " + child.FactoryGene.CalculateRank() + "; Delivery Company: " + child.CompanyGene.GetCompany().Name + "; Company Rank:" + child.CompanyGene.CalculateRank() + "; TOTAL RANK: " + child.CalculateFitness() + "; ");

            potentialChildren.Add(child);

            child = new ReceiptSolution(secondParent.CityGene, firstParent.FactoryGene, firstParent.CompanyGene);

            _logger.Log("Potential child: City: " + child.CityGene.GetCity().CityName + "; City Rank: " + child.CityGene.CalculateRank() + "; Factory: "+ child.FactoryGene.GetFactory().ID + "; Factory Rank: " + child.FactoryGene.CalculateRank() + "; Delivery Company: " + child.CompanyGene.GetCompany().Name +"; Company Rank:" + child.CompanyGene.CalculateRank() + "; TOTAL RANK: " + child.CalculateFitness() + "; ");

            potentialChildren.Add(child);

            child = new ReceiptSolution(secondParent.CityGene, firstParent.FactoryGene, secondParent.CompanyGene);

            _logger.Log("Potential child: City: " + child.CityGene.GetCity().CityName + "; City Rank: " + child.CityGene.CalculateRank() + "; Factory: " + child.FactoryGene.GetFactory().ID + "; Factory Rank: " + child.FactoryGene.CalculateRank() + "; Delivery Company: " + child.CompanyGene.GetCompany().Name + "; Company Rank:" + child.CompanyGene.CalculateRank() + "; TOTAL RANK: " + child.CalculateFitness() + "; ");

            potentialChildren.Add(child);

            child = new ReceiptSolution(firstParent.CityGene, secondParent.FactoryGene, firstParent.CompanyGene);

            _logger.Log("Potential child: City: " + child.CityGene.GetCity().CityName + "; City Rank: " + child.CityGene.CalculateRank() + "; Factory: " + child.FactoryGene.GetFactory().ID + "; Factory Rank: " + child.FactoryGene.CalculateRank() + "; Delivery Company: " + child.CompanyGene.GetCompany().Name + "; Company Rank:" + child.CompanyGene.CalculateRank() + "; TOTAL RANK: " + child.CalculateFitness() + "; ");

            potentialChildren.Add(child);

            child = new ReceiptSolution(secondParent.CityGene, secondParent.FactoryGene, firstParent.CompanyGene);

            _logger.Log("Potential child: City: " + child.CityGene.GetCity().CityName + "; City Rank: " + child.CityGene.CalculateRank() + "; Factory: " + child.FactoryGene.GetFactory().ID + "; Factory Rank: " + child.FactoryGene.CalculateRank() + "; Delivery Company: " + child.CompanyGene.GetCompany().Name + "; Company Rank:" + child.CompanyGene.CalculateRank() + "; TOTAL RANK: " + child.CalculateFitness() + "; ");

            potentialChildren.Add(child);            

            child = new ReceiptSolution(firstParent.CityGene, firstParent.FactoryGene, secondParent.CompanyGene);

            _logger.Log("Potential child: City: " + child.CityGene.GetCity().CityName + "; City Rank: " + child.CityGene.CalculateRank() + "; Factory: " + child.FactoryGene.GetFactory().ID + "; Factory Rank: " + child.FactoryGene.CalculateRank() + "; Delivery Company: " + child.CompanyGene.GetCompany().Name + "; Company Rank:" + child.CompanyGene.CalculateRank() + "; TOTAL RANK: " + child.CalculateFitness() + "; ");

            potentialChildren.Add(child);

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

            _logger.Log("SELECTED CHILD: City: " + child.CityGene + "; City Rank: " + child.CityGene.CalculateRank() + "; Factory: " + selectedChild.FactoryGene.GetFactory().ID + "; Factory Rank: " + selectedChild.FactoryGene.CalculateRank() + "; Delivery Company: " + selectedChild.CompanyGene.GetCompany().Name + "; Company Rank:" + selectedChild.CompanyGene.CalculateRank() + "; TOTAL RANK: " + selectedChild.CalculateFitness() + "; ");

            _logger.Log("End of Crossingover");
            
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
            _logger.Log("Selection: ");

            IChromosome firstParent = population.GetTheBestSolution();

            _logger.Log("Selected first parent: " + _logger.FormChromosomeString((ReceiptSolution)firstParent));

            population.RemoveChromosome(firstParent);

            ReceiptPopulation castedpopulation = (ReceiptPopulation)population;

            IChromosome secondParent = population.GetRandomChromosome();

            if (castedpopulation.GetChromosomeWithSameCity((ReceiptSolution)firstParent)!=null) 
            {
                secondParent = castedpopulation.GetChromosomeWithSameCity((ReceiptSolution)firstParent);
            }

            _logger.Log("Selected second parent: " + _logger.FormChromosomeString((ReceiptSolution)secondParent));

            ReceiptSolution child = Mating((ReceiptSolution)firstParent, (ReceiptSolution)secondParent);

            population.AddChromosome(child);

            population.AddChromosome(firstParent);

            population.RemoveChromosome(secondParent);

            _logger.Log("Current Population: ");

            int iteration = 0;

            foreach (ReceiptSolution solution in population.GetChromosomes()) 
            {
                _logger.Log("Chromosome " + iteration +" " + _logger.FormChromosomeString(solution));
                iteration++;
            }

            _logger.Log("End of selection.");

            return population;
        }

        public IPopulation Mutation(IPopulation population)
        {
            _logger.Log("Mutation: ");

            Random rand = new Random();

            int countOfMutants = rand.Next(population.GetChromosomes().Count);

            for (int i=0; i <= countOfMutants; i++) 
            {
                Random randChromosome = new Random();

                int chIndex = randChromosome.Next(population.GetChromosomes().Count);

                ReceiptSolution selectedChromosome = (ReceiptSolution)population.GetChromosomes()[chIndex];

                _logger.Log("Chromosome before mutation: " + _logger.FormChromosomeString(selectedChromosome));
                
                List<FactoryGene> possibleFactories = _factoryGenes.FindAll(gene => gene.GetFactory().CityID == selectedChromosome.CityGene.GetCity().ID & gene.GetFactory() != selectedChromosome.FactoryGene.GetFactory());

                if (possibleFactories.Count!=0) {
                    
                    Random randFactory = new Random();

                    int factoryIndex = randFactory.Next(possibleFactories.Count);

                    FactoryGene selectedFactoryGene = possibleFactories[factoryIndex];

                    selectedChromosome.FactoryGene = selectedFactoryGene;
                }

                List<DeliveryCompanyGene> possibleCompanies = _companyGenes.FindAll(gene => gene.GetCompany() != selectedChromosome.CompanyGene.GetCompany());

                if (possibleCompanies.Count!=0) 
                {
                    Random randCompany = new Random();

                    int companyIndex = randCompany.Next(possibleCompanies.Count);

                    DeliveryCompanyGene selectedCompany = possibleCompanies[companyIndex];

                    selectedChromosome.CompanyGene = selectedCompany;

                    population.RemoveChromosome(selectedChromosome);
                }

                _logger.Log("Chromosome after mutation: " + _logger.FormChromosomeString(selectedChromosome));

                population.AddChromosome(selectedChromosome);

                //_factoryGenes.RemoveAt(factoryIndex);

                //_companyGenes.RemoveAt(companyIndex);

            }

            _logger.Log("Current Population: ");

            int iteration = 0;

            foreach (ReceiptSolution solution in population.GetChromosomes())
            {
                _logger.Log("Chromosome " + iteration + " " + _logger.FormChromosomeString(solution));
                iteration++;
            }

            _logger.Log("End of Mutation.");

            return population;
            
        }

    }
}
