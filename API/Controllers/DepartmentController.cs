using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]

    public class DepartmentController : BaseController<DepartmentRepository, Department>
    {
        DepartmentRepository repository;

        public DepartmentController(DepartmentRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
