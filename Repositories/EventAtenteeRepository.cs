using Microsoft.EntityFrameworkCore;
using Daw_Exam.Server.Contexts;
using Daw_Exam.Server.Entities;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Daw_Exam.Server.Repositories
{


    public interface IEventAtendeeRepository
    {
        IQueryable<EventAtendee> GetAll();
        EventAtendee GetById(int id);
        void Create(EventAtendee eventAtendeeToAdd);
        void Update(EventAtendee eventAtendeeToUpdate);
        void Delete(EventAtendee eventAtendeeToDelete);
        void SaveChanges();
    }


    public class EventAtendeeRepository : IEventAtendeeRepository
    {
        private readonly DawContext _context;

        public EventAtendeeRepository(DawContext context)
        {
            _context = context;
        }

        public async  <IQueryable<EventAtendee>> GetAll()
        {
           await return _context.EventAtendees;
        }

        public async  <EventAtendee> GetById(int id)
        {
           await return _context.EventAtendees.FirstOrDefault(e => e.Id == id);
        }

        public async void Create(EventAtendee eventAtendeeToAdd)
        {
            await _context.EventAtendees.Add(eventAtendeeToAdd);
        }

        public async void Update(EventAtendee eventAtendeeToUpdate)
        {
            await _context.EventAtendees.Update(eventAtendeeToUpdate);
        }

        public async void Delete(EventAtendee eventAtendeeToDelete)
        {
            var eventAtendeeToDelete = _context.EventAtendees.FirstOrDefault(e => e.Id == id);
            if(eventAtendeeToDelete != null)
                await _context.EventAtendees.Remove(eventAtendeeToDelete);
        }

        public async void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}