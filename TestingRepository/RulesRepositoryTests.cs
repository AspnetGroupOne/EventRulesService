using Core.Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace TestingRepository;

public class RulesRepositoryTests
{
    private readonly DataContext _context;
    private readonly ForbiddenItemRepository _repository;

    public RulesRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _context = new DataContext(options);
        _repository = new ForbiddenItemRepository(_context);
        _context.Database.EnsureCreated();
    }

    

    //CREATE
    [Fact]
    public async Task CreateAsync_ShouldReturnTrue_IfValidEntity()
    {
        //Arrange
        var entity = RepoTestData.ValidForbiddenEntities[0];
        await _context.SaveChangesAsync();

        //Act
        var result = await _repository.CreateAsync(entity);

        //Assert
        Assert.True(result.Success);
    }
    [Fact]
    public async Task CreateAsync_ShouldReturnFalse_IfInvalidEntity()
    {
        //Arrange
        _context.ForbiddenItems.AddRange(RepoTestData.ValidForbiddenEntities);
        await _context.SaveChangesAsync();
        var entity = RepoTestData.InvalidForbiddenEntities[0];

        //Act
        var result = await _repository.CreateAsync(entity);

        //Assert
        Assert.False(result.Success);
    }


    //READ
    [Fact]
    public async Task ExistsAsync_ShouldReturnTrue_IfValidPredicate()
    {
        //Arrange
        _context.ForbiddenItems.AddRange(RepoTestData.ValidForbiddenEntities);
        await _context.SaveChangesAsync();
        var validForbiddenId = "1";

        //Act
        var result = await _repository.ExistsAsync(Forbidden => Forbidden.EventId == validForbiddenId);

        //Assert
        Assert.True(result.Success);
    }
    [Fact]
    public async Task ExistsAsync_ShouldReturnFalse_IfInvalidPredicate()
    {
        //Arrange
        _context.ForbiddenItems.AddRange(RepoTestData.ValidForbiddenEntities);
        await _context.SaveChangesAsync();
        var inValidForbiddenId = "";

        //Act
        var result = await _repository.ExistsAsync(Forbidden => Forbidden.EventId == inValidForbiddenId);

        //Assert
        Assert.False(result.Success);
    }


    [Fact]
    public async Task GetAsync_ShouldReturnTrue_IfValidPredicate()
    {
        //Arrange
        _context.ForbiddenItems.AddRange(RepoTestData.ValidForbiddenEntities);
        await _context.SaveChangesAsync();
        var validForbiddenId = "1";

        //Act
        var result = await _repository.GetAsync(entity => entity.EventId == validForbiddenId);

        //Assert
        Assert.True(result.Success);
    }
    [Fact]
    public async Task GetAsync_ShouldReturnFalse_IfInvalidPredicate()
    {
        //Arrange
        _context.ForbiddenItems.AddRange(RepoTestData.ValidForbiddenEntities);
        await _context.SaveChangesAsync();
        var validForbiddenId = "8585";

        //Act
        var result = await _repository.GetAsync(entity => entity.EventId == validForbiddenId);

        //Assert
        Assert.False(result.Success);
    }


    //UPDATE
    [Fact]
    public async Task UpdateAsync_ShouldReturnTrue_IfValidEntity()
    {
        //Arrange
        _context.ForbiddenItems.AddRange(RepoTestData.ValidForbiddenEntities);
        await _context.SaveChangesAsync();
        var validForbiddenId = "1";

        //Act
        var entity = await _repository.GetAsync(entity => entity.EventId == validForbiddenId);
        var updateEntity = entity.Content;
        updateEntity.Tent = true;

        var result = await _repository.UpdateAsync(updateEntity);

        //Assert
        Assert.True(result.Success);
    }
    [Fact]
    public async Task UpdateAsync_ShouldReturnFalse_IfInvalidEntity()
    {
        //Arrange
        _context.ForbiddenItems.AddRange(RepoTestData.ValidForbiddenEntities);
        await _context.SaveChangesAsync();
        var inValidEntity = new ForbiddenEntity
        {
            EventId = "5",
            
        };

        //Act
        var result = await _repository.UpdateAsync(inValidEntity);

        //Assert
        Assert.False(result.Success);
    }


    //DELETE
    [Fact]
    public async Task DeleteAsync_ShouldReturnTrue_IfValidEntity()
    {
        //Arrange
        _context.ForbiddenItems.AddRange(RepoTestData.ValidForbiddenEntities);
        await _context.SaveChangesAsync();
        var validEntity = RepoTestData.ValidForbiddenEntities[0];

        //Act
        var result = await _repository.RemoveAsync(validEntity);

        //Assert
        Assert.True(result.Success);
    }
    [Fact]
    public async Task DeleteAsync_ShouldReturnFalse_IfInvalidEntity()
    {
        //Arrange
        _context.ForbiddenItems.AddRange(RepoTestData.ValidForbiddenEntities);
        await _context.SaveChangesAsync();
        var invalidEntity = RepoTestData.InvalidForbiddenEntities[1];

        //Act
        var result = await _repository.RemoveAsync(invalidEntity);

        //Assert
        Assert.False(result.Success);
    }
}
