using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfVisocki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string urlVar = urlBox.Text;

            string[] lines = File.ReadAllLines(urlVar, Encoding.UTF8);
            string sub = findBox.Text;

            Dictionary<int, int> spisok = new Dictionary<int, int>();
            int count;

            for (int i = 0; i < lines.Length; i++)
            {
                count = 0;
                string[] temp = sub.Split(',').Select(x => x.Trim()).ToArray(); //разделяем строку запятыми, выбираем каждый элемент и убираем из него пробелы
                foreach (var str in temp)//пробегаем по полученному массиву подстрок
                {
                    //если в i-й строке содержится подстрока str
                    if (lines[i].Contains(str)) 
                    {
                        output.Items.Add("Найдено совпадение в строке №" + (i + 1) + ":\n" + lines[i]);
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
