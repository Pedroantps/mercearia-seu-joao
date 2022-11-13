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

namespace mercearia_seu_joao.View
{
    /// <summary>
    /// Lógica interna para frmMenu.xaml
    /// </summary>
    public partial class frmMenu : Window
    {
        Usuario usuario;
        public frmMenu()
        {
            InitializeComponent();
        }
        public frmMenu(Usuario usuarioLogado)
        {
            InitializeComponent();
            usuario = usuarioLogado;
        }


        private void Button_Produto(object sender, RoutedEventArgs e)
        {

            FrmProduto frmProduto = new FrmProduto();
            frmProduto.Show();

        }
        private void Button_Usuario(object sender, RoutedEventArgs e)
        {
            frmUsuario frmUsuario = new frmUsuario();
            frmUsuario.Show();
        }
        private void Button_Venda(object sender, RoutedEventArgs e)
        {
            frmVenda frmVenda = new frmVenda();
            frmVenda.Show();
        }

        private void Button_Sair(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string datadehoje = DateTime.Now.ToString(" d MMMM 'de' yyyy");
            txtNome.Text = $"Olá  , hoje é dia {datadehoje}.";
        }
    }
}
