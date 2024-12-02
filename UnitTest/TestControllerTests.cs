using Acudir.Test.Apis.Controllers;
using Application.Dtos;
using Application.Request.PersonaRequest;
using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class TestControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IServicePersona> _servicePersonaMock;
        private readonly TestController _controller;

        public TestControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _servicePersonaMock = new Mock<IServicePersona>();
            _controller = new TestController(_mediatorMock.Object, _servicePersonaMock.Object);
        }

        #region GetAll Tests
        [Fact]
        public async Task GetAll_ReturnsOkResult_WhenPersonasFound()
        {
            // Arrange
            var personas = new List<PersonaDto> { new PersonaDto { Id = 1, NombreCompleto = "John Doe" } };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPersonaRequest>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(personas);

            // Act
            var result = await _controller.GetAll(null, null, null, null, null, null);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<PersonaDto>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task GetAll_ReturnsNotFound_WhenNoPersonasFound()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPersonaRequest>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(new List<PersonaDto>());

            // Act
            var result = await _controller.GetAll(null, null, null, null, null, null);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("No se encontraron personas con los datos proporcionados.", notFoundResult.Value);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WhenPersonasIsEmpty()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPersonaRequest>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(new List<PersonaDto>()); // Lista vacía

            // Act
            var result = await _controller.GetAll(null, null, null, null, null, null);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<PersonaDto>>(okResult.Value);
            Assert.Empty(returnValue);  // Verifica que la lista está vacía
        }
        #endregion

        #region Add Tests
        [Fact]
        public async Task Add_ReturnsOkResult_WhenPersonaAdded()
        {
            // Arrange
            var addPersonaDto = new AddPersonaRequestDto
            {
                NombreCompleto = "John Doe",
                Edad = 30,
                Domicilio = "123 Main St",
                Telefono = "555-5555",
                Profesion = "Developer"
            };
            var persona = new PersonaDto
            {
                Id = 1,
                NombreCompleto = "John Doe",
                Edad = 30,
                Domicilio = "123 Main St",
                Telefono = "555-5555",
                Profesion = "Developer"
            };
            _servicePersonaMock.Setup(s => s.AddPersonaAsync(It.IsAny<AddPersonaRequestDto>()))
                               .ReturnsAsync(persona);

            // Act
            var result = await _controller.Add(addPersonaDto.NombreCompleto, addPersonaDto.Edad, addPersonaDto.Domicilio, addPersonaDto.Telefono, addPersonaDto.Profesion);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<PersonaDto>(okResult.Value);
            Assert.Equal(persona.Id, returnValue.Id);
            Assert.Equal(persona.NombreCompleto, returnValue.NombreCompleto);
            Assert.Equal(persona.Edad, returnValue.Edad);
            Assert.Equal(persona.Domicilio, returnValue.Domicilio);
            Assert.Equal(persona.Telefono, returnValue.Telefono);
            Assert.Equal(persona.Profesion, returnValue.Profesion);
        }

        [Fact]
        public async Task Add_ReturnsBadRequest_WhenMissingRequiredField()
        {
            // Arrange
            var addPersonaDto = new AddPersonaRequestDto { NombreCompleto = "", Edad = 30 }; // NombreCompleto vacío
            
            // Act
            var result = await _controller.Add(addPersonaDto.NombreCompleto, addPersonaDto.Edad, addPersonaDto.Domicilio, addPersonaDto.Telefono, addPersonaDto.Profesion);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("El campo NombreCompleto es obligatorio.", badRequestResult.Value);
        }
        #endregion

        #region Error Handling Tests
        [Fact]
        public async Task Add_ReturnsInternalServerError_WhenServiceFails()
        {
            // Arrange
            var addPersonaDto = new AddPersonaRequestDto { NombreCompleto = "John Doe", Edad = 30 };
            _servicePersonaMock.Setup(s => s.AddPersonaAsync(It.IsAny<AddPersonaRequestDto>()))
                                .ThrowsAsync(new Exception("Error interno"));

            // Act
            var result = await _controller.Add(addPersonaDto.NombreCompleto, addPersonaDto.Edad, addPersonaDto.Domicilio, addPersonaDto.Telefono, addPersonaDto.Profesion);

            // Assert
            var errorResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, errorResult.StatusCode);
            Assert.Equal("Error interno", errorResult.Value);
        }
        #endregion

        #region Update Tests
        [Fact]
        public async Task Update_ReturnsOkResult_WhenPersonaUpdated()
        {
            // Arrange
            var updatePersonaDto = new UpdatePersonaRequestDto
            {
                Id = 1,
                NombreCompleto = "John Doe",
                Edad = 30,
                Domicilio = "123 Main St",
                Telefono = "555-5555",
                Profesion = "Developer"
            };
            var persona = new PersonaDto
            {
                Id = 1,
                NombreCompleto = "John Doe",
                Edad = 30,
                Domicilio = "123 Main St",
                Telefono = "555-5555",
                Profesion = "Developer"
            };
            _servicePersonaMock.Setup(s => s.UpdatePersonaAsync(It.IsAny<UpdatePersonaRequestDto>()))
                               .ReturnsAsync(persona);

            // Act
            var result = await _controller.Update(updatePersonaDto.Id, updatePersonaDto.NombreCompleto, updatePersonaDto.Edad, updatePersonaDto.Domicilio, updatePersonaDto.Telefono, updatePersonaDto.Profesion);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<PersonaDto>(okResult.Value);
            Assert.Equal(persona.Id, returnValue.Id);
            Assert.Equal(persona.NombreCompleto, returnValue.NombreCompleto);
            Assert.Equal(persona.Edad, returnValue.Edad);
            Assert.Equal(persona.Domicilio, returnValue.Domicilio);
            Assert.Equal(persona.Telefono, returnValue.Telefono);
            Assert.Equal(persona.Profesion, returnValue.Profesion);
        }

        [Fact]
        public async Task Update_ReturnsBadRequest_WhenNoChangesDetected()
        {
            // Arrange
            var updatePersonaDto = new UpdatePersonaRequestDto
            {
                Id = 1,
                NombreCompleto = "John Doe",
                Edad = 30,
                Domicilio = "123 Main St",
                Telefono = "555-5555",
                Profesion = "Developer"
            };
            _servicePersonaMock.Setup(s => s.UpdatePersonaAsync(It.IsAny<UpdatePersonaRequestDto>()))
                               .ReturnsAsync((PersonaDto?)null);

            // Act
            var result = await _controller.Update(updatePersonaDto.Id, updatePersonaDto.NombreCompleto, updatePersonaDto.Edad, updatePersonaDto.Domicilio, updatePersonaDto.Telefono, updatePersonaDto.Profesion);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("No se detectaron cambios.", badRequestResult.Value);
        }
        #endregion
    }
}


