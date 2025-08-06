using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietP.Core.Entities;
using DietP.Core.Repositories;
using DietP.Core.Services;

namespace DietP.Service.Services
{
    public class UserService: IUserService
    {
        private readonly IDataRepository _dataRepository;
        public UserService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public async Task<List<User>?> GetAllUsers()
        {
            return await _dataRepository.GetAllUsers();
        }
        public async Task<User?> login(string email, string password)
        {
            var allUsers = await _dataRepository.GetAllUsers();
            if (allUsers == null)
            {
                throw new Exception("The list is null!");
            }
            User? user = allUsers.FirstOrDefault(user => user.Email == email && user.Password == password);
            if (user == null)
            {
                throw new Exception("User not found!");
            }
            return user;
        }
        public async Task<User> register(User newUser)
        {
            var allUser = await _dataRepository.GetAllUsers();
            User? isUser = allUser.FirstOrDefault(user => user.Email == newUser.Email);
            if (isUser != null)
                throw new Exception("this user is already exist!");
            return await _dataRepository.AddUser(newUser);
        }

        public async Task<User> UpdateUser(string firstName, string lastName, string email, string password, int calPerDay, float bmi
            ,float weight, float wishWeight, float height, int daysForDiet,
            string newFirstName, string newLastName, string newEmail, string newPassword, int newCalPerDay, float newBmi
            , float newWeight, float newWishWeight, float newHeight, int newDaysForDiet)
        {
            var allUsers = await _dataRepository.GetAllUsers();
            if (allUsers == null)
            {
                throw new Exception("The list is null!");
            }
            User? user = allUsers.FirstOrDefault(user =>
                                                user.FirstName == firstName &&
                                                user.LastName == lastName &&
                                                user.Email == email &&
                                                user.Password == password &&
                                                user.Weight == weight &&
                                                user.WishWeight == wishWeight &&
                                                user.Height == height &&
                                                user.DaysForDiet == daysForDiet);
            if(user == null)
            {
                throw new Exception("The user not found");
            }
            user.FirstName = newFirstName;
            user.LastName = newLastName;
            user.Email = newEmail;
            user.Password = newPassword;
            user.Weight = newWeight;
            user.WishWeight = newWishWeight;
            user.Height = newHeight;
            user.DaysForDiet = newDaysForDiet;
            return await _dataRepository.UpdateUser(user);
        }

        public async Task<User> DeleteUser(string password, string email)
        {
            var allUsers = await _dataRepository.GetAllUsers();
            if (allUsers == null)
            {
                throw new Exception("The list is null!");
            }
            User? user = allUsers.FirstOrDefault(user => user.Email == email && user.Password == password);
            if (user == null)
            {
                throw new Exception("The user is not found!");
            }


            return await _dataRepository.DeleteUser(user.Id);
        }
    }
}


