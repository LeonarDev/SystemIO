using System;
using System.IO;
using System.Globalization;
using SystemIO.Entities;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            // Fazer um programa para ler o caminho de um arquivo .csv contendo os dados de itens vendidos.
            // Cada item possui um nome, preço unitário e quantidade, separados por vírgula.
            // Você deve gerar um novo arquivo chamado "summary.csv", localizado em uma subpasta chamada "out"
            // a partir da pasta original do arquivo de origem, contendo apenas o nome e o valor total para
            // aquele item (preço unitário multiplicado pela quantidade), conforme exemplo.

            Console.WriteLine("Enter file full path: ");
            string sourceFilePath = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(sourceFilePath);

                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
                string targetFolderPath = sourceFolderPath + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(targetFilePath);

                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (string line in lines)
                    {
                        string[] column = line.Split(',');
                        string name = column[0];
                        double price = double.Parse(column[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(column[2]);

                        Product product = new Product(name, price, quantity);

                        sw.WriteLine($"{product.Name}, {product.Total().ToString("F2", CultureInfo.InvariantCulture)}");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.Message);
            }
        }
    }
}