using Backend.Data;
using Backend.Dto;
using Backend.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcertController : ControllerBase
    {
        private readonly IConcert _concertRepo;
        public ConcertController(IConcert concertRepo)
        {
            _concertRepo = concertRepo;
        }

        [HttpPost("create")]
        public IActionResult CreateConcert([FromQuery] ConcertDto concertDto)
        {
            var checkConcertName = _concertRepo.GetAllConcert().Where(c => c.Musisi.ToLower() == concertDto.Musisi.ToLower()).FirstOrDefault();
            if (checkConcertName != null) return BadRequest("Concert Name already exist");

            var newConcert = new Model.Concert
            {
                Musisi = concertDto.Musisi,
                Image = concertDto.Image,
                Description = concertDto.Description,
                Venue = concertDto.Venue,
                Date = concertDto.Date
            };

            _concertRepo.CreateConcert(newConcert);
            return Ok("Create Success");
        }

        [HttpGet]
        public IActionResult GetAllConcert()
        {
            return Ok(_concertRepo.GetAllConcert());
        }

        [HttpGet("{id}")]
        public IActionResult GetConcertById(int id)
        {
            var concertId = _concertRepo.GetConcertById(id);
            if (concertId == null) return BadRequest("Id not found");
            return Ok(concertId);
        }

        [HttpPut("update")]
        public IActionResult UpdateConcert(int id, ConcertDto concertDto)
        {
            var concertName = _concertRepo.GetAllConcert().Where(n => n.Musisi == concertDto.Musisi).FirstOrDefault();
            var concertId = _concertRepo.GetConcertById(id);

            if (concertId == null)
            {
                return BadRequest("Concert Id not found");
            }
            else
            {
                if (concertId.Musisi != concertDto.Musisi && concertName != null)
                {
                    return BadRequest("Concert Name already exist");
                }

                concertId.Musisi = concertDto.Musisi;
                concertId.Image = concertDto.Image;
                concertId.Venue = concertDto.Venue;
                concertId.Date = concertDto.Date;

                _concertRepo.UpdateConcert(concertId);
                return Ok("Update Success");
            }
        }

        [HttpDelete]
        public IActionResult DeleteConcert(int id)
        {
            var deleteConcert = _concertRepo.GetConcertById(id);
            if(deleteConcert == null)
            {
                return BadRequest("Id not found");
            }

            _concertRepo.DeleteConcert(id);
            return Ok("Delete Success");
        }
    }
}
