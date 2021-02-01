using ColorDataAccess;
using ColorDataAccess.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ColorWebService.Controllers
{
    [RoutePrefix("api")]
    public class ColorController : ApiController
    {
        [ResponseType(typeof(IEnumerable<Color>))]
        [HttpGet]
        [Route("inventory")]
        public IHttpActionResult GetInventory()
        {
            
            try
            {
                List<Color> colors = new List<Color>();
                colors = Singleton.GetInstance().GetFacade().GetAll().ToList();
                return Ok(colors);
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [ResponseType(typeof(Color))]
        [HttpGet]
        [Route("color/{id}")]
        public IHttpActionResult GetColor([FromUri]int id)
        {
            if (id == 0)
            {
                return StatusCode( HttpStatusCode.NoContent);
            }
          
            try
            {
                Color color = Singleton.GetInstance().GetFacade().Get(id);
                return Ok(color);
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("addcolor")]
        public IHttpActionResult AddColor([FromBody] JObject jcolor )
        {
            Color color = JsonConvert.DeserializeObject<Color>(jcolor.ToString());
            try
            {
                Singleton.GetInstance().GetFacade().Insert(color);
                return Ok();
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [HttpPut]
        [Route("updatecolor")]
        public IHttpActionResult UpdateColor([FromBody] string[] data)
        {
            Color color = new Color
            {
                Id = int.Parse(data[0]),
                Name = data[1],
                HexCode = data[2],
                IsAvailable = data[3] == "true" ? true : false
            };
            try
            {
                Singleton.GetInstance().GetFacade().Update(color);
                return Ok();
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IHttpActionResult DeleteColor([FromUri] int id)
        {
            try
            {
                Singleton.GetInstance().GetFacade().Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
