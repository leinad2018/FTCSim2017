using System;

namespace FTCSimulation
{
    class Program
    {
        private static int[] cubes = new int[12];//{ 1, 2, 1, 2, 2, 1, 2, 1, 1, 2, 1, 2 };
        static void Main(string[] args)
        {
            for (int i = 0; i < cubes.Length; i++)
            {
                cubes[i] = 1;
            }
            int sum = 0;
            do
            {
                Console.Out.WriteLine(cubes[0] + " " + cubes[1] + " " + cubes[2] + " " + cubes[3] + " " + cubes[4] + " " + cubes[5] + " " + cubes[6] + " " + cubes[7] + " " + cubes[8] + " " + cubes[9] + " " + cubes[10] + " " + cubes[11] + " " + sum);
                sum += PlaceGlyphs(true);
            } while (IncreaseSimNum(0));
            Console.Out.WriteLine("Total Options with Horizontal: " + sum);
            Console.Out.WriteLine("Click any key to continue...");
            Console.ReadKey();
            


            for (int i = 0; i < cubes.Length; i++)
            {
                cubes[i] = 1;
            }
            sum = 0;
            do
            {
                Console.Out.WriteLine(cubes[0] + " " + cubes[1] + " " + cubes[2] + " " + cubes[3] + " " + cubes[4] + " " + cubes[5] + " " + cubes[6] + " " + cubes[7] + " " + cubes[8] + " " + cubes[9] + " " + cubes[10] + " " + cubes[11] + " " + sum);
                sum += PlaceGlyphs(false);
            } while (IncreaseSimNum(0));
            Console.Out.WriteLine("Total Options without Horizontal: " + sum);
            Console.Out.WriteLine("Click any key to continue...");
            Console.ReadKey();
        }

        private static bool IncreaseSimNum(int n)
        {
            if (n > 11)
            {
                return false;
            }
            cubes[n]++;
            if (cubes[n] > 2)
            {
                cubes[n] = 1;
                return IncreaseSimNum(n + 1);
            }
            return true;
        }

        public static int PlaceGlyphs(bool useHorz)
        {
            Cryptobox box = new Cryptobox();
            int sum = 0;
            if (useHorz)
            {
                bool vert = true;
                for (int i = 0; i < 2; i++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        sum += PlaceGlyphs(useHorz, c, vert, 0, box);
                    }
                    vert = false;
                }
            }
            else
            {
                bool vert = true;
                for (int c = 0; c < 3; c++)
                {
                    sum += PlaceGlyphs(useHorz, c, vert, 0, box);
                }
            }


            return sum;
        }

        public static int PlaceGlyphs(bool useHorz, int col, bool vertical, int pos, Cryptobox box)
        {
            int i = 0;
            while (i <= 4)
            {
                if (i == 4)
                {
                    return box.checkPatterns();
                }
                if (box.box[col, i] == 0)
                {
                    break;
                }
                i++;
            }
            int sum = 0;
            Cryptobox newBox = box.Clone();
            if (newBox.addGlyphs(col, i, vertical, cubes[pos], cubes[pos + 1]))
            {
                if (useHorz)
                {
                    bool vert = true;
                    for (int q = 0; q < 2; q++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            sum += PlaceGlyphs(useHorz, c, vert, pos + 2, newBox);
                        }
                        vert = false;
                    }
                }
                else
                {
                    bool vert = true;
                    for (int c = 0; c < 3; c++)
                    {
                        sum += PlaceGlyphs(useHorz, c, vert, pos + 2, newBox);
                    }
                }
                
            }

            return sum;
        }
    }
}