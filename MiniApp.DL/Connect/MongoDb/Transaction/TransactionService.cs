using Microsoft.Extensions.Configuration;
using MiniApp.DL.InterfaceConnect.MongoDb.Transaction;
using MongoDB.Driver;
using System.Net.WebSockets;

namespace MiniApp.DL.Connect.MongoDb.Transaction;
public class TransactionService : IDisposable, ITransactionService
{
    private readonly IMongoClient _client;
    private readonly IClientSessionHandle _session;
    protected string _connectionString = "";
    protected string _databaseName = "";

    public TransactionService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Mongo") ?? "";
        _databaseName = configuration.GetSection("DatabaseName")["MiniApp"] ?? "";
        var settings = MongoClientSettings.FromConnectionString(_connectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        _client = new MongoClient(settings);

        _session = _client.StartSession();
    }

    public IMongoDatabase GetDatabase()
    {
        return _client.GetDatabase(_databaseName);
    }

    public void StartTransaction()
    {
        _session.StartTransaction();
    }

    public void CommitTransaction()
    {
        _session.CommitTransaction();
    }

    public void AbortTransaction()
    {
        _session.AbortTransaction();
    }

    public void Dispose()
    {
        _session.Dispose();
        //_client.Dispose();
    }

    public void ExcuteTransaction(Action<IMongoDatabase> action)
    {
        using (var session = _client.StartSession())
        {
            session.StartTransaction();
            try
            {
                action(GetDatabase());
                session.CommitTransaction();
            }
            catch (Exception)
            {
                session.AbortTransaction();
                throw;
            }
        }
    }
}