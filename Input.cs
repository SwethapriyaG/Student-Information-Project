using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmering_2_projekt
{
    class Input
    {
        /// <summary>
        /// Acceptera värde som anges av användaren
        /// </summary>
        /// <returns></returns>
        public int UserVal()
        {
            string inputstring = Console.ReadLine();
            return Utilities.ValidateInt(inputstring);
        }
        /// <summary>
        /// Acceptera texten som anges av användaren
        /// </summary>
        /// <returns></returns>
        public string UserInput(string msg)
        {
            Utilities.WriteLog(msg);
            return Console.ReadLine();
        }
        /// <summary>
        /// Kolla användaren om Avslut program eller Fortsätta
        /// </summary>
        /// <returns></returns>
        public bool ProgramAvslut()
        {
            string str;
            do
            {
                str = UserInput("Är du säker på att du vill avsluta J/N?");
                str = Utilities.CheckUserJN(str);
                if (str == "J")
                {
                    return true;
                }
                else if (str == "N")
                {
                    Utilities.ConsoleClear();
                }
            } while ((str != "J") && (str != "N"));
            return false;
        }
        

        /// <summary>
        /// Validera code 4 långd och andras till storabokstav
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public string Code(string msg,bool invalidproceed=false)//"Ange elev rull:"
        {
            string str = "";
            do
            {
                Utilities.WriteLog(msg);
                str = Console.ReadLine();
                str = str.ToUpper();

            } while (Utilities.ValidateText(str, 4, 4) == ""&& invalidproceed==false);//Loopa tills användaren anger rätt värde
            return str;
        }
        /// <summary>
        /// Validera namn
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public string Namn(string msg)
        {
            string str = "";
            do
            {
                Utilities.WriteLog(msg);
                str = Console.ReadLine();
            } while (Utilities.ValidateText(str, 1, 20) == "");//Loopa tills användaren anger rätt värde
            return str;
        }
        
        /// <summary>
        /// Validera Address
        /// </summary>
        /// <returns></returns>
        public string StudentAddress()
        {
            string str = "";
            do
            {
                Utilities.WriteLog("Ange elev adress:");
                str = Console.ReadLine();
            } while (string.IsNullOrEmpty(str));//Loopa tills användaren anger rätt värde
            return str;
        }
    }
}
