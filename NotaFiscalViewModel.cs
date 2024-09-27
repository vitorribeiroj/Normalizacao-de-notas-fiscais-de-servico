using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorArquivosTSE
{
    public class NotaFiscalViewModel
    {
        public string ModeloNotaFiscal { get; set; }
        public string Numero { get; set; }
        public string Serie { get; set; } = "";
        public string CodigoVerificacaoConsultaMunicipal { get; set; }
        public string ChaveAcessoConsultaNacional { get; set; }
        public DateTime DataEmissao { get; set; }
        public string SituacaoNotaFiscal { get; set; }
        public string CNPJ_Emitente { get; set; }
        public string CNPJ_Destinatario { get; set; }
        //public string TipoPessoaEmitente { get; set; }        
        public string NaturezaOperacao { get; set; }
        public double ValorTotalDaNota { get; set; } = 0;
        public long NumeroNotaFiscalSubstituida { get; set; }
        public string NotaFiscalSubstituida { get
            {
                if (this.NumeroNotaFiscalSubstituida == 0) return "";
                else
                {
                    return this.NumeroNotaFiscalSubstituida.ToString();
                }
            } }
               
    }
}
