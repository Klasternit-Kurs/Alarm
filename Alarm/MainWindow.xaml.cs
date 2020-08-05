using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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

namespace Alarm
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public MainWindow()
		{
			InitializeComponent();
			PpAlarm a = new PpAlarm();
			Vatrogasac v1 = new Vatrogasac();
			Vatrogasac v2 = new Vatrogasac();
			Policajac p1 = new Policajac();
			Civil c1 = new Civil();
			a.Alarmm += c1.Panici;
			a.Alarmm += v1.ZvoniAlarm;
			
			a.Alarmm += p1.ZvoniAlarm;
			a.Alarmm += v2.ZvoniAlarm;

			dgm.Click += klik;

			a.Zvoni();

			ObservableCollection<int> brojevi = new ObservableCollection<int>();

			brojevi.CollectionChanged += promena;
			brojevi.Add(5);
			brojevi.Add(7);

		}
		public void promena(object o, NotifyCollectionChangedEventArgs er)
		{
			MessageBox.Show("Promena!");
		}
		public void klik(object o, RoutedEventArgs  r)
		{
			MessageBox.Show("asd");
		}
	}

	public class PpAlarm
	{
		public delegate void AlarmTip();
		public event AlarmTip Alarmm;
		public void Zvoni()
		{
			Alarmm?.Invoke();
		}
	}

	public class Civil
	{
		public void Panici() { }
	}

	public class Policajac
	{
		public bool CuoAlarm;

		public void ZvoniAlarm()
		{
			CuoAlarm = true;
		}
	}

	public class Vatrogasac
	{
		public bool CuoAlarm;

		public void ZvoniAlarm()
		{
			CuoAlarm = true;

		}
	}
}
