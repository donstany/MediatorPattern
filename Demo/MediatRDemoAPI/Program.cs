using BLL.Requests.ValuesRequest;
using BLL.Values.Commands.DeleteValueCommand;
using DAL;
using FluentValidation;
using MediatR;
using MediatRDemoAPI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<ValueRequest>, ValueRequestValidator>();

builder.Services.AddValidatorsFromAssemblies(new List<Assembly>() { typeof(DateTime).GetTypeInfo().Assembly });
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidation<,>));
builder.Services.AddTransient<IDatabase, Database>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddTransient<IRequestHandler<ValueRequest, ValueResponse>, ValuesRequestHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteValueCommand, bool>, DeleteValueCommandHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
}

app.UseHsts();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCustomExceptionHandler();

//app.UseSwaggerUI(options =>
//{
//    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
//});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
