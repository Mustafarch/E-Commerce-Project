namespace WebTicket.Entities
{
    public class Blog
    {
        public int ID { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Contents { get; set; }

        public string Picture { get; set; }

        public int ReadNumber { get; set; }

        public DateTime History { get; set; }
    }
}
