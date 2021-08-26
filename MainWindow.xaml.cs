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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.WindowsAPICodePack.Shell;
using System.IO;
using System.Threading;

namespace PlutoFN
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			File.WriteAllText("Config\\email.txt", EmailBR.Text);
			File.WriteAllText("Config\\password.txt", PasswordBR.Text);
			Thread.Sleep(2000);
			Dashboard dash = new Dashboard();
			dash.Show();
			this.Close();
			
		}

		private void Register_Click(object sender, RoutedEventArgs e)
		{
			
		}
	}
}
