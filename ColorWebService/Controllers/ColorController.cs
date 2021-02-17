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
    [RoutePrefix("api")]/// api prefix
    public class ColorController : ApiController
    {
        [ResponseType(typeof(IEnumerable<Color>))]
        [HttpGet]
        [Route("inventory")]
        public IHttpActionResult GetInventory()//fetch all inventory
        {
            
            try
            {
              //  List<IColor> colors =new List<IColor>();
               IEnumerable<IColor> colors = Singleton.GetInstance().GetFacade().GetAll();
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
        public IHttpActionResult GetColor([FromUri]int id)//fetch specific color by id
        {
            if (id == 0)
            {
                return StatusCode( HttpStatusCode.NoContent);
            }
          
            try
            {
                IColor color = Singleton.GetInstance().GetFacade().Get(id);
                return Ok(color);
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("addcolor")]//inserts color
        public IHttpActionResult AddColor([FromBody] Color color )
        {           
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
        [Route("updatecolor")]//updates color
        public IHttpActionResult UpdateColor([FromBody] JObject data)
        {
            try
            {
                 Color color = JsonConvert.DeserializeObject<Color>(data.ToString());
                Singleton.GetInstance().GetFacade().Update(color);
                return Ok();
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]//deletes  color by id
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
