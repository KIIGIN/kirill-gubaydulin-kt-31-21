namespace kirill_gubaydulin_kt_31_21.Filters.DepartmentFilters
{
    public class DepartmentFoundingFilter
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }

    public class DepartmentTeachersCountFilter
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
