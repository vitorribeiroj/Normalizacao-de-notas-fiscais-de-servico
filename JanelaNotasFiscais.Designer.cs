namespace GeradorArquivosTSE
{
    partial class JanelaNotasFiscais
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            totalNotasFiscaisLabel = new Label();
            backBtn = new Button();
            notasFiscaisGridView = new DataGridView();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)notasFiscaisGridView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(totalNotasFiscaisLabel);
            panel1.Controls.Add(backBtn);
            panel1.Controls.Add(notasFiscaisGridView);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(932, 462);
            panel1.TabIndex = 0;
            // 
            // totalNotasFiscaisLabel
            // 
            totalNotasFiscaisLabel.AutoSize = true;
            totalNotasFiscaisLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            totalNotasFiscaisLabel.Location = new Point(12, 409);
            totalNotasFiscaisLabel.Name = "totalNotasFiscaisLabel";
            totalNotasFiscaisLabel.Size = new Size(122, 15);
            totalNotasFiscaisLabel.TabIndex = 4;
            totalNotasFiscaisLabel.Text = "Total de notas fiscais: ";
            // 
            // backBtn
            // 
            backBtn.Location = new Point(765, 405);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(158, 50);
            backBtn.TabIndex = 3;
            backBtn.Text = "Voltar";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // notasFiscaisGridView
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            notasFiscaisGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            notasFiscaisGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            notasFiscaisGridView.Location = new Point(12, 36);
            notasFiscaisGridView.Name = "notasFiscaisGridView";
            notasFiscaisGridView.RowTemplate.Height = 25;
            notasFiscaisGridView.Size = new Size(911, 361);
            notasFiscaisGridView.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(134, 15);
            label1.TabIndex = 0;
            label1.Text = "Relação de notas fiscais:";
            // 
            // JanelaNotasFiscais
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 466);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "JanelaNotasFiscais";
            Text = "Notas Fiscais";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)notasFiscaisGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView notasFiscaisGridView;
        private Label label1;
        private Button backBtn;
        private Label totalNotasFiscaisLabel;
    }
}