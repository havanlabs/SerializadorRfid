using CriptografiaRFID.Modelos.Gs1Defaults;
using System.Collections.Generic;
using System.Linq;

namespace CriptografiaRFID.Constantes
{
    /// <summary>
    /// Classe de Manipulação dos Cabeçalhos dos padrões
    /// </summary>
    public static class EpcHeaders
    {
        #region
        public const string GDTI_96 = "00101100";
        public const string GSRN_96 = "00101101";
        public const string RESERVADO = "00101110";
        public const string USDoD_96 = "00101111";
        public const string SGTIN_96 = "00110000";
        public const string SSCC_96 = "00110001";
        public const string SGLN_96 = "00110010";
        public const string GRAI_96 = "00110011";
        public const string GIAI_96 = "00110100";
        public const string GID_96 = "00110101";
        public const string SGTIN_198 = "00110110";
        public const string GRAI_170 = "00110111";
        public const string GIAI_202 = "00111000";
        public const string SGLN_195 = "00111001";
        public const string GDTI_113 = "00111010";
        public const string ADI_var = "00111011";
        #endregion

        /// <summary>
        /// Lista para manipulação dos Cabeçalhos
        /// </summary>
        private static List<Headers> info = new List<Headers>()
            {
                new Headers("gdti-96",GDTI_96),
                new Headers("gsrn-96",GSRN_96),
                new Headers("reservado",RESERVADO),
                new Headers("usdod-96",USDoD_96),
                new Headers("sgtin-96",SGTIN_96),
                new Headers("sscc-96",SSCC_96),
                new Headers("sgln-96",SGLN_96),
                new Headers("grai-96",GRAI_96),
                new Headers("giai-96",GIAI_96),
                new Headers("gid-96",GID_96),
                new Headers("sgtin-198",SGTIN_198),
                new Headers("grai-170",GRAI_170),
                new Headers("giai-202",GIAI_202),
                new Headers("sgln-195",SGLN_195),
                new Headers("gdti-113",GDTI_113),
                new Headers("adi-var",ADI_var)
            };

        /// <summary>
        /// Nome do Padrão
        /// </summary>
        /// <param name="NumberCode">Código decimal do Padrão</param>
        /// <returns></returns>
        public static string GetName(int NumberCode)
        {
            var result = info.FirstOrDefault(x => x.NumberCode == NumberCode);
            return result != null ? result.Description : "Inexistente";
        }
        /// <summary>
        /// Nome do Padrão
        /// </summary>
        /// <param name="BinaryString">Código binário do Padrão</param>
        /// <returns></returns>
        public static string GetName(string BinaryString)
        {
            var result = info.FirstOrDefault(x => x.BinCode == BinaryString);
            return result != null ? result.Description : "Inexistente";
        }
        /// <summary>
        /// Codigo Binário do Padrão
        /// </summary>
        /// <param name="NumberCode">Código decimal do Padrão</param>
        /// <returns></returns>
        public static string GetBin(int NumberCode) {
            var result = info.FirstOrDefault(x => x.NumberCode == NumberCode);
            return result != null ? result.BinCode : "";
        }
        /// <summary>
        /// Codigo Binário do Padrão
        /// </summary>
        /// <param name="Nome">Nome do Padrão</param>
        /// <returns></returns>
        public static string GetBin(string Nome)
        {
            var result = info.FirstOrDefault(x => x.Description == Nome);
            return result != null ? result.BinCode : "";
        }
        /// <summary>
        /// Código decimal do Padrão
        /// </summary>
        /// <param name="Nome">Nome do Padrão</param>
        /// <returns></returns>
        public static int GetCode(string Nome)
        {
            var result = info.FirstOrDefault(x => x.Description == Nome);
            return result != null ? result.NumberCode : 0;
        }
        /// <summary>
        /// Código decimal do Padrão
        /// </summary>
        /// <param name="BinaryString">Código binário do Padrão</param>
        /// <returns></returns>
        public static int GetCodeFromBin(string BinaryString)
        {
            var result = info.FirstOrDefault(x => x.BinCode == BinaryString);
            return result != null ? result.NumberCode : 0;
        }

    }
}
