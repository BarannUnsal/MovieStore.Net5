using System;
using AutoMapper;
using MovieStore.WebApi.DbOperations.Abstract;

namespace MovieStore.WebApi.Application.ActorOperations.Commands.Update
{
    public class UpdateActorCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int ActorId { get; set; }
        public UpdateActorViewModel Model { get; set; }
        public UpdateActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var actor = _context.Actors.Find(ActorId);
            if (actor == null)
            {
                throw new InvalidOperationException("Güncellenecek Aktör Bulunamadı!");
            }
            actor.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? actor.Name : Model.Name;
            actor.Surname = string.IsNullOrEmpty(Model.Surname.Trim()) ? actor.Surname : Model.Surname;
            actor.isActive = Model.isActive != default ? Model.isActive : actor.isActive;

            _context.SaveChanges();
        }
    }
    public class UpdateActorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool isActive { get; set; }
    }
}