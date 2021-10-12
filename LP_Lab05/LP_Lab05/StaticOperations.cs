using System;
using System.Collections.Generic;

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
                throw new Exception("недостаточно ОЗУ!!!\n");
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