namespace App.Models
{
    public class Company : App.Models.ICompany
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Classification Classification { get; set; }
    }
}