using CriptografiaRFID.Constantes;
using CriptografiaRFID.Helpers;
using CriptografiaRFID.Interfaces;
using CriptografiaRFID.Modelos.Gs1Defaults;
using System;

namespace CriptografiaRFID.Modelos.Epc
{
    /// <summary>
    /// Objeto com o Padrão sgtin-96 para codificação e decodificação
    /// </summary>
    public class Sgtin96 : GS1, IGS1
    {
        /// <summary>
        /// Contrutor via string binária
        /// </summary>
        /// <param name="parm">String Binária</param>
        public Sgtin96(string parm)
        {
            this.Decript(parm);
        }
        /// <summary>
        /// Contrutor via Código de barras(com a particao como default 1)
        /// </summary>
        /// <param name="barcode">Código de Barras</param>
        /// <param name="serial">Série</param>
        /// <param name="part">Partição</param>
        public Sgtin96(string barcode, long serial, int part = 6)
        {
            //Se vier com "0" no inicio
            if (barcode.Substring(0, 1) == "0") barcode = barcode.Substring(1, barcode.Length - 1);

            //preenche com "0" se não for um ean 13
            barcode = HelperConverter.fill(barcode, 13);

            this.Header = EpcHeaders.GetName(EpcHeaders.SGTIN_96);
            this.Filter = "1";
            this.Partition = part;
            string auxbarcode = barcode.Substring(0, (barcode.Length - 1));
            this.CompanyPrefix = Convert.ToInt64(
                HelperConverter.fill(
                    auxbarcode.Substring(0, SgtinPartition.GetCompanyDigitos(this.Partition)), 
                    SgtinPartition.GetCompanyDigitos(this.Partition)));
            this.ItemReference = Convert.ToInt64(
                HelperConverter.fill(
                    auxbarcode.Substring(SgtinPartition.GetCompanyDigitos(this.Partition), 
                    (auxbarcode.Length - SgtinPartition.GetCompanyDigitos(this.Partition))), 
                SgtinPartition.GetItemDigitos(this.Partition)));
            this.SerialNumber = serial;
            this.Barcode = barcode;
        }
        /// <summary>
        /// Contrutor via Código de barras
        /// </summary>
        /// <param name="barcode">Código de Barras</param>
        /// <param name="serial">Série</param>
        /// <param name="Filter">Filter</param>
        /// <param name="part">Partição</param>
        public Sgtin96(string barcode, long serial, string Filter, int part = 6)
        {
            //Se vier com "0" no inicio
            if (barcode.Substring(0, 1) == "0") barcode = barcode.Substring(1, barcode.Length - 1);

            //preenche com "0" se não for um ean 13
            barcode = HelperConverter.fill(barcode, 12);

            this.Header = EpcHeaders.GetName(EpcHeaders.SGTIN_96);
            this.Filter = Filter;
            this.Partition = part;
            string auxbarcode = barcode.Substring(0, (barcode.Length - 1));
            this.CompanyPrefix = Convert.ToInt64(HelperConverter.fill(auxbarcode.Substring(0, SgtinPartition.GetCompanyDigitos(this.Partition)), SgtinPartition.GetCompanyDigitos(this.Partition)));
            this.ItemReference = Convert.ToInt64(
                HelperConverter.fill(
                    auxbarcode.Substring(SgtinPartition.GetCompanyDigitos(this.Partition),
                    (auxbarcode.Length - SgtinPartition.GetCompanyDigitos(this.Partition))),
                SgtinPartition.GetItemDigitos(this.Partition)));
            this.SerialNumber = serial;
            this.Barcode = barcode;
        }
        /// <summary>
        /// Construtor via Objeto
        /// </summary>
        /// <param name="param">Objeto Padrão GS1</param>
        public Sgtin96(GS1 param): base(param){}
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
        public Sgtin96(string _header, string _filter, int _partition, long _companyPrefix, long _itemReference, long _serialNumber, string _barcode): base(_header, _filter, _partition, _companyPrefix, _itemReference, _serialNumber, _barcode){}

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

            this.CompanyPrefix = Convert.ToInt64(linhaBinaria.Substring(posicaoInicial, SgtinPartition.GetCompany(this.Partition)), 2);
            posicaoInicial += SgtinPartition.GetCompany(this.Partition);

            this.ItemReference = Convert.ToInt64(linhaBinaria.Substring(posicaoInicial, SgtinPartition.GetItem(this.Partition)), 2);
            posicaoInicial += SgtinPartition.GetItem(this.Partition);

            this.SerialNumber = Convert.ToInt64(linhaBinaria.Substring(posicaoInicial, 38), 2);

            this.Barcode = HelperBarcode.getbarcodeEan13(CompanyPrefix, ItemReference, Partition);
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
            string CompanyPrefix = HelperConverter.fill(Convert.ToString(this.CompanyPrefix, 2), SgtinPartition.GetCompany(this.Partition));
            string ItemReference = HelperConverter.fill(Convert.ToString(this.ItemReference, 2), SgtinPartition.GetItem(this.Partition));
            string SerialNumber = HelperConverter.fill(Convert.ToString(this.SerialNumber, 2), 38);

            string BinString = $"{Header}{Filter}{Partition}{CompanyPrefix}{ItemReference}{SerialNumber}";
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
            return $"urn:epc:id:sgtin:{HelperConverter.fill(this.CompanyPrefix.ToString(), SgtinPartition.GetCompanyDigitos(this.Partition))}.{HelperConverter.fill(this.ItemReference.ToString(), SgtinPartition.GetItemDigitos(this.Partition))}.{this.SerialNumber}";
        }

        /// <summary>
        /// Url EPC de Tag
        /// </summary>
        /// <returns></returns>        
        public string EpcTagURI()
        {
            return $"urn:epc:tag:{this.Header}:{this.Filter}.{HelperConverter.fill(this.CompanyPrefix.ToString(), SgtinPartition.GetCompanyDigitos(this.Partition))}.{HelperConverter.fill(this.ItemReference.ToString(), SgtinPartition.GetItemDigitos(this.Partition))}.{this.SerialNumber}";
        }
    }
}
