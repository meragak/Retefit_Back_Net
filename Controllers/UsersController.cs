using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Retfeet.API.Models;
using Retfeet.API.services;

namespace Retfeet.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }
      
        
        
        // GET: api/Users
        //Get the list of all users (no matter where they work,what are their missions
        
        [HttpGet]
        [Route("get")]
        public IActionResult  GetUsers()
        {
            return new JsonResult(_repository.GetUsers());
        }
        [HttpGet]
        [Route("get/{id}")]

        // GET: api/Users
        //Get the  user by id

        public IActionResult GetUser(int id)
        {
            return  new JsonResult(_repository.GetUser(id));
        }
        // Post: api/Users/register
        //Get the  user by id
        [HttpPost]
        [Route("users/register")]
        public IActionResult AddUser(Users user)
        {

            if(_repository.userExits(user))
            {
                StatusCode(303);
                return  new JsonResult(user);
            }
            try { 
            _repository.addUser(user);
             StatusCode(200);
                return new JsonResult(user);
             }
            catch
            {
                StatusCode(403);
                return new JsonResult(user);
            }
        }
    }
}
       