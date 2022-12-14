using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Media;
using System.Diagnostics;
using System.Threading;

namespace Chivalrys_Dead
{
    class Game
    {
        static void ConsoleDraw(IEnumerable<string> lines, int x, int y)
        {
            if (x > Console.WindowWidth) return;
            if (y > Console.WindowHeight) return;

            var trimLeft = x < 0 ? -x : 0;
            int index = y;

            x = x < 0 ? 0 : x;
            y = y < 0 ? 0 : y;

            var linesToPrint =
                from line in lines
                let currentIndex = index++
                where currentIndex > 0 && currentIndex < Console.WindowHeight
                select new
                {
                    Text = new String(line.Skip(trimLeft).Take(Math.Min(Console.WindowWidth - x, line.Length - trimLeft)).ToArray()),
                    X = x,
                    Y = y++
                };

            Console.Clear();
            foreach (var line in linesToPrint)
            {
                Console.SetCursorPosition(line.X, line.Y);
                Console.Write(line.Text);
            }
        }
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
            Random Title = new Random();
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
            // Music Setup
            Console.WriteLine("Add meg százalékban hogy milyen hangos legyen a játék");
            int Game_Volume = int.Parse(Console.ReadLine());
            // Start Main Menu theme
            string Main_Menu_Music = "Searching for Integrity.wav";
            music.Play(Main_Menu_Music);
            music.SetVolume(Game_Volume);


            var Title01 = new[]
            {
                    @":::===== :::  === ::: :::  === :::====  :::      :::====  ::: ===  == :::===       :::====  :::===== :::====  :::==== ",
                    @":::      :::  === ::: :::  === :::  === :::      :::  === ::: === ==  :::          :::  === :::      :::  === :::  ===",
                    @"===      ======== === ===  === ======== ===      =======   =====       =====       ===  === ======   ======== ===  ===",
                    @"===      ===  === ===  ======  ===  === ===      === ===    ===           ===      ===  === ===      ===  === ===  ===",
                    @" ======= ===  === ===    ==    ===  === ======== ===  ===   ===       ======       =======  ======== ===  === ======= ",
            };
            var Title02 = new[]
            {
                    @" ▄████▄   ██░ ██  ██▓ ██▒   █▓ ▄▄▄       ██▓     ██▀███ ▓██   ██▓  ██████    ▓█████▄ ▓█████ ▄▄▄      ▓█████▄ ",
                    @"▒██▀ ▀█  ▓██░ ██▒▓██▒▓██░   █▒▒████▄    ▓██▒    ▓██ ▒ ██▒▒██  ██▒▒██    ▒    ▒██▀ ██▌▓█   ▀▒████▄    ▒██▀ ██▌",
                    @"▒▓█    ▄ ▒██▀▀██░▒██▒ ▓██  █▒░▒██  ▀█▄  ▒██░    ▓██ ░▄█ ▒ ▒██ ██░░ ▓██▄      ░██   █▌▒███  ▒██  ▀█▄  ░██   █▌",
                    @"▒▓▓▄ ▄██▒░▓█ ░██ ░██░  ▒██ █░░░██▄▄▄▄██ ▒██░    ▒██▀▀█▄   ░ ▐██▓░  ▒   ██▒   ░▓█▄   ▌▒▓█  ▄░██▄▄▄▄██ ░▓█▄   ▌",
                    @"▒ ▓███▀ ░░▓█▒░██▓░██░   ▒▀█░   ▓█   ▓██▒░██████▒░██▓ ▒██▒ ░ ██▒▓░▒██████▒▒   ░▒████▓ ░▒████▒▓█   ▓██▒░▒████▓ ",
                    @"░ ░▒ ▒  ░ ▒ ░░▒░▒░▓     ░ ▐░   ▒▒   ▓▒█░░ ▒░▓  ░░ ▒▓ ░▒▓░  ██▒▒▒ ▒ ▒▓▒ ▒ ░    ▒▒▓  ▒ ░░ ▒░ ░▒▒   ▓▒█░ ▒▒▓  ▒ ",
                    @"  ░  ▒    ▒ ░▒░ ░ ▒ ░   ░ ░░    ▒   ▒▒ ░░ ░ ▒  ░  ░▒ ░ ▒░▓██ ░▒░ ░ ░▒  ░ ░    ░ ▒  ▒  ░ ░  ░ ▒   ▒▒ ░ ░ ▒  ▒ ",
                    @"░         ░  ░░ ░ ▒ ░     ░░    ░   ▒     ░ ░     ░░   ░ ▒ ▒ ░░  ░  ░  ░      ░ ░  ░    ░    ░   ▒    ░ ░  ░ ",
                    @"░ ░       ░  ░  ░ ░        ░        ░  ░    ░  ░   ░     ░ ░           ░        ░       ░  ░     ░  ░   ░    ",
                    @"░                         ░                              ░ ░                  ░                       ░      ",
            };
            var Title03 = new[]
            {
                    @" ██████ ██   ██ ██ ██    ██  █████  ██      ██████  ██    ██ ███████     ██████  ███████  █████  ██████  ",
                    @"██      ██   ██ ██ ██    ██ ██   ██ ██      ██   ██  ██  ██  ██          ██   ██ ██      ██   ██ ██   ██ ",
                    @"██      ███████ ██ ██    ██ ███████ ██      ██████    ████   ███████     ██   ██ █████   ███████ ██   ██ ",
                    @"██      ██   ██ ██  ██  ██  ██   ██ ██      ██   ██    ██         ██     ██   ██ ██      ██   ██ ██   ██ ",
                    @" ██████ ██   ██ ██   ████   ██   ██ ███████ ██   ██    ██    ███████     ██████  ███████ ██   ██ ██████  ",
            };
            int Titlenum = Title.Next(1, 4);
            switch (Titlenum)
            {
                case 1:
                    Console.WindowWidth = 160;
                    Console.WriteLine("\n\n");
                    var maxLength = Title01.Aggregate(0, (max, line) => Math.Max(max, line.Length));
                    var x = Console.BufferWidth / 2 - maxLength / 2;
                    for (int y = -Title01.Length; y < Console.WindowHeight + Title01.Length; y++)
                    {
                        ConsoleDraw(Title01, x, y);
                        Thread.Sleep(100);
                    }
                    break;
                case 2:
                    Console.WindowWidth = 160;
                    Console.WriteLine("\n\n");
                    var maxLength2 = Title02.Aggregate(0, (max, line) => Math.Max(max, line.Length));
                    var x2 = Console.BufferWidth / 2 - maxLength2 / 2;
                    for (int y = -Title02.Length; y < Console.WindowHeight + Title02.Length; y++)
                    {
                        ConsoleDraw(Title01, x2, y);
                        Thread.Sleep(100);
                    }
                    break;
                case 3:
                    Console.WindowWidth = 160;
                    Console.WriteLine("\n\n");
                    var maxLength3 = Title03.Aggregate(0, (max, line) => Math.Max(max, line.Length));
                    var x3 = Console.BufferWidth / 2 - maxLength3 / 2;
                    for (int y = -Title03.Length; y < Console.WindowHeight + Title03.Length; y++)
                    {
                        ConsoleDraw(Title03, x3, y);
                        Thread.Sleep(100);
                    }
                    break;
            }
            
