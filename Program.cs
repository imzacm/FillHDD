using System;
using System.IO;

namespace FillHDD
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int length;
			string option;
			string filename = "Dummy";
			start:
			Console.WriteLine ("Type the numer and press enter");
			Console.WriteLine ("1) Fill a drive");
			Console.WriteLine ("2) Enter a file size");
			option = Console.ReadLine ();
			if (option == "1")
			{
				string drive;
				Console.WriteLine ("Enter the drive letter (C:)");
				drive = Console.ReadLine ();
				string freespace = GetTotalFreeSpace (drive).ToString();
				Console.WriteLine("Drive " + drive + " has " + freespace + "free");
				length = Convert.ToInt32(freespace);
				Console.WriteLine ("Do you want to fill that up? (Y/N)");
				option = Console.ReadLine ();
				if (option == "Y" || option == "y") 
				{
					CreateDummyFile (drive + "\\" + filename, length);
				} 
				else
				{
					if (option == "N" || option == "n")
					{
						goto start;
					} 
					else 
					{
						Console.WriteLine ("Invalid value");
						goto start;
					}
				}
			} 
			else
			{
				if (option == "2")
				{
					Console.WriteLine ("Enter the size of the file (MB)");
					length = Convert.ToInt16(Console.ReadLine ());
					Console.WriteLine ("Do you want to create a " + length.ToString() + " MB file? (Y/N)");
					option = Console.ReadLine ();
					if (option == "Y" || option == "y") 
					{
						CreateDummyFile (filename, length);
					} 
					else
					{
						if (option == "N" || option == "n")
						{
							goto start;
						} 
						else 
						{
							Console.WriteLine ("Invalid value");
							goto start;
						}
					}
				} 
				else
				{
					Console.WriteLine ("Invalid value");
					goto start;
				}
				Console.ReadLine ();
			}
		}

		public static long GetTotalFreeSpace(string driveName)
		{
			foreach (DriveInfo drive in DriveInfo.GetDrives())
			{
				if (drive.IsReady && drive.Name == driveName)
				{
					return drive.TotalFreeSpace;
				}
			}
			return -1;
		}

		public static bool CreateDummyFile(string filename, int length)
		{
			using (var fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
			{
				fileStream.SetLength(1024 * 1024 * length);
			}
			return true;
		}
	}
}
