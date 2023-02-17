using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAAFinalProject
{
    public class Team
    {
        // These private fields represent the attributes of a team and are not accessible outside of this class.
        private string name;
        private string coach;
        private string chairman;
        private int year_is_that_founded;
        private string stadium;

        // These public properties allow access to the private fields of the class and can be read and modified by external code.
        public string Name { get { return this.name; } set { this.name = value; } }
        public string Coach { get { return this.coach; } set { this.coach = value; } }
        public string Chairman { get { return this.chairman; } set { this.chairman = value; } }
        public int YearIsThatFounded { get { return this.year_is_that_founded; } set { this.year_is_that_founded = value; } }
        public string Stadium { get { return this.stadium; } set { this.stadium = value; } }

        public static void DisplayTeams(ProjectList<Team> TeamList) // This static method is used to display the names of all the teams in a list.
        {
            Console.Clear();
            int counter = 0;

            foreach (Team t in TeamList.GetEnumerator())
            {
                counter++;
                Console.WriteLine(counter + ". " + t.name);
            }
            Console.Write("Devam etmek için ENTER tuşuna basınız ...");
            Console.ReadLine();
        }

        public static void DisplayTeamsDetailed(ProjectList<Team> TeamList) // This static method is used to display the details of all the teams in a list.
        {
            Console.Clear();
            int counter = 0;

            foreach (Team t in TeamList.GetEnumerator())
            {
                counter++;
                Console.WriteLine("{0}. Takım ", counter);
                Console.WriteLine("Takım Adı : {0} ", t.Name);
                Console.WriteLine("Teknik Direktör : {0} ", t.Coach);
                Console.WriteLine("Başkan : {0} ", t.Chairman);
                Console.WriteLine("Kurulduğu Yıl : {0}", t.YearIsThatFounded);
                Console.WriteLine("Stadyum : {0} ", t.Stadium);
                Console.WriteLine(" ");
                Console.WriteLine(" ");
            }
            Console.Write("Devam etmek için ENTER tuşuna basınız ...");
            Console.ReadLine();
        }

        public static Team GetTeam(ProjectList<Team> TeamList, string name) // This static method is used to find and return a team from a list by name.
        {
            bool IsTeamAvailableInList = false;
            Team team = new Team();

            foreach (Team t in TeamList.GetEnumerator())
            {
                if (t.Name.ToUpper() == name.ToUpper())
                {
                    team = t;
                    IsTeamAvailableInList = true;
                }
            }
            if (IsTeamAvailableInList)
            {
                return team;
            }

            else
            {
                return null;
            }
        }

        public bool CheckTeamToBeAdded(ProjectList<Team> TeamList, Team team) // This method is used to check whether a team already exists in a list.
        {
            bool check_team = false;

            foreach (Team t in TeamList.GetEnumerator())
            {
                if (Equals(t.Name.ToUpper(), team.Name.ToUpper()))
                {
                    check_team = true;
                }
            }

            return check_team;
        }

        public void AddTeamInfo(Team team) // This method is used to get user input for adding a new team to a list.
        {
            Console.Clear();

            Console.Write("Eklemek istediğiniz takımın adını giriniz : ");
            team.Name = Console.ReadLine();
            Console.Write("Takımın teknik direktörünün ismini giriniz : ");
            team.Coach = Console.ReadLine();
            Console.Write("Takımın başkanının ismini giriniz : ");
            team.Chairman = Console.ReadLine();
            Console.Write("Takımın kuruluş yılını giriniz : ");
            team.YearIsThatFounded = Convert.ToInt32(Console.ReadLine());
            Console.Write("Takımın stadyum adını giriniz : ");
            team.Stadium = Console.ReadLine();
        }
    }
}
