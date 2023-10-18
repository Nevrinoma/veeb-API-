using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using veeb.models;

namespace VeebiPood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TootedController
    {
        private static List<Toode> _tooted = new()
        {
            new Toode(1,"Koola", 1.5, true),
            new Toode(2,"Fanta", 1.0, false),
            new Toode(3,"Sprite", 1.7, true),
            new Toode(4,"Vichy", 2.0, true),
            new Toode(5,"Vitamin well", 2.5, true)
        };

        // GET https://localhost:4444/tooted
        [HttpGet]
        public List<Toode> Get()
        {
            return _tooted;
        }
        [HttpPost("lisa")]
        public List<Toode> Add([FromBody] Toode toode)
        {
            _tooted.Add(toode);
            return _tooted;
        }

        // DELETE https://localhost:4444/tooted/kustuta/0
        [HttpDelete("kustuta/{index}")]
        public List<Toode> Delete(int index)
        {
            _tooted.RemoveAt(index);
            return _tooted;
        }

        [HttpDelete("kustuta2/{index}")]
        public string Delete2(int index)
        {
            _tooted.RemoveAt(index);
            return "Kustutatud!";
        }

        // POST https://localhost:4444/tooted/lisa/1/Coca/1.5/true
        [HttpPost("lisa/{id}/{nimi}/{hind}/{aktiivne}")]
        public List<Toode> Add(int id, string nimi, double hind, bool aktiivne)
        {
            Toode toode = new Toode(id, nimi, hind, aktiivne);
            _tooted.Add(toode);
            return _tooted;
        }

        [HttpPost("lisa2")]
        public List<Toode> Add2(int id, string nimi, double hind, bool aktiivne)
        {
            Toode toode = new Toode(id, nimi, hind, aktiivne);
            _tooted.Add(toode);
            return _tooted;
        }

        // PATCH https://localhost:4444/tooted/hind-dollaritesse/1.5
        [HttpPatch("hind-dollaritesse/{kurss}")]
        public List<Toode> UpdatePrices(double kurss)
        {
            for (int i = 0; i < _tooted.Count; i++)
            {
                _tooted[i].Price = _tooted[i].Price * kurss;
            }
            return _tooted;
        }

        // või foreachina:

        [HttpGet("hind-dollaritesse2/{kurss}")] // GET /tooted/hind-dollaritesse2/1.5
        public List<Toode> Dollaritesse2(double kurss)
        {
            foreach (var t in _tooted)
            {
                t.Price = t.Price * kurss;
            }

            return _tooted;
        }

        [HttpGet("udalit-vse")]
        public List<Toode> DeleteAll()
        {
            _tooted.Clear(); 
            return _tooted;
        }

        [HttpGet("deaktivirovat-vse")]
        public List<Toode> DeactivateAll()
        {
            foreach (var toode in _tooted)
            {
                toode.IsActive = false;
            }
            return _tooted;
        }

        [HttpGet("odin-tovar/{index}")]
        public Toode GetProductByIndex(int index)
        {
            if (index >= 0 && index < _tooted.Count)
            {
                return _tooted[index];
            }
            else
            {
                
                return null;
            }
        }

        [HttpGet("mvp")]
        public Toode GetProductWithHighestPrice()
        {
            if (_tooted.Count == 0)
            {
                return null;
            }

            Toode productWithHighestPrice = _tooted[0]; 

            foreach (var toode in _tooted)
            {
                if (toode.Price > productWithHighestPrice.Price)
                {
                    productWithHighestPrice = toode;
                }
            }

            return productWithHighestPrice;
        }




    }
}
