using System;
using System.Collections.Generic;
using DAW_Exam.Server.Entities;
using DAW_Exam.Server.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAW_Exam.Server.Contexts;
using System.Linq;


[ApiController]

[Route("api/[controller]")]

public class EventController : ControllerBase
{
    public EventController(DawContext context)
    {
        Context = context;
    }

    public DawContext Context { get; }

    [HttpGet]
    public async Task<IEnumerable<EventDTO>> Get()
    {
       
        var ret = await Context.Events.Include(x => x.EventAtendees).Select(x => new EventDTO
        {
            Id = x.Id,
            Name = x.Name,
            Location = x.Location,
            Participants = x.EventAtendees.Select(x => new ParticipantDTO
            {
                Id = x.Participant.Id,
                Name = x.Participant.Name,
                Email = x.Participant.Email,
                Age = x.Participant.Age,
                IsOrganizer = x.Participant.IsOrganizer
            }).ToList()
        }).ToListAsync();

        return ret;
    }

 [HttpGet("{id}")]
public ActionResult<IEnumerable<ParticipantDTO>> GetParticipants(int id)
{
    
    var participants = Context.EventAtendees.Join(Context.Participants, ea => ea.ParticipantId, p => p.Id, (ea, p) => new ParticipantDTO
    {
        Id = p.Id,
        Name = p.Name,
        Email = p.Email,
        Age = p.Age,
        IsOrganizer = p.IsOrganizer
    }).Where(x => x.Id == id).ToList();

    return participants; 
}



    [HttpPost]
    public EventDTO Post([FromBody]EventDTO value)
    {
        var entity = DTOToEvent(value);
        Context.Events.Add(entity);
        Context.SaveChanges();
        return EventToDTO(entity);
    }

    [HttpPut("{id}")]
    public EventDTO Put(int id, EventDTO value)
    {
        var entity = DTOToEvent(value);
        entity.Id = id;
        Context.Events.Update(entity);
        Context.SaveChanges();
        return EventToDTO(entity);
    }

    [HttpDelete("{id}")]
    public async Task <EventDTO> Delete(int id)
    {
        var entity = Context.Events.FirstOrDefault(x => x.Id == id);
        Context.Events.Remove(entity);
        Context.SaveChanges();
        return EventToDTO(entity);
    }

    private EventDTO EventToDTO(Event entity)
    {
        return new EventDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            Location = entity.Location,
            Participants = entity.EventAtendees.Select(x => new ParticipantDTO
            {
                Id = x.Participant.Id,
                Name = x.Participant.Name,
                Email = x.Participant.Email,
                Age = x.Participant.Age,
                IsOrganizer = x.Participant.IsOrganizer
            }).ToList()
        };
    }

    private Event DTOToEvent(EventDTO dto)
    {
        return new Event
        {
            Id = dto.Id,
            Name = dto.Name,
            Location = dto.Location,
            EventAtendees = dto.Participants.Select(x => new EventAtendee
            {
                ParticipantId = x.Id,
                EventId = dto.Id
            }).ToList()
        };
    }
}