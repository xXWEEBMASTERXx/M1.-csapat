using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Media;

namespace Chivalrys_Dead
{

    class Game
    {
        class Sound
        {
            private MediaPlayer music_Player;

            public void Play(string filename)
            {
                music_Player = new MediaPlayer();
                music_Player.Open(new Uri(filename, UriKind.Relative));
                music_Player.Play();
            }

            public void SetVolume(int volume)
            {
                music_Player.Volume = volume / 100.0f;
            }
        }
        static void Main(string[] args)
        {
            Sound music = new Sound();
            bool IsAllAlphabetic(string value)
            {
                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                        return false;
                }

                return true;
            }
            /*
            FontFamily fontFamily = new FontFamily("Old English Text MT");
            Font font = new Font(
            fontFamily,
            72,
            FontStyle.Regular,
            GraphicsUnit.Pixel);

            Console.WriteLine("Chivalry's Dead");
            */







            Console.WriteLine("Please lower volume before pressing any keys!");
            Console.ReadKey();
            string Main_Menu_Music = "Searching for Integrity.wav";

            // Name input
            music.Play(Main_Menu_Music);
            music.SetVolume(5);
            Console.Write("Enter your name: ");
            var Temporary_name = Console.ReadLine();
            if (IsAllAlphabetic(Temporary_name) is true)
            {
                string Player_name = Temporary_name;
    }
            else
            {
                Console.WriteLine("Error: name contains non Alphabetic characters");
                Console.ReadKey();
                Environment.Exit(0);
             
            }
        }
    }
}
