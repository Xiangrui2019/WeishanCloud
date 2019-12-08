using Microsoft.AspNetCore.Builder;

namespace WeishanCloud.Library.Extensions
{
    public static class WeishanDefault
    {
        public static IApplicationBuilder UseWeishanDefault(this IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            return app;
        }
    }
}