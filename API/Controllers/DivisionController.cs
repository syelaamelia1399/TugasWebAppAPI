using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]

    public class DivisionController : BaseController<DivisionRepository, Division>
    {
        DivisionRepository repository;

        public DivisionController(DivisionRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
