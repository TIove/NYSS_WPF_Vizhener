using Microsoft.Win32;
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

namespace NYSS_WPF_Vizhener
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static void Upload(string str, string s = null)
        {
            if (s == default)
            {

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Текст (*.txt)|*.txt";

                if (saveFileDialog1.ShowDialog() == true)
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    using (StreamWriter sw = new StreamWriter(saveFileDialog1.OpenFile(), Encoding.GetEncoding("windows-1251")))
                    {
                        sw.Write(str);
                    }
                }
            }
            else
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (StreamWriter sw = new StreamWriter(File.OpenWrite(s), Encoding.GetEncoding("windows-1251")))
                {
                    sw.Write(str);
                }
            }
        }
        private static string GetPath(string s = null)
        {
            if (s != null)
                return s;
            var dialog = new OpenFileDialog();
            dialog.Filter = "Text(.txt)|*.txt";
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }
            return null;
        }

        public static (string, string) Download(bool isEncode, string key, string p = default)
        {
            (string, string) res = (null, null);
            if (p == default)
            {
                var path = GetPath();
                if (path != null)
                {
                    if (!isEncode)
                    {
                        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                        res.Item2 = File.ReadAllText(path, Encoding.GetEncoding("windows-1251"));
                        res.Item1 = VizhenerAlgorithm.Decode(res.Item2, key);
                    }
                    else
                    {
                        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                        res.Item1 = File.ReadAllText(path, Encoding.GetEncoding("windows-1251"));
                        res.Item2 = VizhenerAlgorithm.Decode(res.Item1, key);
                    }

                }
            }
            else
            {
                if (!isEncode)
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    res.Item2 = File.ReadAllText(p, Encoding.GetEncoding("windows-1251"));
                    res.Item1 = VizhenerAlgorithm.Decode(res.Item2, key);
                }
                else
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    res.Item1 = File.ReadAllText(p, Encoding.GetEncoding("windows-1251"));
                    res.Item2 = VizhenerAlgorithm.Decode(res.Item1, key);
                }
            }
            return res;
        }

        public bool IsEncode = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsEncode)
            {
                before.Text = VizhenerAlgorithm.Encode(after.Text, key.Text);
            } else
            {
                after.Text = VizhenerAlgorithm.Decode(before.Text, key.Text);
            }
            
        }

        private void RadioButton_Checked_Encode(object sender, RoutedEventArgs e)
        {
            decode.IsChecked = false;
            IsEncode = !IsEncode;
            if (!IsEncode)
            {
                before.IsReadOnly = false;
                after.IsReadOnly = true;
            }
            else
            {
                after.IsReadOnly = false;
                before.IsReadOnly = true;
            }
        }

        private void RadioButton_Checked_Decode(object sender, RoutedEventArgs e)
        {
            encode.IsChecked = false;
            IsEncode = !IsEncode;
            if (!IsEncode)
            {
                before.IsReadOnly = false;
                after.IsReadOnly = true;
            }
            else
            {
                after.IsReadOnly = false;
                before.IsReadOnly = true;
            }
        }

        private void Button_Click_Upload(object sender, RoutedEventArgs e)
        {
            if (!IsEncode)
                Upload(after.Text);
            else
                Upload(before.Text);
        }

        private void download_Click_Download(object sender, RoutedEventArgs e)
        {
            var res = Download(IsEncode, key.Text);
            if (res.Item1 != null && res.Item2 != null)
            {
                after.Text = res.Item1;
                before.Text = res.Item2;
            }
        }


        private void TextBox_TextChanged_Before(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_After(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_Key(object sender, TextChangedEventArgs e)
        {

        }
    }
}
