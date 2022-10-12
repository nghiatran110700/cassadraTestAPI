namespace cassadraTestAPI.Model
{
    public class Post
    {
        public Guid post_id { get; set; }
        public string title { get; set; }
        public DateTime lastupdated { get; set; }
        public string body { get; set; }
    }
}
