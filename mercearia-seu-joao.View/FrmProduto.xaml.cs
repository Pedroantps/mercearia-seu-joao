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

namespace mercearia_seu_joao.View
{
    /// <summary>
    /// Lógica interna para FrmProduto.xaml
    /// </summary>
    public partial class FrmProduto : Window
    {
        List<Produto> listaDeProdutos = new List<Produto>();
        public FrmProduto()
        {
            InitializeComponent();
            AtualizaDataGrid();
        }

        private bool VerificaCampos()
        {
            if(txtNome.Text != "" && txtQtd.Text != "" && txtprecoUnitario.Text != "" && txtFornecedor.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void NovoProduto(object sender, RoutedEventArgs e)
        {
            if(VerificaCampos() == true)
            {
                if(txtId.Text == "")
                {
                    AdicionaProduto();
                }
                
            }
            else
            {
                MessageBox.Show(
                "Não foi possível inserir o produto.",
                "Atenção",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
            }
        }

        private void AlterarProduto(object sender, RoutedEventArgs e)
        {
            if(txtId.Text != "")
            {
                int id = int.Parse(txtId.Text);
                MessageBoxResult result = MessageBox.Show(
                $"Deseja alterar o produto de id:{id} ?",
                "Alterar o produto",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
                if(result == MessageBoxResult.Yes)
                {
                    bool foiAlterado = ConsultaProduto.AlterarProduto(
                        id,
                        txtNome.Text,
                        int.Parse(txtQtd.Text),
                        float.Parse(txtprecoUnitario.Text),
                        txtFornecedor.Text
                    );
                    if(foiAlterado == true)
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

        private void ExcluirProduto(object sender, RoutedEventArgs e)
        {
            if (txtId.Text != "")
            {
                int id = int.Parse(txtId.Text);
                string dataHoraExclusao = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                MessageBoxResult result = MessageBox.Show(
                $"Deseja excluir o produto de id:{id} ?",
                "Excluir o produto",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bool foiExcluido = ConsultaProduto.ExcluirProduto(id, dataHoraExclusao);
                    if (foiExcluido == true)
                    {
                        MessageBox.Show(
                        "Produto excluído!",
                        "Informação",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                        AtualizaDataGrid();
                        LimpaTodosOsCampos();

                    }
                    else
                    {
                        MessageBox.Show(
                        "Não foi possível excluir o produto.",
                        "Atenção",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    }
                }
            }
        }
    

        private void LimparCampos(object sender, RoutedEventArgs e)
        {
            LimpaTodosOsCampos();
        }

        private void PegarItemNoGrid(object sender, MouseButtonEventArgs e)
        {
            Produto produto = (Produto)dgvProdutos.SelectedItem;
            txtId.Text = produto.id.ToString();
            txtNome.Text = produto.nome;
            txtQtd.Text = produto.quantidade.ToString();
            txtprecoUnitario.Text = produto.precoUnitario.ToString();
            txtFornecedor.Text = produto.fornecedor; 
        }
        private void AdicionaProduto()
        {
            string dataHoraInclusao = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            bool foiInserido = ConsultaProduto.InserirProduto(
                txtNome.Text,
                int.Parse(txtQtd.Text),
                float.Parse(txtprecoUnitario.Text),
                txtFornecedor.Text,
                dataHoraInclusao);
            if(foiInserido == true)
            {
                MessageBox.Show(
                "Produto cadastrado!",
                "Atenção",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
                LimpaTodosOsCampos();
                AtualizaDataGrid();
            }
        }
        private void AtualizaDataGrid()
        {
            listaDeProdutos.Clear();
            listaDeProdutos = ConsultaProduto.ObterTodosProdutos();
            dgvProdutos.ItemsSource = listaDeProdutos;
            dgvProdutos.Items.Refresh();
        }
        private void LimpaTodosOsCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtQtd.Text = "";
            txtprecoUnitario.Text = "";
            txtFornecedor.Text = "";
        }

        private void Sair(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
