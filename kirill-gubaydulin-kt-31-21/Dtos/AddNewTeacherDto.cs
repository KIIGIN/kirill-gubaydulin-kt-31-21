namespace kirill_gubaydulin_kt_31_21.Dtos
{
    public class AddNewTeacherDto
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public int DegreeId { get; set; }
        public int DisciplineId { get; set; }
        public int LoadId { get; set; }
        public AddNewTeacherDto() { }
    }
}
