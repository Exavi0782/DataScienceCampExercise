using System;

namespace Camp3
{

    class Program
    {
        static void Main(string[] args)
        {
            double[] coin = new double[] { 0.1, 0.2, 0.4, 0.8, 0.9 };
            char[] coinSide = new char[] { 'H', 'H', 'H', 'T', 'H', 'T', 'H', 'H' };
            double probilityCoin = coin[0] * 0.2 + coin[1] * 0.2 + coin[2] * 0.2 + coin[3] * 0.2 + coin[4] * 0.2;
            double[] bayasTheorem = new double[5];
            double[] result = new double[8];
			Console.Write("[ ");
            for (int i = 0; i < 8; i++)
            {
				for (int j = 0; j < 5; j++)
				{
					switch (coinSide[i])
					{
						case 'H':
							bayasTheorem[j] = (coin[j] * 0.2) / probilityCoin;
							result[i] += (bayasTheorem[j] * coin[j]);
							break;
						case 'T':
							bayasTheorem[j] = ((1 - coin[j]) * 0.2) / probilityCoin;
							result[i] += (bayasTheorem[j] * (1 - coin[j]));
							break;
						default:
							Console.WriteLine("Error!");
							break;
					}
				}
				if (i == 7)
					Console.WriteLine($"{Math.Round(result[i], 2)} ]");

				else
					Console.Write($"{Math.Round(result[i], 2)}; ");

				probilityCoin = result[i];
			}
        }
    }
}
