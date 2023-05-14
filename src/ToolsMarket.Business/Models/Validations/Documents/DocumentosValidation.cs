using System.Text.RegularExpressions;

namespace ToolsMarket.Business.Models.Validations.Documents
{
    public class DocumentosValidation
    {
        public class ValidaCPF
        {
            public const int TamanhoCpf = 11;

            public static bool Validar(string cpf)
            {
                var cpfNumeros = Utils.ApenasNumeros(cpf);
                if (!TamanhoValido(cpfNumeros)) return false;
                return !TemDigitosRepetidos(cpfNumeros) && TemDigitosValidos(cpfNumeros);
            }

            private static bool TamanhoValido(string valor)
            {
                return valor.Length == TamanhoCpf;
            }

            private static bool TemDigitosRepetidos(string valor)
            {
                string[] invalidNumbers =
                {
                 "00000000000",
                 "11111111111",
                 "22222222222",
                 "33333333333",
                 "44444444444",
                 "55555555555",
                 "66666666666",
                 "77777777777",
                 "88888888888",
                 "99999999999"
             };
                return invalidNumbers.Contains(valor);
            }

            private static bool TemDigitosValidos(string valor)
            {
                var number = valor.Substring(0, TamanhoCpf - 2);
                var digitoVerificador = new DigitoVerificador(number)
                    .ComMultiplicadoresDeAte(2, 11)
                    .Substituindo("0", 10, 11);
                var firstDigit = digitoVerificador.CalculaDigito();
                digitoVerificador.AddDigito(firstDigit);
                var secondDigit = digitoVerificador.CalculaDigito();

                return string.Concat(firstDigit, secondDigit) == valor.Substring(TamanhoCpf - 2, 2);
            }
        }

        public class ValidaCNPJ
        {
            public const int TamanhoCnpj = 14;

            public static bool Validar(string cnpj)
            {
                Regex r = new Regex(@"\d+");

                string result = "";

                foreach (Match m in r.Matches(cnpj))
                    result += m.Value;

                cnpj = result;

                int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

                int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

                int soma;

                int resto;

                string digito;

                string tempCnpj;

                if (cnpj.Length != 14)
                    return false;

                tempCnpj = cnpj.Substring(0, 12);

                soma = 0;

                for (int i = 0; i < 12; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

                resto = (soma % 11);

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = resto.ToString();

                tempCnpj = tempCnpj + digito;

                soma = 0;

                for (int i = 0; i < 13; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

                resto = (soma % 11);

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();

                return cnpj.EndsWith(digito);
            }
        }

        public class DigitoVerificador
        {
            private string _numero;
            private const int Modulo = 11;
            private readonly List<int> _multiplicadores = new() { 2, 3, 4, 5, 6, 7, 8, 9 };
            private readonly IDictionary<int, string> _substituicoes = new Dictionary<int, string>();
            private bool _complementarDoModulo = true;

            public DigitoVerificador(string numero)
            {
                _numero = numero;
            }

            public DigitoVerificador ComMultiplicadoresDeAte(int primeiroMultiplicador, int ultimoMultiplicador)
            {
                _multiplicadores.Clear();
                for (var i = primeiroMultiplicador; i <= ultimoMultiplicador; i++)
                    _multiplicadores.Add(i);

                return this;
            }

            public DigitoVerificador Substituindo(string substituto, params int[] digitos)
            {
                foreach (var i in digitos)
                {
                    _substituicoes[i] = substituto;
                }

                return this;
            }

            public void AddDigito(string digito)
            {
                _numero = string.Concat(_numero, digito);
            }

            public string CalculaDigito()
            {
                return !(_numero.Length > 0) ? "" : GetDigitSum();
            }

            private string GetDigitSum()
            {
                var soma = 0;
                for (int i = _numero.Length - 1, m = 0; i >= 0; i--)
                {
                    var produto = (int)char.GetNumericValue(_numero[i]) * _multiplicadores[m];
                    soma += produto;

                    if (++m >= _multiplicadores.Count) m = 0;
                }

                var mod = (soma % Modulo);
                var resultado = _complementarDoModulo ? Modulo - mod : mod;

                return _substituicoes.ContainsKey(resultado) ? _substituicoes[resultado] : resultado.ToString();
            }
        }

        public class Utils
        {
            public static string ApenasNumeros(string valor)
            {
                var onlyNumber = "";
                foreach (var s in valor)
                {
                    if (char.IsDigit(s)) onlyNumber += s;
                }
                return onlyNumber.Trim();
            }
        }
    }
}
