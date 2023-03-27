using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Programmering_2_projekt
{
    class StudentOperation
    {
        private readonly Input _input;

        public StudentOperation(Input input)
        {
            _input=input;
        }
        /// <summary>
        /// Skapa elev
        /// </summary>
        public void AddStudent()
        {
            string StdRollNo, StdName, StdAddress;
            
            FilHanterare filHanterare = new FilHanterare();// instansierar ett objekt
            //Validera elev rullnum
            StdRollNo = _input.Code("Ange elevs rullnum:"); // Det ska ta rullnummer från användaren
            
            Student student = new Student(filHanterare);
            List<string> datalist = student.FetchStudentsFrmFil(); //Hämta alla elever                                                                    
            string item = Utilities.FetchItem(datalist, "ElevRull:" + StdRollNo + Utilities.DELIMETER);//kolla om elev
            if (item == string.Empty)
            {
                
                //Validera elev namn
                StdName = _input.Namn("Stiga elevs namn:"); // tar namn från användar och spara i variable
                StdAddress = _input.StudentAddress(); // tar adress från användar och spara i variable
                
                student = new Student(StdRollNo, StdName, StdAddress, filHanterare);
                student.AppendStudent();//skapa to fil
                Utilities.WriteLineLog("\nElev hade lagt framgångsrikt.\n");// en meddelande till användar
                Utilities.WriteLineLog("*****************************");
                student.ViewStudent(); ;//vis ut
            }
            else
            {
                Utilities.WriteErrorLog("Elev finns redan.");
                List<string> studentitem = Utilities.SplitDelimeter(item);
                student = new Student(studentitem[0], studentitem[1], studentitem[2]);
                student.ViewStudent();
            }
        }
        /// <summary>
        /// Visa all elever
        /// </summary>
        public bool ViewStudentAll()
        {
            FilHanterare filHanterare = new FilHanterare();
            Student student = new Student(filHanterare);
            List<string> datalist = student.FetchStudentsFrmFil(); //Hämta alla elev                                                                   
            if (!(datalist.Count > 0))
            {
                Utilities.WriteErrorLog("Elev finns inte.");
                return false;
            }
            else
            {
                foreach (var item in datalist)
                {
                    List<string> studentitem = Utilities.SplitDelimeter(item);
                    student = new Student(studentitem[0], studentitem[1], studentitem[2]);
                    student.ViewStudent();

                }
                return true;
            }
        }
        /// <summary>
        /// Ta bort student
        /// </summary>
        public void DeleteStudent()
        {
            string studentroll;
            FilHanterare filHanterare = new FilHanterare();
            //Validera elev rull
            studentroll = _input.Code("Ange elev rull:",true);
            Student student = new Student(filHanterare);
            List<string> datalist = student.FetchStudentsFrmFil(); //Hämta alla elever
                                                                   //kolla om elev 

            string delSearchString = "ElevRull:" + studentroll + Utilities.DELIMETER;
            string item = Utilities.FetchItem(datalist, delSearchString);
            if (item == string.Empty)
            {
                Utilities.WriteErrorLog("Elev finns inte.");
            }
            else
            {
                var a = datalist.Where(t => !t.Contains(delSearchString)).ToArray();
                student.RewriteStudentFil(a);
            }
        }
        /// <summary>
        /// Visa en elev
        /// </summary>
        public void ViewStudent()
        {
            string studentroll;
            FilHanterare filHanterare = new FilHanterare();
            //Validera elevs rull
            studentroll = _input.Code("Ange elev rull:",true);
            Student student = new Student(filHanterare);
            List<string> datalist = student.FetchStudentsFrmFil(); //Hämta alla elever                                                                   
            string item = Utilities.FetchItem(datalist, "ElevRull:" + studentroll + Utilities.DELIMETER);//kolla om elev 
            if (item == string.Empty)
            {
                Utilities.WriteErrorLog(studentroll + " finns inte.");
            }
            else
            {
                List<string> studentitem = Utilities.SplitDelimeter(item);
                student = new Student(studentitem[0], studentitem[1], studentitem[2]);
                student.ViewStudent();
            }
        }
        /// <summary>
        /// Ändra Elev
        /// </summary>
        public void ModifyStudent()
        {
            string stdroll, stdname, stdaddress, str1;
            
            bool modifiedstudent = false;

            FilHanterare filHanterare = new FilHanterare();
            Student student = new Student(filHanterare);

            //Validera elev rull
            stdroll = _input.Code("Ange elev code:",true);
            //Hämta alla elev
            List<string> datalist = student.FetchStudentsFrmFil();
            //sök string
            string ModSearchString = "ElevRull:" + stdroll + Utilities.DELIMETER;
            //kolla om elev finns
            string item = Utilities.FetchItem(datalist, ModSearchString);
            if (item == string.Empty)
            {
                Utilities.WriteErrorLog("Elev finns inte.");
            }
            else
            {

                List<string> studentitem = Utilities.SplitDelimeter(item);
                student = new Student(studentitem[0], studentitem[1], studentitem[2], filHanterare);
                stdname = studentitem[1];
                stdaddress = studentitem[2];
                student.ViewStudent();

                //Kolla användaren om de vill ändra elev namn
                do
                {
                    str1 = _input.UserInput("Vill du ändra elev namn J/N?");
                    str1 = Utilities.CheckUserJN(str1);
                    if (str1 == "J")
                    {
                        do
                        {
                            //Validera elev namn
                            stdname = _input.Namn("Ange elev namn:");
                            modifiedstudent = true;
                        } while (Utilities.ValidateText(stdname, 1, 20) == "");
                    }

                } while ((str1 != "J") && (str1 != "N"));

                //Kolla användaren om de vill ändra elves adress
                do
                {
                    str1 = _input.UserInput("Vill du ändra elves adress J/N?");
                    str1 = Utilities.CheckUserJN(str1);
                    if (str1 == "J")
                    {
                        do
                        {
                            Utilities.WriteLog("Ange elevs adress:");
                            stdaddress = Console.ReadLine();
                            modifiedstudent = true;
                        } while (stdaddress == ""); 
                    }
                } while ((str1 != "J") && (str1 != "N"));
                //Om användaren ändra elevs namn eller elevs adress då ändra fil
                if (modifiedstudent)
                {
                    var a = datalist.Where(t => !t.Contains(ModSearchString)).ToArray();
                    student.RewriteStudentFil(a);
                    student = new Student(stdroll, stdname, stdaddress, filHanterare);
                    student.AppendStudent();
                }
            }
        }


        public void TaBortAllaStudent()
        {
            FilHanterare filHanterare = new FilHanterare();
            Student student = new Student(filHanterare);
            student.DeleteStudentFil();            
        }
    }
}
