using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ClosedXML.Excel;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Excel;

namespace Ca.Skoolbo.Homesite.Extensions
{
    public static class CsvHelperExtension
    {
        #region Write
        public static byte[] WriteCsvToMemory(Action<CsvWriter> writerValue, string header = "", Encoding encoding = null)
        {
            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream, encoding ?? Encoding.UTF8))
            using (var writer = new CsvWriter(streamWriter))
            {
                if (!string.IsNullOrEmpty(header))
                {
                    streamWriter.WriteLine(header);
                }

                writerValue.Invoke(writer);

                streamWriter.Flush();

                return memoryStream.ToArray();
            }
        }

        public static byte[] WriteExcel(string worksheetName, Action<CsvWriter> writerValue)
        {
            using (var memoryStream = new MemoryStream())
            using (var workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var worksheet = workbook.AddWorksheet(worksheetName);
                
                using (var writer = new CsvWriter(new ExcelSerializer(worksheet)))
                {
                    writer.Configuration.Delimiter = ",";
                    writer.Configuration.HasExcelSeparator = true;
                    writerValue.Invoke(writer);
                }
                workbook.SaveAs(memoryStream);


                return memoryStream.ToArray();
            }
        }

        public static byte[] WriteExcel(Dictionary<string, Action<CsvWriter>> worksheets)
        {
            using (var memoryStream = new MemoryStream())
            using (var workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                foreach (var item in worksheets)
                {
                    var worksheet = workbook.AddWorksheet(item.Key);

                    using (var writer = new CsvWriter(new ExcelSerializer(worksheet)))
                    {
                        writer.Configuration.Delimiter = ",";
                        writer.Configuration.HasExcelSeparator = true;

                        item.Value.Invoke(writer);
                    }
                }
               
                workbook.SaveAs(memoryStream);


                return memoryStream.ToArray();
            }
        }

        public static void WriteFieldEmpty(this CsvWriter writerValue, int total)
        {
            for (int i = 0; i < total; i++)
            {
                writerValue.WriteField(string.Empty);
            }
        }

        #endregion

        #region Read
        public static void ReadCsvFromByteArray(byte[] stream, Action<CsvReader> csvReader, Action<CsvReader> csvConfig = null, Encoding encoding = null)
        {
            if (stream.Length == 0)
                return;
            using (var memoryStream = new MemoryStream(stream))
            using (var streamWriter = new StreamReader(memoryStream, encoding ?? Encoding.UTF8, true))
            using (var reader = new CsvReader(streamWriter))
            {
                if (csvConfig != null)
                    csvConfig.Invoke(reader);
                else
                    CsvReaderConfig(reader, encoding);

                csvReader.Invoke(reader);
            }
        }

        public static void ReadCsvFromStream(Stream stream, Action<CsvReader> csvReader, Action<CsvReader> csvConfig = null, Encoding encoding = null)
        {
            if (stream.Length == 0)
                return;

            using (var streamReader = new StreamReader(stream, encoding ?? Encoding.UTF8, true))
            using (var reader = new CsvReader(streamReader))
            {
                if (csvConfig != null)
                    csvConfig.Invoke(reader);
                else
                    CsvReaderConfig(reader, encoding);

                csvReader.Invoke(reader);
            }
        }

        public static void ReadCsvFromPath(string path, Action<CsvReader> csvReader, Action<CsvReader> csvConfig = null, Encoding encoding = null)
        {
            using (var streamWriter = new StreamReader(path, encoding ?? Encoding.UTF8, true))
            using (var reader = new CsvReader(streamWriter))
            {
                if (csvConfig != null)
                    csvConfig.Invoke(reader);
                else
                    CsvReaderConfig(reader, encoding);

                csvReader.Invoke(reader);
            }
        }
        public static void ReadCsvFromString(TextReader textReader, Action<CsvReader> csvReader, Action<CsvReader> csvConfig = null, Encoding encoding = null)
        {
            using (var streamWriter = new CsvParser(textReader, new CsvConfiguration
            {
                Encoding = encoding ?? Encoding.UTF8
            }))
            using (var reader = new CsvReader(streamWriter))
            {
                if (csvConfig != null)
                    csvConfig.Invoke(reader);
                else
                    CsvReaderConfig(reader, encoding);

                csvReader.Invoke(reader);
            }
        }

        public static void ReadCsvFromString(string stringData, Action<CsvReader> csvReader, Action<CsvReader> csvConfig = null, Encoding encoding = null)
        {
            using (TextReader textReader = new StringReader(stringData))
            using (var streamWriter = new CsvParser(textReader, new CsvConfiguration
            {
                Encoding = encoding ?? Encoding.UTF8
            }))
            using (var reader = new CsvReader(streamWriter))
            {
                if (csvConfig != null)
                    csvConfig.Invoke(reader);
                else
                    CsvReaderConfig(reader, encoding);

                csvReader.Invoke(reader);
            }
        }

        public static T GetValueOrEmpty<T>(this CsvReader reader, string columName)
        {
            T t;

            bool isGetSuccess = reader.TryGetField(columName, out t);

            return isGetSuccess ? t : default(T);
        }

        public static void CsvReaderConfig(CsvReader reader, Encoding encoding = null)
        {
            reader.Configuration.TrimHeaders = true;
            reader.Configuration.Encoding = encoding ?? Encoding.UTF8;
            reader.Configuration.WillThrowOnMissingField = false;
        }

        public static void CsvWriterConfig(CsvWriter writer, Encoding encoding = null)
        {
            writer.Configuration.TrimHeaders = true;
            writer.Configuration.Encoding = encoding ?? Encoding.UTF8;
            writer.Configuration.WillThrowOnMissingField = false;
        }
        #endregion
    }
}