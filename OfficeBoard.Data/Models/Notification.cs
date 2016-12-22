namespace OfficeBoard.Data.Models
{
    using System;

    public class Notification
    {
        public int Id { get; set; }

        public DateTime DateSent { get; set; }

        public int NoteId { get; set; }

        public virtual Note Note { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
