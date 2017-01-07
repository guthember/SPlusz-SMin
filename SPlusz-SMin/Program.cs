using System;
using System.IO;

namespace sNulla
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] eletter = new char[20, 20];
            //Random vel = new Random(Guid.NewGuid().GetHashCode());
            int dbA = 0, dbB = 0;
            int mennyi = 0;

            FileStream file = new FileStream("adat.txt", FileMode.Create);
            StreamWriter fileKi = new StreamWriter(file);


            // feltöltés
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Random vel = new Random(Guid.NewGuid().GetHashCode());
                    if (vel.NextDouble() < 0.5)
                    {
                        eletter[i, j] = 'A';
                        dbA++;
                    }
                    else
                    {
                        eletter[i, j] = 'B';
                        dbB++;
                    }
                    //Console.Write(eletter[i, j] + " ");
                }
                //Console.WriteLine();
            }
            //Console.WriteLine(dbA);
            //Console.WriteLine(dbB);
            //Console.WriteLine(dbA / (double)dbB);
            fileKi.WriteLine("{0};{1};{2}", dbA, dbB, dbA / (double)dbB);
            do
            {
                // véletlen egyed 
                Random vel = new Random(Guid.NewGuid().GetHashCode());
                int i = 0, j = 0;
                i = vel.Next(0, 20);
                j = vel.Next(0, 20);
                if (eletter[i, j] == 'A')
                {
                    eletter[i, j] = 'B';
                    dbA--;
                    dbB++;
                }
                else
                {
                    eletter[i, j] = 'A';
                    dbA++;
                    dbB--;
                }

                fileKi.WriteLine("{0};{1}", dbA, dbB);

                //Console.WriteLine(dbA);
                //Console.WriteLine(dbB);
                //Console.WriteLine(dbA / (double)dbB);
                //Console.ReadKey();
                if (dbA == 0 || dbB == 0)
                {
                    break;
                }
                mennyi++;
            } while (mennyi < 1000);

            fileKi.Close();
            file.Close();
            Console.WriteLine("Vége!");
            Console.ReadKey();
        }
    }
}