namespace Hotel.Models
{
    public class Database
    {

       
        public string Name { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Popularity { get; set; }
        
        public bool IsPopular { get; set; }



        public Database(string name, string city, string location, string price, string description, string type, string popularity, bool isPopular)
        {
            Name = name;
            City = city;
            Location = location;
            Price = price;
            Description = description;
            Type = type;
            Popularity = popularity;
            IsPopular = isPopular;
        }
    }

}
