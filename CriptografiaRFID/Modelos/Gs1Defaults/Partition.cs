namespace CriptografiaRFID.Modelos.Gs1Defaults
{ 
    /// <summary>
    /// Classe com as informações da Patição
    /// </summary>
    public class Partition
    {
        /// <summary>
        /// Valor da Partição
        /// </summary>
        public int Type { get; private set; }
        /// <summary>
        /// Quantidade de Bits da Empresa
        /// </summary>
        public int Company { get; private set; }
        /// <summary>
        /// Quantidade de Caracteres da Empresa
        /// </summary>
        public int CompanyDigitos { get; private set; }
        /// <summary>
        /// Quantidde de Bits do Item
        /// </summary>
        public int Item { get; private set; }
        /// <summary>
        /// Quantidade de Caracteres do Item
        /// </summary>
        public int ItemDigitos { get; private set; }
        
        public Partition(int tipo, int compania = 0, int compDigitos = 0, int item = 0, int itemDigitos = 0)
        {
            this.Type = tipo;
            this.Company = compania;
            this.CompanyDigitos = compDigitos;
            this.Item = item;
            this.ItemDigitos = itemDigitos;
        }
    }
}
