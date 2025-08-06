using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietP.Core.Entities;

namespace DietP.Core.Repositories
{
    public partial interface IDataRepository
    {
        Task<List<User>?> GetAllUsers();
        Task<User?> GetUser(int id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser (int id);
    }
}
