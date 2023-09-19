using Microsoft.Extensions.Configuration;
using MiniApp.Common.Model;
using MiniApp.DL.Factory.Interface;
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

        public UserDAL(IConfiguration configuration,ITransactionFactory transactionFactory){
            _transactionService = transactionFactory.Create(configuration.GetSection("DatabaseType")["DatabaseCommont"]??"");
        }

        public Users GetUserById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
