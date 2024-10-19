namespace kirill_gubaydulin_kt_31_21.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime FoundingTime { get; set; }
        public int? LeadId { get; set; }
        public Teacher Leader { get; set; }
        public Department() { }
    }
}