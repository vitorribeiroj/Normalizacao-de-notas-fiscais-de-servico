using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Globalization;
using static GeradorArquivosTSE.Utils;

namespace GeradorArquivosTSE
{
    public class NotaFiscalServico
    {
        private int Registro { get { return 2; } }
        private string UF { get; set; } = "MG";
        public long CNPJ_Destinatario { get; set; }
        public TipoPessoa TipoPessoaEmitente { get; set; } = TipoPessoa.J;
        public long CNPJ_Emitente { get; set; }
        public NaturezaOperacao NaturezaOperacao { get; set; } = NaturezaOperacao.SERV;
        public ModeloNotaFiscal ModeloNotaFiscal { get; set; } = ModeloNotaFiscal.COD00;
        public DateTime DataEmissao { get; set; }
        public string Serie { get; set; } = "";
        public long Numero { get; set; }
        public SituacaoNotaFiscal SituacaoNotaFiscal { get; set; }
        public long NumeroNotaFiscalSubstituida { get; set; } = 0;
        public double ValorTotalDaNota { get; set; } = 0;
        public string ChaveAcessoConsultaNacional { get; set; }
        public string CodigoVerificacaoConsultaMunicipal { get; set; }
        public string UrlConsultaNacional { get; set; } = "https://www.nfse.gov.br/consultapublica";
        public string UrlConsultaMunicipal { get; set; } = "https://bhissdigital.pbh.gov.br/nfse/pages/exibicaoNFS-e.jsf";
        public bool UsarConsultaNacional { get; set; } = false;

        public string CriarDetalheNotaFiscalNormalizado()
        {
            string dadosConsulta = "";

            if (UsarConsultaNacional)
            {
                dadosConsulta = $"{Utils.PreencherComEspacoEmBrancoDireita(this.ChaveAcessoConsultaNacional, 50)}" +
                                $"{Utils.PreencherComEspacoEmBrancoDireita(this.UrlConsultaNacional, 250)}";
            }
            else
            {
                dadosConsulta = $"{Utils.PreencherComEspacoEmBrancoDireita(this.CodigoVerificacaoConsultaMunicipal, 50)}" +
                                $"{Utils.PreencherComEspacoEmBrancoDireita(this.UrlConsultaMunicipal, 250)}";
            }

            return $"{this.Registro}" +
                   $"{this.UF}" +
                   $"{Utils.CompletarComZerosEsquerda(this.CNPJ_Destinatario.ToString(), 14)}" +
                   $"{this.TipoPessoaEmitente}" +
                   $"{Utils.CompletarComZerosEsquerda(this.CNPJ_Emitente.ToString(), 14)}" +
                   $"{this.NaturezaOperacao}" +
                   $"{this.ModeloNotaFiscal.ToString().Substring(3)}" +
                   $"{this.DataEmissao.ToString("ddMMyyyy")}" +
                   $"{Utils.PreencherComEspacoEmBrancoDireita(this.Serie, 3)}" +
                   $"{Utils.CompletarComZerosEsquerda(this.Numero.ToString(), 15)}" +
                   $"{this.SituacaoNotaFiscal}" +
                   $"{Utils.CompletarComZerosEsquerda(this.NumeroNotaFiscalSubstituida.ToString(), 15)}" +
                   $"{Utils.CompletarComZerosEsquerda(this.ValorTotalDaNota.ToString().Replace(".", "").Replace(",", ""), 17)}" +
                   dadosConsulta;
        }

