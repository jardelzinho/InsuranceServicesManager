using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PaymentService.Init
{
    public static class ApplicationBuilderExtensions
    {
        public static Task UseInitializer(this IApplicationBuilder app)
        {
            return Task.Run(async () =>
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var initializer = scope.ServiceProvider.GetService<DataLoader>();
                    await initializer.Seed();
                }
            });
        }
    }
}
