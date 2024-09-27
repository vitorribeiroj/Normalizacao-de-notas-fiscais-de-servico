using CsvHelper;
using CsvHelper.Configuration;
using System.Data;
using System.Formats.Asn1;
using System.Globalization;
using System.Reflection;

namespace GeradorArquivosTSE
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class DescriptionAttribute : Attribute
    {
        public string Description { get; }

        public DescriptionAttribute(string description)
        {
            Description = description;
        }
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            // Obtém o campo do enum
            FieldInfo field = value.GetType().GetField(value.ToString());

            // Obtém o atributo DescriptionAttribute do campo
            DescriptionAttribute attribute = field
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .Cast<DescriptionAttribute>()
                .FirstOrDefault();

            // Retorna a descrição ou o nome do valor do enum
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static T GetEnumByDescription<T>(string description) where T : Enum
        {
            // Obtém o tipo do enum
            Type type = typeof(T);

            // Obtém todos os campos do tipo enum
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);

            // Percorre todos os campos do enum
            foreach (FieldInfo field in fields)
            {
                // Obtém o atributo DescriptionAttribute do campo
                DescriptionAttribute attribute = field
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .Cast<DescriptionAttribute>()
                    .FirstOrDefault();

                // Verifica se a descrição corresponde ao valor fornecido
                if (attribute != null && attribute.Description == description)
                {
                    // Retorna o valor correspondente
                    return (T)field.GetValue(null);
                }
            }

            // Se nenhum valor foi encontrado, retorna o valor padrão
            throw new ArgumentException($"Descrição '{description}' não encontrada para o enum '{type.Name}'.");
        }
    }


    internal static class Utils
    {
        private static string CampoNulo { get; set; } = "NULL";

        /// <summary>
        /// Retorna true se o campo for nulo ou vazio
        /// </summary>
        /// <param name="campo"></param>
        /// <returns></returns>
        public static bool VerificarCampoNuloOuVazio(string? campo)
        {
            if(campo is null || campo == CampoNulo || campo == "")
            {
                return true;
            }

            return false;
        }

        public static string CompletarComZerosEsquerda(string campo, int tamanhoCampo)
        {
            string stringDeZeros = "";
            var count = campo.Length;

            if (count < tamanhoCampo)
            {
                stringDeZeros = new string('0', tamanhoCampo - count);
            }

            return stringDeZeros + campo;
        }

        public static string PreencherComEspacoEmBrancoDireita(string campo, int tamanhoCampo)
        {
            string stringDeEspacos = "";
            var count = campo.Length;

            if (count < tamanhoCampo)
            {
                stringDeEspacos = new string(' ', tamanhoCampo - count);
            }

            return campo + stringDeEspacos;
        }

        public static string PreencherComEspacoEmBrancoDireita(int tamanhoCampo)
        {
            return new string(' ', tamanhoCampo);
        }

        public static class CNPJ
        {
            public static bool IsValid(string cnpj)
            {
                // Remove os caracteres especiais
                cnpj = cnpj.Replace(".", "")
                           .Replace("/", "")
                           .Replace("-", "");

                // Verifica se o CNPJ tem 14 dígitos
                if (cnpj.Length != 14)
                    return false;

                // Verifica se todos os caracteres são números
                if (!cnpj.All(char.IsDigit))
                    return false;

                // Verifica se todos os dígitos são iguais (ex: 11111111111111)
                if (cnpj.Distinct().Count() == 1)
                    return false;

                // Calcula os dígitos verificadores
                string cnpjBase = cnpj.Substring(0, 12);
                string cnpjVerificador = cnpj.Substring(12, 2);

                string digito1 = CalcularDigito(cnpjBase);
                string digito2 = CalcularDigito(cnpjBase + digito1);

                // Verifica se os dígitos calculados são iguais aos dígitos do CNPJ
                return cnpjVerificador == digito1 + digito2;
            }

            private static string CalcularDigito(string cnpjBase)
            {
                int[] multiplicadores = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

                if (cnpjBase.Length == 13)
                    multiplicadores = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

                int soma = 0;
                for (int i = 0; i < cnpjBase.Length; i++)
                {
                    soma += int.Parse(cnpjBase[i].ToString()) * multiplicadores[i];
                }

                int resto = soma % 11;
                if (resto < 2)
                    return "0";
                else
                    return (11 - resto).ToString();
            }

            public static long ParsearCNPJ(string cnpj)
            {
                string cnpjSemMascara = cnpj.Replace(".", "")
                                            .Replace("/", "")
                                            .Replace("-", "");

                return long.Parse(cnpjSemMascara);
            }
        }               

        public static DataTable LerCsvParaDataTable(string caminhoArquivo)
        {
            DataTable tabela = new DataTable();

            using (var reader = new StreamReader(caminhoArquivo))
            {
                bool primeiraLinha = true;
                while (!reader.EndOfStream)
                {
                    var linha = reader.ReadLine();
                    var valores = linha.Split(',');

                    if (primeiraLinha)
                    {
                        // Adicionar colunas ao DataTable
                        foreach (var valor in valores)
                        {
                            tabela.Columns.Add(valor.Replace("\"", "").Trim());
                        }
                        primeiraLinha = false;
                    }
                    else
                    {
                        // Adicionar linha ao DataTable
                        var linhaTabela = tabela.NewRow();
                        linhaTabela.ItemArray = valores;
                        tabela.Rows.Add(linhaTabela);
                    }
                }
            }

            return tabela;
        }

        private static List<dynamic> ReadCsv(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var records = new List<dynamic>();
                records = csv.GetRecords<dynamic>().ToList();
                return records;
            }
        }

        private static void WriteCsv(string filePath, List<dynamic> records)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(records);
            }
        }

        public static string CombinarArquivosCsv(List<string> filePathList)
        {
            var combinedRecords = new List<dynamic>();

            string tempFilePath = Path.GetTempFileName();

            foreach (var filePath in filePathList)
            {
                var records = ReadCsv(filePath);
                combinedRecords.AddRange(records);
            }            

            // Escrita do arquivo combinado
            WriteCsv(tempFilePath, combinedRecords);

            return tempFilePath;
        }

        public static void ApagarArquivoCsvTemporario(string tempFilePath)
        {
            File.Delete(tempFilePath);
        }

        //public static class ValidadorDocumentosCPFouCNPJ
        //{
        //    public static string IdentificarDocumento(string documento)
        //    {
        //        // Remove caracteres não numéricos
        //        string numeros = Regex.Replace(documento, @"\D", "");

        //        if (numeros.Length == 11 && ValidarCPF(numeros))
        //        {
        //            return "CPF";
        //        }
        //        else if (numeros.Length == 14 && ValidarCNPJ(numeros))
        //        {
        //            return "CNPJ";
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }

        //    private static bool ValidarCPF(string cpf)
        //    {
        //        if (cpf.Length != 11)
        //            return false;

        //        // Verifica se todos os dígitos são iguais
        //        if (new string(cpf[0], cpf.Length) == cpf)
        //            return false;

        //        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        //        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        //        string tempCpf = cpf.Substring(0, 9);
        //        int soma = 0;

        //        for (int i = 0; i < 9; i++)
        //            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        //        int resto = soma % 11;
        //        resto = resto < 2 ? 0 : 11 - resto;
        //        string digito = resto.ToString();

        //        tempCpf += digito;
        //        soma = 0;

        //        for (int i = 0; i < 10; i++)
        //            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        //        resto = soma % 11;
        //        resto = resto < 2 ? 0 : 11 - resto;
        //        digito += resto.ToString();

        //        return cpf.EndsWith(digito);
        //    }

        //    private static bool ValidarCNPJ(string cnpj)
        //    {
        //        if (cnpj.Length != 14)
        //            return false;

        //        int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        //        int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        //        string tempCnpj = cnpj.Substring(0, 12);
        //        int soma = 0;

        //        for (int i = 0; i < 12; i++)
        //            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

        //        int resto = soma % 11;
        //        resto = resto < 2 ? 0 : 11 - resto;
        //        string digito = resto.ToString();

        //        tempCnpj += digito;
        //        soma = 0;

        //        for (int i = 0; i < 13; i++)
        //            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

        //        resto = soma % 11;
        //        resto = resto < 2 ? 0 : 11 - resto;
        //        digito += resto.ToString();

        //        return cnpj.EndsWith(digito);
        //    }
        //}
    }

    
    
}
