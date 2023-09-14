using MiniApp.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniApp.DL.Interface
{
    public interface IUsers
    {
        public Users GetUserById(string id);

    }
}
