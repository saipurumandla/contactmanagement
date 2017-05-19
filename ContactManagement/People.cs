using System;

namespace ContactManagement
{
    //class to store the contact information
    class People
    {
        public String Name { get; set; }// name of the contact
        public String Number { get; set; } // contact number of the contact (used string to be able to add more usability of country codes)
        //constructor to initiate the class members
        public People(String Name, String Number)
        {
            this.Name = Name;
            this.Number = Number;
        }
        //default constructor
        public People()
        {
            this.Name = "";
            this.Number = "";
        }
        //Method overridding to indentify duplicates based on the hashcode generated.
        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Number.GetHashCode();
        }
        //overridding the equals method to give flexibility to the class operations.
        public override bool Equals(object obj)
        {
            People ppl = obj as People;
            return ppl != null && ppl.Name == this.Name && ppl.Number == this.Number;
        }
        }
}
