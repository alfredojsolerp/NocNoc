
namespace Alfredo.NocNoc.GlasApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllers();
			builder.Services.AddOpenApi();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.MapOpenApi();
			}

			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.UseSwagger();
			app.UseSwaggerUI();

			app.Use(async (context, next) =>
			{
				if (context.Request.Path == "/")
				{
					context.Response.Redirect("/swagger/index.html");
					return;
				}

				await next();
			});

			app.MapControllers();
			app.Run();
		}
	}
}
