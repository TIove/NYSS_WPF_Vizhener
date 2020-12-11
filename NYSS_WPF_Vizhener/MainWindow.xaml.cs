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
        private string GetPath()
        {
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

        public bool IsEncode = true;
        public MainWindow()
        {
            InitializeComponent();
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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            
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
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Текст (*.txt)|*.txt";

            if (saveFileDialog1.ShowDialog() == true)
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.OpenFile(), Encoding.GetEncoding("windows-1251")))
                {
                    if (!IsEncode)
                        sw.Write(after.Text);
                    else
                        sw.Write(before.Text);
                }
            }
        }

        private void download_Click_Download(object sender, RoutedEventArgs e)
        {
            var path = GetPath();
            if (path != null)
            {
                if (!IsEncode)
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    before.Text = File.ReadAllText(path, Encoding.GetEncoding("windows-1251"));
                    after.Text = VizhenerAlgorithm.Decode(before.Text, key.Text);
                }
                else
                {
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    after.Text = File.ReadAllText(path, Encoding.GetEncoding("windows-1251"));
                    before.Text = VizhenerAlgorithm.Decode(after.Text, key.Text);
                }
                
            }
        }

        private string StreamReader()
        {
            throw new NotImplementedException();
        }
    }
}
