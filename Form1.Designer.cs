namespace GestaoFrota
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbTipoVeiculo = new ComboBox();
            txtPlaca = new TextBox();
            txtModelo = new TextBox();
            txtValorDiaria = new TextBox();
            txtAno = new TextBox();
            txtEspecifico = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lblEspecifico = new Label();
            btnAdicionar = new Button();
            btnRemover = new Button();
            dvgFrota = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dvgFrota).BeginInit();
            SuspendLayout();
            // 
            // cmbTipoVeiculo
            // 
            cmbTipoVeiculo.FormattingEnabled = true;
            cmbTipoVeiculo.Location = new Point(8, 40);
            cmbTipoVeiculo.Margin = new Padding(2);
            cmbTipoVeiculo.Name = "cmbTipoVeiculo";
            cmbTipoVeiculo.Size = new Size(129, 23);
            cmbTipoVeiculo.TabIndex = 0;
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(8, 118);
            txtPlaca.Margin = new Padding(2);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(106, 23);
            txtPlaca.TabIndex = 1;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(137, 118);
            txtModelo.Margin = new Padding(2);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(106, 23);
            txtModelo.TabIndex = 2;
            // 
            // txtValorDiaria
            // 
            txtValorDiaria.Location = new Point(268, 118);
            txtValorDiaria.Margin = new Padding(2);
            txtValorDiaria.Name = "txtValorDiaria";
            txtValorDiaria.Size = new Size(106, 23);
            txtValorDiaria.TabIndex = 3;
            // 
            // txtAno
            // 
            txtAno.Location = new Point(397, 118);
            txtAno.Margin = new Padding(2);
            txtAno.Name = "txtAno";
            txtAno.Size = new Size(106, 23);
            txtAno.TabIndex = 4;
            // 
            // txtEspecifico
            // 
            txtEspecifico.Location = new Point(99, 195);
            txtEspecifico.Margin = new Padding(2);
            txtEspecifico.Name = "txtEspecifico";
            txtEspecifico.Size = new Size(106, 23);
            txtEspecifico.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(397, 98);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 7;
            label2.Text = "Ano do Veículo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(268, 98);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 8;
            label3.Text = "Valor da Diária";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(137, 98);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 9;
            label4.Text = "Modelo do Veículo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 98);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(93, 15);
            label5.TabIndex = 10;
            label5.Text = "Placa do Veículo";
            // 
            // lblEspecifico
            // 
            lblEspecifico.AutoSize = true;
            lblEspecifico.Location = new Point(137, 178);
            lblEspecifico.Margin = new Padding(2, 0, 2, 0);
            lblEspecifico.Name = "lblEspecifico";
            lblEspecifico.Size = new Size(0, 15);
            lblEspecifico.TabIndex = 11;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(506, 200);
            btnAdicionar.Margin = new Padding(2);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(109, 37);
            btnAdicionar.TabIndex = 12;
            btnAdicionar.Text = "Adicionar Veículo";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click_1;
            // 
            // btnRemover
            // 
            btnRemover.Location = new Point(629, 200);
            btnRemover.Margin = new Padding(2);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(130, 37);
            btnRemover.TabIndex = 13;
            btnRemover.Text = "Remover Selecionado";
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Click += btnRemover_Click_1;
            // 
            // dvgFrota
            // 
            dvgFrota.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgFrota.Location = new Point(11, 264);
            dvgFrota.Margin = new Padding(2);
            dvgFrota.Name = "dvgFrota";
            dvgFrota.RowHeadersWidth = 62;
            dvgFrota.Size = new Size(748, 260);
            dvgFrota.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 200);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 15;
            label1.Text = "Especificação:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(793, 533);
            Controls.Add(label1);
            Controls.Add(dvgFrota);
            Controls.Add(btnRemover);
            Controls.Add(btnAdicionar);
            Controls.Add(lblEspecifico);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtEspecifico);
            Controls.Add(txtAno);
            Controls.Add(txtValorDiaria);
            Controls.Add(txtModelo);
            Controls.Add(txtPlaca);
            Controls.Add(cmbTipoVeiculo);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Aplicativo de Gestão de Frota";
            ((System.ComponentModel.ISupportInitialize)dvgFrota).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbTipoVeiculo;
        private TextBox txtPlaca;
        private TextBox txtModelo;
        private TextBox txtValorDiaria;
        private TextBox txtAno;
        private TextBox txtEspecifico;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lblEspecifico;
        private Button btnAdicionar;
        private Button btnRemover;
        private DataGridView dvgFrota;
        private Label label1;
    }
}