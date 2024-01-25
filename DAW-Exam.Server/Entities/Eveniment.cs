using System;
using System.Collections.Generic;


namespace DAW_Exam.Server.Entities
{
   public class Event
   {

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Location { get; set; }

    public List <EventAtendee>? EventAtendees { get; set; }

   }
}