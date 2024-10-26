using kirill_gubaydulin_kt_31_21.Interfaces.DepartmentsInterfaces;
using kirill_gubaydulin_kt_31_21.Interfaces.TeacherInterfaces;

namespace kirill_gubaydulin_kt_31_21.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ITeacherService, TeacherService>();

            return services;
        }
    }
}
