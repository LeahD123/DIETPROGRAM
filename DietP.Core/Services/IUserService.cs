using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietP.Core.Entities;
using DietP.Core.Repositories;

namespace DietP.Core.Services
{
    public interface IUserService
    {
        Task<List<User>?> GetAllUsers();
        Task<User?> login(string email, string password);

        Task<User> register(User user);


        Task<User> UpdateUser(string firstName, string lastName, string email, string password, int calPerDay, float bmi
            , float weight, float wishWeight, float height, int daysForDiet,
            string newFirstName, string newLastName, string newEmail, string newPassword, int newCalPerDay, float newBmi
            , float newWeight, float newWishWeight, float newHeight, int newDaysForDiet);
        Task<User> DeleteUser(string password, string email);
    }
}
