using Bogus;
using JornadaMilhas.Dados;
using JornadaMilhasV1.Modelos;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Test.Integracao
{
    public class ContextoFixture // : IAsyncLifetime
    {
        public JornadaMilhasContext _context { get; set; }

        public ContextoFixture()
        {
            var options = new DbContextOptionsBuilder<JornadaMilhasContext>()
              .UseSqlServer("Data Source=PC-DELL-01,49172\\SQLEXPRESS01;Initial Catalog=JornadaMilhas;Integrated Security=False;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;User ID=desenv;Password=desenv;")
              .Options;

            _context = new JornadaMilhasContext(options);
        }       

        public async Task LimpaDadosDoBanco()
        {
            _context.Database.ExecuteSqlRaw("DELETE FROM OfertasViagem");
            _context.Database.ExecuteSqlRaw("DELETE FROM Rotas");
        }

        public void CriaDadosFake()
        {
            Periodo periodo = new PeriodoDataBuilder().Build();

            var rota = new Rota("Curitiba", "São Paulo");

            var fakerOferta = new Faker<OfertaViagem>()
                .CustomInstantiator(f => new OfertaViagem(
                    rota,
                    new PeriodoDataBuilder().Build(),
                    100 * f.Random.Int(1, 100))
                )
                .RuleFor(o => o.Desconto, f => 40)
                .RuleFor(o => o.Ativa, f => true);

            var lista = fakerOferta.Generate(200);
            _context.OfertasViagem.AddRange(lista);
            _context.SaveChanges();
        }
    }
}