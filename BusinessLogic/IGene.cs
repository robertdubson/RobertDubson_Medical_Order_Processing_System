﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IGene
    {
        public double CalculateRank();

        public bool IsSelected();

        public void SelectGene();

        public void UnselectGene();

    }
}
