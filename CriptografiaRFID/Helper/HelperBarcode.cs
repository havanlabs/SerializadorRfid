using CriptografiaRFID.Constantes;
using System.Linq;

namespace CriptografiaRFID.Helpers
{
    /// <summary>
    /// Classe de Apoio para tratamento de Código de Barras
    /// </summary>
    public static class HelperBarcode
    {
        /// <summary>
        /// Geração do Código de barras Ean
        /// </summary>
        /// <param name="CompanyPrefix">Prefixo da Empresa</param>
        /// <param name="ItemReference">Código do item</param>
        /// <param name="partition">Numeto da Partição</param>
        /// <returns>Ean</returns>
        public static string getbarcodeEan13(long CompanyPrefix, long ItemReference, int partition = 6)
        {
            var CompaniaDigito = SgtinPartition.GetCompanyDigitos(partition);
            var auxCompany = CompanyPrefix.ToString();
            if (auxCompany.Length > CompaniaDigito) auxCompany = auxCompany.Substring(1, auxCompany.Length - 1);
            if (auxCompany.Length < CompaniaDigito) auxCompany = HelperConverter.fill(auxCompany, CompaniaDigito);

            var itemDigito = SgtinPartition.GetItemDigitos(partition) - 1;
            var auxItem = ItemReference.ToString();
            if (auxItem.Length > itemDigito) auxItem = auxItem.Substring(1, auxItem.Length - 1);
            if (auxItem.Length < itemDigito) auxItem = HelperConverter.fill(auxItem, itemDigito);

            string fullEan = $"{auxCompany}{auxItem}";

            int calculo = GTINCheckDigito(fullEan);

            return $"{fullEan}{calculo}";
        }

        /// <summary>
        /// Calculo do Dígito verificador
        /// </summary>
        /// <param name="code">Ean sem o digito</param>
        /// <returns>Digito verificador</returns>
        private static int GTINCheckDigito(string code)
        {
            var sum = code.Reverse().Select((c, i) => (int)char.GetNumericValue(c) * (i % 2 == 0 ? 3 : 1)).Sum();
            return (10 - sum % 10) % 10;
        }

    }
}
