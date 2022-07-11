
namespace DataAccess
{
    public class Journey
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public List<Flight> flights { get; set; }
    }
}