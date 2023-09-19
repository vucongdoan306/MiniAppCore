using Microsoft.Extensions.DependencyInjection;
using MiniApp.DL.Connect.MongoDb.Transaction;
using MiniApp.DL.Connect.MySql.Transaction;
using MiniApp.DL.Factory.Interface;
using MiniApp.DL.InterfaceConnect.Transaction;

namespace MiniApp.DL.Factory.Transaction;

public class TransactionFactory : ITransactionFactory
{
    private readonly IServiceProvider _serviceProvider;

    public TransactionFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ITransactionService Create(string databaseType)
    {
        switch (databaseType)
        {
            case "MySql":
                return _serviceProvider.GetRequiredService<MySqlTransactionService>();
            case "MongoDB":
                return _serviceProvider.GetRequiredService<MongoTransactionService>();
            default:
                throw new NotSupportedException($"Database type '{databaseType}' is not supported.");
        }
    }
}
