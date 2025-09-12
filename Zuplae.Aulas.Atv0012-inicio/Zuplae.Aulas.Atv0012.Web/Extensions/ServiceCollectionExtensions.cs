using Zuplae.Aulas.Atv0012.Models;
using Zuplae.Aulas.Atv0012.Servics;
using Zuplae.Aulas.Atv0012.UserAccess;
using Zuplae.Aulas.Atv0012.Web.Helper;


namespace Zuplae.Aulas.Atv0012.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            // Registra os serviços pelas interfaces (injeção mais flexível e testável)
            services.AddScoped<IService<Endereco>, EnderecoService>();
            services.AddScoped<IService<Fornecedor>, FornecedorService>();
            services.AddScoped<IService<Produto>, ProdutoService>();
            services.AddScoped<IService<Usuario>, UsuarioService>();

            services.AddScoped<EnderecoService>();
            services.AddScoped<FornecedorService>();
            services.AddScoped<ProdutoService>();
            services.AddScoped<UsuarioService>();


            // HttpContext e Sessão
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ISessao, Sessao>();
            services.AddScoped<IEmail, Email>();
            services.AddSession(options =>
            {
                
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            

        }
    }
}
