using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SA_Group_Z__21._1_
{
    public class ShapeServiceController : ApiController
    {
        private static readonly Dictionary<string, object> _supportedShapes = new Dictionary<string, object>
        {
            { "circle", new { radius = 0, center = new { x = 0, y = 0 } } },
            { "triangle", new { a = new { x = 0, y = 0 }, b = new { x = 0, y = 0 }, c = new { x = 0, y = 0 } } },
            { "rectangle", new { width = 0, height = 0, topLeft = new { x = 0, y = 0 } } }
        };

        private static readonly string[] _supportedBrailleChars = { "a", "b", "c" };

        [HttpGet]
        [Route("api/ShapeService/SupportedShapes")]
        public IEnumerable<string> GetSupportedShapes()
        {
            return _supportedShapes.Keys.ToList();
        }

        [HttpGet]
        [Route("api/ShapeService/SupportedBrailleChars")]
        public IEnumerable<string> GetSupportedBrailleChars()
        {
            return _supportedBrailleChars;
        }

        [HttpGet]
        [Route("api/ShapeService/ShapeParameters/{shape}")]
        public IHttpActionResult GetShapeParameters(string shape)
        {
            if (!_supportedShapes.ContainsKey(shape))
            {
                return NotFound();
            }

            return Ok(_supportedShapes[shape]);
        }

        [HttpGet]
        [Route("api/ShapeService/BrailleParameters/{brailleText}")]
        public IHttpActionResult GetBrailleParameters(string brailleText)
        {
            var dotCount = brailleText.Length;
            var liquidAmount = dotCount * 0.1; // 0.1 ml per dot

            return Ok(new { DotCount = dotCount, LiquidAmount = liquidAmount });
        }

        [HttpPost]
        [Route("api/ShapeService/ShapeComputation")]
        public IHttpActionResult ComputeShape([FromBody] object shape)
        {
            // perform computation on the provided shape and return the result
            // e.g. calculate the number of dots required for the Braille representation of the shape

            return Ok();
        }
    }
}