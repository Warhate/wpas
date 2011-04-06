using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Layout
{
   public class Log
    {
        /// <summary>
        /// Ведет логирование(=
        /// 
        /// </summary>
        /// <param name="message">Сообщение</param>
        public static void AddLogMessage(String message)
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"logs\log.txt", true);

                //Stream st = File.Open(@"logs\log.txt", FileMode.Append);

                sw.WriteLine(String.Format("{0}-[{1}]: {2}", DateTime.Now.Date.ToLongDateString(), DateTime.Now.ToLongTimeString(), message));
                sw.Close();
            }
            catch (Exception)
            { }
        }
    }
}
