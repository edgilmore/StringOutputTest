using System;
using System.Collections.ObjectModel;
/*
 * Test: Output a string of nested folder names
 * 
 * */
namespace StringOutputTest
{
    class Program
    {
        static void Main()
        {
            Collection<Folder> folderCollection = new Collection<Folder> {new Folder("Doc", null)};
            folderCollection.Add(new Folder("Videos", folderCollection[0]));
            folderCollection.Add(new Folder("Vacation", folderCollection[1]));
            Console.WriteLine(folderCollection[2].GetFolderPath());
            Console.ReadLine();
        }        
    }
    public class Folder
    {
        //properties
        public string Name { get; set; }
        public Folder ParentFolder { get; set; }
        //constructor
        public Folder(string folderName, Folder parentFolder)
        {
            this.Name = folderName;
            this.ParentFolder = parentFolder;
        }
        //method
        public string GetFolderPath()
        {            
            if (this.ParentFolder == null)
            {
                return Name;
            }
            else
            {
                var str = this.ParentFolder.GetFolderPath();
                str += "/";
                str += this.Name;
                return str;
            }                     
        }
    }
}
