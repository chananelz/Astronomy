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

namespace AstronomyWPF
{
    /// <summary>
    /// Interaction logic for Window0.xaml
    /// </summary>
    public partial class Window0 : Window
    {
        public Window0()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var BL = new AstronomyBL.UserValidation();
            bool result = BL.ValidateUser("eli", "1");
        }
    }
}
