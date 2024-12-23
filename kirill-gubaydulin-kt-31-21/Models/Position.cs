﻿namespace kirill_gubaydulin_kt_31_21.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public bool IsValidPositionName()
        {
            List<String> positions = new List<string> { "преподаватель", "старший преподаватель", "доцент", "профессор" };

            return positions.Contains(PositionName.ToLower());
        }
        public Position() { }
    }
}