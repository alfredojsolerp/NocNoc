using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Alfredo.NocNoc.GlasClient
{
	public class NocNocGlasClientModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			context.Services.AddTransient<IGlasApiClient, GlasApiClient>();
		}
	}
}
