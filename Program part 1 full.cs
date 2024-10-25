using System;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Laba_2
{
    public class Array
    {
        private int[]? array { get; set; }
        
        public Array(int len) 
        {
            array = new int[len];
        }

        public Array(int[] arr)
        {
            array = (int[])arr.Clone();
        }
         
        public string return_string(Array a)
        {
            string arr_str = " ";
            for (int i = 0; i < a.array.Length; i++)
            {
                arr_str += Convert.ToString(a.array[i]) + " ";
            }
            return arr_str;
        }

        public int[] return_array(Array a)
        {

            return a.array;
        }

        // умножение
        public static Array operator *(Array a, Array b)
        {
            Array c = new Array(a.array.Length);

            if (a.array.Length != b.array.Length)
            {
                throw new Exception("Arrays must have similar length!");
            }

            for (int i = 0;  i < a.array.Length; i++)
            {
                c.array[i] = a.array[i] * b.array[i];

            }
            return c;
        }

        public static explicit operator int(Array a)
        {
            return a.array.Length;
        }

        public static bool operator !=(Array a, Array b)
        {
            if (a.array.Length == b.array.Length) return true;
            else return false;

        }
        public static bool operator ==(Array a, Array b)
        {
            if (a.array.Length == b.array.Length)
            {
                for (int i = 0; i < a.array.Length; i++)
                {
                    if (a.array[i] == b.array[i]) continue;
                    else
                    {
                        return false;
                        break;
                    }
                }
                return true;
            }
            else return false;
        }


        // перегруенный оператор возвращает true, если первый массив больше второго
        public static bool operator >(Array a, Array b)
        {
            if (a.array.Length > b.array.Length)
            {
                return true;
            }
            else return false;
        }

        //перегруенный оператор возвращает true, если первый массив меньше второго
        public static bool operator <(Array a, Array b)
        {
            if (a.array.Length < b.array.Length)
            {
                return true;
            }
            else return false;
        }

        public static bool operator false(Array a)
        {
            foreach (int item in a.array)
            {
                if (item < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator true(Array a)
        {
            foreach (int item in a.array)
            {
                if (item < 0)
                {
                    return false;
                }
            }
            return true;
        }


    }

    public static class StringExtension
    {
        public static bool HasSymbol(this Array a, int c)
        {
            int[] arr_temp = a.return_array(a);
            for (int i = 0; i < arr_temp.Length; i++)
            {
                if (arr_temp[i] == c)
                {
                    return true;
                }
            }

            return false;

        }
    }

    public static class Delete_negative_elements
    {
        public static int[] Delete(this Array a)
        {
            int[] arr_temp = a.return_array(a);
            int count = 0;
            for (int i = 0; i < arr_temp.Length; i++)
            {
                if (arr_temp[i] >= 0)
                {
                    count++;
                }
            }

            int k = 0;
            int[] arr_new = new int[count];
            for (int i = 0; i< arr_temp.Length; i++)
            {
                if (arr_temp[i] >= 0)
                {
                    arr_new[k] = arr_temp[i];
                    k++;
                }
            }
            return arr_new;
        }
    }

    public class program
    {
        public static void Main(string[] args)
        {
            int c1 = 10;
            int c2 = 0;
            int[] numbers = { 1, 2, 3, 4, 5 };
            int[] numbers_2 = { 0, 1, -2 };
            Array array_1 = new Array(numbers);
            Array array_2 = new Array(numbers);
            Array array_4 = new Array(numbers_2);

            Console.WriteLine($"Array 1: {array_1.return_string(array_1)}");
            Console.WriteLine($"\nArray 2: {array_2.return_string(array_2)}");

            Array array_3 = new Array(numbers.Length);
            array_3 = array_1* array_4;
            string printing = array_3.return_string(array_3);
            Console.WriteLine("\nArray 3: Multiply arrays 1 and 2: ");
            Console.WriteLine(printing);

            Console.WriteLine("\nArray 3 size: ");
            Console.WriteLine((int)array_3);

            Console.WriteLine("\nComparing arrays 1 and 3: ");
            Console.WriteLine(array_1 == array_3);

            Console.WriteLine($"\nArray 4: {array_4.return_string(array_4)}");
            Console.WriteLine($"\nArray 4 is smaller than array 2:\n {array_4<array_2}");

            Console.WriteLine($"\n Check if array_4 has negative elements: ");
            if (array_4)
            {
                Console.WriteLine("\nArray doesn't have negative elements.");
            }
            else
            {
                Console.WriteLine("\nArray has negative elements.");
            }

            Console.WriteLine($"\nIf array 4 has symbol {c1}: {array_4.HasSymbol(c1)}");
            Console.WriteLine($"\nIf array 4 has symbol {c2}: {array_4.HasSymbol(c2)}");

            Console.WriteLine("\nDeleting negative elements of array 4... ");
            int[] mass = new int[(array_4.Delete()).Length];
            mass = array_4.Delete();

            string st = "";
            Console.WriteLine("\nPrinting only positive elements of array 4: ");
            for (int i = 0; i< mass.Length; i++)
            {
                st += mass[i] + " ";
            }
            Console.WriteLine(st);
        }
    }
}
