using Microsoft.EntityFrameworkCore;
using Daw_Exam.Server.Contexts;
using Daw_Exam.Server.Entities;
using System.Linq;
using System;
using System.Collections.Generic;


namespace Daw_Exam.Server.Repositories
{

    public interface IParticipantRepository
    {
        IQueryable<Participant> GetAll();
        Participant GetById(int id);
        void Create(Participant participantToAdd);
        void Update(Participant participantToUpdate);
        void Delete(Participant participantToDelete);
        void SaveChanges();
    }


    public class ParticipantRepository : IParticipantRepository
    {
        private readonly DawContext _context;

        public ParticipantRepository(DawContext context)
        {
            _context = context;
        }

        public IQueryable<Participant> GetAll()
        {
            return _context.Participants;
        }

        public Participant GetById(int id)
        {
            return _context.Participants.FirstOrDefault(e => e.Id == id);
        }

        public void Create(Participant participantToAdd)
        {
            _context.Participants.Add(participantToAdd);
        }

        public void Update(Participant participantToUpdate)
        {
            _context.Participants.Update(participantToUpdate);
        }

        public void Delete(Participant participantToDelete)
        {
            var participantToDelete = _context.Participants.FirstOrDefault(e => e.Id == id);
            if(participantToDelete != null)
                _context.Participants.Remove(participantToDelete);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}