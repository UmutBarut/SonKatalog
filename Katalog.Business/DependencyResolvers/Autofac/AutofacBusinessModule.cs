using Autofac;
using Autofac.Extras.DynamicProxy;
using Katalog.Core.Utilities.Interceptors;
using Katalog.Dataaccess.Abstracts;
using Katalog.Dataaccess.Concrete;
using Castle.DynamicProxy;
using Katalog.Business.Concrete;
using Katalog.Business.Abstracts;
using Katalog.Core.Utilities.Helpers.File;

namespace Katalog.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FirmaManager>().As<IFirmaService>().SingleInstance();
            builder.RegisterType<FirmaDal>().As<IFirmaDal>().SingleInstance();

            builder.RegisterType<KullanilanParcaManager>().As<IKullanilanParcaService>().SingleInstance();
            builder.RegisterType<KullanilanParcaDal>().As<IKullanilanParcaDal>().SingleInstance();

            builder.RegisterType<MarkaManager>().As<IMarkaService>().SingleInstance();
            builder.RegisterType<MarkaDal>().As<IMarkaDal>().SingleInstance();

            builder.RegisterType<ModelManager>().As<IModelService>().SingleInstance();
            builder.RegisterType<ModelDal>().As<IModelDal>().SingleInstance();

            builder.RegisterType<OEMManager>().As<IOEMService>().SingleInstance();
            builder.RegisterType<OEMDal>().As<IOEMDal>().SingleInstance();

            builder.RegisterType<ReferansManager>().As<IReferansService>().SingleInstance();
            builder.RegisterType<ReferansDal>().As<IReferansDal>().SingleInstance();

            builder.RegisterType<TipManager>().As<ITipService>().SingleInstance();
            builder.RegisterType<TipDal>().As<ITipDal>().SingleInstance();

            builder.RegisterType<Urun_ArabaManager>().As<IUrun_ArabaService>().SingleInstance();
            builder.RegisterType<Urun_ArabaDal>().As<IUrun_ArabaDal>().SingleInstance();

            builder.RegisterType<UrunManager>().As<IUrunService>().SingleInstance();
            builder.RegisterType<UrunDal>().As<IUrunDal>().SingleInstance();

            builder.RegisterType<UyumlulukManager>().As<IUyumlulukService>().SingleInstance();
            builder.RegisterType<UyumlulukDal>().As<IUyumlulukDal>().SingleInstance();

            builder.RegisterType<FileManager>().As<IFileService>().SingleInstance();
            builder.RegisterType<FileHelper>().As<IFileHelper>().SingleInstance();
            

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            });
        }
    }
}