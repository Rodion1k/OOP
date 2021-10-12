using  System;
using System.Collections.Generic;
namespace LP_Lab05
{
    public interface IOperationsWithPO
    {
        void Starting(Computer<ProgrammingSoftware> pc);
        void Ending(Computer<ProgrammingSoftware> pc);
    }
}