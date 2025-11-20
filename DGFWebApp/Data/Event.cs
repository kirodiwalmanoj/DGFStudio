namespace DGFWebApp.Data
{
    public class Event
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime EventDate { get; set; }

        public string EventType { get; set; }
    }
}
