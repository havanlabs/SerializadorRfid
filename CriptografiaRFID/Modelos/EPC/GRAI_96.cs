using CriptografiaRFID.Constantes;
using CriptografiaRFID.Helpers;
using CriptografiaRFID.Interfaces;
using CriptografiaRFID.Modelos.Gs1Defaults;
using System;

namespace CriptografiaRFID.Modelos.Epc
{
    /// <summary>
    /// Objeto com o Padrão Grai-96 para codificação e decodificação
    /// </summary>
    public class Grai96 : GS1, IGS1
    {
        /// <summary>
        /// Construtor a partir da string binária
        /// </summary>
        /// <param name="Binary">String Binária<</param>
        public Grai96(string Binary) {
            this.Decript(Binary);
        }
        /// <summary>
        /// Construtor via Objeto
        /// </summary>
        /// <param name="param">Objeto Padrão GS1</param>
        public Grai96(GS1 param):base(param){}
        /// <summary>
        /// Construtor manual via parametros
        /// </summary>
        /// <param name="_header">Cabeçalho do Padão</param>
        /// <param name="_filter">Código do Filter</param>
        /// <param name="_partition">Código da Partição</param>
        /// <param name="_companyPrefix">Prefixo da Empresa</param>
        /// <param name="_itemReference">Código do Item</param>
        /// <param name="_serialNumber">Numero Serial</param>
        /// <param name="_barcode">Código de Barras</param>
        public Grai96(string _header, string _filter, int _partition, long _companyPrefix, long _itemReference, long _serialNumber, string _barcode) : base(_header, _filter, _partition, _companyPrefix, _itemReference, _serialNumber, _barcode) { }

        /// <summary>
        /// Método de Decodificação da string binária para valores legíveis
        /// </summary>
        /// <param name="linhaBinaria">Descriptografa a string Binária no padrão GS1</param>
        public void Decript(string linhaBinaria)
        {

            int posicaoInicial = 0;
            this.Header = EpcHeaders.GetName(linhaBinaria.Substring(posicaoInicial, 8));
            posicaoInicial += 8;

            this.Filter = Convert.ToInt32(linhaBinaria.Substring(posicaoInicial, 3), 2).ToString();
            posicaoInicial += 3;

            this.Partition = Convert.ToInt32(linhaBinaria.Substring(posicaoInicial, 3), 2);
            posicaoInicial += 3;

            this.CompanyPrefix = Convert.ToInt64(linhaBinaria.Substring(posicaoInicial, GraiPartition.GetCompany(this.Partition)), 2);
            posicaoInicial += GraiPartition.GetCompany(this.Partition);

            this.ItemReference = Convert.ToInt64(linhaBinaria.Substring(posicaoInicial, GraiPartition.GetItem(this.Partition)), 2);
            posicaoInicial += GraiPartition.GetItem(this.Partition);

            this.SerialNumber = Convert.ToInt64(linhaBinaria.Substring(posicaoInicial, 38), 2);
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
            string CompanyPrefix = HelperConverter.fill(Convert.ToString(this.CompanyPrefix, 2), GraiPartition.GetCompany(this.Partition));
            string ItemReference = HelperConverter.fill(Convert.ToString(this.ItemReference, 2), GraiPartition.GetItem(this.Partition));
            string SerialNumber = HelperConverter.fill(Convert.ToString(this.SerialNumber, 2), 38);

            string BinString = $"{Header}{Filter}{Partition}{CompanyPrefix}{ItemReference}{SerialNumber}";
            EPCSimplesDTO retorno = new EPCSimplesDTO();
            retorno.BarCode = "NAO POSSUI";
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
            return $"urn:epc:id:grai:{HelperConverter.fill(this.CompanyPrefix.ToString(), GraiPartition.GetCompanyDigitos(this.Partition))}.{HelperConverter.fill(this.ItemReference.ToString(), GraiPartition.GetItemDigitos(this.Partition))}.{this.SerialNumber}";
        }

        /// <summary>
        /// Url EPC de Tag
        /// </summary>
        /// <returns></returns> 
        public string EpcTagURI()
        {
            return $"urn:epc:tag:{this.Header}:{this.Filter}.{HelperConverter.fill(this.CompanyPrefix.ToString(), GraiPartition.GetCompanyDigitos(this.Partition))}.{HelperConverter.fill(this.ItemReference.ToString(), GraiPartition.GetItemDigitos(this.Partition))}.{this.SerialNumber}";
        }
    }
}
