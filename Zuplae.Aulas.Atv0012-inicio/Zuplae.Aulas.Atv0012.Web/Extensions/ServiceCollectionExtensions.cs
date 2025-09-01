using Zuplae.Aulas.Atv0012.Models;
using Zuplae.Aulas.Atv0012.Servics;

namespace Zuplae.Aulas.Atv0012.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IService<Endereco>, EnderecoService>();
            services.AddScoped<IService<Fornecedor>, FornecedorService>();
            services.AddScoped<IService<Produto>, ProdutoService>();
            services.AddScoped<IService<Usuario>, UsuarioService>();

            services.AddScoped<EnderecoService>();
            services.AddScoped<FornecedorService>();
            services.AddScoped<ProdutoService>();
            services.AddScoped<UsuarioService>();
        }
    }
}
