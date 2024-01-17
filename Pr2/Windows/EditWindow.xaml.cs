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
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public Product contextProduct;
        public EditWindow(Product products)
        {
            InitializeComponent();
            contextProduct = products;

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTb.Text.Trim();
            if (name.Length > 0)
            {
                if (name == contextProduct.Name)
                {
                    if (CountTb.Text.Length > 0 )
                    {

                        int count = int.Parse(CountTb.Text.Trim());
                        
                        if(count >= contextProduct.Count) 
                        {
                            contextProduct.Count = count;
                        }
                        else if(count < contextProduct.Count) 
                        {
                        contextProduct.Count -= count;
                        }

                        App.db.SaveChanges();
                        MessageBox.Show("Saved");

                    }
                    else MessageBox.Show("Cont is null");
                }
                else MessageBox.Show("Product names do not match");
            }
            else MessageBox.Show("Name is null");
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
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
