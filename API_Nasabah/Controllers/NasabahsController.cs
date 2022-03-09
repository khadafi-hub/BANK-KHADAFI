using API_Nasabah.Base;
using API_Nasabah.Models;
using API_Nasabah.Repository.Data;
using API_Nasabah.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Net;

namespace API_Nasabah.Controllers
{
    [Route("API_Nasabah/[controller]")]
    [ApiController]
    public class NasabahsController : BaseController<Nasabah, NasabahRepository, string>
    {
        private NasabahRepository nasabahRepository;

        public NasabahsController(NasabahRepository nasabahRepository) : base(nasabahRepository)
        {
            this.nasabahRepository = nasabahRepository;

        }

        [HttpGet("TestCORS")]
        public ActionResult TestCORS()
        {
            return Ok("Test CORS berhasil");
        }

        [HttpPost("Register")]
        public ActionResult Post(RegisterVM registerVM)
        {
            var check = nasabahRepository.Register(registerVM);
            if (check == 1)
            {
                return Conflict(new { status = HttpStatusCode.Conflict, check, messageResult = "NIK yang anda masukan sudah terdaftar, harap masukan NIK anda dengan benar" });
            }
            if (check == 2)
            {
                return Conflict(new { status = HttpStatusCode.Conflict, check, messageResult = "Nomor telepon yang anda masukan sudah terdaftar, harap masukan nomor telepon anda dengan benar" });
            }
            if (check == 3)
            {
                return Conflict(new { status = HttpStatusCode.Conflict, check, messageResult = "Email yang anda masukan sudah terdaftar, harap masukan email anda dengan benar" });
            }

            return Ok(new { status = HttpStatusCode.OK, check, messageResult = "Data Berhasil Ditambahkan" });
        }

        //[Authorize(Roles = "Director,Manager" )]
        [HttpGet("Get")]
        public ActionResult GetAll()
        {
            var result = nasabahRepository.EmployeeAllData();
            try
            {

                /*return Ok(new { status = HttpStatusCode.OK, result, Message = "Data Berhasil Di Perlihatkan" });*/
                return Ok(result);
            }
            catch
            {
                return NotFound(result);
                //return Unauthorized(new { status = HttpStatusCode.Unauthorized, Message = "Maaf, user selain Manager dan Director tidak bisa mengakses fitur ini" });
            }




        }

        [HttpGet("Profile/{NIK}")]
        public ActionResult<RegisterVM> Profile(string NIK)
        {
            var result = nasabahRepository.GetProfile(NIK);
            if (result != null)
            {
                return Ok(new { status = HttpStatusCode.OK, result, messageResult = "Data ditemukan" });
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result, messageResult = $"Data {NIK} tidak ditemukan." });
        }
    }
}
