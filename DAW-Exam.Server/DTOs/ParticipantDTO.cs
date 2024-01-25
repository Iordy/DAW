using System;
using System.Collections.Generic;

using DAW_Exam.Server.Entities;

namespace DAW_Exam.Server.DTOs
{
    public class ParticipantDTO
    {

        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Age { get; set; }

        public bool IsOrganizer { get; set; }

    }

}