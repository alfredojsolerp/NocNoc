using Microsoft.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace Alfredo.NocNoc.EntityFrameworkCore;

public static class NocNocEfCoreEntityExtensionMappings
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        NocNocGlobalFeatureConfigurator.Configure();
        NocNocModuleExtensionConfigurator.Configure();

        OneTimeRunner.Run(() =>
        {
                /* You can configure extra properties for the
                 * entities defined in the modules used by your application.
                 *
                 * This class can be used to map these extra properties to table fields in the database.
                 *
                 * USE THIS CLASS ONLY TO CONFIGURE EF CORE RELATED MAPPING.
                 * USE NocNocModuleExtensionConfigurator CLASS (in the Domain.Shared project)
                 * FOR A HIGH LEVEL API TO DEFINE EXTRA PROPERTIES TO ENTITIES OF THE USED MODULES
                 *
                 * Example: Map a property to a table field:

                     ObjectExtensionManager.Instance
                         .MapEfCoreProperty<IdentityUser, string>(
                             "MyProperty",
                             (entityBuilder, propertyBuilder) =>
                             {
                                 propertyBuilder.HasMaxLength(128);
                             }
                         );

                 * See the documentation for more:
                 * https://docs.abp.io/en/abp/latest/Customizing-Application-Modules-Extending-Entities
                 */
        });
    }
}
