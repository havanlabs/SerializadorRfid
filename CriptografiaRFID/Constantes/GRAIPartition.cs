namespace CriptografiaRFID.Constantes
{
    /// <summary>
    /// Classe de apoio para Partição do GRAI96
    /// </summary>
    public static class GraiPartition
    {
        /// <summary>
        /// Partições do GRAI96
        /// </summary>
        private static DefaultPartition _particoes = new DefaultPartition(EpcHeaders.GRAI_96);
        /// <summary>
        /// Quantidade de Bits do Prefixo
        /// </summary>
        /// <param name="tipo">Numero da Partição</param>
        /// <returns></returns>
        public static int GetCompany(int tipo)
        {
            return _particoes.GetCompany(tipo);
        }
        /// <summary>
        /// Quantidade de Caracteres do Prefixo
        /// </summary>
        /// <param name="tipo">Numero da Partição</param>
        /// <returns></returns>
        public static int GetCompanyDigitos(int tipo)
        {
            return _particoes.GetCompanyDigitos(tipo);
        }
        /// <summary>
        /// Quantidade de Bits do item
        /// </summary>
        /// <param name="tipo">Numero da Partição</param>
        /// <returns></returns>
        public static int GetItem(int tipo)
        {
            return _particoes.GetItem(tipo);
        }
        /// <summary>
        /// Quantidade de Bits do item
        /// </summary>
        /// <param name="tipo">Numero da Partição</param>
        /// <returns></returns>
        public static int GetItemDigitos(int tipo)
        {
            return _particoes.GetItemDigitos(tipo);
        }
    }
}
