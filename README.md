# VSComMariaDB
 Criar uma API com acesso ao banado de dados MariaDB

 # Passos para criar um projeto API com banco de dados MariaDB
 
1-Instalar Pacotes NuGet
  Pomelo.EntityFrameworkCore.MySql 8.0.0
  Microsoft.EntityFrameworkCore.Tools 8.0.0
 
2-Configurar appsettings.json
  "ConnectionStrings": {
        "MariaDB": "server=localhost;port=3306;user=root;password=SuaSenha;database=NomeDoBD"
    },
 
3-Criar classe _DbContext
 
  public class _DbContext : DbContext
  {
        //public DbSet<TabelaAqui> TabelaAqui { get; set; }
  
        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            IConfigurationRoot Configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json")
            .Build();
  
            var ConnectionString = Configuration.GetConnectionString("MariaDB");
            OptionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
        }
  }
 
 
4-Configurar o serviço no Program.cs
builder.Services.AddDbContext<_DbContext>();
 
5-Criar a primeira migration
add-migration CriarBancoDeDados
 
6-Aplicar migration
update-database
