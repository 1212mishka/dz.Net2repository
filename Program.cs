using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    static void task1(int[] A, double [,]B)
    {
        Console.WriteLine("Input 5 numbers");
        for (int i = 0; i < A.Length; i++)
        {
            int.TryParse(Console.ReadLine(), out A[i]);
        }
        Random random = new Random();
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                B[i, j] = random.NextDouble();
            }
        }
        Console.WriteLine();

        foreach (var element in A)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();

        int n = 0;
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                Console.Write(B[i, j] + " ");
                if (j == B.GetLength(1) - 1)
                {
                    Console.WriteLine();
                }
            }
        }
        int sumEven = 0;
        double sumOdd = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] % 2 == 0)
            {
                sumEven += A[i];
            }
        }
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                if (B[i, j] % 2 != 0)
                {
                    sumOdd += B[i, j];
                }
            }
        }
        int maxA = 0, minA = 0, sumA = 0, multA;
        double maxB = 0, minB = 0, sumB = 0;
        maxA = A.Max();
        minA = A.Min();
        maxB = B.Cast<double>().Max();
        minB = B.Cast<double>().Min();
        sumA = A.Sum();
        sumB = B.Cast<double>().Sum();
        Console.Write($"maxA {maxA}, maxB {maxB}, minA {minA}, minB {minB}\n,sumA {sumA}, sumB {sumB}, sum even {sumEven}, sum odd {sumOdd}");

    }
    static void task2(int[,]mass)
    {
        Random rnd1 = new Random();
        for (int i = 0; i < mass.GetLength(0); i++)
        {
            for (int j = 0; j < mass.GetLength(1); j++)
            {
                mass[i, j] = rnd1.Next(-100, 101);
            }
        }
        for (int i = 0; i < mass.GetLength(0); i++)
        {
            for (int j = 0; j < mass.GetLength(1); j++)
            {
                Console.Write(mass[i, j] + " ");
                if (j == mass.GetLength(1) - 1)
                {
                    Console.WriteLine();
                }
            }
        }

        int minMass = int.MaxValue, maxMass = int.MinValue, sumMass = 0, indRmin = 0, indCmin = 0, indRmax = 0, indCmax = 0;

        for (int i = 0; i < mass.GetLength(0); i++)
        {
            for (int j = 0; j < mass.GetLength(1); j++)
            {
                if (mass[i, j] < minMass)
                {
                    minMass = mass[i, j];
                    indRmin = i;
                    indCmin = j;
                }
                if (mass[i, j] > maxMass)
                {
                    maxMass = mass[i, j];
                    indRmax = i;
                    indCmax = j;
                }
            }
        }
        int startRow = Math.Min(indRmin, indRmax);
        int endRow = Math.Max(indRmin, indRmax);
        int startCol = Math.Min(indCmin, indCmax);
        int endCol = Math.Max(indCmin, indCmax);

        for (int i = startRow; i < endRow; i++)
        {
            for (int j = startCol; j < endCol; j++)
            {
                sumMass += mass[i, j];
            }
        }

        Console.WriteLine($"min {minMass}, max {maxMass}, sum{sumMass}");
    }
    static int task3(string str)
    {
        string str2 = "";
        char str3 = ' ';
        str2 = str.Replace(" ", "");
        int ind1 = 0;
        int amount = 0;
        for (int i = 0; i < str2.Length; i++)
        {
            if (str2[i] == '+' || str2[i] == '-')
            {
                ind1 = i;
                amount++;
                str3 = str2[i];
            }
        }
        if (amount == 1)
        {
            string num1 = "";
            string num2 = "";

            char[] chars = str2.ToString().ToCharArray();


            int numInt = 0, numInt2 = 0;
            for (int i = 0; i < str2.Length; i++)
            {
                if (i < ind1)
                {
                    num1 += chars[i];
                }
                if (i > ind1)
                {
                    num2 += chars[i];
                }
            }
            int.TryParse(num1, out numInt);
            int.TryParse(num2, out numInt2);

            if (str3 == '+')
            { return numInt + numInt2; }
            else 
            { return numInt - numInt2; }

        }
        else
        {
            Console.WriteLine("Wrong stroka -1");
            return -1;
        }
    }
    static void task4(string text)
    {
        Console.WriteLine("Input word which you want to change");
        string strText = Console.ReadLine();
        string change = " ";
        int amount = 0;
        int index = text.IndexOf(strText);
        for (int i = 0; i < text.Length; i++)
        {
            if (index != -1)
            {
                amount++;
                index = text.IndexOf(strText, index + strText.Length);
            }

        }
        for (int i = 0; i < strText.Length; i++)
        {
            change += '*';
        }
        string res = text.Replace(strText, change);
        Console.WriteLine(res);
        Console.WriteLine($"Статистика изменеых слов {amount}");
    }
    private static void Main(string[] args)
    {

        int a = 5, b = 3, b1 = 4;
        int[] A = new int[a];
        double[,] B = new double[b, b1];
        Console.WriteLine("task1");
        task1(A,B);
        Console.WriteLine("\n\ntask2");
        int[,] mass = new int[5, 5];
        task2(mass);
        Console.WriteLine("\ntask3");
        string str;
        Console.WriteLine("Input arifmatic ");
        str = Console.ReadLine();
        int sum = 0;
        sum = task3(str);
        Console.Write($" sum = {sum}");
        Console.WriteLine("\n\ntask4");
        string text = "To be, or not to be, that is the question, Whether 'tis nobler in the mind to suffer " +
            "The slings and arrows of outrageous fortune, Or to take arms against a sea " +
            "of troubles, And by opposing end them? To die: to sleep; No more; and " +
            "by a sleep to say we end The heart-ache and the thousand natural shocks That flesh is heir to," +
            " 'tis a consummation Devoutly to be wish'd. To die, to sleep";
        task4(text);



    }
}