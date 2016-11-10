using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ConferentionMembers.Models;

namespace ConferentionMembers.Controllers
{
    public class MembersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Members?yearOfBirth={yearOfBirth}
        /// <summary>
        /// Get conference members with specified year of birth
        /// </summary>
        /// <param name="yearOfBirth"></param>
        /// <returns></returns>
        [ResponseType(typeof(ConferenceMember))]
        public IHttpActionResult GetConferenceMember(int yearOfBirth)
        {
            var conferenceMembers = db.ConferenceMembers.Where(x => x.YearOfBirth == yearOfBirth);
            if (!conferenceMembers.Any())
            {
                return NotFound();
            }
            return Ok(conferenceMembers.ToList());
        }

        // GET: api/Members?education={education}
        /// <summary>
        /// Get conference members with specified education
        /// </summary>
        /// <param name="education"></param>
        /// <returns></returns>
        [ResponseType(typeof(ConferenceMember))]
        public IHttpActionResult GetConferenceMember(EducationType education)
        {
            var conferenceMembers = db.ConferenceMembers.Where(x => x.Education == education);
            if (!conferenceMembers.Any())
            {
                return NotFound();
            }
            return Ok(conferenceMembers.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}