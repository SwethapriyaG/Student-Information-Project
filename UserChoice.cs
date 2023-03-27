using System;
using System.Collections.Generic;
using System.Text;

namespace Programmering_2_projekt
{
    class UserChoice
    {
        private Input _input;
        public UserChoice(Input input)
        {
            _input = input;
        }
        /// <summary>
        /// Utför metoden baserat på användarinmatning
        /// </summary>
        /// <param name="userInput"></param>
        public bool UserChoiceCase()
        {
            string str;
            StudentOperation studentoperation = new StudentOperation(_input);
            FilHanterare filHanterare = new FilHanterare();
            Marks marks;
            int userInput = _input.UserVal();
            switch (userInput)
            {
                case 1://Skapa elev
                    bool addanotherstudent = true;
                    do
                    {
                        studentoperation.AddStudent();
                        do
                        {
                            str = _input.UserInput("Vill du ange en annan elev J/N?");
                            str = Utilities.CheckUserJN(str);
                            if (str == "J")
                            {
                                addanotherstudent = true;
                            }
                            else if (str == "N")
                            {
                                addanotherstudent = false;
                                Utilities.ConsoleClear();
                            }
                        } while ((str != "J") && (str != "N"));

                    } while (addanotherstudent == true);//loop tills användaren vill skapa inte en annan elev                    
                    break;
                
                case 2://Ta bort elev
                    studentoperation.ViewStudentAll();
                    bool delanotherstudent = true;
                    do
                    {
                        studentoperation.DeleteStudent();
                        do
                        {
                            str = _input.UserInput("Vill du ta bort en annan elev J/N?");
                            str = Utilities.CheckUserJN(str);
                            if (str == "J")
                            {
                                delanotherstudent = true;
                            }
                            else if (str == "N")
                            {
                                delanotherstudent = false;
                                Utilities.ConsoleClear();
                            }
                        } while ((str != "J") && (str != "N"));

                    } while (delanotherstudent == true);
                    break;

                case 3://Modifiera elev.
                    studentoperation.ViewStudentAll();
                    bool modifyanotherStudent = true;
                    do
                    {
                        studentoperation.ModifyStudent();
                        do
                        {
                            str = _input.UserInput("Vill du ändra en annan student J/N?");
                            str = Utilities.CheckUserJN(str);
                            if (str == "J")
                            {
                                modifyanotherStudent = true;
                            }
                            else if (str == "N")
                            {
                                modifyanotherStudent = false;
                                Utilities.ConsoleClear();
                            }
                        } while ((str != "J") && (str != "N"));

                    } while (modifyanotherStudent == true);
                    break;
                case 4://visa elev
                    if (studentoperation.ViewStudentAll())
                    {
                        bool seanotherstudent = true;

                        do
                        {
                            studentoperation.ViewStudent();
                            do
                            {
                                str = _input.UserInput("Vill du se en annan elev J/N?");
                                str = Utilities.CheckUserJN(str);
                                if (str == "J")
                                {
                                    seanotherstudent = true;
                                }
                                else if (str == "N")
                                {
                                    seanotherstudent = false;
                                    Utilities.ConsoleClear();
                                }
                            } while ((str != "J") && (str != "N"));

                        } while (seanotherstudent == true);
                    }
                    else
                    {
                        Utilities.WriteLineLog("Tryck på valfri tangent för att fortsätta......");
                        Console.ReadLine();
                        Utilities.ConsoleClear();
                    }
                    
                    break;

                case 5:// lägga märken
                    marks = new Marks(filHanterare);
                    marks.AddMarks();
                    break;
                case 6:// Ta bort märken
                    marks = new Marks(filHanterare);
                    marks.DeleteMarks();
                    Console.WriteLine("Markeringar raderas framgångsrikt");
                    break;
                case 7: // Visa marken
                    Console.Clear();
                    marks = new Marks(filHanterare);
                    marks.DisplayMarks();
                    Console.ReadLine();
                    break;
                case 8://Ta bort hela fil
                    FilHanterare filHanteraredel = new FilHanterare();
                    do
                    {
                        str = _input.UserInput("Är du säker på att du vill ta bort alla J/N?");
                        str = Utilities.CheckUserJN(str);
                        if (str == "J")
                        {
                            studentoperation.TaBortAllaStudent();//Ta Bort Alla Filer
                           
                            Utilities.WriteLineLog("Tryck på valfri tangent för att fortsätta......");
                            Console.ReadLine();
                            Utilities.ConsoleClear();
                        }
                        else if (str == "N")
                        {
                            Utilities.ConsoleClear();
                        }
                    } while ((str != "J") && (str != "N"));
                    break;

                case 9://Avslut program
                    do
                    {
                        str = _input.UserInput("Är du säker på att du vill avsluta J/N?");
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
                    break;
                default:
                    Utilities.WriteLineLog("Ditt val är ej giltigt, prova igen. Ange värdet 1-9.\n");
                    Utilities.WriteErrorLogOchContinue();
                    break;
            }
            return false;
        }
    }
}
