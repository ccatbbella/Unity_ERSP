using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

class Class1
{
    static void Main()
    {
        // Create an instance of StreamReader to read from a file.
        // The using statement also closes the StreamReader.
        string path = "C:/Users/ccatb/Documents/Bush/Assets/Data/resprouter.txt";
        using (StreamReader sr = new StreamReader(path))
        {
            string line = sr.ReadLine();
            string[] datas = line.Split(' ');
            
            int length = datas.Length;
            int idxOfBioMass = Array.IndexOf(datas, "biomass");
            List<string> biomasses = new List<string>();
            while ((line = sr.ReadLine()) != null)
            {
                datas = line.Split(' ');
                biomasses.Add(datas[idxOfBioMass]);
            }
            foreach(string biomass in biomasses)
            {
                Console.Write(biomass);
            }
        }
    }
}
