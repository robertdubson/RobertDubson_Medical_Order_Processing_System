using System;
using System.Collections.Generic;
using System.Text;

namespace Mappers
{
    public interface IMapper<E, D>
    {
        public E FromDomainToEntity(D example);

        public D FromEntityToDomain(E example);

        public E NewExample(D example);
    }
}
