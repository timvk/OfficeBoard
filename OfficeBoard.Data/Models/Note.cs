namespace OfficeBoard.Data.Models
{
    using System;

    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateAdded { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
        
    }
}
