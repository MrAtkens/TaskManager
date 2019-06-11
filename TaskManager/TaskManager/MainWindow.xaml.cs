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

namespace TaskManager
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		bool IsExit = false;
		public MainWindow()
		{
			InitializeComponent();
			System.Windows.Forms.NotifyIcon notify = new System.Windows.Forms.NotifyIcon();
			notify.Icon = new System.Drawing.Icon("SecLogoMini.ico");
			notify.Visible = true;
			notify.Click += NotifyClick;

		}

		private void NotifyClick(object sender, EventArgs e)
		{
			Visibility = Visibility.Visible;
		}

		private void CloseWindow(object sender, RoutedEventArgs e)
		{
			if (!IsExit)
			{
				this.Visibility = Visibility.Collapsed;
			}
			
		}

		private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
		{
			ButtonCloseMenu.Visibility = Visibility.Visible;
			ButtonOpenMenu.Visibility = Visibility.Collapsed;
		}

		private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
		{
			ButtonCloseMenu.Visibility = Visibility.Collapsed;
			ButtonOpenMenu.Visibility = Visibility.Visible;
		}

		private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UserControl usc = null;
			GridMain.Children.Clear();

			switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
			{
				case "ItemCreate":
					usc = new TaskAddWindow();
					GridMain.Children.Add(usc);
					break;
				default:
					break;
			}
		}

		private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void WindowMaximaze(object sender, RoutedEventArgs e)
		{
			if (WindowState == WindowState.Maximized)
			{
				WindowState = WindowState.Normal;
			}
			else
			{
				WindowState = WindowState.Maximized;
			}
		}



		private void WindowMinimaze(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}

		private void ShutDown(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
