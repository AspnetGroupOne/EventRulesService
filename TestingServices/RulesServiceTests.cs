using Core.Domain.Entities;
using Core.Domain.Models;
using Core.Interfaces;
using Core.Internal.Services;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace TestingServices;

public class RulesServiceTests
{
    private readonly DataContext _context;
    private readonly IForbiddenItemService _service;
    private readonly IForbiddenItemRepository _repository;

    public RulesServiceTests()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _context = new DataContext(options);
        _repository = new ForbiddenItemRepository(_context);
        _service = new ForbiddenItemService(_repository);
        _context.Database.EnsureCreated();
    }

   

    //CREATE
    [Fact]
    public async Task AddScheduleAsync_ShouldReturnTrue_IfValidAddForm()
    {
        //Arrange
        var entity = ServTestData.ValidForbiddenAddForm[0];
        await _context.SaveChangesAsync();

        //Act
        var result = await _service.AddAForbiddenItem(entity);

        //Assert
        Assert.True(result.Success);
    }
    [Fact]
    public async Task AddScheduleAsync_ShouldReturnFalse_IfInvalidAddForm()
    {
        //Arrange
        _context.ForbiddenItems.AddRange(ServTestData.ValidForbiddenEntities);
        await _context.SaveChangesAsync();
        var entity = ServTestData.InvalidForbiddenAddForm[0];

        //Act
        var result = await _service.AddAForbiddenItem(entity);

        //Assert
        Assert.False(result.Success);
    }

    //READ
    [Fact]
    public async Task GetScheduleAsync_ShouldReturnTrue_IfValidEventId()
    {
        //Arrange
        await _service.AddAForbiddenItem(ServTestData.ValidForbiddenAddForm[0]);
        await _context.SaveChangesAsync();
        var validScheduleId = "1";

        //Act
        var result = await _service.GetAForbiddenItem(validScheduleId);

        //Assert
        Assert.True(result.Success);
    }
    [Fact]
    public async Task GetScheduleAsync_ShouldReturnFalse_IfInvalidEventId()
    {
        //Arrange
        await _service.AddAForbiddenItem(ServTestData.ValidForbiddenAddForm[0]);
        await _context.SaveChangesAsync();
        var invalidScheduleId = "6";

        //Act
        var result = await _service.GetAForbiddenItem(invalidScheduleId);

        //Assert
        Assert.False(result.Success);
    }
    //UPDATE
    [Fact]
    public async Task UpdateScheduleAsync_ShouldReturnFalse_IfInvalidUpdateForm()
    {
        //Arrange
        await _service.AddAForbiddenItem(ServTestData.ValidForbiddenAddForm[0]);
        await _context.SaveChangesAsync();

        //Act
        var result = await _service.UpdateForbiddenItems(ServTestData.ValidUpdateForbiddenAddForm[0]);

        //Assert
        Assert.False(result.Success);
    }
    //DELETE
    [Fact]
    public async Task DeleteScheduleAsync_ShouldReturnTrue_IfValidEventId()
    {
        //Arrange
        await _service.AddAForbiddenItem(ServTestData.ValidForbiddenAddForm[0]);
        await _context.SaveChangesAsync();
        var validId = "1";

        //Act
        var result = await _service.RemoveForbiddenItem(validId);

        //Assert
        Assert.True(result.Success);
    }
    [Fact]
    public async Task DeleteScheduleAsync_ShouldReturnFalse_IfInvalidEventId()
    {
        //Arrange
        await _service.AddAForbiddenItem(ServTestData.ValidForbiddenAddForm[0]);
        await _context.SaveChangesAsync();
        var invalidId = "60";

        //Act
        var result = await _service.RemoveForbiddenItem(invalidId);

        //Assert
        Assert.False(result.Success);
    }
}
