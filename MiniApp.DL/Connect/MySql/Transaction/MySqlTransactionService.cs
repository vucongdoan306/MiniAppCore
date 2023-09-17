using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using MiniApp.DL.InterfaceConnect.MongoDb.Transaction;
using MongoDB.Driver;
using MySqlConnector;

public class MySqlTransactionService : IDisposable, ITransactionService
{
    private IDbConnection _connection;
    private IDbTransaction _transaction;

    public MySqlTransactionService(string connectionString)
    {
        _connection = new MySqlConnection(connectionString);
        _connection.Open();
        _transaction = _connection.BeginTransaction();
    }

    public IDbConnection Connection => _connection;

    public IDbTransaction Transaction => _transaction;

    public void CommitTransaction()
    {
        try
        {
            _transaction.Commit();
        }
        catch
        {
            _transaction.Rollback();
            throw;
        }
        finally
        {
            _transaction.Dispose();
            _connection.Close();
            _connection.Dispose();
        }
    }

    public void Rollback()
    {
        _transaction.Rollback();
        _transaction.Dispose();
        _connection.Close();
        _connection.Dispose();
    }

    public void Dispose()
    {
        if (_transaction != null)
        {
            _transaction.Dispose();
        }

        if (_connection != null && _connection.State != ConnectionState.Closed)
        {
            _connection.Close();
        }

        if (_connection != null)
        {
            _connection.Dispose();
        }
    }

    public IMongoDatabase GetDatabase()
    {
        throw new NotImplementedException();
    }

    public void StartTransaction()
    {
        throw new NotImplementedException();
    }

    public void AbortTransaction()
    {
        throw new NotImplementedException();
    }

    public void ExcuteTransaction(Action<IMongoDatabase> action)
    {
        throw new NotImplementedException();
    }
}
