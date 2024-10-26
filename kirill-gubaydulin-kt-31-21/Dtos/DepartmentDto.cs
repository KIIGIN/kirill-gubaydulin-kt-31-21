namespace kirill_gubaydulin_kt_31_21.Dtos
{
    public class DepartmentDto
    {
        public string DepartmentName { get; set; }
        public DateTime FoundingTime { get; set; }
        public LeaderDto Leader { get; set; }
        public DepartmentDto() { }
    }

    public class LeaderDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PositionName { get; set; }
        public string DegreeName { get; set; }
        public LeaderDto() { }
    }

}
