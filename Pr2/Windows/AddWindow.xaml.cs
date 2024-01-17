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
using System.Windows.Shapes;
using Pr2.Models;

namespace Pr2.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {

            string name = NameTb.Text.Trim();
            if (name.Length > 0)
            {
                string count = CountTb.Text.Trim();
                if (count.Length > 0)
                {
                    string cost = CountTb.Text.Trim();
                    if (cost.Length > 0)
                    {
                        decimal costdecimal = decimal.Parse(cost);
                      
                          Product newproduct = App.db.Product.Add( new Product
                            {
                                Count = int.Parse(count),
                                Name = name,
                                Cost = costdecimal
                            });
                        
                        var product = App.db.Product.FirstOrDefault(x=>x.Name == newproduct.Name && x.Cost == costdecimal);
                        if (product == null)
                        {
                            App.db.SaveChanges();
                            MessageBox.Show("Product addwd");
                        }
                        else MessageBox.Show("The product already exists ");
                    }
                    else MessageBox.Show(" Cost is null");
                }
                else MessageBox.Show("Count is null");
            }
            else MessageBox.Show("Name is null");
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void CostTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && (e.Text != ".")) 
            {
                e.Handled = true;
            }
        }

        private void CountTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void NameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
