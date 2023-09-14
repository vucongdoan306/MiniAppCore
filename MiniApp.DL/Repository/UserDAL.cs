using MiniApp.Common.Model;
using MiniApp.DL.Interface;
using MiniApp.DL.InterfaceConnect.MongoDb.Transaction;
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
        private ITransactionService _transactionService;

        public UserDAL(ITransactionService _service)
        {
            _transactionService = _service;
        }

        public Users GetUserById(string id)
        {
            Users users = new Users();
            _transactionService.ExcuteTransaction(database =>
            {
                var collection = database.GetCollection<Users>("User");
                var filter = Builders<Users>.Filter.Eq("UserId", id);
                users = collection.Find(filter).FirstOrDefault();
            });


            return users;
        }
    }
}
