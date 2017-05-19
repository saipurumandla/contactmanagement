using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContactManagement
{
    // class to read and write the file.
    class fileMethods
    {
        public List<People> readFile(String fileName) // read the file and fill the list.
        {
            Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
            List<People> list = new List<People>();
            if (File.Exists(fileName)) // checking if the file exits
            {
               
                using (StreamReader reader = new StreamReader(fileName)) // if exists reading the file
                {
                    string line;
                    while ((line = reader.ReadLine()) != null) // read file line by line
                    {
                        Console.WriteLine(line);
                        String[] parts = line.Split(','); // split the lines with ','
                        if(parts.Length==2)
                        {
                            list.Add(new People() { Name = parts[0], Number = parts[1] }); // add the data to the list

                        }
                        
                    }
                }
                return list; // return the file
            }
            else // if file does not exists
            {
                Console.WriteLine("wmpty");
                return new List<People>(); // return empty list
            }
        }
        public void writeFile(List<People> list,String fileName) // write the file 
        {
            var csv = new StringBuilder(); // create a string builder
            foreach(People ppl in list) // for all the entries in the list
            {
                var newLine = string.Format("{0},{1}", ppl.Name, ppl.Number); // create a newline
                csv.AppendLine(newLine); // append a new line to the stringbuilder 
            }
            File.WriteAllText(fileName, csv.ToString()); // write the stringbuilder to file.
        }
    }
}
