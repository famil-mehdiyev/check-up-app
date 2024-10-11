using CheckUpApp.Context;
using CheckUpApp.Model.BaseModel;
using Microsoft.AspNetCore.Mvc;

namespace CheckUpApp.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DoctorController : ControllerBase
    {


       private readonly  CheckUpContext _context;

        public DoctorController(CheckUpContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            _context.doctors.Add(doctor);
            doctor.CreatedDate = DateTime.Now;  
            _context.SaveChanges(); 

                return Ok();
        }

        [HttpPut]
        public IActionResult Update(int id ,Doctor doctor)
        {
            var updatedDoctor = _context.doctors.FirstOrDefault(x=>x.Id==id);
            updatedDoctor.Name = doctor.Name;
            //updatedDoctor.age = doctor.age;
            updatedDoctor.UpdatedDate = DateTime.Now;
            _context.doctors.Update(updatedDoctor);
            _context.SaveChanges();

            return StatusCode(201,doctor);    
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {

            var gettingData = _context.doctors.FirstOrDefault(x => x.Id == id);
            
            return StatusCode(201 , gettingData);
            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Doctor> doctors = _context.doctors.ToList();
                
            return StatusCode(201,doctors);
        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            Doctor removedDoctor = _context.doctors.FirstOrDefault(x => x.Id == id);

            if (removedDoctor == null)
            {
                return BadRequest();
            }

            _context.Remove(removedDoctor);
            _context.SaveChanges();
            return Ok();
        }
    }
}
