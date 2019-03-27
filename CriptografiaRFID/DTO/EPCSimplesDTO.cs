using System;

namespace CriptografiaRFID
{
    /// <summary>
    /// Objeto Simples contodas as informações da GS1 
    /// </summary>
    public class EPCSimplesDTO
    {
        /// <summary>
        /// Código de Barras
        /// </summary>
        public string BarCode { get; set; }
        /// <summary>
        /// URI epc de Tag
        /// </summary>
        public string EPCString { get; set; }
        /// <summary>
        /// Código EPC no Formato Hexadeciaml
        /// </summary>
        public string HexadecimalString { get; set; }

        [Obsolete("Campos não utilizados.")]
        public string BarCodeRFID { get; set; }
        [Obsolete("Campos não utilizados.")]
        public string Situacao { get; set; }
        [Obsolete("Campos não utilizados.")]
        public string CodigoReposicao { get; set; }
    }
}