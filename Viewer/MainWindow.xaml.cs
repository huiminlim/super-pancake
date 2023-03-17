using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Example
{
    //Defines the customer object
    public class Customer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMember { get; set; }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }
        public Customer(string firstName, string lastName, int age, bool isMember)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            IsMember = isMember;
        }

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Customer> custdata = new ObservableCollection<Customer>();

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
