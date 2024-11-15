using kirill_gubaydulin_kt_31_21.Database;
using kirill_gubaydulin_kt_31_21.Interfaces.DepartmentsInterfaces;
using kirill_gubaydulin_kt_31_21.Interfaces.TeacherInterfaces;
using kirill_gubaydulin_kt_31_21.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;


namespace kirill_gubaydulin_kt_31_21.Tests
{
    public class DepartmentIntegrationTests
    {
        public readonly DbContextOptions<DepartmentDbContext> _dbContextOptions;

        public DepartmentIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<DepartmentDbContext>()
                .UseInMemoryDatabase(databaseName: "dept_db")
                .Options;
        }

        [Fact]
        public async Task GetByFoundingTimeAsync_TwoDates_OneObject()
        {
            // Arrange
            var ctx = new DepartmentDbContext(_dbContextOptions);
            var departmentService = new DepartmentService(ctx);
            var departments = new List<Department>
            {
                new Department
                {
                    DepartmentName = "First Department",
                    FoundingTime = DateTime.Parse("2020-01-10"),
                    LeadId = null
                },
                new Department
                {
                    DepartmentName = "Second Department",
                    FoundingTime = DateTime.Parse("2022-02-20"),
                    LeadId = null
                },
                new Department
                {
                    DepartmentName = "Third Department",
                    FoundingTime = DateTime.Parse("2024-03-30"),
                    LeadId = null
                }
            };
            await ctx.Set<Department>().AddRangeAsync(departments);
            await ctx.SaveChangesAsync();

            // Act
            var filter = new Filters.DepartmentFilters.DepartmentFoundingFilter
            {
                DateFrom = DateTime.Parse("2023-01-01"),
                DateTo = DateTime.Parse("2025-01-01")
            };
            var departmentsResult = await departmentService.GetByFoundingTimeAsync(filter, CancellationToken.None);
            
            // Assert
            Assert.Single(departmentsResult);
        }
    }
}
