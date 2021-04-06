using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
	static class FileReader
	{

		public static void GetFiles()
		{
			try
			{
				string path = Path.Combine(Directory.GetCurrentDirectory(), "battleLogs");
				
				string[] files = Directory.GetFiles(path);

				foreach (string file in files)
                {
					Console.WriteLine("------------------------------------------------------------------------");

					ReadFromFile(file);
                }
				
			}
			catch (Exception e)
			{

				Console.WriteLine("The process failed: {0}", e.ToString());
			}
		}

		public static void DeleteFiles()
        {
			try
			{
				string path = Path.Combine(Directory.GetCurrentDirectory(), "battleLogs");

				string[] files = Directory.GetFiles(path);

				foreach (string file in files)
				{
					File.Delete(file);
				}

                Console.WriteLine("Files from previous battles are deleted");
			}
			catch (Exception e)
			{

				Console.WriteLine("The process failed: {0}", e.ToString());
			}
		}

        private static void ReadFromFile(string path)
        {
			string line;
			StreamReader file = new StreamReader(@path);
			while((line = file.ReadLine()) != null)
            {
				string[] parts = line.Split(',');
				RoundLogger display = new RoundLogger(parts[0], parts[1], parts[2], parts[3], parts[4]);
				
				display.PrintOutput();
                
            }
			file.Close();
        }
    }
}
