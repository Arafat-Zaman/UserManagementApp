using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace UserManagementApp.E2ETests
{
    public class E2ETestBase : IDisposable
    {
        protected IWebDriver Driver;

        public E2ETestBase()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--headless"); // Optional: Run tests in headless mode
            Driver = new ChromeDriver(options);

            // Set timeouts for element searching
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
