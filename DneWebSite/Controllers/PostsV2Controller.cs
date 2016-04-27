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
using DneWebSite.Models.bulletin;

namespace DneWebSite.Controllers
{
    public class PostsV2Controller : ApiController
    {
        private BulletinDbContext db = new BulletinDbContext();

        // GET: api/PostsV2
        public IQueryable<Post> GetPosts()
        {
            return db.Posts;
        }

        // GET: api/PostsV2/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult GetPost(Guid id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT: api/PostsV2/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPost(Guid id, Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.PostId)
            {
                return BadRequest();
            }

            db.Entry(post).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PostsV2
        [ResponseType(typeof(Post))]
        public IHttpActionResult PostPost(Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Posts.Add(post);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PostExists(post.PostId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = post.PostId }, post);
        }

        // DELETE: api/PostsV2/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult DeletePost(Guid id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            db.Posts.Remove(post);
            db.SaveChanges();

            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(Guid id)
        {
            return db.Posts.Count(e => e.PostId == id) > 0;
        }
    }
}