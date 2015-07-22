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

namespace TorontoVisitorSurvey
{
    /// <summary>
    /// Interaction logic for Survey.xaml
    /// </summary>
    public partial class Survey : Window
    {
        UserLogic ul = new UserLogic();
        public Survey()
        {
            InitializeComponent();
        }

        private async void btnNext_Click(object sender, RoutedEventArgs e)
        {
            await ul.CreateUser(ul.FirstName, ul.LastName, ul.Age, ul.City, ul.Province);
            Survey2 sur2 = new Survey2();
            sur2.Show();
            this.Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await ul.Init();
            this.DataContext = ul;

        }
    }
}
