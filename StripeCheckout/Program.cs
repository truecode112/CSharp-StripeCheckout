using Stripe;

//StripeConfiguration.ApiKey = "sk_test_51Mj17oEsgEGihK8LsMJeQXV3hiXvuv4B0jErwOlWjqezdw8mKXe1lBkJ0v1ymVN182Zfp5j2fXVMOaxnuIKSSUbH0023y8LLxO";
StripeConfiguration.ApiKey = "sk_test_51OZu2rB944NYs2OOOrrQBMLvz4HqDGU2ZtoBvSCJPBj0ALChlLEiK9oMs9nFVQ9naFZ4xSMM1EjXRpBOpk71uTPk0096NU52lO";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
