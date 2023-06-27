using Example.Test.Drivers;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using Tdms.Api.Components.Implementations.Components.Table;
using Tdms.Api.Components.Implementations.Requirements.Menu;
using Tdms.Api.Components.Implementations.Requirements.Table;

namespace Example.Test
{
    [AllureSuite("Тесты авторизации")]
    public class TestForTest : WebApplicationTest
    {
        protected override IWebDriver Driver => Chrome.Remote(Host);

        protected override string Address => "http://10.0.11.18:8081/client/";

        [Test]
        [AllureOwner("Артём Тисло Максимович")]
        [AllureName("Всё-всё")]
        public void GlobalTest()
        {
            LogIn("SYSADMIN", string.Empty);

            var headerRequirement = new TableHeaderRequirement()
                .ByNameEquality("Дата модификаци")
                .Perform();

            var menuItemRequirement = new MenuItemRequirement()
                .ByNameEquality("Фильтр")
                .Perform();

            var table = Context
                .GetComponent<TableComponent>()
                .Perform();

            var header = table.GetHeader()
                .WithRequirement(headerRequirement)
                .Perform();

            var menu = header.ShowMenu()
                .Perform();

            var menuItem = menu.GetItem()
                .WithRequirement(menuItemRequirement)
                .Perform();

            menuItem.Click();
        }
    }
}
