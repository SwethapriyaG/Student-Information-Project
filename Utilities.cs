using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmering_2_projekt
{
    internal static class Utilities
    {
        internal static string PathNamn = @"\Data";
        internal const string DELIMETER = ";";//Separator för kolumnvärden i rad i en textfil
        /// <summary>
        /// Skriv ut meddelandet och skapa en ny rad
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="param"></param>
        internal static void WriteLineLog(string txt, params string[] param)
        {
            Console.WriteLine(txt, param);
        }
        /// <summary>
        /// Skriv ut meddelandet
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="param"></param>
        internal static void WriteLog(string txt, params string[] param)
        {
            Console.Write(txt + " ", param);
        }
        internal static void WriteErrorLogOchContinue()
        {
            WriteLineLog("Tryck på valfri tangent för att fortsätta......");
            Console.ReadLine();
            ConsoleClear();
        }
        /// <summary>
        /// Validate bara Ja eller Nej (J/N)
        /// </summary>
        /// <param name="userinput"></param>
        /// <returns></returns>
        internal static string CheckUserJN(string userinput)
        {
            if (ValidateChar(userinput, "J", "N") == "J")
            {
                return "J";
            }
            else
            {
                return userinput.ToUpper();
            }
        }
        /// <summary>
        /// Rensa console
        /// </summary>
        internal static void ConsoleClear()
        {
            Console.Clear();
        }
        /// <summary>
        /// konvertera string till Int och inputNum=0, om Ogiltig data 
        /// </summary>
        /// <param name="inputstring"></param>
        /// <returns></returns>
        internal static int ValidateInt(string inputstring)
        {
            Int32.TryParse(inputstring, out int inputNum);
            if (inputNum == 0) WriteLineLog("Ange ett nummer.");
            return inputNum;
        }
        /// <summary>
        /// Validera användarvärden t.ex "J" och "N" (Ja eller Nej)
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        internal static string ValidateChar(string txt, params string[] param)
        {
            string val = "";
            for (int i = 0; i < param.Length; i++)
            {
                val += param[i];
                val += ',';
                if (txt.ToUpper() == param[i])
                {
                    return param[i];

                }
            }
            WriteLineLog("Ange värdena {0}", val.Substring(0, val.Length - 1));
            return string.Empty;
        }
        /// <summary>
        /// Textlängden ska vara mellan minlength och maxlength.
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        internal static string ValidateText(string txt, int minlength = 0, int maxlength = 0)
        {
            if ((minlength == maxlength) && (txt.Length != maxlength) && (maxlength != 0)) //t.ex-bara 4 längd
            {
                WriteLineLog("Längden ska vara {0}", maxlength.ToString());
                return string.Empty;
            }
            else if (!((txt.Length >= minlength) && (txt.Length <= maxlength))) //t.ex-mellan 1 och 20
            {
                WriteLineLog("Längden ska vara mellan {0} och {1}.", minlength.ToString(), maxlength.ToString());
                return string.Empty;
            }
            else
            {
                return txt;
            }
        }
        /// <summary>
        /// konvertera string till double och inputNum=0, om Ogiltig data 
        /// </summary>
        /// <param name="inputstring"></param>
        /// <returns></returns>
        internal static double ValidateDouble(string inputstring)
        {
            double.TryParse(inputstring, out double inputNum);
            if (inputNum == 0) WriteLineLog("Ange ett nummer.");
            return inputNum;
        }
        /// <summary>
        /// konvertera string till float och inputNum=0, om Ogiltig data 
        /// </summary>
        /// <param name="inputstring"></param>
        /// <returns></returns>
        internal static float ValidateFloat(string inputstring)
        {
            float.TryParse(inputstring, out float inputNum);
            if (inputNum == 0) WriteLineLog("Ange ett nummer.");
            return inputNum;
        }
        /// <summary>
        /// Bygg sträng med raddata FieldNamn1:FieldValue1,FieldNamn2:FieldValue2..
        /// </summary>
        /// <param name="FieldNamn"></param>
        /// <param name="FieldValue"></param>
        /// <returns></returns>
        internal static string BuildString(List<string> FieldNamn, List<string> FieldValue)
        {
            string str = "";
            for (int i = 0; i < FieldNamn.Count; i++)
            {
                str += FieldNamn[i] + FieldValue[i] + DELIMETER;
            }
            return str.Substring(0, str.Length - 1);
        }
        /// <summary>
        /// Hämta data om det finns i listan annars returnera tom
        /// </summary>
        /// <param name="datalist"></param>
        /// <param name="rowtofetch"></param>
        /// <returns></returns>
        internal static string FetchItem(List<string> datalist, string rowtofetch)
        {
            foreach (var item in datalist)
            {
                if (item.Contains(rowtofetch)) //Om finns
                {
                    return item;
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// Skriv ut fel meddelandet
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="param"></param>
        internal static void WriteErrorLog(string txt, params string[] param)
        {
            Console.Write("\n" + txt + "\n", param);
        }
        
        internal static List<string> SplitDelimeter(string row)
        {
            string[] itemarray;
            string[] fieldarray;
            List<string> listvalues = new List<string>();
            itemarray = row.Split(Utilities.DELIMETER);
            for (int i = 0; i < itemarray.Length; i++)
            {
                fieldarray = itemarray[i].Split(':');
                listvalues.Add(fieldarray[1]);
            }
            return listvalues;
        }

        
    }
    
}
