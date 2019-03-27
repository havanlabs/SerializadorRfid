using CriptografiaRFID.Constantes;
using CriptografiaRFID.Helpers;
using CriptografiaRFID.Modelos.Epc;
using CriptografiaRFID.Modelos.Gs1Defaults;
using System;

namespace CriptografiaRFID
{
    /// <summary>
    /// Classe helper para Conversão e Desconversão do Epc Criptografado
    /// </summary>
    public static class EpcHelper
    {
        /// <summary>
        /// Método de Desconversão do valor Hexadecimal
        /// </summary>
        /// <param name="hexaString">Valor hexadecimal do EPC</param>
        /// <returns>Tipo primitivo dos Padrões(GS1), pode ser Convertido para qualquer um dos Padrões (SGTIN96, GRAI96, GIAI96)</returns>
        public static GS1 GetGS1(string hexaString)
        {
            string LinhaBinaria = HelperConverter.HexToBinary(hexaString);

            switch (LinhaBinaria.Substring(0, 8))
            {
                case EpcHeaders.SGTIN_96:
                    return new Sgtin96(LinhaBinaria);

                case EpcHeaders.GRAI_96:
                    return new Grai96(LinhaBinaria);

                case EpcHeaders.GIAI_96:
                    return new Giai96(LinhaBinaria);

                default:
                    return null;
            }
        }

        /// <summary>
        /// Método de geração do EPC.
        /// </summary>
        /// <param name="Parametro">Tipo primitivo GS1</param>
        /// <returns></returns>
        public static EPCSimplesDTO SerializarGenerico(GS1 Parametro)
        {
            switch (EpcHeaders.GetBin(Parametro.Header))
            {
                case EpcHeaders.SGTIN_96:
                    return new Sgtin96(Parametro).Encript();

                case EpcHeaders.GRAI_96:
                    return new Grai96(Parametro).Encript();

                case EpcHeaders.GIAI_96:
                    return new Giai96(Parametro).Encript();

                default:
                    return null;
            }
        }

        /// <summary>
        /// Serialização Rápida Para SGTIN96
        /// </summary>
        /// <param name="barcode">Código de Barras do Produto</param>
        /// <param name="serial">Numero do Serial da tag do produto</param>
        /// <param name="partition">Numero da Partição a ser utilizada (lenght do prefixo da GS1)</param>
        /// <returns></returns>
        public static EPCSimplesDTO SerializarSgtin(string barcode, long serial, int partition)
        {
            if (barcode.Length == 0)
            {
                return null;
            }
            else
            {
                return new Sgtin96(barcode, serial, partition).Encript();
            }
        }

        /// <summary>
        /// Método de geração do EPC.
        /// </summary>
        /// <param name="Parametro">Tipo primitivo GS1</param>
        /// <param name="barcode">Código de Barras do Produto</param>
        /// <param name="serial">Numero do Serial da tag do produto</param>
        /// <param name="partition">Numero da Partição a ser utilizada (lenght do prefixo da GS1)</param>
        /// <returns></returns>
        [Obsolete("Método Legado. Utilizar 'SerializarGenerico' ou SerializarSgtin")]
        public static EPCSimplesDTO EncriptFiltro(GS1 Parametro, string barcode = "", long serial = 0, int partition = 6)
        {
            if (barcode.Length == 0)
            {
                switch (EpcHeaders.GetBin(Parametro.Header))
                {
                    case EpcHeaders.SGTIN_96:
                        return new Sgtin96(Parametro).Encript();

                    case EpcHeaders.GRAI_96:
                        return new Grai96(Parametro).Encript();

                    case EpcHeaders.GIAI_96:
                        return new Giai96(Parametro).Encript();

                    default:
                        return null;
                }
            }
            else
            {
                return new Sgtin96(barcode, serial, partition).Encript();
            }
        }
    }
}
