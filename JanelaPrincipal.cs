using System.Diagnostics;
using System.Globalization;
using static GeradorArquivosTSE.Utils;

namespace GeradorArquivosTSE
{
    public partial class JanelaPrincipal : Form
    {
        bool ArquivoNotasCarregado = false;
        List<NotaFiscalServico> NotasFiscais = new List<NotaFiscalServico>();
        long CnpjEnte;

        public JanelaPrincipal()
        {
            InitializeComponent();

            DesabilitarControles();
        }

        private void numeroNotifUniEleitoralInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            int maxLength = 10;
            if (numeroNotifUniEleitoralInput.Text.Length >= maxLength && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void numeroRemessaInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            int maxLength = 6;
            if (numeroRemessaInput.Text.Length >= maxLength && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void numeroLoteRemessaInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            int maxLength = 4;
            if (numeroLoteRemessaInput.Text.Length >= maxLength && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void numeroRemessaCorrecaoInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            int maxLength = 6;
            if (numeroRemessaCorrecaoInput.Text.Length >= maxLength && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void numeroLoteRemessaCorrecaoInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            int maxLength = 4;
            if (numeroLoteRemessaCorrecaoInput.Text.Length >= maxLength && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void processarArquivoNotasFiscaisBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string temporaryPath = "";

                if (listBoxArquivosCarregados.Items.Count > 0)
                {
                    List<string> listaArquivos = new List<string>();

                    foreach (var item in listBoxArquivosCarregados.Items)
                    {
                        listaArquivos.Add(item.ToString());
                    }

                    temporaryPath = Utils.CombinarArquivosCsv(listaArquivos);
                }

                ProcessarArquivoDeNotas(temporaryPath);

                Utils.ApagarArquivoCsvTemporario(temporaryPath);

                MessageBox.Show("Processamento feito com sucesso!");

                HabilitarControles();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível processar o(s) arquivo(s) selecionado(s)\n\nVerifique o formato ou o conteúdo dos arquivos");

                DesabilitarControles();
            }
            //}
        }

        private void DesabilitarControles()
        {
            gerarArquivoValidacaoBtn.Enabled = false;
            verNotasBtn.Enabled = false;
            //labelArquivoCarregado.Visible = false;
        }

        private void HabilitarControles()
        {
            gerarArquivoValidacaoBtn.Enabled = true;
            verNotasBtn.Enabled = true;
            //labelArquivoCarregado.Visible = true;
        }

        private void ProcessarArquivoDeNotas(string filePath)
        {
            NotasFiscais.Clear();
            NotasFiscais.AddRange(NotaFiscalServico.ListarNotasFiscaisDeArquivo(filePath));
            ArquivoNotasCarregado = true;
        }

        private void gerarArquivoValidacaoBtn_Click(object sender, EventArgs e)
        {
            string cnpj = cnpjEnteInput.Text;

            if (CNPJ.IsValid(cnpj))
            {
                if (ArquivoNotasCarregado)
                {
                    if (DateTime.TryParseExact(numeroRemessaInput.Text, "yyyyMM", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime numeroRemessa))
                    {
                        CnpjEnte = CNPJ.ParsearCNPJ(cnpj);

                        GerarArquivoParaValidacao();
                    }
                    else
                    {
                        MessageBox.Show("Formato inválido do número da remessa");
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo com as notas fiscais não foi carregado");
                }
            }
            else
            {
                MessageBox.Show("O CNPJ informado não é válido");
            }
        }

        private void GerarArquivoParaValidacao()
        {
            try
            {
                if (consultaNacionalOption.Checked)
                {
                    NotasFiscais.ForEach(nota => nota.UsarConsultaNacional = true);
                }
                else if (consultaMunicipalOption.Checked)
                {
                    NotasFiscais.ForEach(nota =>
                    {
                        if (!VerificarCampoNuloOuVazio(nota.CodigoVerificacaoConsultaMunicipal))
                            nota.UsarConsultaNacional = false;
                    });
                }

                string header = GerarHeader();

                List<string> detalhes = GerarDetalhes();

                string trailer = GerarTrailer();

                List<string> linhas = new List<string> { header };
                linhas.AddRange(detalhes);
                linhas.Add(trailer);

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog.Title = "Salvar Arquivo de Texto";
                    saveFileDialog.FileName = $"{CnpjEnte}-REMESSA_{numeroRemessaInput.Text}-LOTE_{CompletarComZerosEsquerda(numeroLoteRemessaInput.Text, 4)}.txt";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        File.WriteAllLines(filePath, linhas);

                        DialogResult result = MessageBox.Show("Deseja abrir o arquivo salvo?", "Arquivo gerado com sucesso!", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            // Abrir o arquivo no editor de texto padrão
                            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                        }

                        Application.Restart();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Não foi possível gerar o arquivo. Verifique os dados informados ou o arquivo carregado");
            }
        }

        private string GerarHeader()
        {
            Header header = new Header();

            header.CNPJ_Ente = CnpjEnte;

            if (numeroNotifUniEleitoralInput.Text != "")
            {
                header.NumeroNotificacao = long.Parse(numeroNotifUniEleitoralInput.Text);
            }

            header.NumeroRemessa = int.Parse(numeroRemessaInput.Text);
            header.NumeroLoteRemessa = int.Parse(numeroLoteRemessaInput.Text);

            if (numeroRemessaCorrecaoInput.Text != "")
            {
                header.NumeroRemessaCorrecao = int.Parse(numeroRemessaCorrecaoInput.Text);
            }
            if (numeroLoteRemessaCorrecaoInput.Text != "")
            {
                header.NumeroLoteRemessaCorrecao = int.Parse(numeroLoteRemessaCorrecaoInput.Text);
            }

            return header.CriarHeaderNormalizado();
        }

        private List<string> GerarDetalhes()
        {
            List<string> detalhesNormalizados = new List<string>();

            foreach (var notaFiscal in NotasFiscais)
            {
                detalhesNormalizados.Add(notaFiscal.CriarDetalheNotaFiscalNormalizado());
            }

            return detalhesNormalizados;
        }

        private string GerarTrailer()
        {
            var trailer = new RegistroTrailer();
            trailer.TotalDeNotasFiscais = NotasFiscais.Count;

            return trailer.CriarTrailerNormalizado();
        }

        private void fecharBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void verNotasBtn_Click(object sender, EventArgs e)
        {
            var janelaNotas = new JanelaNotasFiscais(NotasFiscais);
            janelaNotas.Show();

        }

        private void JanelaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void addArquivoBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Multiselect = true;

            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.Title = "Select a CSV File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    listBoxArquivosCarregados.Items.Add(fileName);
                }
            }
        }

        private void removerArquivoBtn_Click(object sender, EventArgs e)
        {
            if (listBoxArquivosCarregados.SelectedItem is not null)
            {
                listBoxArquivosCarregados.Items.Remove(listBoxArquivosCarregados.SelectedItem);
            }

            if(listBoxArquivosCarregados.Items.Count <= 0)
            {
                DesabilitarControles();
            }
        }

    }
}