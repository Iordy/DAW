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

public class ParticipantController: ControllerBase
{
    public ParticipantController(DawContext context)
    {
        Context = context;
    }

    public DawContext Context { get; }

    [HttpGet]
    public IEnumerable<ParticipantDTO> Get()
    {
       
        var ret =  Context.Participants.Include(x => x.EventAtendees).Select(x => new ParticipantDTO
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email,
            Age = x.Age,
            IsOrganizer = x.IsOrganizer
        }).ToList();

        return ret;
    }

    [HttpGet("{id}")]
    public ParticipantDTO Get(int id)
    {
        var entity = Context.Participants.Include(x => x.EventAtendees).FirstOrDefault(x => x.Id == id);
        return ParticipantToDTO(entity);
    }

 [HttpPost]
public ActionResult<ParticipantDTO> Post([FromBody]ParticipantDTO value)
{
    var entity = DTOToParticipant(value);
    Context.Participants.Add(entity);
    Context.SaveChanges();
    return ParticipantToDTO(entity);
}

    [HttpPut("{id}")]
    public ParticipantDTO Put(int id, [FromBody]ParticipantDTO value)
    {
        var entity = DTOToParticipant(value);
        entity.Id = id;
        Context.Participants.Update(entity);
        Context.SaveChanges();
        return ParticipantToDTO(entity);
    }

    [HttpDelete("{id}")]
    public ParticipantDTO Delete(int id)
    {
        var entity = Context.Participants.FirstOrDefault(x => x.Id == id);
        Context.Participants.Remove(entity);
        Context.SaveChanges();
        return ParticipantToDTO(entity);
    }

    private ParticipantDTO ParticipantToDTO(Participant participant)
    {
        return new ParticipantDTO
        {
            Id = participant.Id,
            Name = participant.Name,
            Email = participant.Email,
            Age = participant.Age,
            IsOrganizer = participant.IsOrganizer
        };
    }

    private Participant DTOToParticipant(ParticipantDTO participant)
    {
        return new Participant
        {
            Id = participant.Id,
            Name = participant.Name,
            Email = participant.Email,
            Age = participant.Age,
            IsOrganizer = participant.IsOrganizer
        };
    }
}