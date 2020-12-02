namespace myfirstmvc.Models
{
    public class Posts
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}