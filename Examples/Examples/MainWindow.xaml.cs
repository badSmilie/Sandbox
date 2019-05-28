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

namespace Examples
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.AddHandler(ExitCommandRouted.ExecuteEvent, new RoutedEventHandler(OnExitExecute));
        }

        private void SimpleButton_Click(object sender, RoutedEventArgs e)
        {
            SimpleButton simpleButton = e.Source as SimpleButton;
            switch (simpleButton.Name)
            {
                case "btnYes": MessageBox.Show("Ja");
                    break;
            }
        }

        private void OnExitExecute(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
