using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {

            int i, j, l, ok = 0, p, k = 0;
            string[][] array = new string[26][];
            string buffX, buff1;
            string buffY, buff2;
            if (args.Length == 0)
                Console.Write("Command line nu are argumente");
            string arrayOfString = "abcdefghijklmnopqrstuvwxyz";
            for (i = 0; i < arrayOfString.Length; i++)
            {
                ok = 0;
                for (j = 0; j < args.Length; j++)
                {
                    buffX = args[j];
                    buff1 = args[j].ToLower();
                    if (arrayOfString[i] == buff1[0])
                        ok++;
                }
                if (ok > 0)
                {
                    array[k] = new string[ok];
                    p = 0;
                    for (l = 0; l < args.Length; l++)
                    {
                        buffY = args[l];
                        buff2 = args[l].ToLower();
                        if (arrayOfString[i] == buff2[0])
                        {
                            array[k][p] = args[l];
                            p++;
                        }
                    }
                    k++;
                }


            }
            Console.WriteLine("--Cuvintele sortate:--"); 
            for (i = 0; i < k; i++)
            {

                for (j = 0; j < array[i].Length; j++)
                    
                    Console.Write("{0} ", array[i][j]);
                Console.Write("\n");
            }
            Console.ReadKey();
        }
    }
}