            // Name input
            Console.Write("Your name (2-20 characters): ");
            var Temporary_name = Console.ReadLine();
            string Player_name = "";
            int Max_name_length = 20;
            while (true)
            {
                if (IsAllAlphabetic(Temporary_name) is true)
                {
                    if (Temporary_name.Length <= Max_name_length)
                    {
                        Player_name = Temporary_name;
                    }
                    else
                    {
                        Console.WriteLine("Error: Name is too long, use 2-20 characters.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Error: Name contains non-alphabetic characters.");
                    Console.ReadKey();
                }

                Console.Write($"Are you {Player_name}? (yes/no) ");
                string Answer = Console.ReadLine();
                while (Answer != "Yes" || Answer != "yes")
                {
                    if (Answer == "yes" || Answer == "Yes")
                    {
                        Console.WriteLine("Press a key to start");
                        Console.ReadKey();
                        break;
                    }
                    else if (Answer == "no" || Answer == "No")
                    {
                        Console.Write("Your name (2-20 characters): ");
                        Temporary_name = Console.ReadLine();
                        if (IsAllAlphabetic(Temporary_name) is true)
                        {
                            if (Temporary_name.Length <= Max_name_length)
                            {
                                Player_name = Temporary_name;
                            }
                            else
                            {
                                Console.WriteLine("Error: Name is too long, use 2-20 characters.");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Name contains non-alphabetic characters.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //Console.ReadKey();
        }
    }
}
