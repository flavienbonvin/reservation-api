using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ReservationController : ApiController
    {
        public ModelContainer context = new ModelContainer();

        public IHttpActionResult GetReservation(int id)
        {
            var reservation = context.Reservations.Find(id);

            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }


        public IHttpActionResult GetAllReservations()
        {
            var reservations = from Reservation in context.Reservations
                        select Reservation;

            if (reservations == null)
            {
                return NotFound();
            }
            return Ok(reservations);
        }

        [HttpPost]
        public void PostReservation([FromBody]Reservation reservation)
        {
            context.Reservations.Add(reservation);
            context.SaveChanges();
        }
    }
}
