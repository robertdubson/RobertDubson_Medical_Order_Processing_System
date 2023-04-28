using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public abstract class BaseModel
    {
        
        public int ID { get; protected set; }

        public virtual void setId(int iD) 
        {
            ID = iD;
        }
    }
}
