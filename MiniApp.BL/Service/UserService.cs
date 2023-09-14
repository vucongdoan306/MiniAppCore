using MiniApp.BL.Interface;
using MiniApp.Common.Model;
using MiniApp.DL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniApp.BL.Service
{
    public class UserService : IUserService
    {
        IUsers _repo;
        public UserService(IUsers repo)
        {
            _repo = repo;
        }

        public Users GetUserById(string id)
        {
            return _repo.GetUserById(id);
        }
    }
}
