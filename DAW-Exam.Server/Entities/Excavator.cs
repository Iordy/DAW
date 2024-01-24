using System;
using System.Collections.Generic;
using DAW_Exam.Server.Entities;

namespace DAW_Exam.Server.Entities
{
    public class Excavator
    {

        public int Id { get; set; }

        public string? Model { get; set; }

        public string? Manufacturer { get; set; }

        public int? YearOfFabrication { get; set; }

        public int? Weight { get; set; }

        public ExcavatorType? ExcavatorType { get; set; }

        public int? ExcavatorTypeId { get; set;} 

        
    }

}