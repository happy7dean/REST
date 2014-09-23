﻿using System.Collections.Generic;
using System.Security.Policy;
using System.Threading.Tasks;
using Models;
using RESTServer;
using RESTServer.Handlers;
using RESTServer.Routing;
using RESTServerConsoleHost.Repositories;
using RESTServer.Utils.Serialization;

namespace RESTServerConsoleHost.Handlers
{
    [RouteBase("/users", SerializationToUse.Json)]
    public class UserHandler : IDynamicRouteHandler<User, int>
    {
        private readonly IRepository<User,int> userRepository;

        public UserHandler(IRepository<User,int> userRepository)
        {
            this.userRepository = userRepository;
        }


        [Route("/GetUserByTheirId/{0}", HttpMethod.Get)]
        public async Task<User> GetUserByTheirId(int id)
        {
            return userRepository.Get(id);
        }

        [Route("/GetAllUsers", HttpMethod.Get)]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return userRepository.GetAll();
        }


        [Route("/DeleteUserByTheirId/{0}", HttpMethod.Delete)]
        public async Task<bool> DeleteAUser(int id)
        {
            return userRepository.Delete(id);
        }


        //#region IVerbHandler<Person,int> Members

        //public async Task<Person> Get(int id)
        //{
        //    return userRepository.Get(id);
        //}

        //public async Task<IEnumerable<Person>> Get()
        //{
        //    return userRepository.GetAll();
        //}

        //public async Task<Person> Post(Person item)
        //{
        //    return userRepository.Add(item);
        //}

        //public async Task<bool> Put(int id, Person item)
        //{
        //    item.Id = id;
        //    return userRepository.Update(item);
        //}

        //public async Task<bool> Delete(int id)
        //{
        //    return userRepository.Delete(id);
        //}

        //#endregion
    }
}