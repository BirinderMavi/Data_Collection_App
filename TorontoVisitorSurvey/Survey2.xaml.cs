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
    /// Interaction logic for Survey2.xaml
    /// </summary>
    public partial class Survey2 : Window
    {
        InfoLogic il = new InfoLogic();
       
        public Survey2()
        {
            InitializeComponent();
        }

        private async void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            await il.CreateResponse(il.CnTower, il.Ripley, il.Wonderland, il.Zoo, il.Rogers);
            this.Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await il.Init();
            this.DataContext = il;
        }
    }
}
