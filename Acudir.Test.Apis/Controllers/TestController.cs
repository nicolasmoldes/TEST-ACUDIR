namespace Acudir.Test.Apis.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        //Devolver una lista que retorne Personas
        [HttpGet("GetAll")]
        public ActionResult<Object>? GetAll()
        {
            return null;
        } 
        //Post Guardar una Persona o mas

        //Put Modificarlas
    }
}
