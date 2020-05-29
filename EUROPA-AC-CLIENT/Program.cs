using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Net;
using Microsoft.Win32;
using MySql.Data.MySqlClient;

namespace EUROPA_AC_CLIENT
{
	class Program
	{
		[DllImport("user32.dll")]
		static extern IntPtr SetWindowsHookEx(int idHook, keyboardHookProc callback, IntPtr hInstance, uint threadId);

		[DllImport("user32.dll")]
		static extern bool UnhookWindowsHookEx(IntPtr hInstance);

		[DllImport("user32.dll")]
		static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref keyboardHookStruct lParam);

		[DllImport("kernel32.dll")]
		static extern IntPtr LoadLibrary(string lpFileName);

		[DllImport("user32.dll")]
		static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		public delegate int keyboardHookProc(int code, int wParam, ref keyboardHookStruct lParam);

		public struct keyboardHookStruct
		{
			public int vkCode;
			public int scanCode;
			public int flags;
			public int time;
			public int dwExtraInfo;
		}

		const int WH_KEYBOARD_LL = 13;
		const int WM_KEYDOWN = 0x100;
		const int WM_KEYUP = 0x101;
		const int WM_SYSKEYDOWN = 0x104;
		const int WM_SYSKEYUP = 0x105;

		static IntPtr hhook = IntPtr.Zero;
		static IntPtr hCurrentWindow = IntPtr.Zero;

		static string rv = "Graphics Drivers";

		private static string version = "0.1";

		private static string ifOk = "Yes";

