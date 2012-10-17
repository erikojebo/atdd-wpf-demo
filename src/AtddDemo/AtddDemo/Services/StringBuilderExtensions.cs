using System.Text;

namespace AtddDemo.Services
{
    public static class StringBuilderExtensions
    {
        public static void AppendFormatLine(this StringBuilder sb, string format, params object[] formatParameters)
        {
            sb.AppendFormat(format, formatParameters);
            sb.AppendLine();
        }
    }
}