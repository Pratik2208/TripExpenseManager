namespace TripExpenseManager.Data.Data.Models
{
    public class LocationCategory : Document
    {
        public LocationCategory()
        {

        }
        public LocationCategory(string name, string image)
        {
            Name = name;
            Image = image;
        }

        public string Name { get; set; }
        public string Image { get; set; }
    }
}
