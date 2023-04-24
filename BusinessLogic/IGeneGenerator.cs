using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IGeneGenerator<E>
    {
        public List<E> GenerateGenes();       
       
    }
}
