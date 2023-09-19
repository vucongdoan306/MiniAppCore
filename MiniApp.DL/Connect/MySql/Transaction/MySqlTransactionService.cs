using System;
using System.Data;
namespace MiniApp.DL.Connect.MySql.Transaction;

using Microsoft.Extensions.Configuration;
using MiniApp.DL.InterfaceConnect.Transaction;
using MySqlConnector;

public class MySqlTransactionService : ITransactionService
{
    private MySqlConnection _connection;
    private MySqlTransaction? _transaction = null;

    private string _connectionString = "";
    
    private bool _disposed = false;

    public MySqlTransactionService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString(configuration.GetSection("DatabaseType")["DatabaseCommon"]??"") ?? "";
        _connection = new MySqlConnection(_connectionString);
    }

    public IDbConnection GetConnection()
    {
        if (_connection.State == ConnectionState.Closed)
            _connection.Open();

        return _connection;
    }

    public void BeginTransaction()
    {
        
        if (_connection.State == ConnectionState.Closed)
        {
            _connection.Open();
        }

        _transaction = _connection.BeginTransaction();
    }

    public void Commit()
    {
        _transaction?.Commit();
    }

    public void Rollback()
    {
        _transaction?.Rollback();
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _transaction?.Dispose();
            _connection?.Dispose();
            _disposed = true;
        }
    }
}
