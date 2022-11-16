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
    /// Lógica interna para frmUsuario.xaml
    /// </summary>
    public partial class frmUsuario : Window
    {
        List<Usuario> listaDeUsuarios = new List<Usuario>();
        public frmUsuario()
        {
            InitializeComponent();
            cboxTipoUsuario.Items.Add("gerente");
            cboxTipoUsuario.Items.Add("caixa");
            AtualizaDataGrid();
        }

        private void NovoUsuario(object sender, RoutedEventArgs e)
        {
            if (VerificaCampos() == true)
            {
                if (txtId.Text == "")
                {
                    AdicionaProduto();
                }
            }
            else
            {
                MessageBox.Show(
                "Não foi possível inserir o usuário.",
                "Atenção",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
            }
        }

        private void AlterarUsuario(object sender, RoutedEventArgs e)
        {
            if (txtId.Text != "" && pbSenha.Password == pbConfirmarSenha.Password)
            {
                int id = int.Parse(txtId.Text);
                MessageBoxResult result = MessageBox.Show(
                $"Deseja alterar o produto de id:{id} ?",
                "Alterar o produto",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bool foiAlterado = ConsultaUsuario.AlterarUsuario(
                        id,
                        txtNome.Text,
                        cboxTipoUsuario.Text,
                        txtEmail.Text,
                        pbSenha.Password
                    );
                    if (foiAlterado == true)
                    {
                        MessageBox.Show(
                        "Produto alterado!",
                        "Informação",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                        AtualizaDataGrid();
                        LimpaTodosOsCampos();

                    }
                    else
                    {
                        MessageBox.Show(
                        "Não foi possível alterar o produto.",
                        "Atenção",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    }
                }
            }
        }

        private void ExcluirUsuario(object sender, RoutedEventArgs e)
        {

        }

        private void LimparCampos(object sender, RoutedEventArgs e)
        {
            LimpaTodosOsCampos();
        }
        private bool VerificaCampos()
        {
            if (txtNome.Text != "" &&  cboxTipoUsuario.Text != "" && txtEmail.Text != "" && pbSenha.Password != "" && pbConfirmarSenha.Password != "")
            {
                if (pbSenha.Password == pbConfirmarSenha.Password)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(
                    "Senhas não condizem.",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void AdicionaProduto()
        {
            bool foiInserido = ConsultaUsuario.InserirUsuario(
                txtNome.Text,
                cboxTipoUsuario.Text,
                txtEmail.Text,
                pbSenha.Password);
            if (foiInserido == true)
            {
                MessageBox.Show(
                "Usuario cadastrado!",
                "Atenção",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
                LimpaTodosOsCampos();
                AtualizaDataGrid();
            }
        }
        private void AtualizaDataGrid()
        {
            listaDeUsuarios.Clear();
            listaDeUsuarios = ConsultaUsuario.ObterTodosUsuarios();
            dgvUsuarios.ItemsSource = listaDeUsuarios;
            dgvUsuarios.Items.Refresh();
        }
        private void LimpaTodosOsCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            cboxTipoUsuario.Text = "";
            txtEmail.Text = "";
            pbSenha.Password = "";
            pbConfirmarSenha.Password = "";
        }
        private void PegarItemNoGrid(object sender, MouseButtonEventArgs e)
        {
            Usuario usuario = (Usuario)dgvUsuarios.SelectedItem;
            txtId.Text = usuario.id.ToString();
            txtNome.Text = usuario.nome;
            cboxTipoUsuario.Text = usuario.tipoUsuario;
            txtEmail.Text = usuario.email;
            pbSenha.Password = usuario.senha;
            pbConfirmarSenha.Password = usuario.senha;
        }

        private void Sair(object sender, RoutedEventArgs e)
        {

        }
    }
}
