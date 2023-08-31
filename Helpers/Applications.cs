using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Server_Administration_Tool.Models;

namespace Helpers {
    public static class Applications {

        private static readonly DataLoader s_loader = new();

        public static HtmlString GetApplications() {
            StringBuilder sb = new();

            foreach (var app in s_loader.Apps()) 
            {
                sb.Append($"<li>{app}</li>");
            }

            return new HtmlString(sb.ToString());
        }

        public static HtmlString GetApplicationsList() {
            StringBuilder sb = new ();

            var apps = s_loader.Apps();

            Random r = new ();

            foreach (var item in apps)
            {
                string state = string.Empty;
                string color = string.Empty;

                int smth = r.Next(3);

                switch (smth)
                {
                    case 0:
                        state = AppsStates.OK.ToString();
                        color = "#BDECB6"; // светло-зеленый
                        break;
                    case 1:
                        state = AppsStates.Fail.ToString();
                        color = "#FA8072"; // salmon
                        break;
                    case 2:
                        state = AppsStates.Stopped.ToString();
                        color = "#D3D3D3"; // светло-серый
                        break;
                }

                sb.Append($@"
                    <div class='app-item' style='background-color: {color}'>
		                <img src='/src/hamburger-menu.png' alt='image for application' style='width: 5vw;'>
		                <div class='app-info'>
			                <span>Приложение: {item}</span>
			                <br>
			                <span>Состояние: {state}</span>
		                </div>
		                <div class='app-control'>
			                <a class='control' href='/Apps/StartApplication?app={item}'>Запуск</a>
			                <a class='control' data-bs-toggle='modal' data-bs-target='#restart-modal'>Перезапуск</a>
			                <a class='control' href='/Apps/StopApplication?app={item}'>Остановка</a>
                            <a class='control' data-bs-toggle='modal' data-bs-target='#update-modal'>Обновление</a>
                            <a class='control' data-bs-toggle='modal' data-bs-target='#info-modal'>Информация</a>
		                </div>
	                </div>
                ");
            }

            return new HtmlString(sb.ToString());
        }
    }
}