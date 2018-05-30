using System;
using System.IO;
using System.Text;

namespace AMLLC.CORE.SHARED
{
    public class ExceptionHandler
    {
        private static ExceptionHandler _Instance;
        private static readonly object _Lock = new object();
        private StreamWriter _StreamWriter;

        public static ExceptionHandler Instance
        {
            get
            {
                lock (_Lock)
                {
                    if (_Instance == null)
                    {
                        _Instance = new ExceptionHandler();
                    }
                }
                return _Instance;
            }
        }

        private ExceptionHandler()
        {
            string exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            _StreamWriter = new StreamWriter(Path.Combine(exePath, Helper.GetLogNameTxt()));
        }

        public void WriteExceptionLog(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss"));
            sb.Append(": ");
            sb.Append(ex.Message);
            _StreamWriter.WriteLine(sb.ToString());
            _StreamWriter.Flush();
        }
    }
}
