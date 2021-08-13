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
using System.Text.RegularExpressions;

namespace FN.Framtal.Presentation._2004.View
{
    /// <summary>
    /// Interaction logic for Chapter1.xaml
    /// </summary>
    public partial class RSK0101_01View : UserControl
    {

        List<KeyValuePair<TextBox , TextBox>> lstYouth; 

        public RSK0101_01View()
        {
            InitializeComponent();
            lstYouth = new List<KeyValuePair<TextBox , TextBox>>();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            lstYouth.Clear();
            lstYouth.Add(new KeyValuePair<TextBox , TextBox>(this.youthnum1, this.youthtext1));
        }

        private void onYouthText(object sender, KeyEventArgs e)
        {
            if (((e.Key == Key.N && Keyboard.IsKeyDown(Key.LeftCtrl)) || (e.Key == Key.Enter)) && ((TextBox)sender).Name == ("youthtext" + lstYouth.Count.ToString()))
            {
                TextBox tempYouthNum = new TextBox();
                TextBox tempYouthText = new TextBox();

                tempYouthNum.Name = "youthnum" + (lstYouth.Count + 1).ToString();
                tempYouthText.Name = "youthtext" + (lstYouth.Count + 1).ToString();

                tempYouthNum.FontSize = 8;
                tempYouthText.FontSize = 8;
                tempYouthNum.Height = 22;
                tempYouthText.Height = 22;

                tempYouthText.KeyDown += new KeyEventHandler(onYouthText);
                lstYouth.Add(new KeyValuePair<TextBox, TextBox>(tempYouthNum , tempYouthText));

                youthTextPane.Children.Add(tempYouthText);
                youthNumPane.Children.Add(tempYouthNum);

                tempYouthNum.Focus();
            }
        }

        private void TempYouthText_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
