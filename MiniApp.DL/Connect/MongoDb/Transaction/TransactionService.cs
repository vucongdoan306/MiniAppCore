
using System;
using MongoDB.Driver;
namespace MiniApp.DL.Connect.MongoDb.Transaction;
public class TransactionService 
{
    private readonly IMongoClient _client;
    private readonly IClientSessionHandle _session;

    public TransactionService(string connectionString)
    {
        _client = new MongoClient(connectionString);
        _session = _client.StartSession();
    }

    public IMongoDatabase GetDatabase(string databaseName)
    {
        return _client.GetDatabase(databaseName);
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
        _client.Dispose();
    }
}