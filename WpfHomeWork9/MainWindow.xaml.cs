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

namespace WpfHomeWork9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            menuItemLight.IsChecked = true;
            menuItemDark.IsChecked = false;
            Uri uri = new Uri("Light.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)     //обработчик команды открыть
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)     //обработчик команды сохранить
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
                MessageBox.Show("Файл сохранен");
            }
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)        //обработчик команды закрыть
        {
            Application.Current.Shutdown();
        }

        private void HelpExecuted(object sender, ExecutedRoutedEventArgs e)     //обработчик команды справка
        {
            MessageBox.Show("Справки по телефону!", "¯\\_(ツ)_/¯", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BoldExecuted(object sender, ExecutedRoutedEventArgs e)     //обработчик команды Bold
        {
            FontWeight fontWeight = textBox.FontWeight;
            if (textBox != null && fontWeight != FontWeights.Bold)
            {
                textBox.FontWeight = FontWeights.Bold;
            }
            else if (textBox != null && fontWeight == FontWeights.Bold)
            {
                textBox.FontWeight = FontWeights.Normal;
            }
        }

        private void ItalicExecuted(object sender, ExecutedRoutedEventArgs e)       //обработчик команды Italic
        {
            FontStyle fontStyle = textBox.FontStyle;
            if (textBox != null && fontStyle != FontStyles.Italic)
            {
                textBox.FontStyle = FontStyles.Italic;
            }
            else if (textBox != null && fontStyle == FontStyles.Italic)
            {
                textBox.FontStyle = FontStyles.Normal;
            }
        }

        private void UnderlineExecuted(object sender, ExecutedRoutedEventArgs e)        //обработчик команды Underline
        {
            TextDecorationCollection fontDecoration = textBox.TextDecorations;
            if (textBox != null && fontDecoration != TextDecorations.Underline)
            {
                textBox.TextDecorations = TextDecorations.Underline;
            }
            else if (textBox != null && fontDecoration == TextDecorations.Underline)
            {
                textBox.TextDecorations = null;
            }
        }

        private void RedExecuted(object sender, ExecutedRoutedEventArgs e)      //обработчик команды Red
        {
            if (textBox != null && textBox.Foreground != Brushes.Red)
            {
                textBox.Foreground = Brushes.Red;
            }
        }

        private void BlackExecuted(object sender, ExecutedRoutedEventArgs e)        //обработчик Black
        {
            if (textBox != null && textBox.Foreground != Brushes.Black)
            {
                textBox.Foreground = Brushes.Black;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)      //обработчик события SelectionChanged на ComboBox
        {
            string fontName = (sender as ComboBox).SelectedItem as string;
            if (textBox != null)
                textBox.FontFamily = new FontFamily(fontName);
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)        //обработчик события SelectionChanged на ComboBox
        {
            int fontSize = Convert.ToInt32((sender as ComboBox).SelectedItem as string);
            if (textBox != null)
                textBox.FontSize = fontSize;
        }

        private void LeftExecuted(object sender, ExecutedRoutedEventArgs e)        //обработчик команды Left
        {
            if (textBox != null)
                textBox.TextAlignment = TextAlignment.Left;
        }

        private void CenterExecuted(object sender, ExecutedRoutedEventArgs e)        //обработчик команды Center
        {
            if (textBox != null)
                textBox.TextAlignment = TextAlignment.Center;
        }

        private void RightExecuted(object sender, ExecutedRoutedEventArgs e)        //обработчик команды Right
        {
            if (textBox != null)
                textBox.TextAlignment = TextAlignment.Right;
        }

        private void JustifyExecuted(object sender, ExecutedRoutedEventArgs e)        //обработчик команды Justify
        {
            if (textBox != null)
                textBox.TextAlignment = TextAlignment.Justify;
        }

        private void LightExecuted(object sender, ExecutedRoutedEventArgs e)
        {

            menuItemLight.IsChecked = true;
            menuItemDark.IsChecked = false;
            Uri uri = new Uri("Light.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);

        }

        private void DarkExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            menuItemDark.IsChecked = true;
            menuItemLight.IsChecked = false;
            Uri uri = new Uri("Dark.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }
    }

}
