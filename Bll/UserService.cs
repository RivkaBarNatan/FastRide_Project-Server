using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using DAL;
using MongoDB.Driver;
using AutoMapper;

namespace BL
{
    public class UserService
    {
        private readonly IMongoCollection<User> family;
        private readonly IMapper mapper;
        public UserService(IDatabaseSettings settings, IMapper map)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            family = database.GetCollection<User>(GetType().Name);

            mapper = map;
        }
        public List<UserDTO> GetAllUsersList()
        {
            return mapper.Map<List<UserDTO>>(family.Find(_ => true).ToList());
        }

        public UserDTO GetUserByUserName(string name)
        {
            return mapper.Map<UserDTO>(family.Find(f => f.UserName == name).ToList().FirstOrDefault()); ;
        }

        public  void AddUserToList(UserDTO family)
        {
            this.family.InsertOne(mapper.Map<User>(family));
            //TODO TE.SaveChanges();
        }

        public bool ChekIfPasswordIsExist(string userName, string password)
        {
            bool isExist = false;
            List<User> lf = family.Find(_ => true).ToList();
            for (int i = 0; i < lf.Count; i++)
            {
                if (lf[i].UserName.Equals(userName) && lf[i].Password.Equals(password))
                    isExist = true;
            }
            return !isExist;
        }
        public  void PutUser(UserDTO fam)
        {
            family.ReplaceOne(f => f.UserId == fam.UserId, mapper.Map<User>(fam));
        }

        public  void DeleteUser(string id)
        {
            family.DeleteOne(f => f.UserId == id);
        }
    }
}
