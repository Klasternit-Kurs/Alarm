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
			DrugiAlarm da = new DrugiAlarm();
			Vatrogasac v1 = new Vatrogasac();
			Vatrogasac v2 = new Vatrogasac();
			Policajac p1 = new Policajac();

			Civil c1 = new Civil();
			a.Alarmm += c1.Panici;
			//da.AlarmmDva += c1.Panici;

			a.Alarmm += v1.ZvoniAlarm;
			
			a.Alarmm += p1.ZvoniAlarm;
			a.Alarmm += v2.ZvoniAlarm;

			dgm.Click += klik;
			dgm2.Click += klik;

			a.Zvoni();

			ObservableCollection<int> brojevi = new ObservableCollection<int>();

			brojevi.CollectionChanged += promena;
			brojevi.Add(5);
			brojevi.Add(7);

		}
		public void promena(object o, NotifyCollectionChangedEventArgs er)
		{
			MessageBox.Show(o.ToString());
		}
		public void klik(object o, RoutedEventArgs  r)
		{
			
			Button b = (Button)o;
			if (b.Content.ToString() == "Test")
				MessageBox.Show(o.ToString());
			else if (b.Content.ToString() == "Test2")
				this.Close();
		}
	}


	public class DrugiAlarm
	{
		public delegate void AlarmTip(object KoSalje);
		public event AlarmTip AlarmmDva;
		public void ZvoniDrugi()
		{
			AlarmmDva?.Invoke(this);
		}
	}

	public class AlarmEventArgs : EventArgs
	{

	}

	public class PpAlarm
	{
		public delegate void AlarmTip(object KoSalje, AlarmEventArgs a);
		public event AlarmTip Alarmm;
		public void Zvoni()
		{
			Alarmm?.Invoke(this, new AlarmEventArgs());
		}
	}

	public class Civil
	{
		public void Panici(object KoSalje, AlarmEventArgs a) 
		{
			if (KoSalje is PpAlarm aa)
				MessageBox.Show("Prvi");
			else if (KoSalje is DrugiAlarm d)
				MessageBox.Show("Drugi!");
		}
	}

	public class Policajac
	{
		public bool CuoAlarm;

		public void ZvoniAlarm(object KoSalje, AlarmEventArgs a)
		{
			CuoAlarm = true;
		}
	}

	public class Vatrogasac
	{
		public bool CuoAlarm;

		public void ZvoniAlarm(object KoSalje, AlarmEventArgs a)
		{
			CuoAlarm = true;
			//if (a.temperatura > 10)
		}
	}
}
