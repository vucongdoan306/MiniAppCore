using MiniApp.DL.InterfaceConnect.Transaction;

namespace MiniApp.DL.Factory.Interface;

public interface ITransactionFactory
{
    ITransactionService Create(string databaseType);
}
