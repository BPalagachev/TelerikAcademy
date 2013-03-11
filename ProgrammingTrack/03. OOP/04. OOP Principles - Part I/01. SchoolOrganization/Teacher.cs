using System;
using System.Collections;
using System.Collections.Generic;

namespace SchoolOrganization
{
    public class Teacher : Person, ICommentable
    {
        private IList<Discipline> setOfDisciplines;

        public Teacher(string aName)
            : base(aName)
        {
            this.setOfDisciplines = new List<Discipline>();
        }

        public IEnumerable GetSetOfDisciplines
        {
            get
            {
                IList<Discipline> set = new List<Discipline>();
                foreach (var discipline in this.setOfDisciplines)
                {
                    set.Add(discipline);
                }

                return set;
            }
        }

        public string Comments { get; set; }

        public void AddDiscipline(Discipline discipline)
        {
            this.setOfDisciplines.Add(discipline);
        }
    }
}
