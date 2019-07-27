using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning.SolidPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class CsvParser
    {
        private CsvConfig _Config;
        public CsvParser(CsvConfig config)
        {
            this._Config = config;
        }

        public async Task ProcessAsync(string filename)
        {
            string csvData;
            using (var reader = new System.IO.StringReader(filename))
            {
                csvData = await reader.ReadToEndAsync();
            }

            if (string.IsNullOrWhiteSpace(csvData))
                return;

            //TODO: Read Header
            //TODO: Read rows
        }

    }

    public class CsvConfig
    {
        public bool HasHeader { get; set; }
        public List<string> Headers { get; set; }
    }
}