        public static List<NotaFiscalServico> ListarNotasFiscaisDeArquivo(string filePath)
        {
            DataTable tabelaDeNotas = LerCsvParaDataTable(filePath);

            List<NotaFiscalServico> NotasFiscais = new List<NotaFiscalServico>();

            foreach (DataRow row in tabelaDeNotas.Rows)
            {
                NotaFiscalServico nota = new NotaFiscalServico();

                nota.CNPJ_Destinatario = CNPJ.ParsearCNPJ(row["CNPJ_Tomador"].ToString().Replace("\"", "").Trim());
                nota.Numero = long.Parse(row["Numero"].ToString().Replace("\"", "").Trim());
                nota.DataEmissao = DateTime.Parse(row["DataEmissao"].ToString().Replace("\"", "").Trim());
                nota.ValorTotalDaNota = double.Parse(row["ValorServicos"].ToString().Replace("\"", "").Trim(), CultureInfo.InvariantCulture);
                nota.CNPJ_Emitente = CNPJ.ParsearCNPJ(row["CNPJ_Prestador"].ToString().Replace("\"", "").Trim());

                var serie = row["Serie"].ToString();

                if (!VerificarCampoNuloOuVazio(serie)) nota.Serie = serie;

                if (row["SituacaoDocumento"].ToString().Replace("\"", "").Trim() == "Normal")
                {
                    nota.SituacaoNotaFiscal = SituacaoNotaFiscal.A;
                }
                else
                {
                    nota.SituacaoNotaFiscal = SituacaoNotaFiscal.C;
                }

                if (!VerificarCampoNuloOuVazio(row["NFSeSubstituida"].ToString().Replace("\"", "").Trim()))
                    nota.NumeroNotaFiscalSubstituida = long.Parse(row["NFSeSubstituida"].ToString().Replace("\"", "").Trim());

                nota.ChaveAcessoConsultaNacional = Regex.Replace(row["ChaveAcesso"].ToString().Replace("\"", "").Trim(), @"\D", "");

                nota.CodigoVerificacaoConsultaMunicipal = row["CodigoVerificacao"].ToString().Replace("\"", "").Trim();

                if (VerificarCampoNuloOuVazio(nota.CodigoVerificacaoConsultaMunicipal))
                {
                    nota.UsarConsultaNacional = true;
                }

                NotasFiscais.Add(nota);

            }

            return NotasFiscais;
        }

    }

    public enum TipoPessoa
    {
        /// <summary>
        /// Física
        /// </summary>
        [Description("Física")]
        F,

        /// <summary>
        /// Jurídica
        /// </summary>
        [Description("Jurídica")]
        J
    }

    public enum NaturezaOperacao
    {
        /// <summary>
        /// Venda
        /// </summary>
        [Description("Venda")]
        VEND,

        /// <summary>
        /// Serviço
        /// </summary>
        [Description("Serviço")]
        SERV,

        /// <summary>
        /// Doação
        /// </summary>
        [Description("Doação")]
        DOAC,

        /// <summary>
        /// Devolução
        /// </summary>
        [Description("Devolução")]
        DEVO
    }

    public enum ModeloNotaFiscal
    {
        /// <summary>
        /// Não existe número de modelo de NFS-e
        /// </summary>
        [Description("NFS-e")]
        COD00,

        /// <summary>
        /// Nota Fiscal
        /// </summary>
        [Description("Nota Fiscal")]
        COD01,

        /// <summary>
        /// Nota Fiscal Avulsa
        /// </summary>
        [Description("Nota Fiscal Avulsa")]
        COD1B,

        /// <summary>
        /// Nota Fiscal de Venda a Consumidor
        /// </summary>
        [Description("Nota Fiscal de Venda a Consumidor")]
        COD02,

        /// <summary>
        /// Cupom Fiscal emitido por ECF
        /// </summary>
        [Description("Cupom Fiscal emitido por ECF")]
        COD2D,

        /// <summary>
        /// Bilhete de Passagem emitido por ECF
        /// </summary>
        [Description("Bilhete de Passagem emitido por ECF")]
        COD2E,

        /// <summary>
        /// Nota Fiscal de Produtor
        /// </summary>
        [Description("Nota Fiscal de Produtor")]
        COD04,

        /// <summary>
        /// Nota Fiscal/Conta de Energia Elétrica
        /// </summary>
        [Description("Nota Fiscal/Conta de Energia Elétrica")]
        COD06,

        /// <summary>
        /// Nota Fiscal de Serviço de Transporte
        /// </summary>
        [Description("Nota Fiscal de Serviço de Transporte")]
        COD07,

        /// <summary>
        /// Conhecimento de Transporte Rodoviário de Cargas
        /// </summary>
        [Description("Conhecimento de Transporte Rodoviário de Cargas")]
        COD08,

        /// <summary>
        /// Conhecimento de Transporte de Cargas Avulso
        /// </summary>
        [Description("Conhecimento de Transporte de Cargas Avulso")]
        COD8B,

        /// <summary>
        /// Conhecimento de Transporte Aquaviário de Cargas
        /// </summary>
        [Description("Conhecimento de Transporte Aquaviário de Cargas")]
        COD09,

        /// <summary>
        /// Conhecimento Aéreo
        /// </summary>
        [Description("Conhecimento Aéreo")]
        COD10,

