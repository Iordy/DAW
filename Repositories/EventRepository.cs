using Microsoft.EntityFrameworkCore;
using Daw_Exam.Server.Contexts;
using Daw_Exam.Server.Entities;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Daw_Exam.Server.Repositories

{
    public interface IEventRepository
    {
        IQueryable<Event> GetAll();
        Event GetById(int id);
        void Create(Event eventToAdd);
        void Update(Event eventToUpdate);
        void Delete(Event eventToDelete);
        void SaveChanges();
    }

    public class EventRepository : IEventRepository
    {
        private readonly DawContext _context;

        public EventRepository(DawContext context)
        {
            _context = context;
        }

        public Event GetAll()
        {
            return _context.Events;
        }

        public Event GetById(int id)
        {
            return _context.Events.FirstOrDefault(e => e.Id == id);
        }

        public void Create(Event eventToAdd)
        {
            _context.Events.Add(eventToAdd);
        }

        public void Update(Event eventToUpdate)
        {
            _context.Events.Update(eventToUpdate);
        }

        public void Delete(Event eventToDelete)
        {
            var eventToDelete = _context.Events.FirstOrDefault(e => e.Id == id);
            if(eventToDelete != null)
                _context.Events.Remove(eventToDelete);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}