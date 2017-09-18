using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using ProductsBLL;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using ProductsApi.App_Start.IOC;

namespace ProductsApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel, true));

            container.Register(Component.For<IProductsCalculator>().ImplementedBy<ProductsCalculator>().LifestyleSingleton());
            container.Register(Component.For<IProductsLog>().ImplementedBy<ProductsLog>().LifestyleSingleton());
            container.Register(Component.For<IProductCreateUpdate>().ImplementedBy<ProductCreateUpdate>().LifestyleSingleton());
            container.Register(
                Classes
                    .FromThisAssembly()
                    .BasedOn<ApiController>()
                    .LifestyleScoped()
                );
            var dependencyResolver = new WindsorDependencyResolver(container.Kernel);

            GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;




            config.EnableCors();
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
