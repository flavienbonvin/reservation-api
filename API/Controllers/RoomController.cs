using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class RoomController : ApiController
    {
        public ModelContainer context = new ModelContainer();

        public IHttpActionResult GetRoom(int id)
        {
            var room = context.Rooms.Find(id);

            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }


        public IHttpActionResult GetAllRooms()
        {
            var rooms = from Room in context.Rooms
                          select Room;

            if (rooms == null)
            {
                return NotFound();
            }
            return Ok(rooms);
        }

        [HttpPost]
        public void PostRoom([FromBody]Room room)
        {
            context.Rooms.Add(room);
            context.SaveChanges();
        }
    }
}
