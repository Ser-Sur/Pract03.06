using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pract03._06
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Money money1 = new Money();
        Money money2 = new Money();
        Money money3 = new Money();
        int divider = 0;

        public MainWindow()
        {
            InitializeComponent();
            tbDivider.Text = null;
        }

        private void Addition_Click(object sender, RoutedEventArgs e)
        {
            if (IsSetMoneyForBinaryOperations())
            {
                money3 = money1 + money2;
                tbRez.Text = Convert.ToString(money3.Rub + " руб., " + money3.Cop + " коп.");
                tbDivider.Text = null;
            }
            else
            {
                MessageBox.Show("Введите значения!!!");
                tbRez.Text = null;
            }
        }

        private void Subtraction_Click(object sender, RoutedEventArgs e)
        {
            if (IsSetMoneyForBinaryOperations())
            {
                money3 = Money.Subtraction(money1, money2);
                tbRez.Text = Convert.ToString(money3.Rub + " руб., " + money3.Cop + " коп.");
                tbDivider.Text = null;
            }
            else
            {
                MessageBox.Show("Введите значения!!!");
                tbRez.Text = null;
            }
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            tbCop2.Text = null;
            tbRub2.Text = null;
            if (IsSetMoneyForDivision())
            {
                money3 = Money.Division(money1, divider);
                tbRez.Text = Convert.ToString(money3.Rub + " руб., " + money3.Cop + " коп.");
            }
            else
            {
                MessageBox.Show("Введите значения!!!");
                tbRez.Text = null;
            }
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Создание наследованных классов.\nАртемкин М. ИСП-31 Практическая работа №6.\n\nИспользовать класс Pair (пара чисел). Определить класс-наследник Money с характеристиками: рубли и копейки.\nПереопределить операцию сложения и определить методы вычитания и деления денежных сумм.");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool IsSetMoneyForDivision()
        {
            if (Int32.TryParse(tbRub1.Text, out int rub1) && rub1 >= 0 && Int32.TryParse(tbCop1.Text, out int cop1) && cop1 >= 0 && cop1 < 100 && Int32.TryParse(tbDivider.Text, out int dividerr) && dividerr > 0)
            {
                money1.Rub = rub1;
                money1.Cop = cop1;
                divider = dividerr;
                return true;
            }
            else return false;
        }

        private bool IsSetMoneyForBinaryOperations()
        {
            if (Int32.TryParse(tbRub1.Text, out int rub1) && rub1 >= 0 && Int32.TryParse(tbCop1.Text, out int cop1) && cop1 >= 0 && cop1 < 100 && Int32.TryParse(tbRub2.Text, out int rub2) && rub2 >= 0 && Int32.TryParse(tbCop2.Text, out int cop2) && cop2 >= 0 && cop2 < 100)
            {
                money1.Rub = rub1;
                money1.Cop = cop1;
                money2.Rub = rub2;
                money2.Cop = cop2;
                return true;
            }
            else return false;
        }
    }
}