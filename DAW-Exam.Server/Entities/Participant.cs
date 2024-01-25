using System;
using System.Collections.Generic;


namespace DAW_Exam.Server.Entities
{
   public class Participant
   {

    public int Id { get; set; }
    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Age { get; set; }

    public bool IsOrganizer { get; set; }

    public List <EventAtendee>? EventAtendees { get; set; }

   }
}