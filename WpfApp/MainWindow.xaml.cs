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
using CoreLib;
using System.IO;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> rounds1 = new List<string>();
        List<string> rounds2 = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void openIn_Click(object sender, RoutedEventArgs e)
        {
            textIn.Text = "";
            try
            {
                using (StreamReader fileIn = new StreamReader(pathIn.Text))
                {
                    textIn.Text = fileIn.ReadToEnd();
                }
                MessageBox.Show("Файл успешно открыт!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Путь к файлу некорректен!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void saveIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!File.Exists(pathIn.Text))
                {
                    throw new FileNotFoundException();
                }
                using (StreamWriter fileOut = new StreamWriter(pathIn.Text))
                {
                    fileOut.Write(textIn.Text);
                }
                MessageBox.Show("Файл успешно сохранен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Путь к файлу некорректен!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void openHash_Click(object sender, RoutedEventArgs e)
        {
            textHash.Text = "";
            try
            {
                using (StreamReader fileIn = new StreamReader(pathHash.Text))
                {
                    textHash.Text = fileIn.ReadToEnd();
                }
                MessageBox.Show("Файл успешно открыт!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Путь к файлу некорректен!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void saveHash_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!File.Exists(pathHash.Text))
                {
                    throw new FileNotFoundException();
                }
                using (StreamWriter fileOut = new StreamWriter(pathHash.Text))
                {
                    fileOut.Write(textHash.Text);
                }
                MessageBox.Show("Файл успешно сохранен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Путь к файлу некорректен!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void invBitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = int.Parse(invBitTextBox.Text);
                if (n < 0 || n > textIn.Text.Length * 8)
                {
                    throw new ArgumentException();
                }
                MD5 md5 = new MD5(textIn.Text);
                rounds1 = md5.rounds;
                hashGraphFirst.Text = md5.GetStringHash();
                byte[] m = textIn.Text.Select(new Func<char, byte>((char c) => (byte)c)).ToArray();
                m[n / 8] ^= (byte)(1 << n % 8);
                md5 = new MD5(m); 
                rounds2 = md5.rounds;
                hashGraphSecond.Text = md5.GetStringHash();
                OxyPlot.PlotModel plotModel = new OxyPlot.PlotModel();
                plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis() { Position = OxyPlot.Axes.AxisPosition.Bottom, Minimum = 0, Maximum = 64 });
                plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis() { Position = OxyPlot.Axes.AxisPosition.Left, Minimum = 0, Maximum = 256 });
                OxyPlot.Series.LineSeries lineSeries = new OxyPlot.Series.LineSeries();
                for (int i = 0; i < 64; ++i)
                {
                    int c = 0;
                    for (int j = 0; j < 128; ++j)
                    {
                        if (rounds1[i][j] != rounds2[i][j])
                        {
                            c++;
                        }
                    }
                    lineSeries.Points.Add(new OxyPlot.DataPoint(i, c));
                }
                plotModel.Series.Add(lineSeries);
                plotView.Model = plotModel;
            }
            catch
            {
                MessageBox.Show("Номер инвертируемого бита некорректен!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void pathIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                openIn_Click(sender, new RoutedEventArgs());
            }
        }

        private void pathHash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                openHash_Click(sender, new RoutedEventArgs());
            }
        }

        private void hashIn_Click(object sender, RoutedEventArgs e)
        {
            MD5 md5 = new MD5(textIn.Text);
            textHash.Text = md5.GetStringHash();
        }

        private void textIn_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textIn.Text.Length == 0)
            {
                invBitTextBlock.Visibility = Visibility.Hidden;
                invBitTextBox.Visibility = Visibility.Hidden;
            }
            else
            {
                invBitTextBlock.Text = "Инвертировать бит с номером [0, " + (textIn.Text.Length * 8).ToString() + "]:";
                invBitTextBlock.Visibility = Visibility.Visible;
                invBitTextBox.Visibility = Visibility.Visible;
            }
        }
    }
}