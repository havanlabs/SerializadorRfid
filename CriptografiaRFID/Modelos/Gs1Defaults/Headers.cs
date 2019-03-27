using System;

namespace CriptografiaRFID.Modelos.Gs1Defaults
{
    /// <summary>
    /// Classe de Tipo dos Padrões de Serialização 
    /// </summary>
    public class Headers
    {
        /// <summary>
        /// Código decimal do Padrão
        /// </summary>
        public int NumberCode { get; set; }
        /// <summary>
        /// Nome do Padrão
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Codigo Binário do Padrão
        /// </summary>
        public string BinCode { get; set; }

        /// <summary>
        /// Método Contrutor
        /// </summary>
        /// <param name="nome">Nome do Padrão</param>
        /// <param name="bin">Codigo Binário do Padrão</param>
        public Headers(string nome, string bin)
        {
            this.NumberCode = Convert.ToInt32(bin, 2);
            this.Description = nome;
            this.BinCode = bin;
        }
    }
}
