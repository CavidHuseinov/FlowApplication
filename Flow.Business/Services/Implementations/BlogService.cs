using AutoMapper;
using Flow.Business.Helpers.DTOs.Blog;
using Flow.Business.Services.Interfaces;
using Flow.Core.Entities;
using Flow.DAL.Context;
using Flow.DAL.Repositories.Interfaces;
using Flow.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Business.Services.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _writeRepository;
        private readonly IReadRepository<Blog> _readRepository;
        private readonly IMapper _mapper;
        private readonly FlowDbContext _context;

        public BlogService(IMapper mapper, IReadRepository<Blog> readRepository, IBlogRepository writeRepository, FlowDbContext context)
        {
            _mapper = mapper;
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _context = context;
        }

        public async Task<GetBlogDto> CreateAsync(CreateBlogDto dto)
        {
            var blog = _mapper.Map<Blog>(dto);
            var createdBlog = await _writeRepository.CreateAsync(blog);

            if (dto.TagIds != null && dto.TagIds.Any())
            {
                var tags = await _context.Tags
                    .Where(tag => dto.TagIds.Contains(tag.Id))
                    .ToListAsync();

                if (tags.Any())
                {
                    createdBlog.BlogTags = new Collection<BlogTag>();
                    foreach (var tag in tags)
                    {
                        createdBlog.BlogTags.Add(new BlogTag
                        {
                            TagId = tag.Id,
                            BlogId = createdBlog.Id
                        });
                    }
                    await _writeRepository.UpdateAsync(createdBlog);
                }
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<GetBlogDto>(createdBlog);
        }


        public async Task RemoveAsync(Guid Id)
        {
            var blog = await _readRepository.GetByIdAsync(Id);
            if (blog == null)
            {
                throw new KeyNotFoundException($"Blog with id {Id} not found.");
            }
            await _writeRepository.DeleteAsync(blog);
        }

        public async Task<ICollection<GetBlogDto>> GetAllAsync()
        {
            var blog = await _readRepository.GetAllAsync(
                include: query=>query
                .Include(x=>x.Category)
                .Include(x => x.BlogTags).ThenInclude(x=>x.Tag)
                );
            return _mapper.Map<ICollection<GetBlogDto>>(blog);
        }

        public async Task<GetBlogDto> GetByIdAsync(Guid Id)
        {
            var blog = await _readRepository.GetAllAsync(
                predicate: x => x.Id == Id,
                include: query => query
                .Include(x => x.Category)
                .Include(x => x.BlogTags).ThenInclude(x => x.Tag)
                );
            var result = blog.FirstOrDefault();
            if (result == null)
            {
                throw new KeyNotFoundException($"Blog with id {Id} not found.");
            }
            return _mapper.Map<GetBlogDto>(result);
        }

        public async Task UpdateAsync(UpdateBlogDto dto)
        {
            var blog = await _readRepository.GetByIdAsync(dto.Id);
            if (blog == null) throw new Exception("blog not found");

            _mapper.Map(dto, blog);
            await _writeRepository.UpdateAsync(blog);
        }
    }
}
