using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace mercearia_seu_joao.View
{
    public partial class frmLogin : Window
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        private void clicar1(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(
            "Consulte o seu gerente.",
            "Informação",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
        }

        private bool Verifica()
        {
            if (txt_InserirEmail.Text != "" && txt_InserirSenha.Password != "")
            {
                return true;
            }
            else
            {
                MessageBox.Show(
                "Preencha todos os campos!",
                "Atenção",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
                return false;
            }
        }

        private void ClicarBotao(object sender, RoutedEventArgs e)
        {
            if (Verifica() == true)
            {
                string nome = "";
                string tipoUsuario = "";
                string email = txt_InserirEmail.Text;
                string senha = txt_InserirSenha.Password;
                Usuario usuario = cUsuario.ObterUsuarioPeloEmailSenha(email, senha, tipoUsuario, nome);
                string name = usuario.nome;
                nome = name;
                string tipo = usuario.tipoUsuario;
                tipoUsuario = tipo;
                if (usuario != null)
                {

                    frmMenu frmMenu = new frmMenu(usuario, tipoUsuario, nome);
                    frmMenu.Show();
                    Close();

                }
                else
                {
                    MessageBox.Show(
                    "Dados incorretos!",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );
                }

            }
        }
    

    }
}
