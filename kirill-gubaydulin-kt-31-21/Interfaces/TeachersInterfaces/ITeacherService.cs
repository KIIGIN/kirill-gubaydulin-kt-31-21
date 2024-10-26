using kirill_gubaydulin_kt_31_21.Database;
using kirill_gubaydulin_kt_31_21.Dtos;
using kirill_gubaydulin_kt_31_21.Filters.TeacherFilter;
using kirill_gubaydulin_kt_31_21.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;


namespace kirill_gubaydulin_kt_31_21.Interfaces.TeacherInterfaces
{
    public interface ITeacherService
    {
        public Task<IEnumerable<TeacherDto>> GetAllAsync(CancellationToken cancellationToken);
        public Task<IEnumerable<TeacherDto>> GetByIdAsync(int id, CancellationToken cancellationToken);
        public Task AddNewTeacherAsync(AddNewTeacherDto addNewTeacherDto, CancellationToken cancellationToken);
        public Task EditTeacherByIdAsync(int id, AddNewTeacherDto addNewTeacherDto, CancellationToken cancellationToken);
        public Task DeleteTeacherByIdAsync(int id, CancellationToken cancellationToken);
    }

    public class TeacherService : ITeacherService
    {
        private readonly DepartmentDbContext _dbContext;
        public TeacherService(DepartmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TeacherDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var teachers = await _dbContext.Set<Teacher>()
                .Select(t => new TeacherDto
                {
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    MiddleName = t.MiddleName,
                    Department = t.Department.DepartmentName,
                    Position = t.Position.PositionName,
                    Degree = t.Degree.DegreeName,
                    Discipline = t.Discipline.DisciplineName,
                    Load = t.Load.Hours
                })
                .ToListAsync(cancellationToken);

            return teachers;
        }

        public async Task<IEnumerable<TeacherDto>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var teachers = await _dbContext.Set<Teacher>()
                .Where(t => t.TeacherId == id)
                .Select(t => new TeacherDto
                {
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    MiddleName = t.MiddleName,
                    Department = t.Department.DepartmentName,
                    Position = t.Position.PositionName,
                    Degree = t.Degree.DegreeName,
                    Discipline = t.Discipline.DisciplineName,
                    Load = t.Load.Hours
                })
                .ToListAsync(cancellationToken);

            return teachers;
        }

        public async Task AddNewTeacherAsync(AddNewTeacherDto addNewTeacherDto, CancellationToken cancellationToken = default)
        {
            if (addNewTeacherDto != null)
            {
                var teacher = new Teacher
                {
                    TeacherId = addNewTeacherDto.TeacherId,
                    FirstName = addNewTeacherDto.FirstName,
                    LastName = addNewTeacherDto.LastName,
                    MiddleName = addNewTeacherDto.MiddleName,
                    DepartmentId = addNewTeacherDto.DepartmentId,
                    PositionId = addNewTeacherDto.PositionId,
                    DegreeId = addNewTeacherDto.DegreeId,
                    DisciplineId = addNewTeacherDto.DisciplineId,
                    LoadId = addNewTeacherDto.LoadId
                };

                await _dbContext.Teachers.AddAsync(teacher);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task EditTeacherByIdAsync(int id, AddNewTeacherDto addNewTeacherDto, CancellationToken cancellationToken = default)
        {
            var teacher = await _dbContext.Teachers
                .FirstOrDefaultAsync(t => t.TeacherId == id);

            if (teacher != null)
            {
                teacher.TeacherId = addNewTeacherDto.TeacherId;
                teacher.FirstName = addNewTeacherDto.FirstName;
                teacher.LastName = addNewTeacherDto.LastName;
                teacher.MiddleName = addNewTeacherDto.MiddleName;
                teacher.DepartmentId = addNewTeacherDto.DepartmentId;
                teacher.PositionId = addNewTeacherDto.PositionId;
                teacher.DegreeId = addNewTeacherDto.DegreeId;
                teacher.DisciplineId = addNewTeacherDto.DisciplineId;
                teacher.LoadId = addNewTeacherDto.LoadId;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteTeacherByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var teacher = await _dbContext.Teachers.FindAsync(id);

            if (teacher != null)
            {
                _dbContext.Teachers.Remove(teacher);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
