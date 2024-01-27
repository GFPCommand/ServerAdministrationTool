using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServerAdministrationTool.Models;

namespace Helpers {
    public static class Users {
        public static HtmlString GetUsers() {
            DataLoader loader = new();

            StringBuilder sb = new();

            foreach (var item in loader.Users())
            {
                sb.Append($"<li>{item}</li>");
            }

            return new HtmlString(sb.ToString());
        }
    }
}