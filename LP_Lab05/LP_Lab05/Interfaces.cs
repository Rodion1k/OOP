using  System;
using System.Collections.Generic;
namespace LP_Lab05
{
    public interface ICheckOperations
    {
        bool CheckNeedSoft(List<ProgrammingSoftware> software, ProgrammingSoftware needSoft);
        bool CheckRAMMemory(Computer pc, float rm);
        bool CheckROMMemory(Computer pc, float rm);
        bool CheckNeedSystemSoft(Computer pc, string name);
    }

    public interface IOperationsWithPC
    {
        void Instal(ProgrammingSoftware pSoftware);
        void RunComputer();
        void TurnOffComputer();
    }
}