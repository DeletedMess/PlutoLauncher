using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Markup;
using System.Threading;
using System.Reflection;
using System.CodeDom.Compiler;

namespace PlutoFN
{
	/// <summary>
	/// Interaction logic for Dashboard.xaml
	/// </summary>
	public partial class Dashboard : Window
	{
		public Dashboard()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Settings settings = new Settings();
			settings.Show();
		}

		private void DashBoard_Load(object sender, RoutedEventArgs e)
		{
			DiagEmail.Text = File.ReadAllText("config//email.txt");
			DiagPassword.Text = File.ReadAllText("config//password.txt");
			if (File.Exists("config\\path.txt"))
			{
				DiagPath.Text = File.ReadAllText("config//path.txt");
			}
			else
			{
				DiagPath.Text = "make sure to set a path";
			}
			return;
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			// Launches Fortnite. We will have a better way soon.
			Process process = ProcessHelper.StartProcess(this.DiagPath.Text + "\\FortniteGame\\Binaries\\Win64\\FortniteLauncher.exe", true, "");
			Process process2 = ProcessHelper.StartProcess(this.DiagPath.Text + "\\FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping_BE.exe", true, "");
			Process process4 = ProcessHelper.StartProcess(this.DiagPath.Text + "\\FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping_EAC.exe", true, "");
			Process process3 = ProcessHelper.StartProcess(this.DiagPath.Text + "\\FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe", false, "-AUTH_TYPE=epic -AUTH_LOGIN=\"" + this.DiagEmail.Text + "\" -AUTH_PASSWORD=\"" + this.DiagPassword.Text + "\" - SKIPPATCHCHECK");
			process3.WaitForInputIdle();
			ProcessHelper.InjectDll(process3.Id, System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "PlutoFNSSL.dll"));
			Thread.Sleep(1000);
			ProcessHelper.InjectDll(process3.Id, System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Rift.dll"));
			process3.WaitForExit();
			process.Kill();
			process2.Kill();
		}

		private void DiagnosticData_Click(object sender, RoutedEventArgs e)
		{
			if (DiagEmail.Visibility == Visibility.Visible)
			{
				DiagEmail.Visibility = Visibility.Hidden;
			}
			else
			{
				DiagEmail.Visibility = Visibility.Visible;
			}
			if (DiagPassword.Visibility == Visibility.Visible)
			{
				DiagPassword.Visibility = Visibility.Hidden;
			}
			else
			{
				DiagPassword.Visibility = Visibility.Visible;
			}
			if (DiagPath.Visibility == Visibility.Visible)
			{
				DiagPath.Visibility = Visibility.Hidden;
			}
			else
			{
				DiagPath.Visibility = Visibility.Visible;
			}
			if (DiagName.Visibility == Visibility.Visible)
			{
				DiagName.Visibility = Visibility.Hidden;
			}
			else
			{
				DiagName.Visibility = Visibility.Visible;
			}
			
			
		}
	}
}
