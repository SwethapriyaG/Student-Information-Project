using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Programmering_2_projekt
{
    class Marks
    {
        private FilHanterare _filHanterare;
        private string filnamn = "marks.txt";
        public Marks(FilHanterare filHanterare)
        {
            _filHanterare = filHanterare;
        }
       public string Result(int[] StuMarks)
        {
            float Total = 0; //Declerer variable
            for (int i = 0; i < StuMarks.Length; i++) // If condition för att lägga till alla ämnesmärken
            {
                  
                Total += StuMarks[i];
            }
            
            double Avg = Total / (StuMarks.Length); // genomsnittliga betyg
            if (Avg >= 35) // If condition för att säga godkänna eller misslyckas
            {
                return "pass";
            }
            else if (Avg < 35)
            {
                return "fail";
            }
            else
                return "unknown"; 

        }
        public void AddMarks() // AddMarks metod använder att lägga märken 
        {
            //Declerar string variable
            string str= "";
            string grade ="";
            string rollno;
            string mark1;
            double mark2;
            string record;
            bool incorrectval=false;
            
            Klasser klasser = new Klasser(); // Declerar klasser objekt från Klasser klass
            List<double> markslist = new List<double>();// Declerar double variable list för markslist variable
            Subject subject = new Subject();  // Declerar objekt från Subject klass
            do // do loop att hitta klass
            {
                if (str == "")
                {
                    for (int i = 0; i < klasser.KlasserList.Count; i++) // for loop att söka klassen
                    {
                        Console.WriteLine(klasser.KlasserList[i]);
                    }
                    do
                    {
                        Console.WriteLine("Välj betyg:");
                        grade = Console.ReadLine(); // användare kan Välja betyg
                        if (grade != "") 
                        {
                            grade = klasser.GetSubjekt(grade);
                        }
                    } while (grade == ""); 
                }
                do
                {
                    Student student = new Student(_filHanterare);
                    List<string> datalist = student.FetchStudentsFrmFil(); //Hämta alla elever                                                                   
                    Console.WriteLine("Ange elevs rullnum...");
                    rollno = Console.ReadLine(); //  kan ta elevs rullnum från användare
                    record = Utilities.FetchItem(datalist, "ElevRull:" + rollno + Utilities.DELIMETER);//kolla om elev 
                    if (!(record == string.Empty))
                    {                  
                        for (int i = 0; i < subject.SubjectList.Count; i++) //for loop för att ämne och märken
                        {
                            Console.Write(subject.SubjectList[i] + " : ");
                            do
                            {
                                incorrectval = false;
                                mark1 = Console.ReadLine();
                                double.TryParse(mark1, out mark2);
                                
                                if (!mark1.All(char.IsDigit))
                                {
                                    incorrectval = true;
                                }
                                if (!((mark2 >= 0) && (mark2 <= 100))) // If condition kan endast tillåta ett visst minimum och maximalt antal
                                {
                                    incorrectval = true;
                                }
                                if (incorrectval == true)
                                {
                                    Console.WriteLine("Ange mellan 0 och 100."); //En meddelande Att veta användare, vilket numret de kan använda
                                }
                            } while (incorrectval == true);

                            markslist.Add(mark2);
                            string str1;
                            str1 = "ElevRull:" + rollno;
                            str1 += ";Grade:" + grade;
                            str1 += ";Subject:" + subject.SubjectList[i];

                            str1 += ";Mark:" + mark2;
                            _filHanterare.AppendFile(str1, filnamn); 
                        }
                    }
                    else
                    {
                        Console.WriteLine("Elev RullNum:" + rollno + " not found ");
                    }
                } while (record == "");
                Console.WriteLine("Vill du ange betyg för en annan elev J/N?");
                str = Console.ReadLine();
            } while (str.ToUpper() == "J");
        }

        public void DeleteMarks() //Metod att ta bort märken
        {
            
            string grade;
            Klasser klasser = new Klasser();
            string linetofetch = "";

            Console.WriteLine("Ange elevs rullnum att radera:");
            string studentrollno = Console.ReadLine();

            for (int i = 0; i < klasser.KlasserList.Count; i++) //loop för klass
            {
                Console.WriteLine(klasser.KlasserList[i]);
            }
            Console.WriteLine("Välj betyg:");
            grade = Console.ReadLine();
            grade = klasser.GetSubjekt(grade);
            linetofetch = "ElevRull:" + studentrollno;
            linetofetch += ";Grade:" + grade;

            List<string> datalist = FetchMarksFrmFil(); //Hämta alla elever
                                                        //kolla om elev 

            string item = Utilities.FetchItem(datalist, linetofetch);
            if (item == string.Empty)
            {
                Utilities.WriteErrorLog("Elev finns inte.");
            }
            else
            {
                var a = datalist.Where(t => !t.Contains(linetofetch)).ToArray();
                RewriteMarksFil(a);
            }


        }
        public void DisplayMarks()//Metod för visa märken
        {
            //Declerar variable och objekter
            string grade;
            Klasser klasser = new Klasser();
            Student student = new Student(_filHanterare);
            Subject subject = new Subject();
            string linetofetch = "";
            string[] itemarray;
            string[] fieldarray;
            int[] subjectmarks = new int[subject.SubjectList.Count];
            

            Console.Clear();

            for (int i = 0; i < klasser.KlasserList.Count; i++) // for loop för lista klasser
            {
                Console.WriteLine(klasser.KlasserList[i]);
            }
            Console.WriteLine("Välj betyg:");
            grade = Console.ReadLine();
            grade = klasser.GetSubjekt(grade);

            Console.WriteLine("Ange elevs rullnum för att visa::");
            string inputString = Console.ReadLine();

            List<string> studentdatalist = student.FetchStudentsFrmFil(); //Hämta alla elever                                                                   
            string record = Utilities.FetchItem(studentdatalist, "ElevRull:" + inputString + Utilities.DELIMETER);//kolla om elev 
            if (record != string.Empty)
            {
                
                //fileMethods.BreakLine('-', 50);
                List<string> studentitem = Utilities.SplitDelimeter(record);
                student = new Student(studentitem[0], studentitem[1], studentitem[2]);
                student.ViewStudent();
                //fileMethods.BreakLine('-', 50);
                List<string> datalist = FetchMarksFrmFil();
                if (datalist.Count > 0)
                {
                    for (int i = 0; i < subject.SubjectList.Count; i++) // ämne list
                    {
                        linetofetch = "ElevRull:" + inputString;
                        linetofetch += ";Grade:" + grade;
                        foreach (var item in datalist) // söker vajre list for den här rullen
                        {
                            if (item.Contains(linetofetch + ";Subject:" + subject.SubjectList[i])) // Söker ämnem sedan splitar med :
                            {
                                itemarray = item.Split(';');
                                fieldarray = itemarray[3].Split(':');
                                Console.WriteLine(subject.SubjectList[i] + " : " + fieldarray[1]);
                                subjectmarks[i] = int.Parse(fieldarray[1]);
                                break;
                            }
                        }
                    }
                    //fileMethods.BreakLine('-', 50); // skriva ut -
                    Console.WriteLine("Totalt antal betyg : " + TotalMarks(subjectmarks).ToString());// visar alla ämnen 
                    Console.WriteLine("Resultat : " + Result(subjectmarks));
                    //fileMethods.BreakLine('-', 50);
                    Console.WriteLine("Tryck på valfri tangent för att fortsätta......");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Elev RullNum:" + inputString + " hittades inte att visa.");
                }
            }
            else
            {
                Console.WriteLine("Elev RullNum:" + inputString + " hittades inte att visa.");
            }
        }
        /// <summary>
        /// Skriva all elev data to fil
        /// </summary>
        /// <param name="str"></param>
        public void RewriteMarksFil(string[] str)
        {
            _filHanterare.RewriteFil(str, filnamn);
        }
        private int TotalMarks(int[] subjectmarks) // Metod for totalt märken
        {
            int total=0;
            for (int i = 0; i < subjectmarks.Length; i++) // loop för räkna märken
            {
                total += subjectmarks[i];
            }
            return total;
        }
        /// <summary>
        /// All elever från FIl to List
        /// </summary>
        /// <returns></returns>
        public List<string> FetchMarksFrmFil()
        {
            return _filHanterare.FetchAllLines(filnamn);
        }
    }
}
