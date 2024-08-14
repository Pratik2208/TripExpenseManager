using Newtonsoft.Json;

namespace TripExpenseManager.Data.Data.Models
{
    public abstract class Document
    {
        [JsonIgnore]
        public string Id { get; set; }
        protected Document()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
