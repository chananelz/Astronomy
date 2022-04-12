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

namespace AstronomyWPF
{
    /// <summary>
    /// Interaction logic for AI_Asteroide.xaml
    /// </summary>
    public partial class AI_Asteroide : Page
    {
        public AI_Asteroide()
        {
            InitializeComponent();
            Consumo consumo = new Consumo(47);
            DataContext = new ConsumoViewModel(consumo);
        }

        private void Calculate_the_Risk(object sender, RoutedEventArgs e)
        {

            try
            {
                double my_absoluteMagnitude = Convert.ToDouble(AbsoluteMagnitude.Text);
                double my_diameterMin = Convert.ToDouble(diameterMin.Text);
                double my_diameterMax = Convert.ToDouble(diameterMax.Text);
                double my_velocity = Convert.ToDouble(Velocity.Text);
                double my_missDistance = Convert.ToDouble(missDistance.Text);

                var BL = new AstronomyBL.Weighted_k_NN();
                double result = BL.getPercentageOfRisk(my_absoluteMagnitude, my_diameterMin, my_diameterMax, my_velocity, my_missDistance);
                if (result == 0.0)
                {
                    result = 0.001;
                }

                Consumo my_consumo = new Consumo(result * 100);
                DataContext = new ConsumoViewModel(my_consumo);
                radial_chart.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to read your input, try again.", "input error", MessageBoxButton.OK, MessageBoxImage.Error);
                InitializeComponent();
                Consumo consumo = new Consumo(47);
                DataContext = new ConsumoViewModel(consumo);
            }

        }
    }

    public class ConsumoViewModel
    {
        public List<Consumo> Consumo { get; private set; }

        public ConsumoViewModel(Consumo consumo)
        {
            Consumo = new List<Consumo>();
            Consumo.Add(consumo);
        }
    }

    public class Consumo
    {
        public string Titulo { get; private set; }
        public double Porcentagem { get; private set; }

        public Consumo(double num)
        {
            Titulo = "Dangerous Asteroide";
            Porcentagem = CalcularPorcentagem(num);
        }

        public double CalcularPorcentagem(double num)
        {
            return num; //Calculo da porcentagem de consumo
        }
    }
}
