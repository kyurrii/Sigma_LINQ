using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1

            String string1 = "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert";

            string[] strArr1 = string1.Split(' ');
            int strArrLength1 = strArr1.Length;

            string[] strArr11 = new string[strArrLength1];

            int i = 0;
            string sep = ".";

            foreach (string el in strArr1)
            {
                ++i;
                strArr11[i - 1] = i + sep + el;

            }

            string sep2 = " ";

            Console.WriteLine("Task1");
            foreach (string el in strArr11)
            {

                Console.WriteLine(el);
            }

            String str12 = string.Join(sep2, strArr11, 0, strArrLength1);
            Console.WriteLine(str12);
           

            //Task2

            string players = "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis,29 / 09 / 1976; Luke Shaw, 12 / 07 / 1995; Gaston Ramirez, 02 / 12 / 1990; Adam Lallana, 10 / 05 / 1988";



            String[] playersArr = players.Split(';');
            int playersListLength = playersArr.Length;

            Dictionary<string, DateTime> sepPlayers = new Dictionary<string, DateTime>();


            foreach (var el in playersArr)
            {
                string[] elem = el.Split(',');
                string Name = elem[0];
                DateTime Bdate = DateTime.Parse(elem[1]);  
                sepPlayers.Add(Name, Bdate);
            }
           /*
            foreach (KeyValuePair<string, DateTime> item in sepPlayers)
            {
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
            }       */

           // Console.ReadKey();

            DateTime datenow = DateTime.Today;

            var playersSorted = sepPlayers.OrderByDescending(s => s.Value);

            var selectresult = playersSorted.Select(s => new
            {
                PlayerName = s.Key,
                PalyerBirthDate = s.Value,
                PlayerAge =( calcTime(datenow, s.Value).Days/365)
            }
                                           );
            Console.WriteLine("Task2");
            foreach (var item in selectresult)
            {
                Console.WriteLine("Name: {0}, BirthDate: {1}, Age: {2} ", item.PlayerName, item.PalyerBirthDate,item.PlayerAge);
            }

           
            //Task3

            string songstring = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";
            String[] songArr = songstring.Split(',');

            int length = songArr.Length;
            int[] songArrTime = new int[length];

            DateTime timeZero = DateTime.Today;

            i = 0;
            foreach(string item in songArr)
            {
                ++i;
                songArrTime[i-1]= (int)calcTime( DateTime.Parse(item), timeZero).TotalSeconds/60;
               
            };

            int totalSoundDuration = songArrTime.Sum();

            Console.WriteLine("Task3");
            foreach (var item in songArrTime)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Total sound duration, seconds : {0}", totalSoundDuration);

           Console.ReadKey();
        }


        

           public static TimeSpan calcTime (DateTime date1,DateTime date2)
           {
             var interval = date1 - date2;

             return interval;
           }

         public class Player
        {
            public string Name { get; set; }
            public DateTime Bdate { get; set; }
        }

    }
}
