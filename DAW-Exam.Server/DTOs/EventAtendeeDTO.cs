using System;
using System.Collections.Generic;

using DAW_Exam.Server.Entities;

namespace DAW_Exam.Server.DTOs
{
    public class EventAtendeeDTO
    {
            
            public int Id { get; set; }
    
            public ParticipantDTO? Participant { get; set; }

            public EventDTO? Event { get; set; }
    }
}