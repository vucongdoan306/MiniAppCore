using MiniApp.BL.Interface;
using MiniApp.BL.Service;
using MiniApp.DL.Connect.MySql.Transaction;
using MiniApp.DL.Factory.Interface;
using MiniApp.DL.Factory.Transaction;
using MiniApp.DL.Interface;
using MiniApp.DL.InterfaceConnect.Transaction;
using MiniApp.DL.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ITransactionFactory, TransactionFactory>();


// Add services to the container.
builder.Services.AddScoped<IUsers, UserDAL>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    // Bắt đầu giao dịch
    var transactionService = context.RequestServices.GetRequiredService<ITransactionService>();
    transactionService.BeginTransaction();

    // Chuyển quyền kiểm soát đến middleware tiếp theo trong pipeline
    await next();

    // Commit giao dịch nếu mọi thứ thành công
    transactionService.Commit();
});

app.MapControllers();

app.Run();
