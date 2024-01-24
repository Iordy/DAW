using System;
using System.Collections.Generic;

using DAW_Exam.Server.Entities;

namespace DAW_Exam.Server.DTOs
{
    public class ExcavatorDTO
    {

        public int Id { get; set; }

        public string? Model { get; set; }

        public string? Manufacturer { get; set; }

        public int? YearOfFabrication { get; set; }

        public int? Weight { get; set; }

        public ExcavatorTypeDTO? ExcavatorType { get; set; }
        
    }

}