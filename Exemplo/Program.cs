using CriptografiaRFID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.WriteLine("[ 1 ] Gerar epc");
                Console.WriteLine("[ 2 ] Descriptografar EPC");
                Console.WriteLine("[ 0 ] Sair");
                Console.WriteLine("-------------------------------------");
                Console.Write("Digite uma opção: ");
                opcao = Int32.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite um Codigo de Barras: ");
                        string Barcode = Console.ReadLine();

                        Console.Write("Digite a Partição: ");
                        int Particao = Int32.Parse(Console.ReadLine());

                        Console.Write("Digite o Numero de Série: ");
                        long Serie = long.Parse(Console.ReadLine());
                        GerarEpcs(Barcode, Particao, Serie);
                        break;

                    case 2:
                        Console.Write("Digite o Codigo Epc Hexadecimal: ");
                        string Epc = Console.ReadLine();
                        DescriptografarEpcs(Epc);
                        break;
                    default:
                        break;
                }

                Console.WriteLine();
                Console.WriteLine();
            }
            while (opcao != 0);
        }

        private static void GerarEpcs(string Barcode, int Particao, long Serie) {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Dado Criptografado");
            Console.WriteLine();
            try
            {
                var aux = EpcHelper.SerializarSgtin(Barcode, Serie, Particao);
                Console.WriteLine($"EPC URI:          -> {aux.EPCString}");
                Console.WriteLine($"EPC Hexadecimal:  -> {aux.HexadecimalString}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }            
        }

        private static void DescriptografarEpcs(string epcHexadecimal) {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Dado Descriptografado");
            Console.WriteLine();
            try
            {
                var aux = EpcHelper.GetGS1(epcHexadecimal);
                
                Console.WriteLine($"Header:             -> {aux.Header}");
                Console.WriteLine($"Filter:             -> {aux.Filter}");
                Console.WriteLine($"Partition:          -> {aux.Partition}");
                Console.WriteLine($"Prefixo da Empresa: -> {aux.CompanyPrefix}");
                Console.WriteLine($"Codigo do Item:     -> {aux.ItemReference}");
                Console.WriteLine($"Numero Serial:      -> {aux.SerialNumber}");
                Console.WriteLine($"Codigo de Barras:   -> {aux.Barcode}");              
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
