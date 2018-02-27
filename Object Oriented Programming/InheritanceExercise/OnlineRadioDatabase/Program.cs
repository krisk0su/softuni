using System;
using System.Linq;

namespace OnlineRadioDatabase
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            int counter = 0;

            var ts = new TimeSpan();

            for (int i = 0; i < n; i++)
            {
                try
                {

                    var tokens = Console.ReadLine().Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);


                    var artist = tokens[0];

                    var name = tokens[1];

                    var duration = tokens[2].Split(":");

                    int minutes = 0;
                    int seconds = 0;

                    try
                    {
                        minutes = int.Parse(duration[0]);
                        seconds = int.Parse(duration[1]);
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException ("Invalid song length.");
                      

                    }
                    Song son = new Song(artist, name, minutes, seconds);

                    Console.WriteLine("Song added.");
                    counter++;
                   

                    ts += TimeSpan.FromSeconds(seconds);
                    ts += TimeSpan.FromMinutes(minutes);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }

            Console.WriteLine($"Songs added: {counter}");
            Console.WriteLine($"Playlist length: {ts.Hours}h {ts.Minutes}m {ts.Seconds}s");
           
        }
    }

    
}
