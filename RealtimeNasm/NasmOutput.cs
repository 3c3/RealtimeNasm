using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtimeNasm
{
    public class NasmOutput
    {
        public byte[] assembledBytes;
        public string stdOut;

        static char[] hexDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        private string ToCHex(byte value)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("0x");
            builder.Append(hexDigits[value >> 4]);
            builder.Append(hexDigits[value & 0x0F]);
            return builder.ToString();
        }

        private string ToHex(byte value)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(hexDigits[value >> 4]);
            builder.Append(hexDigits[value & 0x0F]);
            return builder.ToString();
        }

        public string ToStringAsArray()
        {
            if (assembledBytes == null) return "{ }";
            if (assembledBytes.Length == 0) return "{ }";

            StringBuilder builder = new StringBuilder();
            builder.Append("{ ");
            builder.Append(ToCHex(assembledBytes[0]));

            for (int i = 1; i < assembledBytes.Length; i++)
            {
                builder.Append(", ");
                builder.Append(ToCHex(assembledBytes[i]));
            }

            builder.Append(" }");

            return builder.ToString();
        }

        public string ToStringAsHex()
        {
            if (assembledBytes == null) return "";
            if (assembledBytes.Length == 0) return "";

            StringBuilder builder = new StringBuilder();
            builder.Append(ToHex(assembledBytes[0]));

            for (int i = 1; i < assembledBytes.Length; i++)
            {
                builder.Append(" ");
                builder.Append(ToHex(assembledBytes[i]));
            }

            return builder.ToString();
        }

        public string ToStringAsDecimal()
        {
            if (assembledBytes == null) return "";
            if (assembledBytes.Length == 0) return "";

            StringBuilder builder = new StringBuilder();
            builder.Append(assembledBytes[0]);

            for (int i = 1; i < assembledBytes.Length; i++)
            {
                builder.Append(" ");
                builder.Append(assembledBytes[i]);
            }

            return builder.ToString();
        }
    }
}
