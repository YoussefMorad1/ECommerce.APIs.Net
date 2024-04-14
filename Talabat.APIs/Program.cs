
using Microsoft.EntityFrameworkCore;
using Talabat.Repository.Data;

namespace Talabat.APIs;

public class Program
{
	public static void Main(string[] args)
	{
		#region Configure Services 
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddDbContext<StoreContext>(options =>
		{
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
		}); 
		#endregion

		var app = builder.Build();

		#region Update Database (Apply All migrations, if found)
		using var scope = app.Services.CreateScope();
		var services = scope.ServiceProvider;
		var context = services.GetRequiredService<StoreContext>();
		var loggerFactory = services.GetRequiredService<ILoggerFactory>();
		try 
		{ 
			context.Database.Migrate();
		}
		catch (Exception ex)
		{
			var logger = loggerFactory.CreateLogger<Program>();
			logger.LogError(ex, "An error occurred during migration");
		}
		#endregion

		#region Configure Pipelines
		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();


		app.MapControllers(); 
		#endregion

		app.Run();
	}
}
