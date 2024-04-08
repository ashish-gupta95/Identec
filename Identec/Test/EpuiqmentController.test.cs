using Identec.Controllers;
using Identec.Model;
using Identec.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Identec.Tests.Controllers
{
    public class EquipmentControllerTests
    {
        [Fact]
        public async Task GetEquipmentByIdAsync_ReturnsNotFound_WhenEquipmentNotFound()
        {
            // Arrange
            var mockEquipmentService = new Mock<IEquipmentService>();
            mockEquipmentService.Setup(service => service.GetEquipmentByIdAsync(It.IsAny<int>()))
                                 .ReturnsAsync((Equipment)null);
            var controller = new EquipmentController(mockEquipmentService.Object);

            // Act
            var result = await controller.GetEquipmentByIdAsync(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetEquipmentByIdAsync_ReturnsOk_WhenEquipmentFound()
        {
            // Arrange
            var expectedEquipment = new Equipment { Id = 1, Name = "Excavator", Status = "Active" };
            var mockEquipmentService = new Mock<IEquipmentService>();
            mockEquipmentService.Setup(service => service.GetEquipmentByIdAsync(It.IsAny<int>()))
                                 .ReturnsAsync(expectedEquipment);
            var controller = new EquipmentController(mockEquipmentService.Object);

            // Act
            var result = await controller.GetEquipmentByIdAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualEquipment = Assert.IsAssignableFrom<Equipment>(okResult.Value);
            Assert.Equal(expectedEquipment.Id, actualEquipment.Id);
            Assert.Equal(expectedEquipment.Name, actualEquipment.Name);
            Assert.Equal(expectedEquipment.Status, actualEquipment.Status);
        }

        [Fact]
        public async Task UpdateEquipmentAsync_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockEquipmentService = new Mock<IEquipmentService>();
            var controller = new EquipmentController(mockEquipmentService.Object);
            controller.ModelState.AddModelError("status", "status is required");

            // Act
            var result = await controller.UpdateEquipmentAsync(new Equipment());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdateEquipmentAsync_ReturnsNoContent_OnSuccessfulUpdate()
        {
            // Arrange
            var mockEquipmentService = new Mock<IEquipmentService>();
            var controller = new EquipmentController(mockEquipmentService.Object);

            // Act
            var result = await controller.UpdateEquipmentAsync(new Equipment());

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
