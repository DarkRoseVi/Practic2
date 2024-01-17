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
    /// Логика взаимодействия для DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        public Product contextProduct;
        public DeleteWindow(Product product)
        {
            InitializeComponent();
           contextProduct = product;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTb.Text.Trim();
            if (name.Length > 0)
            {
                if (name == contextProduct.Name)
                {
                    App.db.Product.Remove(contextProduct);
                    App.db.SaveChanges();
                    MessageBox.Show("Product is delete");
                    DialogResult = true;
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
