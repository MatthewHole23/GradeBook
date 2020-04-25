using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
       public class NamedObject
    {
        public string name;
        
        public NamedObject(string name)
        {
            Name = name;
        }
        

        // need to think of a way to implement this effectively
        public string Name
        {
            get;    //using the generic get and set keywords without any additional implementation
            set;

            // this code needs to be effectively implemented generically so any new object 'book' creation goes through this 'set' routine
            /*
            get
            {
                return name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    name = value;

                }
                else
                {
                    throw new FormatException("A gradebook's name cannot be empty");
                }
            }
            */
        }

    }
}
