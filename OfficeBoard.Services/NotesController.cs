namespace OfficeBoard.Services
{
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models;
    using System;
    using System.Linq;
    using System.Web.Http;

    public class NotesController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult GetTodaysNotes()
        {
            var notes = this.OfficeBoardContext.Notes
                    .Where(n => n.DateAdded.Day == DateTime.Now.Day)
                    .Select(n => new
                    {
                        Id = n.Id,
                        Title = n.Title,
                        Content = n.Content,
                        Author = n.Author.UserName,
                        DateAdded = n.DateAdded
                    });

            return this.Ok(notes);
        }

        [HttpGet]
        public IHttpActionResult GetOld()
        {
            var notes = this.OfficeBoardContext.Notes
                    .Where(n => n.DateAdded.Day < DateTime.Now.Day)
                    .Select(n => new
                    {
                        Id = n.Id,
                        Title = n.Title,
                        Content = n.Content,
                        Author = n.Author.UserName,
                        DateAdded = n.DateAdded
                    });

            return this.Ok(notes);
        }

        [HttpPost]
        public IHttpActionResult AddNote(NotesBindingModel model)
        {
            if(model == null)
            {

            }

            var newNote = new Note()
            {
                Title = model.Title,
                Content = model.Content,
                DateAdded = DateTime.Now,
                AuthorId = User.Identity.GetUserId()
            };

            this.OfficeBoardContext.Notes.Add(newNote);
            this.OfficeBoardContext.SaveChanges();

            return this.Ok(newNote);
        }

        public IHttpActionResult GetOwnNotes()
        {
            var loggedUserId = User.Identity.GetUserId();

            var notes = this.OfficeBoardContext.Notes
                    .Where(n => n.AuthorId == loggedUserId)
                    .Select(n => new
                    {
                        Id = n.Id,
                        Title = n.Title,
                        Content = n.Content,
                        Author = n.Author.UserName,
                        DateAdded = n.DateAdded
                    });

            return this.Ok(notes);
        }
    }
}