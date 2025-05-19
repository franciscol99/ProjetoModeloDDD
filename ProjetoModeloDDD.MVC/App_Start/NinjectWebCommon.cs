[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ProjetoModeloDDD.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ProjetoModeloDDD.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace ProjetoModeloDDD.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using ProjetoModeloDDD.Application;
    using ProjetoModeloDDD.Application.Interface;
    using ProjetoModeloDDD.Domain.Interfaces;
    using ProjetoModeloDDD.Domain.Interfaces.Services;
    using ProjetoModeloDDD.Domain.Services;
    using ProjetoModeloDDD.Infra.Data.Repositories;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IProdutoAppService>().To<ProdutoAppService>();
            kernel.Bind<ILivroAppService>().To<LivroAppService>();
            kernel.Bind<IAnimalAppService>().To<AnimalAppService>();
            kernel.Bind<IMusicaAppService>().To<MusicaAppService>();
            kernel.Bind<ICarroAppService>().To<CarroAppService>();
            kernel.Bind<IFabricanteAppService>().To<FabricanteAppService>();
            kernel.Bind<IRegistroCompraAppService>().To<RegistroCompraAppService>();
            kernel.Bind<IAgendaAppService>().To<AgendaAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IProdutoService>().To<ProdutoService>();
            kernel.Bind<ILivroService>().To<LivroService>();
            kernel.Bind<IAnimalService>().To<AnimalService>();
            kernel.Bind<IMusicaService>().To<MusicaService>();
            kernel.Bind<ICarroService>().To<CarroService>();
            kernel.Bind<IFabricanteService>().To<FabricanteService>();
            kernel.Bind<IRegistroCompraService>().To<RegistroCompraService>();
            kernel.Bind<IAgendaService>().To<AgendaService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();
            kernel.Bind<ILivroRepository>().To<LivroRepository>();
            kernel.Bind<IAnimalRepository>().To<AnimalRepository>();
            kernel.Bind<IMusicaRepository>().To<MusicaRepository>();
            kernel.Bind<ICarroRepository>().To<CarroRepository>();
            kernel.Bind<IFabricanteRepository>().To<FabricanteRepository>();
            kernel.Bind<IRegistroCompraRepository>().To<RegistroCompraRepository>();
            kernel.Bind<IAgendaRepository>().To<AgendaRepository>();
        }
    }
}