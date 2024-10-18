namespace kirill_gubaydulin_kt_31_21.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime FoundingTime { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Department() { }
    }
}