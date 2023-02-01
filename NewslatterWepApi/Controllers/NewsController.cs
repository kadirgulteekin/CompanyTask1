using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewslatterWepApi.Context;
using NewslatterWepApi.Models;

namespace NewslatterWepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsContoller : ControllerBase
    {
        private readonly NewsLatterDb _newsLatterDb;

        public NewsContoller(NewsLatterDb newsLatterDb)
        {
            _newsLatterDb = newsLatterDb;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _newsLatterDb.Newslatters.FindAsync(id);
            if(result == null)
            {
                return Ok("Bu Id'ye ait herhangi bir haber yoktur.");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(NewsLatter newsLatter)
        {
            newsLatter.CreatedDate = DateTime.Now;
            await _newsLatterDb.Newslatters.AddAsync(newsLatter);
            await _newsLatterDb.SaveChangesAsync();
            return Ok("Haber kaydı başarılıdır");
        }

        [HttpPut]
        public async Task<IActionResult> Put(NewsLatter newsLatter)
        {
            _newsLatterDb.Newslatters.Update(newsLatter);
            await _newsLatterDb.SaveChangesAsync();
            return Ok("Haber kaydı başarıyla güncllendi");
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _newsLatterDb.Newslatters.FindAsync(id);
            _newsLatterDb.Newslatters.Remove(result);
            await _newsLatterDb.SaveChangesAsync();
            return Ok("Haber kaydı başarıyla silindi");

        }

    }
}