        /// <summary>
        /// Conhecimento de Transporte Ferroviário de Cargas
        /// </summary>
        [Description("Conhecimento de Transporte Ferroviário de Cargas")]
        COD11,

        /// <summary>
        /// Bilhete de Passagem Rodoviário
        /// </summary>
        [Description("Bilhete de Passagem Rodoviário")]
        COD13,

        /// <summary>
        /// Bilhete de Passagem Aquaviário
        /// </summary>
        [Description("Bilhete de Passagem Aquaviário")]
        COD14,

        /// <summary>
        /// Bilhete de Passagem e Nota de Bagagem
        /// </summary>
        [Description("Bilhete de Passagem e Nota de Bagagem")]
        COD15,

        /// <summary>
        /// Bilhete de Passagem Ferroviário
        /// </summary>
        [Description("Bilhete de Passagem Ferroviário")]
        COD16,

        /// <summary>
        /// Despacho de Transporte
        /// </summary>
        [Description("Despacho de Transporte")]
        COD17,

        /// <summary>
        /// Resumo de Movimento Diário
        /// </summary>
        [Description("Resumo de Movimento Diário")]
        COD18,

        /// <summary>
        /// Ordem de Coleta de Cargas
        /// </summary>
        [Description("Ordem de Coleta de Cargas")]
        COD20,

        /// <summary>
        /// Nota Fiscal de Serviço de Comunicação
        /// </summary>
        [Description("Nota Fiscal de Serviço de Comunicação")]
        COD21,

        /// <summary>
        /// Nota Fiscal de Serviço de Telecomunicação
        /// </summary>
        [Description("Nota Fiscal de Serviço de Telecomunicação")]
        COD22,

        /// <summary>
        /// GNRE
        /// </summary>
        [Description("GNRE")]
        COD23,

        /// <summary>
        /// Autorização de Carregamento e Transporte
        /// </summary>
        [Description("Autorização de Carregamento e Transporte")]
        COD24,

        /// <summary>
        /// Manifesto de Carga
        /// </summary>
        [Description("Manifesto de Carga")]
        COD25,

        /// <summary>
        /// Conhecimento de Transporte Multimodal de Cargas
        /// </summary>
        [Description("Conhecimento de Transporte Multimodal de Cargas")]
        COD26,

        /// <summary>
        /// Nota Fiscal de Transporte Ferroviário de Cargas
        /// </summary>
        [Description("Nota Fiscal de Transporte Ferroviário de Cargas")]
        COD27,

        /// <summary>
        /// Nota Fiscal/Conta de Fornecimento de Gás Canalizado
        /// </summary>
        [Description("Nota Fiscal/Conta de Fornecimento de Gás Canalizado")]
        COD28,

        /// <summary>
        /// Nota Fiscal/Conta de Fornecimento de Água Canalizada
        /// </summary>
        [Description("Nota Fiscal/Conta de Fornecimento de Água Canalizada")]
        COD29,

        /// <summary>
        /// Bilhete/Recibo do Passageiro
        /// </summary>
        [Description("Bilhete/Recibo do Passageiro")]
        COD30,

        /// <summary>
        /// Nota Fiscal Eletrônica
        /// </summary>
        [Description("Nota Fiscal Eletrônica")]
        COD55,

        /// <summary>
        /// Conhecimento de Transporte Eletrônico – CT-e
        /// </summary>
        [Description("Conhecimento de Transporte Eletrônico – CT-e")]
        COD57,

        /// <summary>
        /// Cupom Fiscal Eletrônico - CF-e
        /// </summary>
        [Description("Cupom Fiscal Eletrônico - CF-e")]
        COD59,

        /// <summary>
        /// Cupom Fiscal Eletrônico CF-e-ECF
        /// </summary>
        [Description("Cupom Fiscal Eletrônico CF-e-ECF")]
        COD60,

        /// <summary>
        /// Nota Fiscal Eletrônica ao Consumidor Final - NFC-e
        /// </summary>
        [Description("Nota Fiscal Eletrônica ao Consumidor Final - NFC-e")]
        COD65

    }

    public enum SituacaoNotaFiscal
    {
        /// <summary>
        /// Ativa
        /// </summary>
        [Description("Ativa")]
        A,

        /// <summary>
        /// Cancelada
        /// </summary>
        [Description("Cancelada")]
        C
    }

}
