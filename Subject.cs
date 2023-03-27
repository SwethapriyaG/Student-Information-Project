using System;
using System.Collections.Generic;
using System.Text;

namespace Programmering_2_projekt
{
    class Subject 
    {
       public List<string> SubjectList; //Declerar list variable
        public Subject() 
        {
            SubjectList = new List<string>();// Declerar list string varibale för Ämnen
            SubjectList.Add("1. Subject 1");
            SubjectList.Add("2. Subject 2");
            SubjectList.Add("3. Subject 3");
            SubjectList.Add("4. Subject 4");
            SubjectList.Add("5. Subject 5");


        }
    }
}
