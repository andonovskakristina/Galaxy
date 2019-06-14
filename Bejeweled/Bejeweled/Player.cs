using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled
{
   public class Player
    {
        public string Name { get; set; }
        public int score { get; set; }

        public Player() { }
        public Player (string n,int s)
        {
            Name = n;
            score = s;
        }

       public override string ToString()
        {
            return Name + " - " + score;
        }
             
    }
}
