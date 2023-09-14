namespace MiniApp.DL.InterfaceConnect.MongoDb.Transaction;

public interface ITransactionService
{
    public IMongoDatabase GetDatabase(string databaseName);

    public void StartTransaction();
    public void CommitTransaction();
    public void AbortTransaction();

    public void Dispose();

}
