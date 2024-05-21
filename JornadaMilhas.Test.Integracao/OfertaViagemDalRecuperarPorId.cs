using JornadaMilhas.Dados;
using Xunit.Abstractions;

namespace JornadaMilhas.Test.Integracao;
[Collection(nameof(ContextoCollection))]

public class OfertaViagemDalRecuperarPorId // : IClassFixture<ContextoFixture>
{
    private readonly JornadaMilhasContext context;

    public OfertaViagemDalRecuperarPorId(ITestOutputHelper output, ContextoFixture fixture)
    {
        context = fixture._context;
        output.WriteLine(context.GetHashCode().ToString());
    }

    [Fact]
    public void RetornaNuloQuandoIdInexistente()
    {
        //arrange
        var dal = new OfertaViagemDAL(context);

        //act
        var ofertaRecuperada = dal.RecuperarPorId(-2);

        //assert
        Assert.Null(ofertaRecuperada);
    }
}
