using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAAFinalProject
{
    public class Player
    {

        // Fields of the player
        private string name;
        private string surname;
        private int birth_year;
        private int age;
        private string market_value;
        private string position;
        private int shirt_number;
        private string nationality;
        private int height;
        private Team team;

        // Properties of the player
        public string Name { get { return this.name; } set { this.name = value; } }
        public string Surname { get { return this.surname; } set { this.surname = value; } }
        public int BirthYear
        {
            get
            {
                return this.birth_year;
            }
            set
            {
                Age = DateTime.Now.Year - value; // Subtract the birth year from the current year and send it to the Age property
                this.birth_year = value;
            }
        }
        public int Age { get { return this.age; } set { this.age = value; } }
        public string MarketValue { get { return this.market_value; } set { this.market_value = value; } }
        public string Position { get { return this.position; } set { this.position = value; } }
        public int ShirtNumber { get { return this.shirt_number; } set { this.shirt_number = value; } }
        public string Nationality { get { return this.nationality; } set { this.nationality = value; } }
        public int Height { get { return this.height; } set { this.height = value; } }
        public Team Team { get { return this.team; } set { this.team = value; } }


        public static void DisplayPlayersDetailed(ProjectList<Player> PlayerList, string teamName) // Method that displays detailed information of players on the selected team
        {
            Console.Clear();
            int counter = 0;

            foreach (Player p in PlayerList.GetEnumerator()) // Iterate through the list and create a player object named p
            {
                if (Equals(p.Team.Name.ToUpper(), teamName.ToUpper())) // Display players whose team name matches the input
                {
                    counter++;
                    Console.WriteLine("{0}. Futbolcu -> ", counter);
                    Console.WriteLine("İsim : {0}", p.name);
                    Console.WriteLine("Soyisim : {0}", p.surname);
                    Console.WriteLine("Doğum Yılı : {0}", p.birth_year);
                    Console.WriteLine("Yaş : {0}", p.age);
                    Console.WriteLine("Piyasa Değeri : {0}", p.market_value);
                    Console.WriteLine("Mevki : {0}", p.position);
                    Console.WriteLine("Forma Numarası : {0}", p.shirt_number);
                    Console.WriteLine("Uyruk : {0}", p.nationality);
                    Console.WriteLine("Boy : {0}", p.height);
                    Console.WriteLine("Takım : {0}", p.Team.Name);
                    Console.WriteLine(" ");
                }
            }

            if (counter == 0) // If no player is found
            {
                Console.WriteLine("Herhangi bir oyuncu bulunamadı. Girilen takım adı sistemde mevcut olmayabilir veya girilen takımda oyuncu bulunmuyor olabilir. Lütfen tekrar kontrol ediniz.");
            }

            Console.Write("Devam etmek için ENTER tuşuna basınız ...");
            Console.ReadLine();
        }

        public static void DisplayPlayers(ProjectList<Player> PlayerList, string teamName) // Method that displays the names of players on the selected team
        {
            Console.Clear();
            int counter = 0;

            foreach (Player player in PlayerList.GetEnumerator()) // Create a player object named p and scroll through the list
            {
                if (Equals(player.Team.Name.ToUpper(), teamName.ToUpper())) // Printed players matching the entered team name
                {
                    counter++;
                    Console.WriteLine("{0}. {1} {2}", counter, player.name, player.surname);
                }
            }
            if (counter == 0) // If no player is found
            {
                Console.WriteLine("Herhangi bir oyuncu bulunamadı. Girilen takım adı sistemde mevcut olmayabilir veya girilen takımda oyuncu bulunmuyor olabilir. Lütfen tekrar kontrol ediniz.");
            }

            Console.Write("Devam etmek için ENTER tuşuna basınız ...");
            Console.ReadLine();
        }

        public static void DisplayAllPlayers(ProjectList<Player> playerList) // Method that prints the names of all players on the screen
        {
            Console.Clear();
            int counter = 0;

            foreach (Player p in playerList.GetEnumerator()) // Create a player object named p and browse the list. All players are printed.
            {
                counter++;
                Console.Write("{0}. Futbolcu -> ", counter);
                Console.Write(p.name + " ");
                Console.Write(p.surname);
                Console.WriteLine(" ");
            }
            Console.Write("Devam etmek için ENTER tuşuna basınız ...");
            Console.ReadLine();
        }

        public bool CheckPlayerToBeAdded(ProjectList<Player> Players, Player player) // Method to check which player to add
        {
            Console.Clear();
            bool check_player = false; // Create a bool variable called check_player and set it to false by default.
            check_player = CheckPlayerInList(Players, player, check_player);

            if (!check_player) // If the player does not exist in the list
            {
                int tempShirtNumber = player.ShirtNumber; // Create an int value named tempShirtNumber and assign the incoming player's shirt number to it
                player.ShirtNumber = CheckShirtNumberInTeam(tempShirtNumber, Players, player);
            }

            return check_player;
        }

        private bool CheckPlayerInList(ProjectList<Player> players, Player player, bool controlPlayer) // Method to check if the player you want to add is available in the list
        {
            Console.Clear();
            foreach (Player p in players.GetEnumerator()) // Create a player object named p and scroll through the list
            {
                if (Equals(p.Name.ToUpper(), player.Name.ToUpper()) && Equals(p.Surname.ToUpper(), player.Surname.ToUpper())) // If the incoming first and last name values match any player in the list
                {
                    controlPlayer = true; // Player exists in the list
                }
            }
            return controlPlayer;
        }

        public int CheckShirtNumberInTeam(int shirtNumber, ProjectList<Player> PlayerList, Player player) // Method to check if the incoming player's shirt number is available in the team
        {
            Console.Clear();
            bool checkInList = true;
            bool checkShirtNumberSize = true;

            do
            {
                Console.Clear();
                checkInList = true;
                checkShirtNumberSize = true;

                if (!(1 <= shirtNumber && shirtNumber <= 99)) // Condition block to check if the form number is between 1 and 99
                {
                    Console.WriteLine("Forma numarası 1 ile 99 aralığında olmak zorundadır. Lütfen yeni forma numarası giriniz : ");
                    shirtNumber = Convert.ToInt32(Console.ReadLine());
                    checkShirtNumberSize = false;
                }


                foreach (Player p in PlayerList.GetEnumerator()) 
                {
                    if (Equals(p.ShirtNumber, shirtNumber) && Equals(p.Team.Name.ToUpper(), player.Team.Name.ToUpper())) // If the shirt number of the players in the list matches the incoming shirt number and the team of the players in the list matches the incoming player's team
                    {
                        checkInList = false;
                        Console.WriteLine("Vermek istediğiniz forma numarası takımda mevcuttur.");
                        Console.Write("Yeni bir forma numarası giriniz : ");
                        shirtNumber = Convert.ToInt32(Console.ReadLine());
                    }
                }
            } while (!(checkInList && checkShirtNumberSize)); // Loop ends if the form number does not exist in the set and is within the enumeration size

            return shirtNumber;
        }

        public void RemovePlayerInList(ProjectList<Player> PlayerList, string PlayerName, string PlayerSurname) // Method to remove the selected player from the list
        {
            Console.Clear();
            bool removed = false;

            foreach (Player p in PlayerList.GetEnumerator())
            {
                if (Equals(p.Name.ToUpper(), PlayerName.ToUpper()) && Equals(p.Surname.ToUpper(), PlayerSurname.ToUpper())) // If the first and last name of the player in the list matches the first and last name of the incoming player
                {
                    PlayerList.Remove(p);
                    removed = true;
                }
            }

            if (removed)
            {
                Console.WriteLine("Futbolcu başarıyla silindi.");
            }
            else
                Console.WriteLine("Girilen futbolcu bulunamadı. Silme işlemi başarısızlıkla sonuçlandı.");

            Console.Write("Devam etmek için ENTER tuşuna basınız ...");
            Console.ReadLine();
        }

        public Player AddPlayerInfo() // Method to get the information if the user wants to add a player to the list
        {
            Console.Clear();

            Player player = new Player();

            Console.Write("Futbolcunun ismini giriniz : ");
            player.Name = Console.ReadLine();

            Console.Write("Futbolcunun soyismini giriniz : ");
            player.Surname = Console.ReadLine();

            Console.Write("Futbolcunun doğum yılını giriniz : ");
            player.BirthYear = Convert.ToInt32(Console.ReadLine());

            Console.Write("Futbolcunun piyasa değerini giriniz : ");
            player.MarketValue = Console.ReadLine();

            Console.Write("Futbolcunun mevkisini giriniz : ");
            player.Position = Console.ReadLine();

            Console.Write("Futbolcunun forma numarasını giriniz : ");
            player.ShirtNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Futbolcunun uyruğunu giriniz : ");
            player.Nationality = Console.ReadLine();

            Console.Write("Futbolcunun boyunu giriniz : ");
            player.Height = Convert.ToInt32(Console.ReadLine());

            return player;
        }
    }
}
