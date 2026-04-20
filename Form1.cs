using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GestaoFrota.Models;

namespace GestaoFrota
{
    public partial class Form1 : Form
    {
        // Aqui criamos um "repositório" que guarda os veículos
        private FrotaRepository _repositorio;

        // BindingSource é usado para conectar os dados (lista de veículos) à tabela da tela
        private BindingSource _bindingSource;

        public Form1()
        {
            InitializeComponent(); // Inicializa os componentes da tela

            _repositorio = new FrotaRepository(); // Cria o repositório de veículos
            _bindingSource = new BindingSource(); // Cria a fonte de dados

            ConfigurarFormulario(); // Configura a aparência e os botões da tela
            CarregarDados();        // Carrega os veículos já cadastrados
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Gestão de Frota"; // Nome da janela
            this.Size = new System.Drawing.Size(800, 600); // Tamanho da janela

            // Adiciona opções no combo box (Carro ou Caminhão)
            cmbTipoVeiculo.Items.AddRange(new string[] { "Carro", "Caminhão" });
            cmbTipoVeiculo.SelectedIndex = 0; // Seleciona "Carro" como padrão
            cmbTipoVeiculo.SelectedIndexChanged += CmbTipoVeiculo_SelectedIndexChanged; // Quando mudar a opção, chama o método

            // Liga os botões aos métodos que serão executados quando clicados
            btnAdicionar.Click += btnAdicionar_Click_1;
            btnRemover.Click += btnRemover_Click_1;

            // Configura a tabela que mostra os veículos
            dvgFrota.DataSource = _bindingSource; // Conecta a tabela à lista de veículos
            dvgFrota.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Seleção por linha inteira
            dvgFrota.ReadOnly = true; // Não permite editar direto na tabela
        }

        // Esse método muda o texto do rótulo dependendo do tipo de veículo escolhido
        private void CmbTipoVeiculo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            lblEspecifico.Text = cmbTipoVeiculo.SelectedItem?.ToString() == "Carro"
                ? "Qtd. Portas:" // Se for carro, pede quantidade de portas
                : "Capacidade Carga (Kg):"; // Se for caminhão, pede capacidade de carga
        }

        // Carrega todos os veículos cadastrados e mostra na tabela
        private void CarregarDados()
        {
            var veiculos = _repositorio.ObterTodos(); // Busca todos os veículos
            _bindingSource.DataSource = veiculos.ToList(); // Coloca na fonte de dados
            _bindingSource.ResetBindings(false); // Atualiza a tabela
        }

        // Método chamado quando clicamos em "Adicionar"
        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Pega os dados digitados pelo usuário
                string placa = txtPlaca.Text;
                string modelo = txtModelo.Text;
                int ano = int.Parse(txtAno.Text);
                decimal diaria = decimal.Parse(txtValorDiaria.Text);

                Veiculo novoVeiculo;

                // Se for carro, cria um objeto Carro
                if (cmbTipoVeiculo.SelectedItem?.ToString() == "Carro")
                {
                    int portas = int.Parse(txtEspecifico.Text);
                    novoVeiculo = new Carro(placa, modelo, ano, diaria, portas);
                }
                else // Se for caminhão, cria um objeto Caminhão
                {
                    double carga = double.Parse(txtEspecifico.Text);
                    novoVeiculo = new Caminhao(placa, modelo, ano, diaria, carga);
                }

                // Adiciona o veículo no repositório
                _repositorio.Adicionar(novoVeiculo);

                // Atualiza a tabela e limpa os campos
                CarregarDados();
                LimparCampos();

                // Mostra mensagem confirmando o cadastro e o custo de 5 dias
                MessageBox.Show($"Veículo adicionado! Custo p/ 5 dias: {novoVeiculo.CalcularCustoAluguel(5):c}");
            }
            catch (Exception ex)
            {
                // Se der erro, mostra mensagem
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método chamado quando clicamos em "Remover"
        private void btnRemover_Click_1(object? sender, EventArgs e)
        {
            // Verifica se algum veículo está selecionado na tabela
            if (dvgFrota.CurrentRow?.DataBoundItem is Veiculo veiculoSelecionado)
            {
                // Remove o veículo pelo ID
                _repositorio.Remover(veiculoSelecionado.Id);
                CarregarDados(); // Atualiza a tabela
            }
            else
            {
                // Se não tiver nada selecionado, avisa o usuário
                MessageBox.Show("Selecione um veículo para remover.");
            }
        }

        // Limpa os campos de texto depois de adicionar um veículo
        private void LimparCampos()
        {
            txtPlaca.Clear();
            txtAno.Clear();
            txtEspecifico.Clear();
            txtModelo.Clear();
            txtValorDiaria.Clear();
            txtPlaca.Focus(); // Coloca o cursor de volta no campo Placa
        }
    }
}
