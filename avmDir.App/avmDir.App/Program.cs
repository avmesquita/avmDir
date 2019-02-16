using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avmDir.App
{
	class Program
	{
		public static StreamWriter sw = null;

		~Program()
		{
			sw.Dispose();
			sw = null;
		}

		/// <summary>
		/// Lookup folder, listing files and folders
		/// </summary>
		/// <param name="directory"></param>
		static void DirSearch(string directory)
		{
			try
			{
				foreach (string f in Directory.GetFiles(directory, "*.*"))
				{
					if (sw == null)
						Console.WriteLine(f);
					else
						sw.WriteLine(f);
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		static void Main(string[] args)
		{
			string msg = "Syntax:" + Environment.NewLine +
						 "" + Environment.NewLine +
						 "       > avmDir.App <caminho> <arquivo_destino>" + Environment.NewLine +
						 "" + Environment.NewLine;

			if ((args == null) | (args.Length.Equals(0)))
			{
				Console.WriteLine(msg);
			}

			if (args.Length.Equals(1))
				DirSearch(args[0]);
			else if (args.Length.Equals(2))
			{
				sw = new StreamWriter(args[1].ToString());
				DirSearch(args[0].ToString());
				sw.Flush();
				sw.Close();
			}
			else
				Console.WriteLine("Invalid parameter");
		}
	}
}
