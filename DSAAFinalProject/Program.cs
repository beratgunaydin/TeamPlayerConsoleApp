using System;
using System.Collections;
using System.IO;

namespace DSAAFinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ProjectList<Team> Teams = new ProjectList<Team>(); // List to store teams
            ProjectList<Player> Players = new ProjectList<Player>(); // List of footballers to hide

            Team t = new Team();
            Player p = new Player();

            var linesTeam = File.ReadAllLines("TeamList.txt"); // Codes for reading data from txt
            for (int i = 0; i < linesTeam.Length; i++)
            {
                var fields = linesTeam[i].Split('-');

                Team team = new Team();
                team.Name = fields[0];
                team.Coach = fields[1];
                team.Chairman = fields[2];
                team.YearIsThatFounded = Int32.Parse(fields[3]);
                team.Stadium = fields[4];

                Teams.Add(team);
            }

            var linesPlayer = File.ReadAllLines("PlayerList.Txt");

            for (int i = 0; i < linesPlayer.Length; i++)
            {
                var fields = linesPlayer[i].Split("-");

                Player player = new Player();
                player.Name = fields[0];
                player.Surname = fields[1];
                player.BirthYear = Int32.Parse(fields[2]);
                player.MarketValue = fields[3];
                player.Position = fields[4];
                player.ShirtNumber = Int32.Parse(fields[5]);
                player.Nationality = fields[6];
                player.Height = Int32.Parse(fields[7]);
                string teamName = fields[8];
                Team team = Team.GetTeam(Teams, teamName);
                if (team != null)
                {
                    player.Team = team;
                    Players.Add(player);
                }
                else
                    Console.WriteLine("Futbolcu eklemek istediğiniz takım veri tabanında bulunamadı. ");
            }

            string choice;

            do // Operations that the user can perform according to their choices
            {
                Console.Clear();
                Console.WriteLine("*****MENÜ*****");
                Console.WriteLine("1- Mevcut Takımları Listele");
                Console.WriteLine("2- Mevcut Takımların Bilgilerini Listele");
                Console.WriteLine("3- Tüm Futbolcuları Listele");
                Console.WriteLine("4- Seçili Takımdaki Futbolcuların İsimlerini Listele");
                Console.WriteLine("5- Seçili Takımdaki Futbolcuların Bilgilerini Listele");
                Console.WriteLine("6- Takım Ekle");
                Console.WriteLine("7- Seçili Takıma Futbolcu Ekle");
                Console.WriteLine("8- Futbolcu Sil");
                Console.WriteLine("9- Çıkış");
                Console.WriteLine(" ");
                Console.Write("Yapmak istediğiniz işlemi seçiniz : ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Team.DisplayTeams(Teams);
                        break;

                    case "2":
                        Team.DisplayTeamsDetailed(Teams);
                        break;

                    case "3":
                        Player.DisplayAllPlayers(Players);
                        break;

                    case "4":
                        Console.Write("Futbolcu isimlerini listelemek istediğiniz takımın ismini giriniz : ");
                        string teamName = Console.ReadLine();
                        Player.DisplayPlayers(Players, teamName);
                        break;

                    case "5":
                        Console.Write("Futbolcu bilgilerini listelemek istediğiniz takımın ismini giriniz : ");
                        teamName = Console.ReadLine();
                        Player.DisplayPlayersDetailed(Players, teamName);
                        break;

                    case "6":
                        t.AddTeamInfo(t);

                        if (t.CheckTeamToBeAdded(Teams, t))
                        {
                            Console.WriteLine("Eklemek istediğiniz takım sistemde mevcuttur. Ekleme işlemi başarısızlıkla sonuçlandı. ");
                        }
                        else
                        {
                            Teams.Add(t);
                            Console.WriteLine("Takım başarıyla eklendi. ");
                        }
                        Console.Write("Devam etmek için ENTER tuşuna basınız ...");
                        Console.ReadLine();
                        break;

                    case "7":
                        Console.Write("Futbolcu eklemek istediğiniz takımın ismini giriniz : ");
                        teamName = Console.ReadLine();

                        t = Team.GetTeam(Teams, teamName);

                        if (t != null)
                        {
                            p = p.AddPlayerInfo();
                            p.Team = t;

                            if (!(p.CheckPlayerToBeAdded(Players, p)))
                            {
                                Players.Add(p);
                                Console.WriteLine("Futbolcu seçilen takıma başarıyla eklendi. ");
                            }
                            else
                            {
                                Console.WriteLine("Eklemek istediğiniz futbolcu sistemde mevcuttur. İşlem başarısızlıkla sonuçlandı.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Futbolcu eklemek istediğiniz takım sistemde mevcut değildir. İşlem başarısızlıkla sonuçlandı.");
                        }
                        Console.Write("Devam etmek için ENTER tuşuna basınız ...");
                        Console.ReadLine();
                        break;

                    case "8":
                        Console.Write("Silmek istediğiniz futbolcunun ismini giriniz : ");
                        string playerName = Console.ReadLine();

                        Console.Write("Silmek istediğiniz futbolcunun soyismini giriniz : ");
                        string playerSurname = Console.ReadLine();

                        p.RemovePlayerInList(Players, playerName, playerSurname);
                        break;

                    case "9":
                        Console.Clear();
                        Console.WriteLine("Çıkış yapılıyor. Lütfen bekleyiniz. ");
                        System.Threading.Thread.Sleep(2000);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Hatalı işlem girişi. Lütfen tekrar deneyiniz.");
                        System.Threading.Thread.Sleep(2000);
                        break;
                }
            } while (choice != "9");

        }
    }
}
