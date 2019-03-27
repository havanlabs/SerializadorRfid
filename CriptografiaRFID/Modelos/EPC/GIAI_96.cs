using CriptografiaRFID.Constantes;
using CriptografiaRFID.Helpers;
using CriptografiaRFID.Interfaces;
using CriptografiaRFID.Modelos.Gs1Defaults;
using System;

namespace CriptografiaRFID.Modelos.Epc
{
    /// <summary>
    /// Objeto com o Padrão Giai-96 para codificação e decodificação
    /// </summary>
    public class Giai96 : GS1, IGS1
    {
        /// <summary>
        /// Construtor via Objeto
        /// </summary>
        /// <param name="param">Objeto Padrão GS1</param>
        public Giai96(GS1 param) : base(param) { }
        /// <summary>
        /// Construtor a partir da string binária
        /// </summary>
        /// <param name="Binary">String Binária<</param>
        public Giai96(string Binary)
        {
            this.Decript(Binary);
        }

        /// <summary>
        /// Método de Decodificação da string binária para valores legíveis
        /// </summary>
        /// <param name="linhaBinaria">Descriptografa a string Binária no padrão GS1</param>
        public void Decript(string linhaBinaria)
        {
            int posicaoInicial = 0;
            string part = linhaBinaria.Substring(posicaoInicial, 8);
            this.Header = EpcHeaders.GetName(part);
            posicaoInicial += 8;

            part = linhaBinaria.Substring(posicaoInicial, 3);
            this.Filter = Convert.ToInt32(part, 2).ToString();
            posicaoInicial += 3;

            part = linhaBinaria.Substring(posicaoInicial, 3);
            this.Partition = Convert.ToInt32(part, 2);
            posicaoInicial += 3;

            part = linhaBinaria.Substring(posicaoInicial, GiaiPartition.GetCompany(this.Partition));
            this.CompanyPrefix = Convert.ToInt64(part, 2);
            posicaoInicial += GiaiPartition.GetCompany(this.Partition);

            part = linhaBinaria.Substring(posicaoInicial, GiaiPartition.GetItem(this.Partition));
            this.ItemReference = Convert.ToInt64(part, 2);
            posicaoInicial += GiaiPartition.GetItem(this.Partition);
        }

        /// <summary>
        /// Método de Codificação segundo o Padrão EPC
        /// </summary>
        /// <returns>Objeto Simplicado do padrão</returns>
        public EPCSimplesDTO Encript()
        {
            string Header = EpcHeaders.GetBin(this.Header);
            string Filter = HelperConverter.fill(Convert.ToString(Convert.ToInt32(this.Filter), 2), 3);
            string Partition = HelperConverter.fill(Convert.ToString(this.Partition, 2), 3);
            string CompanyPrefix = HelperConverter.fill(Convert.ToString(this.CompanyPrefix, 2), GiaiPartition.GetCompany(this.Partition));
            string ItemReference = HelperConverter.fill(Convert.ToString(this.ItemReference, 2), GiaiPartition.GetItem(this.Partition));

            string BinString = $"{Header}{Filter}{Partition}{CompanyPrefix}{ItemReference}";
            EPCSimplesDTO retorno = new EPCSimplesDTO();
            retorno.BarCode = this.Barcode;
            retorno.EPCString = EpcTagURI();
            retorno.HexadecimalString = HelperConverter.BinaryStringToHexString(BinString);
            return retorno;
        }

        /// <summary>
        /// Url EPC de identificação pura
        /// </summary>
        /// <returns></returns>
        public string EpcPureURI()
        {
            return $"urn:epc:id:giai:{HelperConverter.fill(this.CompanyPrefix.ToString(), GiaiPartition.GetCompanyDigitos(this.Partition))}.{this.ItemReference}";
        }

        /// <summary>
        /// Url EPC de Tag
        /// </summary>
        /// <returns></returns> 
        public string EpcTagURI()
        {
            return $"urn:epc:tag:{this.Header}:{this.Filter}.{HelperConverter.fill(this.CompanyPrefix.ToString(), GiaiPartition.GetCompanyDigitos(this.Partition))}.{this.ItemReference}";
        }
    }
}
