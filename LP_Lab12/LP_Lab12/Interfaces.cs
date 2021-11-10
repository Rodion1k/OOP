using  System;
using System.Collections.Generic;
using LP_Lab12;
namespace LP_Lab05
{
    public interface IOperationsWithPO
    {
        void Starting(Computer<ProgrammingSoftware> pc);
        void Ending(Computer<ProgrammingSoftware> pc);
    }
}