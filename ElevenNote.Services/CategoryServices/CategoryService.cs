using AutoMapper;
using ElevenNote.Data.Context;
using ElevenNote.Data.Entities;
using ElevenNote.Models.CategoryModels;
using Microsoft.EntityFrameworkCore;

namespace ElevenNote.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public CategoryService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateCategory(CategoryCreate model)
        {
            var category = _mapper.Map<Category>(model);
            await _context.Categories.AddAsync(category);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<List<CategoryListItem>> GetCategories()
        {
            var conversion = await _context.Categories.ToListAsync();
            return _mapper.Map<List<CategoryListItem>>(conversion);
        }
    }
}