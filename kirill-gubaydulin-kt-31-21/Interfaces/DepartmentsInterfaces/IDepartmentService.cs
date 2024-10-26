using kirill_gubaydulin_kt_31_21.Database;
using kirill_gubaydulin_kt_31_21.Models;
using kirill_gubaydulin_kt_31_21.Dtos;
using kirill_gubaydulin_kt_31_21.Filters.DepartmentFilters;

using Microsoft.EntityFrameworkCore;


namespace kirill_gubaydulin_kt_31_21.Interfaces.DepartmentsInterfaces
{
    public interface IDepartmentService
    {
        public Task<IEnumerable<DepartmentDto>> GetByFoundingTimeAsync(DepartmentFoundingFilter filter, CancellationToken cancellationToken);
        public Task<IEnumerable<DepartmentDto>> GetByTeachersCountAsync(DepartmentTeachersCountFilter filter, CancellationToken cancellationToken);
    }

    public class DepartmentService : IDepartmentService
    {
        private readonly DepartmentDbContext _dbContext;
        public DepartmentService(DepartmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DepartmentDto>> GetByFoundingTimeAsync(DepartmentFoundingFilter filter, CancellationToken cancellationToken = default)
        {
            var departmentFoundingTime = await _dbContext.Set<Department>()
                .Where(w => w.FoundingTime >= filter.DateFrom && w.FoundingTime <= filter.DateTo)
                .Select(d => new DepartmentDto
                {
                    DepartmentName = d.DepartmentName,
                    FoundingTime = d.FoundingTime,
                    Leader = new LeaderDto
                    {
                        FirstName = d.Leader.FirstName,
                        LastName = d.Leader.LastName,
                        MiddleName = d.Leader.MiddleName,
                        PositionName = d.Leader.Position.PositionName,
                        DegreeName = d.Leader.Degree.DegreeName
                    }
                })
                .ToListAsync(cancellationToken);

            return departmentFoundingTime;
        }

        public async Task<IEnumerable<DepartmentDto>> GetByTeachersCountAsync(DepartmentTeachersCountFilter filter, CancellationToken cancellationToken = default)
        {
            var departmentsTeachersCount = await _dbContext.Set<Department>()
                .Where(
                    d => _dbContext.Set<Teacher>().Count(t => t.DepartmentId == d.DepartmentId) >= filter.Min
                    && _dbContext.Set<Teacher>().Count(t => t.DepartmentId == d.DepartmentId) <= filter.Max
                )
                .Select(d => new DepartmentDto
                {
                    DepartmentName = d.DepartmentName,
                    FoundingTime = d.FoundingTime,
                    Leader = new LeaderDto
                    {
                        FirstName = d.Leader.FirstName,
                        LastName = d.Leader.LastName,
                        MiddleName = d.Leader.MiddleName,
                        PositionName = d.Leader.Position.PositionName,
                        DegreeName = d.Leader.Degree.DegreeName
                    }
                })
                .ToListAsync(cancellationToken);

            return departmentsTeachersCount;
        }
    }
}
