namespace FootballBaseDB.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Citizenship { get; set; }

        public int? TeamID { get; set; }
        public Team Team { get; set; }
    }
}