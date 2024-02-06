using Microsoft.AspNetCore.Mvc;
using ServerAdministrationTool.Models;

namespace ServerAdministrationTool.Controllers
{
    public class UsersController : Controller
    {
        DataUploader _uploader = new();

        [HttpPost]
        public void CreateUser(string new_user, string new_pass, string role)
        {
            _uploader.WriteNewUser(new_user, new_pass, role);
        }

        [HttpGet]
        public string ReadUser(string name)
        {
            string userInfo = string.Empty;

            return userInfo;
        }

        [HttpPut]
        public void UpdateUser(string name, string old_name, string new_name)
        {

        }

        [HttpDelete]
        public void DeleteUser(string name)
        {

        }
    }
}
