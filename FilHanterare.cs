using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Programmering_2_projekt
{
    public class FilHanterare
    {
        private string FilPath = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory()) + Utilities.PathNamn;

        public FilHanterare() { }
        /// <summary>
        /// skriver in en ström av data till en fil
        /// </summary>
        /// <param name="text"></param>
        public void AppendFile(string text, string FilNamn)
        {
            FilNamn = this.FilPath + "\\" + FilNamn;
            if (!FileExists(FilNamn))
            {
                DirCreate();////Skapar katalog 
            }
            using (StreamWriter streamwriter = File.AppendText(FilNamn))
            {
                streamwriter.WriteLine(text);//skriva till file
            }
        }
        /// <summary>
        /// Skapa katalog om finns inte
        /// </summary>
        private void DirCreate()
        {
            if (!Directory.Exists(this.FilPath))
            {
                Directory.CreateDirectory(this.FilPath);
            }
        }

        /// <summary>
        /// Returnerar bool om fil finns
        /// </summary>
        /// <param name="FilNamn"></param>
        /// <returns></returns>
        public bool FileExists(string FilNamn)
        {
            return File.Exists(FilNamn);
        }
        /// <summary>
        /// Från fil data till listan
        /// </summary>
        /// <returns></returns>
        public List<string> FetchAllLines(string filNamn)
        {
            filNamn = this.FilPath + "\\" + filNamn;

            if (FileExists(filNamn))
                return File.ReadAllLines(filNamn).ToList();

            return new List<string>();
        }
        /// <summary>
        /// Skriva data tillbaka till fil
        /// </summary>
        /// <param name="str"></param>
        /// <param name="FilNamn"></param>
        public void RewriteFil(string[] str, string FilNamn)
        {
            FilNamn = this.FilPath + "\\" + FilNamn;
            if (!FileExists(FilNamn))
            {
                DirCreate();////Skapar katalog 
            }
            File.WriteAllLines(FilNamn, str);
        }
        /// <summary>
        /// Tar bort fil
        /// </summary>
        public void DeleteFile(string FilNamn)
        {
            FilNamn = this.FilPath + "\\" + FilNamn;
            if (!FileExists(FilNamn))
            {
                Utilities.WriteLineLog("\nFil {0} finns inte.\n", FilNamn);
            }
            else
            {
                File.Delete(FilNamn);
                Utilities.WriteLineLog("\nFil {0} har tagits bort.\n", FilNamn);
            }
        }        
    }
}
