using System;
using System.Collections.Generic;
using System.Text;

namespace FTCSimulation
{
    class Patterns
    {
        public static readonly int[,] Pattern1 = { { 1, 2, 1, 2 }, { 2, 1, 2, 1 }, { 1, 2, 1, 2 } };
        public static readonly int[,] Pattern2 = { { 2, 1, 2, 1 }, { 1, 2, 1, 2 }, { 2, 1, 2, 1 } };
        public static readonly int[,] Pattern3 = { { 2, 1, 1, 2 }, { 1, 2, 2, 1 }, { 2, 1, 1, 2 } };
        public static readonly int[,] Pattern4 = { { 1, 2, 2, 1 }, { 2, 1, 1, 2 }, { 1, 2, 2, 1 } };
        public static readonly int[,] Pattern5 = { { 2, 2, 1, 1 }, { 2, 1, 1, 2 }, { 1, 1, 2, 2 } };
        public static readonly int[,] Pattern6 = { { 1, 1, 2, 2 }, { 1, 2, 2, 1 }, { 2, 2, 1, 1 } };

        public static List<int[,]> GetPatterns()
        {
            List<int[,]> patterns = new List<int[,]>();
            patterns.Add(Pattern1);
            patterns.Add(Pattern2);
            patterns.Add(Pattern3);
            patterns.Add(Pattern4);
            patterns.Add(Pattern5);
            patterns.Add(Pattern6);

            return patterns;
        }
    }
}
