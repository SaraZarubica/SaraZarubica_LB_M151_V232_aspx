﻿using BusinessLayer.Utils;
using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public class UserRepository
    {
        DataContext dbContext;

        public UserRepository()
        {
            dbContext = new DataContext();
        }

        public List<Question> GetAllQuestions(int userId)
        {
            List<Question> list = dbContext.Questions.Where(x => x.UserId == userId).ToList();

            return list;
        }

        public bool Register(string userName, string password, Roll roll)
        {
            byte[] salt = PasswordHelper.GetSalt(128); // salt generieren
            byte[] passwordSalted = PasswordHelper.GenerateSaltedHash(StringUtils.GetByteArray(password), salt); //pw to bytearray, pw byte array mit salt hashen
            User user = new User() { Password = passwordSalted, Salt = salt, Username = userName, Roll = roll }; // salted pw wird gespeichert
            if(dbContext.Users.Where(x => x.Username.ToLower() == userName.ToLower()).FirstOrDefault() == null)
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public User GetUserByUserName(string userName)
        {
            User u = dbContext.Users.Where(x => x.Username.ToLower() == userName.ToLower()).FirstOrDefault();
            return u;
        }

        public bool Login(string userName, string password)
        {
            bool result = false;
            User u = GetUserByUserName(userName);
            if(u != null)
            {
                byte[] typedPw = PasswordHelper.GenerateSaltedHash(StringUtils.GetByteArray(password), u.Salt); // eingegebenes pw beim login wird mit dem salt (der in der DB ist) gehasht
                result = PasswordHelper.CompareByteArrays(u.Password, typedPw); // pw der datenbank (schon beim registrieren gesalthashed) wird mit dem jetzigen hash verglichen, falls gleich user eingeloggt
            }
           
            return result;
        }
    }
}
