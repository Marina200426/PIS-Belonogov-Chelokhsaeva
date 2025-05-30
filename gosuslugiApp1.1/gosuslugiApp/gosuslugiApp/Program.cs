using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gosuslugiApp
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Создание зависимостей
            var dbHelper = new DatabaseHelper();
            var userRepo = new UserRepository(dbHelper);
            var serviceRepo = new ServiceRepository(dbHelper);
            var appRepo = new ApplicationRepository(dbHelper);
            var ruleRepo = new RuleRepository(dbHelper);
            var charRepo = new CharacteristicRepository(dbHelper);
            var charTypeRepo = new CharacteristicTypeRepository(dbHelper);

            var userService = new UserService(userRepo, charRepo);
            var serviceService = new ServiceService(ruleRepo, serviceRepo);
            var appService = new ApplicationService(appRepo, serviceRepo, ruleRepo, charRepo, serviceService, userService);

            var applicationController = new ApplicationController(appService);
            var serviceController = new ServiceController(serviceRepo, serviceService, charTypeRepo, ruleRepo, userService);
            var authController = new AuthController(new AuthService(userRepo));
            var userController = new UserController(userService, charTypeRepo);

            // Запуск приложения
            Application.Run(new LoginForm(authController, applicationController, serviceController, userController));
        }
    }
}
