using System;
using System.Collections.Generic;

class Program
{

    static IEnumerable<string> RepeatFilter(string input)
    {
        var chars = input.ToCharArray();
        var result = new List<string>();
        GeneratePermutations(chars, 0, result);
        return result;
    }

    static void GeneratePermutations(char[] chars, int index, List<string> result)
    {
        if (index == chars.Length - 1)
        {
            result.Add(new string(chars));
        }
        else
        {
            var usedChar = new HashSet<char>();
            for (int i = index; i < chars.Length; i++)
            {
                if (!usedChar.Contains(chars[i]))
                {
                    usedChar.Add(chars[i]);
                    Swap(chars, index, i);
                    GeneratePermutations(chars, index + 1, result);
                    Swap(chars, index, i);
                }
            }
        }
    }
    static void Swap(char[] chars, int i, int j)
    {
        char temp = chars[i];
        chars[i] = chars[j];
        chars[j] = temp;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Введите строку:");
        string input = Console.ReadLine();
        int count = 0;
        var permutations = RepeatFilter(input);
        foreach (var permutation in permutations)
        {
            Console.WriteLine(permutation);
            count++;
        }
        Console.WriteLine($"Количество комбинаций {count}");
        Console.ReadLine();
    }

}




