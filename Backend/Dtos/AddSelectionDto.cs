﻿using Backend.Models;

namespace Backend.Dtos
{
    public class AddSelectionDto
    {

        public string Name { get; set; }=String.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }=String.Empty;

    }
}
