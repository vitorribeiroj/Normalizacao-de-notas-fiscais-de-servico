using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorArquivosTSE
{
    public class RegistroTrailer
    {
        private int Registro { get { return 9; } }
        public int TotalDeNotasFiscais { get; set; }


        public string CriarTrailerNormalizado()
        {
            return $"{this.Registro}" +
                   $"{Utils.CompletarComZerosEsquerda(this.TotalDeNotasFiscais.ToString(),9)}" +
                   $"{Utils.PreencherComEspacoEmBrancoDireita(32+355)}";
        }
    }
}
