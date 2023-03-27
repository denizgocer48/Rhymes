using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ödev3
{
    class Program
    {
        static void Main(string[] args)
        {
            string poem = "Between the woods and frozen lake,He gives his harness bells and frozen a flake,To ask if there is some lake,Of easy wind and downy flake";
            string[] verse = poem.Split(',');
           
            for (int i = 0; i < verse.Length; i++)
            {
                Console.WriteLine(verse[i]);
            }
            string[] rhyme_by_arrangement = new string[verse.Length];

            string[][] x = new string[verse.Length][];

            for (int i = 0; i < verse.Length; i++)
            {
                x[i] = verse[i].Split(' ');
            }

           

            int count = 0;
            Console.WriteLine(" ");
            for (int v = 0; v < verse.Length - 1; v++)
            {
                for (int o = v+1; o < verse.Length; o++)
                {
                    count = 0;
                    if (x[v][x[v].Length - 1].Length >= x[o][x[o].Length - 1].Length && x[v][x[v].Length - 1] != x[o][x[o].Length - 1])
                    {
                        Console.WriteLine(v.ToString() + "-" + o.ToString());
                        Console.WriteLine("Type: Additional Rhyme");
                        Console.Write("Repetition: ");

                        for (int j = 1; j < x[o][x[o].Length - 1].Length; j++)
                        {

                            if (x[v][x[v].Length - 1][x[v][x[v].Length - 1].Length - j] == x[o][x[o].Length - 1][x[o][x[o].Length - 1].Length - j])
                            {
                                count++;
                            }

                        }
                        for (int i = count; i > 0; i--)
                        {
                            Console.Write(x[v][x[v].Length - 1][x[v][x[v].Length - 1].Length - i]);       
                        }
                        

                        Console.WriteLine(" ");
                        
                    }
                    else if (x[v][x[v].Length - 1].Length <= x[o][x[o].Length - 1].Length && x[v][x[v].Length - 1] != x[o][x[o].Length - 1])
                    {

                        Console.WriteLine(v.ToString() + "-" + o.ToString());
                        Console.WriteLine("Type: Additional rhyme");
                        Console.Write("Repetition: ");


                        for (int j = 1; j < x[v][x[v].Length - 1].Length; j++)
                        {

                            if (x[v][x[v].Length - 1][x[v][x[v].Length - 1].Length - j] == x[o][x[o].Length - 1][x[o][x[o].Length - 1].Length - j])
                            {
                                count++;
                            }
                        }
                        for (int i = count; i > 0; i--)
                        {
                            Console.Write(x[o][x[o].Length - 1][x[o][x[o].Length - 1].Length - i]);
                        }
                        
                        
                    }                    
                    Console.WriteLine(" ");
                    if (x[v][x[v].Length - 1] == x[o][x[o].Length - 1] && x[v][x[v].Length - 2 ] != x[o][x[o].Length - 2])
                    {
                        Console.WriteLine(v.ToString() + "-" + o.ToString());
                        Console.WriteLine("Type: Word Rhyme");                      
                        Console.WriteLine("Repetition: " + x[v][x[v].Length - 1]); 
                    }
                    Console.WriteLine(" ");
                }
            }
            
            for (int  v= 0; v < verse.Length -1; v++)
            {
                for (int o = v+1; o < verse.Length-1; o++)
                {
                    count = 0;
                    if (x[v].Length <= x[o].Length && x[v][x[v].Length - 1] == x[o][x[o].Length - 1] && x[v][x[v].Length - 2] == x[o][x[o].Length - 2])
                    {
                        Console.WriteLine(v.ToString() + "-" + o.ToString());
                        Console.WriteLine("Type: Phrase Rhyme");
                        Console.Write("Repetition: ");
                        for (int k = 1; k < x[v].Length; k++)
                        {
                            if (x[v][x[v].Length - k] == x[o][x[o].Length - k])
                            {
                                count++;
                            }
                        }
                        for (int l = count; l > 0; l--)
                        {
                            Console.Write(x[v][x[v].Length - l] + " ");
                        }
                        Console.WriteLine();

                    }
                    else if (x[v].Length >= x[o].Length && x[v][x[v].Length - 1] == x[o][x[o].Length - 1] && x[v][x[v].Length - 2] == x[o][x[o].Length - 2])
                    {                        
                        Console.WriteLine(v.ToString() + "-" + o.ToString());
                        Console.WriteLine("Type: Phrase Rhyme");
                        Console.Write("Repetition: ");
                        for (int k = 1; k < x[o].Length; k++)
                        {

                            if (x[v][x[v].Length - k] == x[o][x[o].Length - k])
                            {
                                count++;
                            }
                        }
                        for (int l = count; l > 0; l--)
                        {
                            Console.Write(x[o][x[o].Length - l] + " ");
                        }  
                        Console.WriteLine();
                    }
                }
            }


            //for rhymes by arrangement
            bool flag; 
            for (int i = 0; i < verse.GetLength(0); i++)
            {
                flag = false;
                for (int z = 0; 0 < verse[i].Length; z++)
                {                   
                    for (int r = 0; r < verse.GetLength(0); r++)
                    {
                        if (r != i)
                        {
                            if ((verse[i].Length - z) < verse[r].Length && verse[i].Substring(z) == verse[r].Substring(verse[r].Length - (verse[i].Length - z)))
                            {
                                flag = true;
                                rhyme_by_arrangement[i] = verse[i].Substring(z);
                                Console.WriteLine(verse[i].Substring(z));
                                break;
                            }
                        }
                    }
                    if (flag == true)
                        break;
                }
            }
            for (int d = 0; d < rhyme_by_arrangement.GetLength(0); d++)
            {
                if (rhyme_by_arrangement.GetLength(0) % 3 == 0 && d % 3 == 0)
                {
                    if (d + 3 < rhyme_by_arrangement.GetLength(0) && rhyme_by_arrangement[d] == rhyme_by_arrangement[d + 1] && rhyme_by_arrangement[d] == rhyme_by_arrangement[d + 2] && rhyme_by_arrangement[d] != rhyme_by_arrangement[d + 3])
                    {
                        Console.WriteLine("Straight Rhyme");
                    }
                    if (d + 2 < rhyme_by_arrangement.GetLength(0) && rhyme_by_arrangement[d] == rhyme_by_arrangement[d + 2] && rhyme_by_arrangement[d] != rhyme_by_arrangement[d + 1])
                    {
                        Console.WriteLine("Hoarse Rhyme");
                    }
                }
                else if (d % 4 == 0)
                {
                  
                    if (d + 3 < rhyme_by_arrangement.GetLength(0) && rhyme_by_arrangement[d] == rhyme_by_arrangement[d + 1] && rhyme_by_arrangement[d] == rhyme_by_arrangement[d + 2] && rhyme_by_arrangement[d] == rhyme_by_arrangement[d + 3])
                    {
                        Console.WriteLine("Straight Rhyme");
                    }
                 
                    if (d + 3 < rhyme_by_arrangement.GetLength(0) && rhyme_by_arrangement[d] == rhyme_by_arrangement[d + 2] && rhyme_by_arrangement[d + 1] == rhyme_by_arrangement[d + 3] && rhyme_by_arrangement[d + 1] != rhyme_by_arrangement[d])
                    {
                        Console.WriteLine("Alternating Rhyme");
                    }
                   
                    if (d + 3 < rhyme_by_arrangement.GetLength(0) && rhyme_by_arrangement[d] == rhyme_by_arrangement[d + 3] && rhyme_by_arrangement[d + 1] == rhyme_by_arrangement[d + 2] && rhyme_by_arrangement[d + 1] != rhyme_by_arrangement[d])
                    {
                        Console.WriteLine("Winding Rhyme");
                    }
                }  
            }
            Console.ReadKey();

            
        }
    }
}
