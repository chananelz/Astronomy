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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(bool)myTermCheckBox.IsChecked)
            {
                return;
            }
            string name = myName.Text;
            string password = myPasword.Password;
            string email = myEmaile.Text;
            bool wantMail = (bool)myEmailCheckBox.IsChecked   ;



            var BL = new AstronomyBL.UserValidation();
            bool result = BL.Sign_up_request(name, password, email, wantMail);

            if (result)
            {
                MessageBox.Show("Added successfully", "information", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }

            else
            {
                MessageBox.Show("work cancelled", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Window0 window0 = new Window0();
            window0.Show();
            this.Close();

        }
    }
}
