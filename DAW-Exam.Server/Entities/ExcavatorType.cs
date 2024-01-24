using System;
using System.Collections.Generic;

namespace DAW_Exam.Server.Entities
{
    public class ExcavatorType
    {
        public int Id { get; set; }

        public string? Type { get; set; }

        public List<Excavator>? Excavators { get; set; }

    }

}