using BLL.Requests.ValuesRequest;
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


builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IRequestHandler<ValueRequest, ValueResponse>, ValuesRequestHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.UseCustomExceptionHandler();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
