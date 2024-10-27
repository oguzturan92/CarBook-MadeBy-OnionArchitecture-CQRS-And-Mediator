using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.RepositoryPattern;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentsRepository;

        public CommentsController(IGenericRepository<Comment> commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentsRepository.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CommentCreate(Comment comment)
        {
            _commentsRepository.Create(comment);
            return Ok("Yorum Eklendi");
        }

        [HttpGet("{id}")]
        public IActionResult CommentGetById(int id)
        {
            var value = _commentsRepository.GetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult CommentUpdate(Comment comment)
        {
            _commentsRepository.Update(comment);
            return Ok("Yorum Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult CommentDelete(Comment comment)
        {
            _commentsRepository.Delete(comment);
            return Ok("Yorum Silindi");
        }
    }
}