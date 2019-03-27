namespace CriptografiaRFID.Interfaces
{
    /// <summary>
    /// Interface com os Métodos padrões
    /// </summary>
    public interface IGS1
    {
        /// <summary>
        /// URI pura do EPC
        /// </summary>
        /// <returns></returns>
        string EpcPureURI();
        /// <summary>
        /// URI da TAg do EPC
        /// </summary>
        /// <returns></returns>
        string EpcTagURI();
        /// <summary>
        /// Método de descriptografia para o padrão Gs1
        /// </summary>
        /// <param name="parm">String binária</param>
        void Decript(string parm);
        /// <summary>
        /// Método de Codificação segundo o Padrão EPC
        /// </summary>
        /// <returns></returns>
        EPCSimplesDTO Encript();
    }
}
