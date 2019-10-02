namespace OnlineShop.Infrastructure
{
	//public class AutoMapperNinjectModule : NinjectModule
	//{
	//public override void Load()
	//{
	//	Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();
	//}

	//private IMapper AutoMapper(Ninject.Activation.IContext context)
	//{
	//	Mapper.Initialize(config =>
	//	{
	//		config.ConstructServicesUsing(type => context.Kernel.GetType());

	//		config.AddProfile(new BllMappingConfig());
	//		config.AddProfile(new UnitOfWorkMappingConfig());
	//		config.AddProfile(new WebApiMappingConfig());
	//	});

	//	Mapper.AssertConfigurationIsValid(); // optional
	//	return Mapper.Instance;
	//}
	//}
}