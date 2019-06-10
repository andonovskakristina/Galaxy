using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled

{
    public class Sound {
    public string Name { get; set; }
    public int redenBroj { get; set; }

    public SoundPlayer song { get; set; }


    public Sound()
    {
        song = new SoundPlayer();
        redenBroj = 0;
    }

    public SoundPlayer GetSong(int index)
    {
        if (index == 0)
        {
            song = new SoundPlayer("505 lyrics - Arctic Monkeys-.wav");
            Name = "505";
        }
        if (index == 1)
        {
            song = new SoundPlayer("Queen - I Want To Break Free (Official Video) (1).wav");
            Name = "I want to break free";
        }
        if (index == 2)
        {
            song = new SoundPlayer("Queen - Love of my life.wav");
            Name = " Love of my life";
        }
        if (index == 3)
        {
            song = new SoundPlayer("Sting - Englishman In New York.wav");
            Name = "Englishman in new york";
        }
        if (index == 4)
        {
            song = new SoundPlayer("System Of A Down - Toxicity.wav");
            Name = " System of a down";
        }
        if (index == 5)
        {
            song = new SoundPlayer("The Police - Roxanne (Official Music Video)-[AudioTrimmer.com].wav");
            Name = "Roxanne";
        }
        if (index == 6)
        {
            song = new SoundPlayer("The White Stripes - 'Seven Nation Army.wav");
            Name = "Seven nation army";
        }
        if (index == 7)
        {
            song = new SoundPlayer("Тоше Проески - Игри без граници (HQ).wav");
            Name = "Igri bez granici";
        }

        return song;
    }
}
}
