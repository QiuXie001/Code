using System;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using System.Threading;

namespace SaveData
{
    class Program
    {
        public static void Add()
        {
        }
        static public bool OpenCSVFile()
        {
            string csvFilePath = @"D:\Qiu\Documents\WeChat Files\wxid_mn2amy8oxha022\FileStorage\File\2024-02\test-0201.csv";


            string[] headers = null;
            List<Tuple<string, string>> data = new List<Tuple<string, string>>();

            using (StreamReader csvReader = new StreamReader(csvFilePath))
            {
                string line;
                while ((line = csvReader.ReadLine()) != null)
                {
                    if (headers == null)
                    {
                        headers = line.Split(',').ToArray();
                    }
                    else
                    {
                        string[] values = line.Split(',').ToArray();
                        data.Add(new Tuple<string, string>(values[0], string.Join(",", values.Skip(1))));
                    }
                }
            }

            return true;
        }
        static void Main(string[] args)
        {
            OpenCSVFile();
        }
    }

}