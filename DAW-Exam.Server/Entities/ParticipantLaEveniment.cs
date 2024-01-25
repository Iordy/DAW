using System;
using System.Collections.Generic;

namespace DAW_Exam.Server.Entities
{
   public class EventAtendee
   {

    public int Id { get; set; }
    public Participant Participant { get; set; }

    public int ParticipantId { get; set;}

    public Event Event { get; set; }

    public int EventId { get; set;}

   }
}