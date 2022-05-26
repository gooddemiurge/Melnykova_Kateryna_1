using System;
using Newtonsoft.Json;
using System.IO;

public class Sequence
{
	public int[] array;
	public Sequence(int[] numbers)
	{
		array = numbers;
	}

	public bool Is_in(int n) 
	{
		for (int i = 0; i < array.Length; i++) 
		{
			if (array[i] == n) 
			{
				return true;
			}
		}
		return false;
	}

	public bool Is_equal(int[] list)
	{
		if (array.Length != list.Length) { return false; }
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != list[i])
			{
				return false;
			}
		}
		return true;
	}

	public int Max() 
	{
		int max = array[0];
		for (int i = 1; i < array.Length; i++) 
		{
			if (max < array[i]) 
			{
				max = array[i];
			}
		}
		return max;
	}

	public int Min()
	{
		int min = array[0];
		for (int i = 1; i < array.Length; i++)
		{
			if (min > array[i])
			{
				min = array[i];
			}
		}
		return min;
	}

	public void My_Type() 
	{
		bool is_descending = true; // спадна послідовність
		bool is_ascending = true; // зростаюча послідовність
		bool is_notdes = true; // неспадна послідовність
		bool is_notasc = true; // незростаюча послідовність
		for (int i = 0; i < array.Length-1; i++)
		{
			if (array[i] <= array[i+1])
			{
				is_descending = false;
			}

			if(array[i] >= array[i + 1]) 
			{
				is_ascending = false;
			}

			if (array[i] < array[i + 1])
			{
				is_notdes = false;
			}

			if (array[i] > array[i + 1])
			{
				is_notasc = false;
			}
		}

		if (is_descending) { Console.WriteLine("Спадна послiдовнiсть"); }
		if (is_ascending) { Console.WriteLine("Зростаюча послiдовнiсть"); }
		if (is_notasc & is_ascending != true) { Console.WriteLine("Неспадна послiдовнiсть"); }
		if (is_notdes & is_descending != true) { Console.WriteLine("Незростаюча послiдовнiсть"); }

		bool is_arithmetic = true; // неспадна послідовність
		bool is_geometric = true; // незростаюча послідовність
		if (array.Length >= 2)
		{
			int d = array[1] - array[0];
			int q = array[1] / array[0];
			for (int i = 1; i < array.Length - 1; i++)
			{
				if (array[i+1] - array[i] != d)
				{
					is_arithmetic = false;
				}

				if (array[i] != 0)
				{
					if (array[i + 1] / array[i] != q)
					{
						is_geometric = false;
					}
				}
				else { is_geometric = false; }
			}
		}
		if (is_arithmetic) { Console.WriteLine("Арифметична прогресiя"); }
		if (is_geometric) { Console.WriteLine("Геометрична прогресiя"); }
	}

	public int[] loc_max() 
	{
		string numbers = "";

		if (array.Length == 1) { numbers += array[0] + " "; }
		if (array.Length >= 2) 
		{
			if (array[0] > array[1]) { numbers += array[0] + " "; }
			if (array[^1] > array[^2]) { numbers += array[^1] + " "; }
		} 
		if (array.Length >= 3)
		{
			for (int i = 1; i < array.Length - 1; i++)
			{
				if (array[i] > array[i - 1] & array[i] > array[i + 1])
				{
					numbers += array[i] + " ";
				}
			}
		}

		string[] s = numbers.Split(' ');
		int[] a = new int[s.Length-1];
		for (int i = 0; i < s.Length-1; i++) { a[i] = int.Parse(s[i]); }

		return a;
	}

	public int[] loc_min()
	{
		string numbers = "";

		if (array.Length == 1) { numbers += array[0] + " "; }
		if (array.Length >= 2)
		{
			if (array[0] < array[1]) { numbers += array[0] + " "; }
			if (array[^1] < array[^2]) { numbers += array[^1] + " "; }
		}
		if (array.Length >= 3)
		{
			for (int i = 1; i < array.Length - 1; i++)
			{
				if (array[i] < array[i - 1] & array[i] < array[i + 1])
				{
					numbers += array[i] + " ";
				}
			}
		}

		string[] s = numbers.Split(' ');
		int[] a = new int[s.Length - 1];
		for (int i = 0; i < s.Length - 1; i++) { a[i] = int.Parse(s[i]); }

		return a;
	}

	public int[] extremes() 
	{
		string numbers = "";

		if (array.Length == 1) { numbers += array[0] + " "; }
		if (array.Length >= 2)
		{
			if (array[0] != array[1]) { numbers += array[0] + " "; }
			for (int i = 1; i < array.Length - 1; i++)
			{
				if ((array[i] < array[i - 1] & array[i] < array[i + 1]) || (array[i] > array[i - 1] & array[i] > array[i + 1]))
				{
					numbers += array[i] + " ";
				}
			}
			if (array[^1] != array[^2]) { numbers += array[^1] + " "; }
		}

		string[] s = numbers.Split(' ');
		int[] a = new int[s.Length - 1];
		for (int i = 0; i < s.Length - 1; i++) { a[i] = int.Parse(s[i]); }

		return a;
	}


	public int[] max_subsequence() 
	{
		string sub = array[0] + " ";
		string max_sub = "";
		int len = 1;
		int max_len = 0;
		for (int i = 1; i < array.Length; i++) 
		{
			sub += array[i] + " ";
			len += 1;

			if (i == array.Length - 1)
			{
				len += 1;
				if (len >= max_len)
				{
					max_len = len;
					max_sub = sub;
				}
			}
			else
			{
				if ((array[i] > array[i - 1] && array[i] > array[i + 1]) || (array[i] < array[i - 1] && array[i] < array[i + 1]))
				{
					if (len >= max_len)
					{
						max_len = len;
						max_sub = sub;
					}
					sub = array[i] + " ";
					len = 0;
				}
			}
		}

		string[] s = max_sub.Split(' ');
		int[] a = new int[s.Length - 1];
		for (int i = 0; i < s.Length - 1; i++) { a[i] = int.Parse(s[i]); }

		return a;
	}

	public int[] min_subsequence()
	{
		string sub = array[0] + " ";
		string min_sub = "";
		int len = 1;
		int min_len = array.Length;
		for (int i = 1; i < array.Length; i++)
		{
			sub += array[i] + " ";
			len += 1;

			if (i == array.Length - 1)
			{
				len += 1;
				if (len <= min_len)
				{
					min_len = len;
					min_sub = sub;
				}
			}
			else
			{
				if ((array[i] > array[i - 1] && array[i + 1] < array[i]) || (array[i] < array[i - 1] && array[i + 1] > array[i]))
				{
					if (len <= min_len)
					{
						min_len = len;
						min_sub = sub;
					}
					sub = array[i] + " ";
					len = 0;
				}
			}
		}

		string[] s = min_sub.Split(' ');
		int[] a = new int[s.Length - 1];
		for (int i = 0; i < s.Length - 1; i++) { a[i] = int.Parse(s[i]); }

		return a;
	}


	public void ToJson(string filePath)
	{
		string j = JsonConvert.SerializeObject(this);

		File.WriteAllText(filePath, j);
	}

	public static Sequence FromJson(string filePath)
	{
		return JsonConvert.DeserializeObject<Sequence>(File.ReadAllText(filePath));
	}


}
