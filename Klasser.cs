using System;
using System.Collections.Generic;
using System.Text;

namespace Programmering_2_projekt
{
    class Klasser
    {
        public List<string> KlasserList;
        public Klasser()
        {
            // Declerar objekt 
            KlasserList = new List<string>();
            KlasserList.Add("1. Klass 1");
            KlasserList.Add("2. Klass 2");
            KlasserList.Add("3. Klass 3");
            KlasserList.Add("4. Klass 4");
            KlasserList.Add("5. Klass 5");
            KlasserList.Add("6. Klass 6");
            KlasserList.Add("7. Klass 7");
            KlasserList.Add("8. Klass 8");
            KlasserList.Add("9. Klass 9");
        }
        public string GetSubjekt(string slno)//metod för klass
        {
            foreach (var item in this.KlasserList)
            {
                if (item.Contains(slno + "."))
                {
                    return item.Substring(3);
                }
            }
            return "";
        }



    }
}
