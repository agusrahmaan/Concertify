using Backend.Dto;
using Backend.Interface;
using Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchase _purchaseRepo;
        private readonly IAccount _account;
        private readonly IConcert _concert;

        public PurchaseController(IPurchase purchaseRepo, IAccount account, IConcert concert)
        {
            _purchaseRepo = purchaseRepo;
            _account = account;
            _concert = concert;
        }

        [HttpPost("create")]
        public IActionResult CreatePurchase(PurhcahseDto purhcahseDto)
        {
            var nameAccount = _account.GetAccountByUsername(purhcahseDto.Name);
            var idConcert = _concert.GetConcertById(purhcahseDto.IdConcert);

            if (idConcert == null)
            {
                return BadRequest("Id not found");
            }
            else if(nameAccount == null)
            {
                return BadRequest("Name not found");
            }
            else
            {
                var createPurchase = new Purchase
                {
                    Qty = purhcahseDto.Qty
                };

                _purchaseRepo.CreatePurchase(createPurchase);
                return Ok("Create Success");
            }
        }

        [HttpGet]
        public IActionResult GetPurchase()
        {
            return Ok(_purchaseRepo.GetAllPurchase());
        }

        [HttpGet("{id}")]
        public IActionResult GetPurchaseById(int id)
        {
            var purchaseId = _purchaseRepo.GetPurchaseById(id);
            if (purchaseId == null) return BadRequest("Id not found");

            return Ok(purchaseId);
        }

        [HttpPut("update")]
        public IActionResult UpdatePurchase(int id, PurhcahseDto purhcahseDto)
        {
            var purchaseName = _purchaseRepo.GetAllPurchase().Where(p => p.n)
        }
    }
}
