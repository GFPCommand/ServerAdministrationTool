using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Helpers {
    public static class Applications {
        public static HtmlString GetApplications() {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++) {
                sb.Append($"<li>{i}</li>");
            }

            return new HtmlString(sb.ToString());
        }

        public static HtmlString GetApplicationsList() {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= 10; i++){
                sb.Append($@"
                    <div class='app-item'>
		                <img src='/src/hamburger-menu.png' alt='image for application' style='width: 5vw;'>
		                <div class='app-info'>
			                <span>Приложение {i}</span>
			                <br>
			                <span>Состояние: ОК</span>
		                </div>
		                <div class='app-control'>
			                <a class='control'>Запуск</a>
			                <a class='control'>Перезапуск</a>
			                <a class='control'>Остановка</a>
                            <a class='control'>Обновление</a>
		                </div>
	                </div>
                ");
            }

            return new HtmlString(sb.ToString());
        }
    }
}