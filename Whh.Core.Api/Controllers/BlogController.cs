using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Whh.Core.Model;
using Whh.Core.IRepository;
using Whh.Core.Services.Base;

namespace MyBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Blog>> GetAllBlogs()
        {
            var blogs = _blogRepository.QueryAsync();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public ActionResult<Blog> GetBlogById(int id)
        {
            var blog = _blogRepository.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public ActionResult<Blog> CreateBlog(Blog blog)
        {
            var createdBlog = _blogRepository.CreateAsync(blog);
            return CreatedAtAction(nameof(GetBlogById), new { id = createdBlog.Id }, createdBlog);
        }

        [HttpPut("{id}")]
        public ActionResult<Blog> UpdateBlog(int id, Blog blog)
        {
            if (id != blog.Id)
            {
                return BadRequest();
            }
            var updatedBlog = _blogRepository.EditAsync(blog);
            if (updatedBlog == null)
            {
                return NotFound();
            }
            return Ok(updatedBlog);
        }

        [HttpDelete("{id}")]
        public ActionResult<Blog> DeleteBlog(int id)
        {
            var deletedBlog = _blogRepository.DeleteByIdAsync(id);
            if (deletedBlog == null)
            {
                return NotFound();
            }
            return Ok(deletedBlog);
        }
    }
}