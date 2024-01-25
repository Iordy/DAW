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

public class EventatendeeController : ControllerBase
{
    public EventatendeeController(DawContext context)
    {
        Context = context;
    }

    public DawContext Context { get; }


[HttpPost]
public async Task <ActionResult<EventAtendeeDTO>> Post([FromBody]EventAtendeeDTO value)
{
    if (value == null)
    {
        return BadRequest("The request body cannot be empty.");
    }


    var entity = DTOToEventAtendee(value);

    if (entity == null)
    {
        return BadRequest("The conversion from DTO to EventAtendee failed.");
    }

    Context.EventAtendees.Add(entity);
    Context.SaveChanges();

   
    var newEntity = Context.EventAtendees
        .Include(ea => ea.Event) 
        .Include(ea => ea.Participant)
        .FirstOrDefault(ea => ea.Id == entity.Id);

    if (newEntity == null)
    {
        return NotFound("The EventAtendee was not found after saving.");
    }


    return EventAtendeeToDTO(newEntity);
}

   
    private EventAtendee DTOToEventAtendee(EventAtendeeDTO eventAtendeeDTO)
    {
        return new EventAtendee
        {
            Id = eventAtendeeDTO.Id,
            ParticipantId = eventAtendeeDTO.Participant.Id,
            EventId = eventAtendeeDTO.Event.Id
        };
    }

    private EventAtendeeDTO EventAtendeeToDTO(EventAtendee eventAtendee)
    {
        return new EventAtendeeDTO
        {
            Id = eventAtendee.Id,
            Participant = new ParticipantDTO
            {
                Id = eventAtendee.Participant.Id,
                Name = eventAtendee.Participant.Name,
                Email = eventAtendee.Participant.Email,
                Age = eventAtendee.Participant.Age,
                IsOrganizer = eventAtendee.Participant.IsOrganizer
            },
            Event = new EventDTO
            {
                Id = eventAtendee.Event.Id,
                Name = eventAtendee.Event.Name,
                Location = eventAtendee.Event.Location
            }
        };
    }



}