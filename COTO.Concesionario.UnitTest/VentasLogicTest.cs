using Moq;
using COTO.Concesionario.Interfaces.Access;
using COTO.Concesionario.Interfaces.DTO;
using COTO.Concesionario.Interfaces.Request;
using COTO.Concesionario.BusinessLogic;

namespace COTO.Concesionario.UnitTest;

public class VentasLogicTests
{
    private readonly Mock<IVentasAccess> _mockVentasAccess;
    private readonly VentasLogic _ventasLogic;

    /// <summary>
    /// NOTA: se hizo un solo test method por cada metodo de la clase VentasLogic
    /// Se podría mejorar agregando más casos
    /// </summary>
    public VentasLogicTests()
    {
        _mockVentasAccess = new Mock<IVentasAccess>();
        _ventasLogic = new VentasLogic(_mockVentasAccess.Object);
    }

    [Fact]
    public async Task AgregarVenta_CreaVentaCorrectamente()
    {
        // Arrange
        var request = new RequestCrearVenta
        {
            Centro = "Palermo",
            TipoCoche = "Suv"
        };

        var ventaDto = new VentaDTO
        {
            Centro = new CentroDTO("Palermo"),
            Coche = CocheDTO.CrearCoche("Suv")
        };

        _mockVentasAccess
            .Setup(x => x.AgregarVenta(It.IsAny<VentaDTO>()))
            .ReturnsAsync(ventaDto);

        // Act
        var result = await _ventasLogic.AgregarVenta(request);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Palermo", result.Centro.Centro.ToString());
        Assert.Equal("Suv", result.Coche.TipoCoche.ToString());

        _mockVentasAccess.Verify(x => x.AgregarVenta(It.Is<VentaDTO>(
            v => v.Centro.Centro.ToString() == "Palermo" && v.Coche.TipoCoche.ToString() == "Suv"
        )), Times.Once);
    }

    
    [Fact]
    public async Task GetVentas_DevuelveListaDeVentas()
    {
        // Arrange
        var ventas = new List<VentaDTO>
        {
            new VentaDTO { Centro = new CentroDTO("Palermo"), Coche = CocheDTO.CrearCoche("Suv") },
            new VentaDTO { Centro = new CentroDTO("Belgrano"), Coche = CocheDTO.CrearCoche("Sedan") }
        };

        _mockVentasAccess
            .Setup(x => x.GetVentas())
            .ReturnsAsync(ventas);

        // Act
        var result = await _ventasLogic.GetVentas();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    
    [Fact]
    public async Task GetVolumenVentas_DevuelveVolumenVentas()
    {
        // Arrange
        var ventas = new List<VentaDTO>
        {
            new VentaDTO { Centro = new CentroDTO("Palermo"), Coche = CocheDTO.CrearCoche("Suv") },
            new VentaDTO { Centro = new CentroDTO("Belgrano"), Coche = CocheDTO.CrearCoche("Sedan") }
        };

        _mockVentasAccess
            .Setup(x => x.GetVentas())
            .ReturnsAsync(ventas);

        // Act
        var result = await _ventasLogic.GetVolumenVentas();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(ventas.Count, result.Cantidad);
    }

    
    [Fact]
    public async Task GetVolumenVentasPorCentro_DevuelveVolumenesAgrupadosPorCentro()
    {
        // Arrange
        var ventas = new List<VentaDTO>
        {
            new VentaDTO { Centro = new CentroDTO("Palermo"), Coche = CocheDTO.CrearCoche("Suv") },
            new VentaDTO { Centro = new CentroDTO("Palermo"), Coche = CocheDTO.CrearCoche("Sedan") },
            new VentaDTO { Centro = new CentroDTO("Belgrano"), Coche = CocheDTO.CrearCoche("Suv") }
        };

        _mockVentasAccess
            .Setup(x => x.GetVentas())
            .ReturnsAsync(ventas);

        // Act
        var result = await _ventasLogic.GetVolumenVentasPorCentro();

        // Assert
        Assert.NotNull(result);
        Assert.Contains(result, v => v.Contains("Palermo"));
        Assert.Contains(result, v => v.Contains("Belgrano"));
    }

    
    [Fact]
    public async Task GetPorcentajesVentas_DevuelvePorcentajesCorrectos()
    {
        // Arrange
        var ventas = new List<VentaDTO>
        {
            new VentaDTO { Centro = new CentroDTO("Palermo"), Coche = CocheDTO.CrearCoche("Suv") },
            new VentaDTO { Centro = new CentroDTO("Palermo"), Coche = CocheDTO.CrearCoche("Sedan") },
            new VentaDTO { Centro = new CentroDTO("Belgrano"), Coche = CocheDTO.CrearCoche("Suv") }
        };

        _mockVentasAccess
            .Setup(x => x.GetVentas())
            .ReturnsAsync(ventas);

        // Act
        var result = await _ventasLogic.GetPorcentajesVentas();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Contains(result, r => r.Centro.ToString() == "Palermo");
        Assert.Contains(result, r => r.Centro.ToString() == "Belgrano");
    }
}
