using System;
using Microsoft.AspNetCore.Mvc;

namespace Schoenmaat.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class SchoenmaatController : ControllerBase
    {

        private SchoenmaatService _schoenmaatService;

        public SchoenmaatController(SchoenmaatService schoenmaatService)
        {
            _schoenmaatService = schoenmaatService;
        }

        [HttpGet]
        [Route("schoenmaat/{voetlengte}")]
        public ActionResult<double> calcSchoenmaat(double voetlengte)
        {
            return _schoenmaatService.calcShoenmaat(voetlengte);
        }
    }
}
