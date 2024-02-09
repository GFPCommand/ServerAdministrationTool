using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerAdministrationTool.Models;

namespace ServerAdministrationTool.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        DataUploader _uploader = new();

        Authority _auth = new();

        private string _errMsg = string.Empty;

        [HttpPost]
        public IActionResult CreateUser(string new_user, string new_pass, string role)
        {
            if (_uploader.WriteData(out _errMsg, UserActions.CREATE, new_user, new_pass, role))
            {
                return new ContentResult() { StatusCode = 201 };
            }
            else return new BadRequestObjectResult(_errMsg);
        }

        [HttpGet]
        public string ReadUser(string name)
        {
            DataLoader loader = new();
            return loader.UserInfo(name);
        }

        [HttpPut]
        public IActionResult UpdateUser(string name, string role, string old_pass, string new_pass)
        {
            if (!_auth.LoginDataIsCorrect(name, old_pass))
            {
                return new BadRequestObjectResult(_errMsg);
            }

            if (_uploader.WriteData(out _errMsg, UserActions.UPDATE, name, new_pass, role))
            {
                return new ContentResult() { StatusCode = 201 };
            }
            else return new BadRequestObjectResult(_errMsg);
        }

        [HttpDelete]
        public IActionResult DeleteUser(string name)
        {
            if (_uploader.WriteData(out _errMsg, UserActions.DELETE, name))
            {
                return new ContentResult() { StatusCode = 200 };
            }
            else return new BadRequestObjectResult(_errMsg);
        }
    }
}
