using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Gram;

namespace AnalyseurSyntaxique.Controllers
{

    [ApiController]
    [Route("v1/[controller]")]
    public class FrancaisController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public async Task<ActionResult> Analyser(string text)
        {
            var grammaire = new FrancaisGrammaire().Analyseur(text);

            return Ok(grammaire);        
        }
    }
}
