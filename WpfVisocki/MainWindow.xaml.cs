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
            //Console.Write("Введите теги через запятую\n>");
            string sub = findBox.Text;

            Dictionary<int, int> spisok = new Dictionary<int, int>();
            int count;

            //предсказатель погоды
            for (int i = 0; i < lines.Length; i++)
            {
                count = 0;
                string[] temp = sub.Split(',').Select(x => x.Trim()).ToArray(); //разделяем строку запятыми, выбираем каждый элемент и убираем из него пробелы
                foreach (var str in temp)//пробегаем по полученному массиву подстрок
                    if (lines[i].Contains(str)) //если в i-й строке содержится подстрока str,
                        count++;//то прибавляем счетчик
                spisok.Add(i, count);//добавляем элемент в словарь с ключом i и значением count
            }

            foreach (var i in spisok)
            {
                //if ((string)i.Value == findBox.Text)
                int a = i.Value;
                int b = i.Key;
                output.Items.Add(i.Key);
                output.Items.Add(i.Value);
            }
                //Console.WriteLine("стр. {0} ({1} совп.)", i.Key, i.Value);
        }
    }
}
