namespace MiniApp.DL.InterfaceConnect.MongoDb.Transaction;
using MongoDB.Driver;

public interface ITransactionService
{
    public IMongoDatabase GetDatabase();

    public void StartTransaction();
    public void CommitTransaction();
    public void AbortTransaction();

    public void Dispose();

    public void ExcuteTransaction(Action<IMongoDatabase> action);

}
