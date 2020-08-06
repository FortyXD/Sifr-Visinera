using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
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
using Word = Microsoft.Office.Interop.Word;
using Xceed.Words.NET;

using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public static class code1//класс с воидами -- основной код
    {
        
      public static string code(string m, string k) // encoder void
        {
            
            int nomer; 
            int d; 
            string s;
            int j, f; 
            int t = 0;

            char[] massage = m.ToCharArray(); 
            char[] key = k.ToCharArray();

            char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            for (int i = 0; i < massage.Length; i++)
            {
                for (j = 0; j < alfavit.Length; j++)
                {
                    if (massage[i] == alfavit[j])
                    {
                        break;
                    }
                }
                if (j != 33) 
                {
                    nomer = j;
                    if (t > key.Length - 1) { t = 0; }
                    for (f = 0; f < alfavit.Length; f++)
                    {
                        if (key[t] == alfavit[f])
                        {
                            break;
                        }
                    }
                    t++;
                    if (f != 33)
                    {
                        d = nomer + f;
                    }
                    else
                    {
                        d = nomer;
                    }
                    if (d > 32)//проверка на вылет
                    {
                        d = d - 33;
                    }

                    massage[i] = alfavit[d];//создание массива бекв 
                }
            }
            s = new string(massage);//готовая
            return s;
        }
        public static string decode(string m, string k) //decoder
        {   int nomer; 
            int d; 
            string s;
            int j, f;
            int t = 0;

            char[] massage = m.ToCharArray(); 
            char[] key = k.ToCharArray(); 

            char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

        
            for (int i = 0; i < massage.Length; i++)
            {
                for (j = 0; j < alfavit.Length; j++)
                {
                    if (massage[i] == alfavit[j])
                    {
                        break;
                    }
                }
                if (j != 33) 
                {
                    nomer = j; 
                    if (t > key.Length - 1) { t = 0; }

                    for (f = 0; f < alfavit.Length; f++)
                    {
                        if (key[t] == alfavit[f])
                        {
                            break;
                        }
                    }
                    t++;
                    if (f != 33) 
                    {
                        d = nomer - f;
                    }
                    else
                    {
                        d = nomer;
                    }
                    if (d < 0)//проверка за выход!!!!!
                    {
                        d = d + 33;
                    }
                    massage[i] = alfavit[d]; 
                }
            }
            s = new string(massage);
            return s;
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }
        private void Button_Click(object sender, RoutedEventArgs e)//encoder 
        {       string message = content.Text.ToLower();
                string keys = keya.Text.ToLower();
                if (message == null || message == ""  || keys == null || keys == "" )
            {
                    MessageBox.Show("Внимание в текста или  ключа нет. введите ключ сначало");
            }
                else
            {
               
                results.Text = code1.code(message, keys);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)//decoder
        {
                string message = content.Text.ToLower();
                string keys = keya.Text.ToLower();
            if (message == null || message == "" || keys == null || keys == "" )
            {
                MessageBox.Show("Внимание в текста или  ключа нет. введите ключ сначало");
            }
            else
            {
                results.Text = code1.decode(message, keys);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)// экспорт результата
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Текст (*.txt)|*.txt";

            if (saveFileDialog1.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.Write(results.Text);
                    sw.Close();
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)  // импорт текста
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Текст (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);

              
                    string path = fileInfo.FullName;

               
                    using (StreamReader sr = new StreamReader(path))
                    {
                         content.Text=sr.ReadToEnd();
                    }

             }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)// импорт ключа
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Текст (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);


                string path = fileInfo.FullName;

                
                using (StreamReader sr = new StreamReader(path)) { keya.Text = sr.ReadToEnd(); }
                
                   

            }

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)//импорт доки
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word (*.docx)|*.docx";
            if (openFileDialog.ShowDialog() == true)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                
                Word.Document doc = null;
                Word.Application app = new Word.Application();

                doc = app.Documents.Open(fileInfo.FullName);
                doc.Activate();
                content.Text = doc.Content.Text;

                doc.Close();
                doc = null;
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)//экспорт доки
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Word (*.docx)|*.docx";

            if (saveFileDialog1.ShowDialog() == true)
            {
                var doc = DocX.Create(saveFileDialog1.FileName);

                doc.InsertParagraph(results.Text);

                doc.Save();

                
            }
        }
    }
}
