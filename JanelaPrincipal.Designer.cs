namespace GeradorArquivosTSE
{
    partial class JanelaPrincipal
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
            label1 = new Label();
            cnpjEnteInput = new TextBox();
            label2 = new Label();
            label3 = new Label();
            numeroNotifUniEleitoralInput = new TextBox();
            panel1 = new Panel();
            addArquivoBtn = new Button();
            removerArquivoBtn = new Button();
            label9 = new Label();
            listBoxArquivosCarregados = new ListBox();
            processarArquivoNotasFiscaisBtn = new Button();
            verNotasBtn = new Button();
            label8 = new Label();
            consultaMunicipalOption = new RadioButton();
            consultaNacionalOption = new RadioButton();
            sairBtn = new Button();
            gerarArquivoValidacaoBtn = new Button();
            label6 = new Label();
            numeroLoteRemessaCorrecaoInput = new TextBox();
            label7 = new Label();
            numeroRemessaCorrecaoInput = new TextBox();
            label5 = new Label();
            numeroLoteRemessaInput = new TextBox();
            label4 = new Label();
            numeroRemessaInput = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(98, 21);
            label1.Name = "label1";
            label1.Size = new Size(258, 15);
            label1.TabIndex = 0;
            label1.Text = "GERADOR DE ARQUIVO DE NFSe PARA O TSE";
            // 
            // cnpjEnteInput
            // 
            cnpjEnteInput.Location = new Point(12, 97);
            cnpjEnteInput.Name = "cnpjEnteInput";
            cnpjEnteInput.Size = new Size(187, 23);
            cnpjEnteInput.TabIndex = 1;
            cnpjEnteInput.Text = "18.715.383/0001-40";
            // 
            // label2
            // 
            label2.Location = new Point(12, 60);
            label2.Name = "label2";
            label2.Size = new Size(84, 34);
            label2.TabIndex = 2;
            label2.Text = "CNPJ do ente (obrigatório):";
            // 
            // label3
            // 
            label3.Location = new Point(258, 62);
            label3.Name = "label3";
            label3.Size = new Size(187, 32);
            label3.TabIndex = 4;
            label3.Text = "Nº da notificação enviada pela Unidade Eleitoral (opcional)";
            // 
            // numeroNotifUniEleitoralInput
            // 
            numeroNotifUniEleitoralInput.Location = new Point(258, 97);
            numeroNotifUniEleitoralInput.MaxLength = 10;
            numeroNotifUniEleitoralInput.Name = "numeroNotifUniEleitoralInput";
            numeroNotifUniEleitoralInput.Size = new Size(187, 23);
            numeroNotifUniEleitoralInput.TabIndex = 3;
            numeroNotifUniEleitoralInput.KeyPress += numeroNotifUniEleitoralInput_KeyPress;
            // 
            // panel1
            // 
            panel1.Controls.Add(addArquivoBtn);
            panel1.Controls.Add(removerArquivoBtn);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(listBoxArquivosCarregados);
            panel1.Controls.Add(processarArquivoNotasFiscaisBtn);
            panel1.Controls.Add(verNotasBtn);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(consultaMunicipalOption);
            panel1.Controls.Add(consultaNacionalOption);
            panel1.Controls.Add(sairBtn);
            panel1.Controls.Add(gerarArquivoValidacaoBtn);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(numeroLoteRemessaCorrecaoInput);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(numeroRemessaCorrecaoInput);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(numeroLoteRemessaInput);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(numeroRemessaInput);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(numeroNotifUniEleitoralInput);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cnpjEnteInput);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(6, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(462, 632);
            panel1.TabIndex = 5;
            // 
            // addArquivoBtn
            // 
            addArquivoBtn.Location = new Point(307, 378);
            addArquivoBtn.Name = "addArquivoBtn";
            addArquivoBtn.Size = new Size(139, 36);
            addArquivoBtn.TabIndex = 24;
            addArquivoBtn.Text = "Adicionar arquivo";
            addArquivoBtn.UseVisualStyleBackColor = true;
            addArquivoBtn.Click += addArquivoBtn_Click;
            // 
            // removerArquivoBtn
            // 
            removerArquivoBtn.Location = new Point(307, 420);
            removerArquivoBtn.Name = "removerArquivoBtn";
            removerArquivoBtn.Size = new Size(139, 36);
            removerArquivoBtn.TabIndex = 23;
            removerArquivoBtn.Text = "Remover arquivo";
            removerArquivoBtn.UseVisualStyleBackColor = true;
            removerArquivoBtn.Click += removerArquivoBtn_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(13, 356);
            label9.Name = "label9";
            label9.Size = new Size(201, 15);
            label9.TabIndex = 22;
            label9.Text = "Arquivos de notas fiscais carregados:";
            // 
            // listBoxArquivosCarregados
            // 
            listBoxArquivosCarregados.FormattingEnabled = true;
            listBoxArquivosCarregados.HorizontalScrollbar = true;
            listBoxArquivosCarregados.ItemHeight = 15;
            listBoxArquivosCarregados.Location = new Point(12, 378);
            listBoxArquivosCarregados.Name = "listBoxArquivosCarregados";
            listBoxArquivosCarregados.Size = new Size(288, 79);
            listBoxArquivosCarregados.TabIndex = 21;
            // 
            // processarArquivoNotasFiscaisBtn
            // 
            processarArquivoNotasFiscaisBtn.Location = new Point(11, 474);
            processarArquivoNotasFiscaisBtn.Name = "processarArquivoNotasFiscaisBtn";
            processarArquivoNotasFiscaisBtn.Size = new Size(210, 65);
            processarArquivoNotasFiscaisBtn.TabIndex = 13;
            processarArquivoNotasFiscaisBtn.Text = "Processar arquivos";
            processarArquivoNotasFiscaisBtn.UseVisualStyleBackColor = true;
            processarArquivoNotasFiscaisBtn.Click += processarArquivoNotasFiscaisBtn_Click;
            // 
            // verNotasBtn
            // 
            verNotasBtn.Location = new Point(235, 474);
            verNotasBtn.Name = "verNotasBtn";
            verNotasBtn.Size = new Size(210, 65);
            verNotasBtn.TabIndex = 19;
            verNotasBtn.Text = "Visualizar notas fiscais";
            verNotasBtn.UseVisualStyleBackColor = true;
            verNotasBtn.Click += verNotasBtn_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 300);
            label8.Name = "label8";
            label8.Size = new Size(227, 15);
            label8.TabIndex = 18;
            label8.Text = "Ambiente padrão para consulta de NFS-e:";
            // 
            // consultaMunicipalOption
            // 
            consultaMunicipalOption.AutoSize = true;
            consultaMunicipalOption.Checked = true;
            consultaMunicipalOption.Location = new Point(12, 321);
            consultaMunicipalOption.Name = "consultaMunicipalOption";
            consultaMunicipalOption.Size = new Size(78, 19);
            consultaMunicipalOption.TabIndex = 17;
            consultaMunicipalOption.TabStop = true;
            consultaMunicipalOption.Text = "Municipal";
            consultaMunicipalOption.UseVisualStyleBackColor = true;
            // 
            // consultaNacionalOption
            // 
            consultaNacionalOption.AutoSize = true;
            consultaNacionalOption.Location = new Point(98, 321);
            consultaNacionalOption.Name = "consultaNacionalOption";
            consultaNacionalOption.Size = new Size(72, 19);
            consultaNacionalOption.TabIndex = 16;
            consultaNacionalOption.Text = "Nacional";
            consultaNacionalOption.UseVisualStyleBackColor = true;
            // 
            // sairBtn
            // 
            sairBtn.Location = new Point(235, 545);
            sairBtn.Name = "sairBtn";
            sairBtn.Size = new Size(210, 65);
            sairBtn.TabIndex = 15;
            sairBtn.Text = "Sair";
            sairBtn.UseVisualStyleBackColor = true;
            sairBtn.Click += fecharBtn_Click;
            // 
            // gerarArquivoValidacaoBtn
            // 
            gerarArquivoValidacaoBtn.Location = new Point(11, 545);
            gerarArquivoValidacaoBtn.Name = "gerarArquivoValidacaoBtn";
            gerarArquivoValidacaoBtn.Size = new Size(210, 65);
            gerarArquivoValidacaoBtn.TabIndex = 14;
            gerarArquivoValidacaoBtn.Text = "Gerar arquivo para validação no FiscalizaJE";
            gerarArquivoValidacaoBtn.UseVisualStyleBackColor = true;
            gerarArquivoValidacaoBtn.Click += gerarArquivoValidacaoBtn_Click;
            // 
            // label6
            // 
            label6.Location = new Point(258, 220);
            label6.Name = "label6";
            label6.Size = new Size(202, 32);
            label6.TabIndex = 12;
            label6.Text = "Nº do lote da remessa de correção (opcional)";
            // 
            // numeroLoteRemessaCorrecaoInput
            // 
            numeroLoteRemessaCorrecaoInput.Location = new Point(258, 255);
            numeroLoteRemessaCorrecaoInput.MaxLength = 4;
            numeroLoteRemessaCorrecaoInput.Name = "numeroLoteRemessaCorrecaoInput";
            numeroLoteRemessaCorrecaoInput.Size = new Size(187, 23);
            numeroLoteRemessaCorrecaoInput.TabIndex = 11;
            // 
            // label7
            // 
            label7.Location = new Point(12, 220);
            label7.Name = "label7";
            label7.Size = new Size(187, 32);
            label7.TabIndex = 10;
            label7.Text = "Nº da remessa de correção  Formato AAAAMM (opcional)";
            // 
            // numeroRemessaCorrecaoInput
            // 
            numeroRemessaCorrecaoInput.Location = new Point(12, 255);
            numeroRemessaCorrecaoInput.MaxLength = 6;
            numeroRemessaCorrecaoInput.Name = "numeroRemessaCorrecaoInput";
            numeroRemessaCorrecaoInput.Size = new Size(187, 23);
            numeroRemessaCorrecaoInput.TabIndex = 9;
            // 
            // label5
            // 
            label5.Location = new Point(258, 141);
            label5.Name = "label5";
            label5.Size = new Size(159, 32);
            label5.TabIndex = 8;
            label5.Text = "Nº do lote de remessa (obrigatório)";
            // 
            // numeroLoteRemessaInput
            // 
            numeroLoteRemessaInput.Location = new Point(258, 176);
            numeroLoteRemessaInput.MaxLength = 4;
            numeroLoteRemessaInput.Name = "numeroLoteRemessaInput";
            numeroLoteRemessaInput.Size = new Size(187, 23);
            numeroLoteRemessaInput.TabIndex = 7;
            // 
            // label4
            // 
            label4.Location = new Point(12, 141);
            label4.Name = "label4";
            label4.Size = new Size(187, 32);
            label4.TabIndex = 6;
            label4.Text = "Nº da remessa                           Formato AAAAMM (obrigatório)";
            // 
            // numeroRemessaInput
            // 
            numeroRemessaInput.Location = new Point(12, 176);
            numeroRemessaInput.MaxLength = 6;
            numeroRemessaInput.Name = "numeroRemessaInput";
            numeroRemessaInput.Size = new Size(187, 23);
            numeroRemessaInput.TabIndex = 5;
            // 
            // JanelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 630);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "JanelaPrincipal";
            Text = "Gerador de Arquivo para FiscalizaJE";
            Load += JanelaPrincipal_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox cnpjEnteInput;
        private Label label2;
        private Label label3;
        private TextBox numeroNotifUniEleitoralInput;
        private Panel panel1;
        private Label label4;
        private TextBox numeroRemessaInput;
        private Label label5;
        private TextBox numeroLoteRemessaInput;
        private Label label6;
        private TextBox numeroLoteRemessaCorrecaoInput;
        private Label label7;
        private TextBox numeroRemessaCorrecaoInput;
        private Button processarArquivoNotasFiscaisBtn;
        private Button gerarArquivoValidacaoBtn;
        private Button sairBtn;
        private Label label8;
        private RadioButton consultaMunicipalOption;
        private RadioButton consultaNacionalOption;
        private Button verNotasBtn;
        private ListBox listBoxArquivosCarregados;
        private Label label9;
        private Button removerArquivoBtn;
        private Button addArquivoBtn;
    }
}