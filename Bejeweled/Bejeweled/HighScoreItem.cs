using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled
{
    [Serializable]
      public class HighScoreItem : IComparable<HighScoreItem>
    {
        public string player { get; set; }
        public int score { get; set; }

       
        public int CompareTo(HighScoreItem other)
        {
            return this.score.CompareTo(other.score);
        }
        public bool Equals(HighScoreItem other)
        {
            return this.player.Equals(other.player) && this.score.Equals(other.score);
        }
    }
}
