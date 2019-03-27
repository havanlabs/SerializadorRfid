namespace CriptografiaRFID.Modelos.Gs1Defaults
{
    /// <summary>
    /// Classe padrão de Tratamento da GS1
    /// </summary>
    public class GS1
    {
        /// <summary>
        /// Cabeçalho do Padrão
        /// </summary>
        public string Header { get; set; }
        /// <summary>
        /// Numero do Filter
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// Numero d aPartição
        /// </summary>
        public int Partition { get; set; }
        /// <summary>
        /// Prefixo da Empresa
        /// </summary>
        public long CompanyPrefix { get; set; }
        /// <summary>
        /// Código do Item
        /// </summary>
        public long ItemReference { get; set; }
        /// <summary>
        /// Numero do Serial
        /// </summary>
        public long SerialNumber { get; set; }
        /// <summary>
        /// Código de Barras
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// Se é reservado ou não
        /// </summary>
        public string Reserved { get; set; }

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
        public GS1(string _header, string _filter, int _partition, long _companyPrefix, long _itemReference, long _serialNumber, string _barcode)
        {
            this.Header = _header;
            this.Filter = _filter;
            this.Partition = _partition;
            this.CompanyPrefix = _companyPrefix;
            this.ItemReference = _itemReference;
            this.SerialNumber = _serialNumber;
            this.Barcode = _barcode;
            this.Reserved = "FALSO";
        }
        /// <summary>
        /// Construtor via Objeto
        /// </summary>
        /// <param name="param">Objeto Padrão GS1</param>
        public GS1(GS1 param) {
            this.Header = param.Header;
            this.Filter = param.Filter;
            this.Partition = param.Partition;
            this.CompanyPrefix = param.CompanyPrefix;
            this.ItemReference = param.ItemReference;
            this.SerialNumber = param.SerialNumber;
            this.Barcode = param.Barcode;
            this.Reserved = param.Reserved;
        }
        /// <summary>
        /// Construtor Padrão
        /// </summary>
        public GS1() { }
    }
}
