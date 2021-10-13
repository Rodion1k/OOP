using System;
using System.Collections.Generic;
using LP_Lab05.Exceptions;

namespace LP_Lab05
{
    public static class Check 
    {
        public static bool CheckNeedSoft(List<ProgrammingSoftware> software, ProgrammingSoftware needSoft)
        {
            foreach (var soft in software)
            {
                if (soft == needSoft)
                    return true;
            }
            return false;
        }

        public static bool CheckRAMMemory(Computer<ProgrammingSoftware> pc, float rm)
        {
            if (pc.RAMmemory - (pc.occupiedRAM + rm) <= 0.05f * pc.RAMmemory)
            {
                throw new PcExc(
                    $"недостаточно памяти на жестком диске!\n нужно: {pc.occupiedROM + rm}, имеется: {pc.ROMmemory} ");
            }
            return true;
        }
        
        public static bool CheckNeedSystemSoft(Computer<ProgrammingSoftware> pc, string name)
        {
            foreach (var soft in pc.InstaledSystemSoft)
            {
                if (soft.GetType().Name == name)
                    return true;
            }
            return false;
        }
    }
}