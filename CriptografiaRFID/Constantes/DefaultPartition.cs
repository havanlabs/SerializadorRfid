using CriptografiaRFID.Modelos.Gs1Defaults;
using System.Collections.Generic;
using System.Linq;

namespace CriptografiaRFID.Constantes
{
    /// <summary>
    /// Classe de Busca e tratamento das Partitions.
    /// </summary>
    public class DefaultPartition
    {
        /// <summary>
        /// Lista Padrão da Paritions
        /// </summary>
        private readonly List<Partition> Partitions;

        /// <summary>
        /// Método construtor. Carrega as Partitions padrões de acordo com o padrão escolhido
        /// </summary>
        /// <param name="tipo">valor do Enum "EpcHeaders" do tipo de padão escolhido</param>
        public DefaultPartition(string tipo) {
            switch (tipo)
            {
                case EpcHeaders.GIAI_96:
                    Partitions = GiaiList();
                    break;
                default:
                    Partitions = DefaultList();
                    break;
            }
        }

        /// <summary>
        /// Pega a quantidade de Bits do Prefixo da Empresa
        /// </summary>
        /// <param name="tipo">Numero da Partição</param>
        /// <returns>Quantidade de bits do Prefixo</returns>
        public int GetCompany(int tipo)
        {
            var result = Partitions.FirstOrDefault(x => x.Type == tipo);
            return result != null ? result.Company : 0;
        }

        /// <summary>
        /// Pega a quantidade de Caracteres do Prefixo da Empresa
        /// </summary>
        /// <param name="tipo">Numero da Partição</param>
        /// <returns>Quantidade de Caracteres do Prefixo</returns>
        public int GetCompanyDigitos(int tipo)
        {
            var result = Partitions.FirstOrDefault(x => x.Type == tipo);
            return result != null ? result.CompanyDigitos : 0;
        }

        /// <summary>
        /// Pega a quantidade de Bits do item
        /// </summary>
        /// <param name="tipo">Numero da Partição</param>
        /// <returns>Quantidade de bits do item</returns>
        public int GetItem(int tipo)
        {
            var result = Partitions.FirstOrDefault(x => x.Type == tipo);
            return result != null ? result.Item : 0;
        }

        /// <summary>
        /// Pega a quantidade de caracteres do item
        /// </summary>
        /// <param name="tipo">Numero da Partição</param>
        /// <returns>Quantidade de caracteres do item</returns>
        public int GetItemDigitos(int tipo)
        {
            var result = Partitions.FirstOrDefault(x => x.Type == tipo);
            return result != null ? result.ItemDigitos : 0;
        }

        /// <summary>
        /// Partições Default(SGTIN96, GRAI96)
        /// </summary>
        /// <returns>Lista com as Partições disponiveis</returns>
        private List<Partition> DefaultList() {
            return new List<Partition>()
                        {
                            new Partition(0, 40, 12, 4, 1),
                            new Partition(1, 37, 11, 7, 2),
                            new Partition(2, 34, 10, 10, 3),
                            new Partition(3, 30, 9, 14, 4),
                            new Partition(4, 27, 8, 17, 5),
                            new Partition(5, 24, 7, 20, 6),
                            new Partition(6, 20, 6, 24, 7),
                        };
        }

        /// <summary>
        /// Partições Do padão GIAI
        /// </summary>
        /// <returns>Lista com as Partições disponiveis</returns>
        private List<Partition> GiaiList()
        {
            return new List<Partition>()
                        {
                            new Partition(0, 40, 12, 42, 13),
                            new Partition(1, 37, 11, 45, 14),
                            new Partition(2, 34, 10, 48, 15),
                            new Partition(3, 30, 9, 52, 16),
                            new Partition(4, 27, 8, 55, 17),
                            new Partition(5, 24, 7, 58, 18),
                            new Partition(6, 20, 6, 62, 19),
                        };
        }


    }
}
