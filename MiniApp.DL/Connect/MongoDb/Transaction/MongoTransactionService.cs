using Microsoft.Extensions.Configuration;
using MiniApp.DL.InterfaceConnect.Transaction;
using MongoDB.Driver;
using System.Data;
using System.Net.WebSockets;

namespace MiniApp.DL.Connect.MongoDb.Transaction;
public class MongoTransactionService : ITransactionService
{
    private readonly IMongoClient _client;
    private readonly IClientSessionHandle _session;

    public MongoTransactionService(string connectionString)
    {
        _client = new MongoClient(connectionString);
        _session = _client.StartSession();
    }

    public IDbConnection GetConnection()
    {
        throw new NotSupportedException("MongoDB does not use ADO.NET connections.");
    }

    public void BeginTransaction()
    {
        _session.StartTransaction();
    }

    public void Commit()
    {
        _session.CommitTransaction();
    }

    public void Rollback()
    {
        _session.AbortTransaction();
    }

    public void Dispose()
    {
        _session?.Dispose();
    }
}