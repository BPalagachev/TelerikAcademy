using System;
using System.Collections;
using System.Collections.Generic;

namespace SchoolOrganization
{
    public class School
    {
        private IList<ClassGroup> classes;

        public School()
        {
            this.classes = new List<ClassGroup>();
        }

        public IEnumerable GetClasses
        {
            get
            {
                IList<ClassGroup> set = new List<ClassGroup>();
                foreach (var group in this.classes)
                {
                    set.Add(group);
                }

                return set;
            }
        }
        
        public void AddClass(ClassGroup group)
        {
            this.classes.Add(group);
        }

        public void RemoveClass(ClassGroup group)
        {
            this.classes.Remove(group);
        }
    }
}
