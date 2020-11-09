using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductInformation.Models;

namespace ProductInformation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {

        /*
         * Common HTTP Methods:
         * GET: Read / Query - Get Data (Typically JSON Format from APIs)
         * POST: Submission of a new Entity
         * PUT: Update of an existing entity (Full replace)
         * PATCH: Update of an existing entity (partial replace, typically with instructions)
         * DELETE: Deletes an entity
         * 
         * 
         * Common HTTP Status Codes:
         * 200: "OK"  - Success / Ok / Everything Good
         * 400: "Bad Request" - Parameters aren't of the right type, etc.
         * 404: "Not found" - Tried to access a resource that's not there
         * 409: "Conflict" - Proposed entity breaks a business logic rule
         * 
         * Less Common HTTP Status Codes:
         * 301: "Move Permanently" - Whatever you are trying to access has changed URL/Location
         * 401: "Unauthourized" - User is not logged in, therefore doesn't have rights to access resource.  
         * 403: "Forbidden" - User is logged in but doesn't have rights to access resource. 
         * 410: "Gone" - Whatever you are trying to access is gone with no new known location. 
         * 418: "I'm a teapot" - Cannot brew a cup of coffee because server is a teapot. (Joke Error)
         * 422: "Unproessable Entity" - Kind of similar to 'Conflict', the entity breaks business logic rules.
         * 500: "Internal Server Error" - Something's broke, who knows what?
         * */

        [HttpGet("All")]
        // Get ALL Products
        public ActionResult<IEnumerable<Product>> AllProducts_GET()
        {
            return new ProductController().GetProducts();
        }

    }
}
