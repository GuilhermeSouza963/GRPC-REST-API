using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using TccDev.Application.Services;
using TccDev.Data.Bancos.SQL.Repositories;
using TccDev.Domain.Interfaces.Repositories;
using TccDev.Domain.Interfaces.Services;

namespace TccDev.Hosting
{
    public class DependenceInjectionConfig
    {
        private static Container _container;
        private static Lifestyle _lifestyle;
        public static Container GetContainer()
        {
            return _container;
        }
        public static Container CreateInstance(Lifestyle lifestyle)
        {
            _lifestyle = lifestyle;
            _container = new Container();
            return _container;
        }

        public static void Config()
        {

            _container.Register(typeof(IProdutoService), typeof(ProdutoService), _lifestyle);
            _container.Register(typeof(IProdutoRepository), typeof(ProdutoRepository), _lifestyle);
        }

        public static void IntegrateSimpleInjector(IServiceCollection services)
        {
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(_container));
            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(_container));

            services.EnableSimpleInjectorCrossWiring(_container);
            services.UseSimpleInjectorAspNetRequestScoping(_container);
        }
    }
}
