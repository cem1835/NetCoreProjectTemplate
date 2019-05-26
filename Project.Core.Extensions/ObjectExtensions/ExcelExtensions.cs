using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Project.Extensions.ObjectExtensions
{
    public class ExcelExtensions
    {
        public void Write(IEnumerable<Dictionary<string, object>> datas, Dictionary<string, object> fields, string path)
        {

            FileStream stream = new FileStream(path, System.IO.FileMode.OpenOrCreate);
            ExcelWriter xlwriter = new ExcelWriter(stream);
            xlwriter.BeginWrite();
            foreach (var field in fields.Select((value, index) => new { index = index, value = value }))
            {
                var obj = field.value.Key;
                xlwriter.WriteCell(0, field.index, (field.value.Value).ToString());

                foreach (var data in datas.Select((value, index) => new { value = value, index = index + 1 }))
                {

                    if (data.value.ContainsKey(obj))
                    {

                        if (data.value[obj] != null)
                        {
                            xlwriter.WriteCell(data.index, field.index, data.value[obj].ToString());
                        }
                    }
                }
            }

            xlwriter.EndWrite();
            stream.Close();

        }

        public void Write<T>(IEnumerable<T> datas, Dictionary<string, object> fields, string path)
        {

            FileStream stream = new FileStream(path, System.IO.FileMode.OpenOrCreate);
            ExcelWriter xlwriter = new ExcelWriter(stream);
            xlwriter.BeginWrite();

            if (fields == null)
            {
                fields = new Dictionary<string, object>();
                foreach (var item in datas.FirstOrDefault().GetType().GetProperties())
                {
                    fields.Add(item.Name, item.Name);
                }

            }
            foreach (var field in fields.Select((value, index) => new { index = index, value = value }))
            {
                var obj = field.value.Key;

                xlwriter.WriteCell(0, field.index, field.value.Value.ToString());
                foreach (var data in datas.Select((value, index) => new { value = value, index = index + 1 }))
                {
                    if (typeof(T).IsClass)
                    {

                        var key = data.value.GetType().GetProperty(field.value.Key).GetValue(data.value, null);
                        if (key != null)
                        {
                            var value = key.ToString();
                            xlwriter.WriteCell(data.index, field.index, value);
                        }
                    }

                }
            }
            xlwriter.EndWrite();
            stream.Close();
        }

        private class ExcelWriter
        {


            private Stream stream;
            private BinaryWriter writer;

            private ushort[] clBegin = { 0x0809, 8, 0, 0x10, 0, 0 };
            private ushort[] clEnd = { 0x0A, 00 };


            private void WriteUshortArray(ushort[] value)
            {
                for (int i = 0; i < value.Length; i++)
                    writer.Write(value[i]);
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ExcelWriter"/> class.
            /// </summary>
            /// <param name="stream">The stream.</param>
            public ExcelWriter(Stream stream)
            {
                this.stream = stream;
                writer = new BinaryWriter(stream);
            }

            /// <summary>
            /// Writes the text cell value.
            /// </summary>
            /// <param name="row">The row.</param>
            /// <param name="col">The col.</param>
            /// <param name="value">The string value.</param>
            public void WriteCell(int row, int col, string value)
            {
                Encoding enTr = Encoding.GetEncoding("Windows-1254"); //excele aktarırken türkçe karakter sorunu var.
                Encoding unicode = Encoding.UTF8;
                ushort[] clData = { 0x0204, 0, 0, 0, 0, 0 };
                int iLen = value.Length;
                byte[] unicodeBytes = unicode.GetBytes(value);
                byte[] plainText = Encoding.Convert(unicode, enTr, unicodeBytes);
                clData[1] = (ushort)(8 + iLen);
                clData[2] = (ushort)row;
                clData[3] = (ushort)col;
                clData[5] = (ushort)iLen;
                WriteUshortArray(clData);
                writer.Write(plainText);
            }

            /// <summary>
            /// Writes the integer cell value.
            /// </summary>
            /// <param name="row">The row number.</param>
            /// <param name="col">The column number.</param>
            /// <param name="value">The value.</param>
            public void WriteCell(int row, int col, int value)
            {
                ushort[] clData = { 0x027E, 10, 0, 0, 0 };
                clData[2] = (ushort)row;
                clData[3] = (ushort)col;
                WriteUshortArray(clData);
                int iValue = (value << 2) | 2;
                writer.Write(iValue);
            }

            /// <summary>
            /// Writes the double cell value.
            /// </summary>
            /// <param name="row">The row number.</param>
            /// <param name="col">The column number.</param>
            /// <param name="value">The value.</param>
            public void WriteCell(int row, int col, double value)
            {
                ushort[] clData = { 0x0203, 14, 0, 0, 0 };
                clData[2] = (ushort)row;
                clData[3] = (ushort)col;
                WriteUshortArray(clData);
                writer.Write(value);
            }

            /// <summary>
            /// Writes the empty cell.
            /// </summary>
            /// <param name="row">The row number.</param>
            /// <param name="col">The column number.</param>
            public void WriteCell(int row, int col)
            {
                ushort[] clData = { 0x0201, 6, 0, 0, 0x17 };
                clData[2] = (ushort)row;
                clData[3] = (ushort)col;
                WriteUshortArray(clData);
            }

            /// <summary>
            /// Must be called once for creating XLS file header
            /// </summary>
            public void BeginWrite()
            {
                WriteUshortArray(clBegin);
            }

            /// <summary>
            /// Ends the writing operation, but do not close the stream
            /// </summary>
            public void EndWrite()
            {
                WriteUshortArray(clEnd);
                writer.Flush();
            }

        }
    }
}
