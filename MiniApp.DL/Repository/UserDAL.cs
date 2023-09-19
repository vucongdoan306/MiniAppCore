using MiniApp.Common.Model;
using MiniApp.DL.Interface;
using MiniApp.DL.InterfaceConnect.Transaction;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniApp.DL.Repository
{
    public class UserDAL : IUsers
    {
        private readonly ITransactionService _transactionService;

        public UserDAL(ITransactionService transactionService){
            _transactionService = transactionService;
        }

        public Users GetUserById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
