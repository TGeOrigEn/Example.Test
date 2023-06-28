using Example.Test.Drivers;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Tdms.Api.Components.Implementations.Components.Table;
using Tdms.Api.Components.Implementations.Components.Window;
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
                .ByNameEquality("Дата модификации")
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

            var itemRequirement = new MenuItemRequirement()
                .ByNameEquality("Столбцы")
                .Perform();

            menu.GetItem()
                .WithRequirement(itemRequirement)
                .Perform().Click();

            GetMenu(1).GetItem().WithRequirement(new MenuItemRequirement().ByNameEquality("Статус").Perform()).Perform().Click();

            table.GetRow().Perform().Click();

            var cell = table.GetRow().Perform().GetCell().WithRequirement(new TableCellRequirement().ByHeader(header).Perform()).Perform();

            var value = cell.GetValue();

            cell.ContextClick();

            GetMenu(0).GetItem().WithRequirement(new MenuItemRequirement().ByNameEquality("Редактировать карточку...").Perform()).Perform().Click();

            var window = Context.GetComponent<WindowComponent>().Perform();

            window.Close();
        }
    }
}
