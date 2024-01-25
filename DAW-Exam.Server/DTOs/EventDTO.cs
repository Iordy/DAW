using System;
using System.Collections.Generic;

using DAW_Exam.Server.Entities;

namespace DAW_Exam.Server.DTOs
{
    public class EventDTO
    {
            
            public int Id { get; set; }
    
            public string? Name { get; set; }
    
            public string? Location { get; set; }

            public List <ParticipantDTO>? Participants { get; set; }
    }

}