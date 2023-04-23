﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IChromosomeGenerator
    {
        public List<IChromosome> GenerateChromosomes();
    }
}
