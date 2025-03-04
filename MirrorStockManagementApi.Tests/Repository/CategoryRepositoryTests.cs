using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;
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
        private readonly ApplicationDbContext _context;
        private readonly CategoryRepository _sut;

        public CategoryRepositoryTests()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(dbOptions);
            _sut = new CategoryRepository(_context);
        }

        [Fact]
        public async Task GetCategoryList_ShouldReturnAllCategories()
        {
            // Arrange
            var testCategories = new List<Category>
            {
                new Category {Id = 1, Name = "Ordinary", Description = "Stock Mirrors"},
                new Category {Id = 2, Name = "Genuine", Description = "Genuine Special Mirros"}
            };

            // Add the categories to the context
            await _context.Categories.AddRangeAsync(testCategories);
            await _context.SaveChangesAsync();


            // Act
            var result = await _sut.GetCategoryListAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Should().BeEquivalentTo(testCategories);
        }
    }
}
