namespace APIshka.Entities
{
    public class New
    {

        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImagesName { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }

        public New()
        {
            
        }

        public New(
            string title,
            string description,
            string? imagesName,
            int userId
            )
        {
            Title = title;
            Description = description;
            ImagesName = imagesName;
            UserId = userId;
        }

    }
}
