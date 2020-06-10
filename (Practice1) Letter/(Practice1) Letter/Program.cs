using System;
using System.IO;
using System.Text;

namespace _Practice1__Letter
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding encoding = Encoding.GetEncoding("cp866");

            string[] input = File.ReadAllLines("INPUT.TXT", encoding);

            string[] numbers = input[0].Replace(" ", " ").Split(' ');
            int k = int.Parse(numbers[0]);
            int n = int.Parse(numbers[1]);

            string[] output = new string[input.Length - 1];
            char[] charsToTrim = { ' ' };

            for (int i = 1; i < input.Length; i++)
            {
                input[i] = input[i].Trim(charsToTrim);
            }


            for (int i = 1; i < input.Length; i++)
            {
                if (input[i].Length <= k)
                {
                    for (int l = 0; l < (k - input[i].Length) / 2; l++)
                        output[i - 1] += " ";

                    output[i - 1] += input[i];

                    for (int l = (k - input[i].Length) / 2 + input[i].Length; l < k; l++)
                        output[i - 1] += " ";

                }
                else
                {
                    output = new string[1];
                    output[0] = "Impossible.";
                    break;
                }
            }

            File.WriteAllLines("OUTPUT.TXT", output, encoding);
        }
    }
}