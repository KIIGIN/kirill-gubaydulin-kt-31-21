using kirill_gubaydulin_kt_31_21.Interfaces.DepartmentsInterfaces;
using kirill_gubaydulin_kt_31_21.Filters.DepartmentFilters;

using Microsoft.AspNetCore.Mvc;
using System.Threading;


namespace kirill_gubaydulin_kt_31_21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : Controller
    {
        private readonly ILogger<DepartmentsController> _logger;
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(ILogger<DepartmentsController> logger, IDepartmentService departmentService)
        {
            _logger = logger;
            _departmentService = departmentService;
        }

        [HttpPost("GetByFoundingTime")]
        public async Task<IActionResult> GetByFoundingTimeAsync(DepartmentFoundingFilter filter, CancellationToken cancellationToken = default)
        {
            var departments = await _departmentService.GetByFoundingTimeAsync(filter, cancellationToken);

            return Ok(departments);
        }

        [HttpPost("GetByTeachersCount")]
        public async Task<IActionResult> GetByTeachersCountAsync(DepartmentTeachersCountFilter filter, CancellationToken cancellationToken = default)
        {
            var departments = await _departmentService.GetByTeachersCountAsync(filter, cancellationToken);

            return Ok(departments);
        }
    }
}
