using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.RepositoryPattern;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories.CommentRepositoires
{
    public class CommentRepository<T>: IGenericRepository<Comment>
    {
        private readonly CarBookContext _context;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public void Create(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Comment entity)
        {
            _context.Comments.Remove(entity);
        }

        public List<Comment> GetAll()
        {
            return _context.Comments.Select(i => new Comment()
            {
                CommentId = i.CommentId,
                CommentFullname = i.CommentFullname,
                CommentContent = i.CommentContent,
                CommentCreateDate = i.CommentCreateDate,
                BlogId = i.BlogId
            }).ToList();
        }

        public Comment GetById(int id)
        {
            return _context.Comments.Find(id);
        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity);
        }
    }
}