using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Drawing;
using System.Windows;

namespace Chivalrys_Dead
{
    class Program
    {
        static void Main(string[] args)
        {
            bool IsAllAlphabetic(string value)
            {
                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                        return false;
                }

                return true;
            }
            
            FontFamily fontFamily = new FontFamily("Old English Text MT");
            Font font = new Font(
               fontFamily,
               72,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
            
            Console.WriteLine("Chivalry's Dead");









            Console.WriteLine("Please lower volume before pressing any keys!");
            Console.ReadKey();

            // Name input
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Searching for Integrity.wav";
            player.Play();
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
            player.Stop();
        }
    }
}
