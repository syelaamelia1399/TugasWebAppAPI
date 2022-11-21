using API.Models;
using API.Repository.Data;
using API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private DepartmentRepository _repository;
        
        public DepartmentController(DepartmentRepository departmentRepository)
        {
            _repository = departmentRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var data = _repository.Index();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var data = _repository.GetById(id);
            if(data == null)
            {
                return Ok(new { Messege = "Data Tidak Ditemukan" });
            }
            return Ok(data);
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            var result = _repository.Create(department);
            if(result == 0)
            {
                return Ok(new { Messege = "Data Gagal Disimpan" });
            }
            return Ok(new { Messege = "Data Berhasil Disimpan" });
        }

        [HttpPut]
        public ActionResult Update(Department department)
        {
            var result = _repository.Update(department);
            if(result == 0)
            {
                return Ok(new { Messege = "Data Gagal di Update" });
            }
            return Ok(new { Messege = "Data Berhasil di Update" });
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _repository.Delete(id);
            if(result == 0)
            {
                return Ok(new { Messege = "Data Gagal di Hapus" });
            }
            return Ok(new { Messege = "Data Berhasil di Hapus" });
        }
    
    }
}
