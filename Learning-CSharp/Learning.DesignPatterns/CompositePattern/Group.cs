using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DesignPatterns.CompositePattern
{
    #region Without Composite pattern
    //class Group
    //{
    //    public string Name { get; set; }
    //    public List<Person> Members { get; set; }

    //    public Group()
    //    {
    //        Members = new List<Person>();
    //    }
    //} 
    #endregion

    class Group : IParty
    {
        public string Name { get; set; }
        public int Gold
        {
            get
            {
                return Members.Sum(x => x.Gold);
            }
            set
            {
                var each = value / Members.Count;
                var leftOver = value % Members.Count;
                foreach (var member in Members)
                {
                    member.Gold += each + leftOver;
                    leftOver = 0;
                }
            }
        }

        public List<IParty> Members { get; set; }
        
        public Group()
        {
            Members = new List<IParty>();
        }

        public void Stats()
        {
            foreach (var member in Members)
            {
                member.Stats();
            }
        }
    }
}
