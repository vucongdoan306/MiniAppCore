namespace MiniApp.DL.InterfaceConnect.Transaction;

using System.Data;
using MongoDB.Driver;

public interface ITransactionService
{
    public void BeginTransaction();
    public void Commit();
    public void Rollback();

    public void Dispose();

    public IDbConnection GetConnection();

}
