using System;

namespace Test_17_PolesUP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string Line = Console.ReadLine();
            
            int Count = 0;

            for(int i = 0;i<Line.Length;i++)
            {
                if((Line[i] >= 'A' && Line[i]<='z') || (Line[i] <= 'я' && Line[i] >= 'А') || Line[i] == 'ё' || Line[i] == 'Ё')
                {
                    Count++;
                }
            }

            string[] Line_Up = new string[Convert.ToInt32(Math.Pow(2,Count))];
            Line_Up[0] = Line;
            int Count_Line_UP = 1;// колличество элементов в Line_Up

            int[] Number = new int[Line.Length];

            string Time = "";

            bool present = false;


            for (int i = 0; i<Line.Length;i++) // Колличество больших букв
            {
                Number[0] = 0;
                for (int k = 1; k <= i; k++) // 
                {
                    Number[k] = Number[k - 1] + 1;
                }

                
                for (; Number[0] <= Line.Length - i - 1; Number[i]++) // идёт по символам
                {
                    


                    for (int j = 0; j<Line.Length;j++)
                    {
                        for (int k = 0; k <= i; k++) // 
                        {

                            if(Number[k]<=j && Number[k]==j)
                            {
                                if ((Line[j] <= 'Z' && Line[j] >= 'A') || (Line[j] <= 'Я' && Line[j] >= 'А') || Line[j] == 'Ё')
                                    Time += $"{(Line[j])}".ToLower();
                                else if ((Line[j] <= 'z' && Line[j] >= 'a') || (Line[j] <= 'я' && Line[j] >= 'а')|| Line[j] == 'ё')
                                    Time += $"{(Line[j])}".ToUpper();
                                else Time += Line[j];
                                present = true;
                            }
                        }

                        if(present==false)
                        {
                            Time += Line[j];
                        }
                        present = false;
                    }
                    for(int j = 0; j<Count_Line_UP;j++)
                    {
                        if(Time==Line_Up[j])
                        {
                            present = true;
                        }
                    }
                    if(present == false)
                    {
                        Line_Up[Count_Line_UP] = Time;
                        Count_Line_UP += 1;

                    }
                    Time = "";
                    present = false;
                    
                    

                    if (Number[i] >= Line.Length-1)
                    {
                        for (int k = i; k > 0; k--)
                        {
                            
                            if (Number[k] > Line.Length - i + k - 1 ||(k==i&& Number[k] >= Line.Length - i + k - 1))
                            {
                                Number[k - 1] += 1;
                                for (int j = k; j<=i;j++ )
                                {
                                    Number[j] = Number[j - 1] + 1;
                                    if(j==i)
                                    {
                                        Number[j] = Number[j - 1];
                                    }
                                }
                            }
                        }

                    }
                }
            }
            Console.Write("[");
            for (int j = 0; j < Count_Line_UP; j++)
            {
                Console.Write(Line_Up[j]);
                Console.Write(",");
            }
            Console.Write("]");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
