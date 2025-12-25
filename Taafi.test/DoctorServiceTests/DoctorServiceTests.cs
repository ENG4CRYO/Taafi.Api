using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.InMemory;
using AutoMapper;
using Taafi.Application.Dtos;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Taafi.Application.Services; // Add this for Microsoft logger factory

namespace Taafi.Tests.DoctorServiceTests
{
    public class DoctorServiceTests
    {
        private readonly IMapper _mapper;

        public DoctorServiceTests()
        {
           
            var mapperExpr = new MapperConfigurationExpression();

  
            mapperExpr.CreateMap<Doctor, DoctorDto>();

        
            var mockLoggerFactory = new Mock<ILoggerFactory>();

            var config = new MapperConfiguration(mapperExpr, mockLoggerFactory.Object);

            _mapper = config.CreateMapper();
        }

        private AppDbContext GetInMemoryDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;
            return new AppDbContext(options);
        }


        [Fact]
        public async Task GetDoctorByIdAsync_WhenIdExists_ReturnsDoctorDto()
        {
            // Arrange

            var dbName = Guid.NewGuid().ToString();

            using (var context = GetInMemoryDbContext(dbName))
            {
                context.Doctors.Add(new Doctor
                {
                    Id = "001-John",
                    Name = "Dr. John Doe",
                    Specialty = new Specialty { Id = "cardiology", Name = "Cardiology" }
                    
                });

                await context.SaveChangesAsync();
            }

            using (var context = GetInMemoryDbContext(dbName))
            {
                var service = new DoctorService(context, _mapper);


                //Act

                var result = await service.GetDoctorByIdAsync("001-John");


                // Assert

                result.Should().NotBeNull();
                result.Data.Should().NotBeNull(); 
                result.Data.Name.Should().Be("Dr. John Doe");
                result.Success.Should().BeTrue();   

            }




        }
    }
}
