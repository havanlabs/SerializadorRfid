using System;
using System.Linq;
using System.Text;

namespace CriptografiaRFID.Helpers
{
    /// <summary>
    /// Classe de apoio de COnversão de TIpos
    /// </summary>
    public static class HelperConverter
    {
        /// <summary>
        /// Preenche uma string com 0 de acordo com o solicitado
        /// </summary>
        /// <param name="value">Valor para ser Preenchido</param>
        /// <param name="lenght">Tamanho da String Final</param>
        /// <returns>String preenchida com 0 até o tamanho informado</returns>
        public static string fill(string value, int lenght)
        {
            while (value.Length < lenght) value = $"0{value}";
            return value;
        }
        /// <summary>
        /// Conversão de uma String Binária para Hexadecimal
        /// </summary>
        /// <param name="binary">String Binária</param>
        /// <returns>Valor Hexadecimal</returns>
        public static string BinaryStringToHexString(string binary)
        {
            StringBuilder result = new StringBuilder(binary.Length / 8 + 1);

            int mod4Len = binary.Length % 8;
            if (mod4Len != 0)
            {
                binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
            }

            for (int i = 0; i < binary.Length; i += 8)
            {
                string eightBits = binary.Substring(i, 8);
                result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
            }

            return result.ToString();
        }
        /// <summary>
        /// Conversão de uma String Hexadecimal para Binária
        /// </summary>
        /// <param name="hexstring">string Hexadecimal</param>
        /// <returns>Valor Binária</returns>
        public static string HexToBinary(string hexstring)
        {
            return String.Join(String.Empty,
                hexstring.Select(
                    c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                )
            );
        }
    }
}
