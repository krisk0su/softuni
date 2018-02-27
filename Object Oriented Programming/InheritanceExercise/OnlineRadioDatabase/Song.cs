using System;
using System.Collections.Generic;
using System.Security;
using System.Text;


public class Song
{
    private string artistName;

    public string ArtistName
    {
        get { return this.artistName; }

        set
        {
            if (string.IsNullOrEmpty(value) || value.Length < 3 || value.Length > 20)
            {
                throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
            }

            this.artistName = value;
        }
    }

    private string name;

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length < 3 || value.Length > 20)
            {
                throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
            }
            this.name = value;
        }
    }

    private int minutes;

    public int Minutes
    {
        get { return minutes; }

        set
        {   
            //minutes
            if (value < 0 || value > 14)
            {
                throw new ArgumentException("Song minutes should be between 0 and 14.");
            }

            minutes = value;


        }
    }

    private int seconds;

    public int Seconds
    {
        get { return seconds; }
        set
        {
            //seconds
            if (value < 0 || value > 59)
            {
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            }
            seconds = value;
        }
    }


    public Song(string artistName, string name, int minutes, int seconds)
    {
        ArtistName = artistName;

        Name = name;

        Minutes = minutes;

        Seconds = seconds;
    }


}

