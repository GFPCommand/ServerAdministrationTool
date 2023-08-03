using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Helpers {
    public static class Users {
        public static HtmlString GetUsers() {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++) {
                char c = Convert.ToChar(i);
                sb.Append($"<li>{c}</li>");
            }

            return new HtmlString(sb.ToString());
        }
    }
}