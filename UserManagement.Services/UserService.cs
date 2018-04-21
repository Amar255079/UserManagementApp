using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManagement.Domain;
using UserManagement.Data;
using UserManagement.Data.Infrastructure;

namespace UserManagement.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void CreateUser(User user);
        void DeleteUser(int id);
        void SaveUser();
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }  
        #region IUserService Members

        public IEnumerable<User> GetUsers()
        {
            var categories = userRepository.GetAll();
            return categories;
        }

        public User GetUser(int id)
        {
            var user = userRepository.GetById(id);
            return user;
        }

        public void CreateUser(User user)
        {
            userRepository.Add(user);
            SaveUser();
        }

        public void DeleteUser(int id)
        {
            var user = userRepository.GetById(id);
            userRepository.Delete(user);
            SaveUser();
        }

        public void SaveUser()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
