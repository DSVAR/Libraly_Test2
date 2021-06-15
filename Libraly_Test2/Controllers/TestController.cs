using Microsoft.AspNetCore.Mvc;

namespace Libraly_Test2.Controllers
{
    
    [ApiController]
    [Route("/test/{ortes}")]
    public class TestController
    {
        [HttpGet]
        public int test(int ortes)
        {
            if (ortes >= 0){
                return ortes;
            }
            
            else {
                return 1;
            }
        }
    }
}