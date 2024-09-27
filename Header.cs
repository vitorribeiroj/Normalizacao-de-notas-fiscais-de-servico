using static GeradorArquivosTSE.Utils;

namespace GeradorArquivosTSE
{
    public class Header
    {
        private int Registro { get { return 1; } }

        /// <summary>
        /// UF da Prefeitura Municipal, Governo ou Secretaria da Fazenda.
        /// </summary>
        private string UF { get { return "MG"; } }

        /// <summary>
        /// Número do CNPJ da Prefeitura Municipal, Governo ou da Secretaria da Fazenda.
        /// </summary>
        public long CNPJ_Ente { get; set; }

        /// <summary>
        /// Data da geração do arquivo. Máscara DDMMAAAA
        /// </summary>
        private DateTime DataProcessamento { get { return DateTime.Today.Date; } }

        /// <summary>
        /// Número da notificação enviada pela Unidade Eleitoral (TRE,TSE). Completar com zeros à esquerda, quando necessário
        /// </summary>
        public long NumeroNotificacao { get; set; } = 0;

        /// <summary>
        /// Ano e Mês referente a geração da remessa de notas fiscais eletrônicas.Máscara AAAAMM
        /// </summary>
        public int NumeroRemessa { get; set; }

        /// <summary>
        /// Número identificador do lote da remessa. Completar com zeros à esquerda, quando necessário
        /// </summary>
        public int NumeroLoteRemessa { get; set; }

        /// <summary>
        /// Ano e Mês referente à remessa anterior a ser corrigida. Máscara AAAAMM.
        /// </summary>
        public int NumeroRemessaCorrecao { get; set; } = 0;

        /// <summary>
        /// Número do lote da remessa anterior a ser corrigida. Completar com zeros à esquerda, quando necessário.
        /// </summary>
        public int NumeroLoteRemessaCorrecao { get; set; } = 0;

        /// <summary>
        /// Versão do arquivo de importação de Notas Fiscais Eletrônicas. Fixo “120".
        /// </summary>
        private int VersaoLeiaute { get { return 120; } }

        /// <summary>
        /// Nome do leiaute. Fixo “ATSENFE”.
        /// </summary>
        private string NomeLeiaute { get { return "ATSENFE"; } }

        /// <summary>
        /// Retorna a string normalizada conforme leiaute do TSE
        /// </summary>
        /// <returns></returns>
        public string CriarHeaderNormalizado()
        {            
            return $"{this.Registro}" +
                   $"{this.UF}" +
                   $"{CompletarComZerosEsquerda(this.CNPJ_Ente.ToString(), 14)}" +
                   $"{this.DataProcessamento.ToString("ddMMyyyy")}" +
                   $"{CompletarComZerosEsquerda(this.NumeroNotificacao.ToString(), 10)}" +
                   $"{CompletarComZerosEsquerda(this.NumeroRemessa.ToString(), 6)}" +
                   $"{CompletarComZerosEsquerda(this.NumeroLoteRemessa.ToString(),4)}" +
                   $"{CompletarComZerosEsquerda(this.NumeroRemessaCorrecao.ToString(), 6)}" +
                   $"{CompletarComZerosEsquerda(this.NumeroLoteRemessaCorrecao.ToString(),4)}" +
                   $"{this.VersaoLeiaute}" +
                   $"{this.NomeLeiaute}" +
                   $"{PreencherComEspacoEmBrancoDireita(332)}";
        }        

    }
}
