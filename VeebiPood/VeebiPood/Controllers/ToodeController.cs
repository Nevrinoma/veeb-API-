using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using veeb.models;

namespace webreallycool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToodeController : ControllerBase
    {
        private static Toode _toode = new Toode(1, "Coca-Cola", 1.5, true);
        // GET: api/Toode
        [HttpGet]
        public Toode GetToode()
        {
            return _toode;
        }
        // GET: api/toode/suurenda-hinda
        [HttpGet("suurenda-hinda")]
        public Toode SuurendaHinda()
        {
            _toode.Price = Math.Round(_toode.Price * 1.1, 3);

            return _toode;
        }
        // GET: api/toode/tf
        [HttpGet("tf")]
        public Toode TrueFalse()
        {
            if (_toode.IsActive == true)
            {
                _toode.IsActive = false;
                return _toode;
            }
            else
            {
                _toode.IsActive = true;
                return _toode;
            }

        }
        // GET: api/toode/rename/Pepsi
        [HttpGet("rename/{newname}")]
        public Toode Rename(string newname)
        {
            _toode.Name = newname;
            return _toode;
        }
        // GET: api/toode/multiply/2
        [HttpGet("multiply/{number}")]
        public Toode Multiply(float number)
        {
            _toode.Price = _toode.Price * number;
            return _toode;
        }
    }
}