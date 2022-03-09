using API_Nasabah.Controllers;
using API_Nasabah.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace API_Nasabah.Base
{
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<Entity> Get()
        {
            var result = repository.Get();
            if (result.Count() == 0)
            {
                return NotFound(new { status = HttpStatusCode.NoContent, result, messageResult = "Data masih kosong" });
            }
            /*return Ok(new { status = HttpStatusCode.OK, result, messageResult = "Semua data berhasil ditampilkan" });*/
            return Ok(result);
        }


        [HttpPost]
        public ActionResult<Entity> Post(Entity entity)
        {

            var result = repository.Insert(entity);
            if (result != 0)
            {
                //return Ok(new { status = HttpStatusCode.OK, result, messageResult = "Data berhasil ditambahkan" });
                return Ok(result);
            }

            return BadRequest(new { status = HttpStatusCode.BadRequest, result, messageResult = "Sepertinya terjadi kesalahan, periksa kembali!" });

        }

        [HttpPut]
        public ActionResult<Entity> Put(Entity entity, Key key)
        {
            var result = repository.Update(entity, key);
            if (result != 0)
            {
                //return Ok(new { status = HttpStatusCode.OK, result, messageResult = "Data Berhasil di Update" });
                return Ok(result);
            }
            return BadRequest(new { status = HttpStatusCode.BadRequest, result, messageResult = "Data tidak berhasil di update" });
        }

        [HttpDelete("{key}")]
        public ActionResult<Entity> Delete(Key key)
        {
            var result = repository.Delete(key);
            if (result != 0)
            {
                //return Ok(new { status = HttpStatusCode.OK, result, messageResult = $"Data {key} berhasil dihapus" });
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result, messageResult = $"Data {key} tidak ditemukan." });
        }


        [HttpGet("{key}")]
        public ActionResult Get(Key key)
        {
            var result = repository.Get(key);
            if (result != null)
            {
                //return Ok(new { status = HttpStatusCode.OK, result, messageResult = "Data ditemukan" });
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result, messageResult = $"Data {key} tidak ditemukan." });
        }


    }
}
