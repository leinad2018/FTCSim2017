using System;
using System.Collections.Generic;
using System.Text;

namespace FTCSimulation
{
    class Cryptobox
    {
        public int[,] box;
        public Cryptobox()
        {
            box = new int[3,4];
        }

        public Cryptobox(int[,] box)
        {
            this.box = box;
        }

        public bool checkSpace(int x,int y, bool vertical)
        {
            if((x > 2 || y > 3) || box[x,y] != 0)
            {
                return false;
            }

            if (vertical)
            {
                y++;
            }
            else
            {
                x++;
            }

            if ((x > 2 || y > 3) || box[x, y] != 0 || (y - 1 >= 0 && !vertical && box[x,y-1] == 0))
            {
                return false;
            }

            return true;
        }

        public bool addGlyphs(int x, int y, bool vertical, int g1, int g2)
        {
            if (checkSpace(x, y, vertical))
            {
                box[x, y] = g1;
                if (vertical)
                {
                    y++;
                }
                else
                {
                    x++;
                }
                box[x, y] = g2;
                return true;
            }
            return false;
        }

        public int checkPatterns()
        {
            int count = 0;
            foreach(int[,] pattern in Patterns.GetPatterns())
            {
                for(int x = 0; x < 3; x++)
                {
                    for(int y = 0; y < 4; y++)
                    {
                        if (box[x, y] != pattern[x, y])
                        {
                            goto loopEnd;
                        }
                    }
                }
                count++;
                loopEnd: { }
            }

            return count;
        }

        public Cryptobox Clone()
        {
            int[,] toReturn = new int[3, 4];
            for(int x = 0; x < 3; x++)
            {
                for(int y = 0; y < 4; y++)
                {
                    toReturn[x, y] = box[x, y];
                }
            }
            return new Cryptobox(toReturn);
        }
    }
}