		static void Main()
		{
			Console.Title = "EUROPA ANTICHEAT by goldblack | " + version;
			
			//PerformVersionCheck();

			if (ifOk == "Yes")
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Green;
				string europamark = @"
                           
                                                  
                              @@@@@@@@  @@@  @@@  @@@@@@@    @@@@@@   @@@@@@@    @@@@@@   
                              @@@@@@@@  @@@  @@@  @@@@@@@@  @@@@@@@@  @@@@@@@@  @@@@@@@@  
                              @@!       @@!  @@@  @@!  @@@  @@!  @@@  @@!  @@@  @@!  @@@  
                              !@!       !@!  @!@  !@!  @!@  !@!  @!@  !@!  @!@  !@!  @!@  
                              @!!!:!    @!@  !@!  @!@!!@!   @!@  !@!  @!@@!@!   @!@!@!@!  
                              !!!!!:    !@!  !!!  !!@!@!    !@!  !!!  !!@!!!    !!!@!!!!  
                              !!:       !!:  !!!  !!: :!!   !!:  !!!  !!:       !!:  !!!  
                              :!:       :!:  !:!  :!:  !:!  :!:  !:!  :!:       :!:  !:!  
                               :: ::::  ::::: ::  ::   :::  ::::: ::   ::       ::   :::  
                              : :: ::    : :  :    :   : :   : :  :    :         :   : :  
                                                                         ANTICHEAT      
                              ==========================================================
                                                                       by goldblack
                                                               
                                                            
				";
				Console.WriteLine(europamark);

				bool keepRunning = true;

				IntPtr hInstance = LoadLibrary("User32");
				hhook = SetWindowsHookEx(WH_KEYBOARD_LL, hookProc, hInstance, 0);

				string dest = "C:\\Windows\\" + System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName;
				string RUN_LOCATION = @"Software\Microsoft\Windows\CurrentVersion\Run";
				string VALUE_NAME = rv;

				RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
				key.SetValue(VALUE_NAME, dest);

				while (keepRunning)
				{
					Application.Run();
				}

				UnhookWindowsHookEx(hhook);
			}
		}

		private static void PerformVersionCheck()
		{
			string CheckVersion = new WebClient()
			{
				Proxy = ((IWebProxy)null)
			}.DownloadString("https://pastebin.com/raw/XxJF23RF");
			if (CheckVersion.Contains(version))
			{
				ifOk = "Yes";
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Version mismatch. Please update your client.");
				Console.WriteLine("Your client version: " + version);
				ifOk = "No";
				Console.ReadKey(true);
			}
		}

		private static string retardcheck = "";

		public static void dodajtokurwawkoncu(char przycisk)
		{
			retardcheck = retardcheck.PadRight(1 + retardcheck.Length, przycisk);

			if (retardcheck == "/exec") {
				Console.WriteLine("tak o bana ci pizgam tera");
				FiveM.HelpMeWithEnter();
				retardcheck = ""; 
			}
			else if (retardcheck == "/save") {
				Console.WriteLine("tak o bana ci pizgam tera");
				FiveM.HelpMeWithEnter();
				retardcheck = "";
			}
			else if (retardcheck == "/dump") {
				Console.WriteLine("tak o bana ci pizgam tera");
				FiveM.HelpMeWithEnter();
				retardcheck = "";
			}
			else if (retardcheck == "/file") {
				Console.WriteLine("tak o bana ci pizgam tera");
				FiveM.HelpMeWithEnter();
				retardcheck = ""; 
			}
			else if (retardcheck == "/menu") {
				Console.WriteLine("tak o bana ci pizgam tera");
				FiveM.HelpMeWithEnter();
				retardcheck = ""; 
			}
			else if (retardcheck == "/lynxmenu") {
				Console.WriteLine("tak o bana ci pizgam tera");
				FiveM.HelpMeWithEnter();
				retardcheck = ""; 
			}
		}

		public static int hookProc(int code, int wParam, ref keyboardHookStruct lParam)
		{
			char klawiszjebany;
			if (code >= 0)
			{
				Keys key = (Keys)lParam.vkCode;
				KeyEventArgs kea = new KeyEventArgs(key);
				if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP)
				{
					if (hCurrentWindow != GetForegroundWindow())
					{
						StringBuilder sb = new StringBuilder(256);
						hCurrentWindow = GetForegroundWindow();
						GetWindowText(hCurrentWindow, sb, sb.Capacity);
					}

					if (kea.KeyCode == Keys.OemQuestion)
					{
						klawiszjebany = '/';

						dodajtokurwawkoncu(klawiszjebany);
					}
					else if (kea.KeyCode == Keys.E)
					{
						klawiszjebany = 'e';

						dodajtokurwawkoncu(klawiszjebany);
					}
					else if(kea.KeyCode == Keys.X)
					{
						klawiszjebany = 'x';

						dodajtokurwawkoncu(klawiszjebany);
					}
					else if(kea.KeyCode == Keys.C)
					{
						klawiszjebany = 'c';

						dodajtokurwawkoncu(klawiszjebany);
					}
					else if (kea.KeyCode == Keys.A)
					{
						klawiszjebany = 'a';

						dodajtokurwawkoncu(klawiszjebany);
					}
					else if (kea.KeyCode == Keys.V)
					{
						klawiszjebany = 'v';

						dodajtokurwawkoncu(klawiszjebany);
					}
					else if (kea.KeyCode == Keys.S)
					{
						klawiszjebany = 's';

						dodajtokurwawkoncu(klawiszjebany);
					}
					else if (kea.KeyCode == Keys.D)
					{
						klawiszjebany = 'd';

						dodajtokurwawkoncu(klawiszjebany);
					}
					else if (kea.KeyCode == Keys.U)
					{
						klawiszjebany = 'u';

						dodajtokurwawkoncu(klawiszjebany);
					}
					else if (kea.KeyCode == Keys.M)
					{
						klawiszjebany = 'm';

						dodajtokurwawkoncu(klawiszjebany);
					}
					else if (kea.KeyCode == Keys.P)
					{
						klawiszjebany = 'p';

						dodajtokurwawkoncu(klawiszjebany);
					}
					else
					{
						retardcheck = "";
					}

				}
			}
			return CallNextHookEx(hhook, code, wParam, ref lParam);
		}

	}

	class FiveM
	{
		public static void HelpMeWithEnter()
		{
			EnterMeIn();
		}

		private static void EnterMeIn()
		{
			Console.WriteLine("Juz robie z nim porzadek");
			new MySQLConnect();

		}
	}

	class MySQLConnect
	{
		private MySqlConnection connection;
		private string server;
		private string database;
		private string uid;
		private string password;

		public MySQLConnect()
		{
			Start();
		}

		private void Start()
		{
			server = "localhost"; // CHANGE ME
			database = "sid";
			uid = "root"; // CHANGE ME
			password = ""; // CHANGEME
			string connectionString;
			connectionString = "SERVER=" + server + ";" + "DATABASE=" +
			database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

			connection = new MySqlConnection(connectionString);

			ThrowMeIn();
		}
		public void ThrowMeIn()
		{
			string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

			//open connection
			if (this.OpenConnection() == true)
			{
				//create command and assign the query and connection from the constructor
				MySqlCommand cmd = new MySqlCommand(query, connection);

				//Execute command
				cmd.ExecuteNonQuery();

				//close connection
				this.CloseConnection();
			}
		}
		private bool OpenConnection()
		{
			try
			{
				connection.Open();
				return true;
			}
			catch (MySqlException ex)
			{
				switch (ex.Number)
				{
					case 0:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("ERROR: Cannot connect to server.");
						break;

					case 1045:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("ERROR: Unknown error.");
						break;
				}
				return false;
			}
		}
		private bool CloseConnection()
		{
			try
			{
				connection.Close();
				return true;
			}
			catch (MySqlException ex)
			{
				return false;
			}
		}
	}
}
