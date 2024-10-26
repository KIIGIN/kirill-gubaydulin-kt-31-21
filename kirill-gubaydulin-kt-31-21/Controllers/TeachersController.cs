using kirill_gubaydulin_kt_31_21.Dtos;
using kirill_gubaydulin_kt_31_21.Filters.TeacherFilter;
using kirill_gubaydulin_kt_31_21.Interfaces.TeacherInterfaces;
using Microsoft.AspNetCore.Mvc;


namespace kirill_gubaydulin_kt_31_21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ILogger<TeachersController> _logger;
        private readonly ITeacherService _teacherService;

        public TeachersController(ILogger<TeachersController> logger, ITeacherService teacherService)
        {
            _logger = logger;
            _teacherService = teacherService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherService.GetAllAsync(cancellationToken);
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherService.GetByIdAsync(id, cancellationToken);
            return Ok(teachers);
        }

        [HttpPost("AddNewTeacher")]
        public async Task<IActionResult> AddNewTeacherAsync([FromBody] AddNewTeacherDto addNewTeacherDto, CancellationToken cancellationToken = default)
        {
            try
            {
                await _teacherService.AddNewTeacherAsync(addNewTeacherDto, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditTeacherByIdAsync([FromRoute] int id, [FromBody] AddNewTeacherDto addNewTeacherDto, CancellationToken cancellationToken = default)
        {
            try
            {
                await _teacherService.EditTeacherByIdAsync(id, addNewTeacherDto, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacherByIdAsync([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            try
            {
                await _teacherService.DeleteTeacherByIdAsync(id, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
