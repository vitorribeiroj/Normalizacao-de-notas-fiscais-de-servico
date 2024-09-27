using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorArquivosTSE
{
    public partial class JanelaNotasFiscais : Form
    {
        public JanelaNotasFiscais(List<NotaFiscalServico> notasFiscais)
        {
            InitializeComponent();

            CarregarNotas(notasFiscais);
        }

        private void CarregarNotas(List<NotaFiscalServico> notasFiscais)
        {
            List<NotaFiscalViewModel> listaDeNotas = notasFiscais.Select(nota => new NotaFiscalViewModel
            {
                ModeloNotaFiscal = nota.ModeloNotaFiscal.GetDescription(),
                Numero = nota.Numero.ToString(),
                Serie = nota.Serie,
                CodigoVerificacaoConsultaMunicipal = nota.CodigoVerificacaoConsultaMunicipal,
                ChaveAcessoConsultaNacional = nota.ChaveAcessoConsultaNacional,
                DataEmissao = nota.DataEmissao,
                SituacaoNotaFiscal = nota.SituacaoNotaFiscal.GetDescription(),
                CNPJ_Emitente = nota.CNPJ_Emitente.ToString(),
                CNPJ_Destinatario = nota.CNPJ_Destinatario.ToString(),
                NaturezaOperacao = nota.NaturezaOperacao.GetDescription(),
                ValorTotalDaNota = nota.ValorTotalDaNota,
                NumeroNotaFiscalSubstituida = nota.NumeroNotaFiscalSubstituida
            })
                .ToList();

            notasFiscaisGridView.DataSource = listaDeNotas;

            ConfigurarGridViewNotasFiscais();

            totalNotasFiscaisLabel.Text = $"Total de notas fiscais: {listaDeNotas.Count}";

        }

        private void ConfigurarGridViewNotasFiscais()
        {
            notasFiscaisGridView.Columns["ModeloNotaFiscal"].HeaderText = "Modelo";
            notasFiscaisGridView.Columns["Numero"].HeaderText = "Número";
            notasFiscaisGridView.Columns["Serie"].HeaderText = "Série";
            notasFiscaisGridView.Columns["CodigoVerificacaoConsultaMunicipal"].HeaderText = "Código de verificação";
            notasFiscaisGridView.Columns["ChaveAcessoConsultaNacional"].HeaderText = "Chave de acesso";
            notasFiscaisGridView.Columns["DataEmissao"].HeaderText = "Data de Emissão";
            notasFiscaisGridView.Columns["SituacaoNotaFiscal"].HeaderText = "Situação";
            notasFiscaisGridView.Columns["CNPJ_Emitente"].HeaderText = "CNPJ do prestador";
            notasFiscaisGridView.Columns["CNPJ_Destinatario"].HeaderText = "CNPJ do destinatário";
            notasFiscaisGridView.Columns["NaturezaOperacao"].HeaderText = "Natureza da operação";
            notasFiscaisGridView.Columns["ValorTotalDaNota"].HeaderText = "Valor total";
            notasFiscaisGridView.Columns["NotaFiscalSubstituida"].HeaderText = "Nota fiscal substituída";
            notasFiscaisGridView.Columns["NumeroNotaFiscalSubstituida"].Visible = false;

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
