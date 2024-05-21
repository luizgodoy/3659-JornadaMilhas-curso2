using JornadaMilhas.Dados;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Test.Integracao
{
    public class ContextoFixture
    {
        public JornadaMilhasContext _context { get; set; }
        public ContextoFixture()
        {
            var options = new DbContextOptionsBuilder<JornadaMilhasContext>()
              .UseSqlServer("Data Source=PC-DELL-01,49172\\SQLEXPRESS01;Initial Catalog=JornadaMilhas;Integrated Security=False;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;User ID=desenv;Password=desenv;")
              .Options;

            _context = new JornadaMilhasContext(options);
        }
    }
}