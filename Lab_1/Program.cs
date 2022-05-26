using System;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] array = new int[input.Length];
            for (int i = 0; i < input.Length; i++) { array[i] = int.Parse(input[i]); }
            Sequence s = new Sequence(array);

            Console.WriteLine(s.Is_in(5));
            int[] list = new int[] {1, 2, 3, 4, 5 };
            Console.WriteLine(s.Is_equal(list));
            Console.WriteLine(s.Max());
            Console.WriteLine(s.Min());
            s.My_Type();
            Console.WriteLine("Локальнi максимуми: ");
            for (int i = 0; i < s.loc_max().Length; i++) { Console.WriteLine(s.loc_max()[i] + " "); }
            Console.WriteLine("Локальнi мiнiмуми: ");
            for (int i = 0; i < s.loc_min().Length; i++) { Console.WriteLine(s.loc_min()[i] + " "); }
            Console.WriteLine("Екстремуми: ");
            for (int i = 0; i < s.extremes().Length; i++) { Console.WriteLine(s.extremes()[i] + " "); }
            Console.WriteLine("Найбiльша пiдпослiдовнiсть: ");
            for (int i = 0; i < s.max_subsequence().Length; i++) { Console.WriteLine(s.max_subsequence()[i] + " "); }
            Console.WriteLine("Найменша пiдпослiдовнiсть: ");
            for (int i = 0; i < s.min_subsequence().Length; i++) { Console.WriteLine(s.min_subsequence()[i] + " "); }

            s.ToJson("new.json");
            var json_array = Sequence.FromJson("test.json");
            Console.WriteLine("Масив з json-файлу: ");
            for (int i = 0; i < json_array.array.Length; i++) { Console.Write(json_array.array[i] + " "); }
        }
    }
}
