using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObjects
{
	public class Debug
	{
		static bool DebugMode = false;
		static bool ToFile = true;
		private static object locker = new object();
		private static string path = "C:\\Users\\Vincent\\OneDrive - Enseignement de la Province de Liège\\Cours\\B2\\C#\\MyCartographyObjects\\MyCartographyObjects\\Log.txt";
		public static void Log(string format,params object[] args)
		{
			if (DebugMode)
				if (ToFile)
					lock (locker)
						File.AppendAllText(path, string.Format(format + "\n", args));
					
				else
					Console.WriteLine();
		}
	}
}
