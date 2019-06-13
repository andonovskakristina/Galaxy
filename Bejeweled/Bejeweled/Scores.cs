using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled
{
    [Serializable]
    public class Scores
    {
        List<HighScoreItem> HS;
        public Scores()
        {
            HS = new List<HighScoreItem>();  
        }

     
        public void add(HighScoreItem item)
        {
             HS.Add(item);
        }


    }
}
