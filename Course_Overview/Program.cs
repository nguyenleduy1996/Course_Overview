using Course_Overview.Areas.Admin.Repository;
using Course_Overview.Areas.Admin.Service;
using Course_Overview.Data;
using LModels.Client;
using LModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Course_Overview.Mail;
using Course_Overview.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectDB"));
});

builder.Services.AddScoped<IUserRepository, UserService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<ICourserRepository, CourseService>();
builder.Services.AddScoped<ITopicRepository, TopicService>();
builder.Services.AddScoped<ITeacherRepository, TeacherService>();
builder.Services.AddScoped<IStudentRepository, StudentService>();
builder.Services.AddScoped<IClassRepository, ClassService>();
builder.Services.AddScoped<IFAQRepository, FAQService>();
builder.Services.AddScoped<IContactRepository, ContactService>();
builder.Services.AddScoped<IAboutRepository, AboutService>();
// Đăng ký IPasswordHasher<User>
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// Phần login 
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

//Đăng ký Service Email
builder.Services.Configure<EmailSetting>(builder.Configuration.GetSection("EmailSetting"));
builder.Services.AddTransient<EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}



// Cấu hình để phục vụ tệp tĩnh từ thư mục Upload
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Upload")),
    RequestPath = "/Upload"
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
	name: "areas",
	pattern: "{area:exists}/{controller=Auth}/{action=Login}/{id?}"
);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
