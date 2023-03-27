using System;
using System.Collections.Generic;
using System.Text;

namespace Programmering_2_projekt
{
    public class Student
    {
        private string stdroll;
        private string stdname;
        private string stdaddress;
        private string filnamn = "student.txt";

        private readonly FilHanterare _filHanterare;
        
        public List<string> FieldNamnDisplay;
        public string StdRoll
        {
            get
            {
                return stdroll;
            }
            private set
            {
                stdroll = value;
            }
        }
        public string StdName
        {
            get
            {
                return stdname;
            }
            private set
            {
                stdname = value;
            }
        }
        public string StdAddress
        {
            get
            {
                return stdaddress;
            }
            private set
            {
                stdaddress = value;
            }
        }
        public Student(FilHanterare filHanterare)
        {
            FieldNamnDisplayDef();

            this._filHanterare = filHanterare;
        }
        public Student(string stdroll, string stdname, string stdaddress, FilHanterare filHanterare)
        {
            FieldNamnDisplayDef();

            this.stdroll = stdroll;
            this.stdname = stdname;
            this.stdaddress = stdaddress;
            this._filHanterare = filHanterare;
        }
        public Student(string stdroll, string stdname, string stdaddress)
        {
            FieldNamnDisplayDef();

            this.stdroll = stdroll;
            this.stdname = stdname;
            this.stdaddress = stdaddress;
        }
        /// <summary>
        /// Kolumnrubrik för elev
        /// </summary>
        /// <returns></returns>
        private List<string> FieldNamnDisplayDef()
        {
            FieldNamnDisplay = new List<string>();
            FieldNamnDisplay.Add("Elev rull");
            FieldNamnDisplay.Add("Elev Namn");
            FieldNamnDisplay.Add("Elev Adress");
            return FieldNamnDisplay;
        }
        /// <summary>
        /// Visa elev
        /// </summary>
        public void ViewStudent()
        {
            Utilities.WriteLineLog(FieldNamnDisplay[0] + " : " + this.stdroll);
            Utilities.WriteLineLog(FieldNamnDisplay[1] + " : " + this.stdname);
            Utilities.WriteLineLog(FieldNamnDisplay[2] + " : " + this.stdaddress);
            Utilities.WriteLineLog("\n");
        }
        /// <summary>
        /// format texten till skriva till fil
        /// </summary>
        /// <returns></returns>
        private string StudentTxtFil(string roll, string name, string address)
        {
            string str = "";
            str += "ElevRull:" + roll + Utilities.DELIMETER;
            str += "ElevNamn:" + name + Utilities.DELIMETER;
            str += "ElevAdress:" + address;
            return str;
        }
        /// <summary>
        /// Skapa en student till fil
        /// </summary>
        public void AppendStudent()
        {
            _filHanterare.AppendFile(StudentTxtFil(this.StdRoll, this.StdName, this.StdAddress.ToString()), filnamn);
        }
        /// <summary>
        /// Skriva all elev data till fil
        /// </summary>
        /// <param name="str"></param>
        public void RewriteStudentFil(string[] str)
        {
            _filHanterare.RewriteFil(str, filnamn);
        }        
        /// <summary>
        /// All elever från FIl to List
        /// </summary>
        /// <returns></returns>
        public List<string> FetchStudentsFrmFil()
        {
            return _filHanterare.FetchAllLines(filnamn);
        }        
        /// <summary>
        /// Ta bort student fil
        /// </summary>
        public void DeleteStudentFil()
        {
            _filHanterare.DeleteFile(filnamn);
        }
    }
}
