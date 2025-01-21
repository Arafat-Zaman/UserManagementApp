using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Xunit;

namespace UserManagementApp.E2ETests
{
    public class UserManagementTests : E2ETestBase
    {
        [Fact]
        public void Should_LoadHomePage()
        {
            // Navigate to the application
            Driver.Navigate().GoToUrl("http://localhost:4200");

            // Assert the page title or header
            var header = Driver.FindElement(By.TagName("h1")).Text;
            Assert.Equal("User List", header);
        }

        [Fact]
        public void Should_SearchUsers()
        {
            // Navigate to the application
            Driver.Navigate().GoToUrl("http://localhost:4200");

            // Input a search query
            var searchBox = Driver.FindElement(By.CssSelector("input[placeholder='Search users by name, company, or role']"));
            searchBox.SendKeys("Manager");

            // Click the search button
            var searchButton = Driver.FindElement(By.CssSelector("button"));
            searchButton.Click();

            // Assert search results
            var rows = Driver.FindElements(By.CssSelector("table tbody tr"));
            Assert.True(rows.Count > 0, "No users found for the search query.");
        }

        [Fact]
        public void Should_ViewUserDetails()
        {
            // Navigate to the application
            Driver.Navigate().GoToUrl("http://localhost:4200");

            // Click on the first "View" link
            var viewLink = Driver.FindElement(By.LinkText("View"));
            viewLink.Click();

            // Assert user details are displayed
            var detailsHeader = Driver.FindElement(By.TagName("h2")).Text;
            Assert.NotEmpty(detailsHeader);
        }

    }
}
