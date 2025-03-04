using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MirrorStockManagementApi.Data;
using MirrorStockManagementApi.Models;
using MirrorStockManagementApi.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MirrorStockManagementApi.Tests.Repository
{
    public class CategoryRepositoryTests
    {

        private readonly DbContextOptions<ApplicationDbContext> _options;
        private readonly ApplicationDbContext _context;
        private readonly CategoryRepository _category;

        public CategoryRepositoryTests()
        {
            // Create a unique database name for each test to avoid conflicts
            var dbName = $"MirrorStockDb_{Guid.NewGuid()}";

            // Configure the in-memory database
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;

            // Create real context with the in-memory database
            _context = new ApplicationDbContext(_options);

            // Initialize the repository with the real context
            _category = new CategoryRepository(_context);
                
        }

        [Fact]
        public async Task GetCategoryList_ShouldReturnAllCategories()
        {
            // Arrange - seed the database
            var testCategories = new List<Category>
            {
                new Category {Id = 1, Name = "Ordinary", Description = "Stock Mirrors"},
                new Category {Id = 2, Name = "Genuine", Description = "Genuine Special Mirros"}

            };
            // Add the categories to the context
            await _context.Categories.AddRangeAsync(testCategories);
            await _context.SaveChangesAsync();


            // Act
            var result = await _category.GetCategoryListAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Should().BeEquivalentTo(testCategories);
        }

    }
}
