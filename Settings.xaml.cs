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
using System.Threading;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace PlutoFN
{
	/// <summary>
	/// Interaction logic for Settings.xaml
	/// </summary>
	public partial class Settings : Window
	{
		public Settings()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			File.WriteAllText("Config\\path.txt", PathBR.Text);
			Thread.Sleep(2000);
			MessageBox.Show("In-order to apply the changes you must restart the Pluto Launcher. Now Closing");
			System.Environment.Exit(0);
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			// Create a "Save As" dialog for selecting a directory (HACK)
			var dialog = new Microsoft.Win32.SaveFileDialog();
			dialog.InitialDirectory = "C:\\"; // Use current value for initial dir
			dialog.Title = "Select a Fortnite Path"; // instead of default "Save As"
			dialog.Filter = "Directory|*.this.directory"; // Prevents displaying files
			dialog.FileName = "select"; // Filename will then be "select.this.directory"
			if (dialog.ShowDialog() == true)
			{
				string path = dialog.FileName;
				// Remove fake filename from resulting path
				path = path.Replace("\\select.this.directory", "");
				path = path.Replace(".this.directory", "");
				// If user has changed the filename, create the new directory
				if (!System.IO.Directory.Exists(path))
				{
					System.IO.Directory.CreateDirectory(path);
				}
				// Our final value is in path
				PathBR.Text = path;
			}

		}
	}
}
