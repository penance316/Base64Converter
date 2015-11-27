using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64Converter
{
	internal class Program
	{
		private const string InputFile = "input";
		private const string OutputFile = "output";

		private static void Main(string[] args)
		{
			int userInput = 0;
			do
			{
				userInput = ShowMainMenu();
				switch (userInput)
				{
					case 1:
						Encode();
						break;
					case 2:
						Decode();
						break;
				}
			} while (userInput != 9);
		}

		public static int ShowMainMenu()
		{
			Console.Clear();
			Console.WriteLine("Base64 Converter");
			Console.WriteLine();
			Console.WriteLine("1. Encode");
			Console.WriteLine("2. Decode");
			Console.WriteLine("9. Exit");
			var result = Console.ReadLine();

			int parsedValue;
			return Int32.TryParse(result, out parsedValue) ? parsedValue : 0;
		}

		private static void Encode()
		{
			Console.Clear();
			Console.Out.WriteLine("Encoding");
			
			var inPath = Path.Combine(Directory.GetCurrentDirectory(), InputFile);
			var outPath = Path.Combine(Directory.GetCurrentDirectory(), OutputFile);

			var fs = new FileStream(InputFile, FileMode.Open, FileAccess.Read);
			var filebytes = new byte[fs.Length];

			fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
			var encodedData = Convert.ToBase64String(filebytes, Base64FormattingOptions.InsertLineBreaks);

			File.WriteAllText(outPath, encodedData);

			Console.Out.WriteLine("Done");
			Console.Out.Write("Press Enter...");
			Console.ReadLine();
		}

		private static void Decode()
		{
			Console.Clear();
			Console.Out.WriteLine("Decoding");
			
			var inPath = Path.Combine(Directory.GetCurrentDirectory(), InputFile);
			var outPath = Path.Combine(Directory.GetCurrentDirectory(), OutputFile);

			var fileString = File.ReadAllText(inPath);

			var decodedData = Convert.FromBase64String(fileString);

			File.WriteAllBytes(outPath, decodedData);

			Console.Out.WriteLine("Done");
			Console.Out.Write("Press Enter...");
			Console.ReadLine();
		}
	}
}