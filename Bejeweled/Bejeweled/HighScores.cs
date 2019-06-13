using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled
{
    [Serializable]
   public class HighScores
    {

        public List<HighScoreItem> Scores { get; set; }

        public HighScores()
        {
            Scores = new List<HighScoreItem>();
        }

        public void sort()
        {
            Scores.Sort();
        }

        public bool add(HighScoreItem item)
        {
            Scores.Add(item);
            Scores.Sort();

            if (Scores.Count > 5)
            {
                bool madeit = false;

                HighScores temp = new HighScores();
                for (int i = 0; i < 5; i++)
                {
                    temp.Scores[i] = this.Scores[i];
                    if (temp.Scores[i].Equals(item))
                    {
                        madeit = true;
                    }
                }
                this.Scores = temp.Scores;

                return madeit;
            }
            else
            {
                return true;
            }
        }
    

}
}
