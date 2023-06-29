using Empyrean.Core.Interfaces;
using Example.Test.Drivers;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;
using Tdms.Api.Components.Implementations.Components.Buttons;
using Tdms.Api.Components.Implementations.Components.Fields;
using Tdms.Api.Components.Implementations.Components.Form;
using Tdms.Api.Components.Implementations.Components.Loading;
using Tdms.Api.Components.Implementations.Components.Main;
using Tdms.Api.Components.Implementations.Components.Menu;
using Tdms.Api.Components.Implementations.Components.Table;
using Tdms.Api.Components.Implementations.Components.TreeView;
using Tdms.Api.Components.Implementations.Components.Window;
using Tdms.Api.Components.Implementations.Requirements;
using Tdms.Api.Components.Implementations.Requirements.Buttons;
using Tdms.Api.Components.Implementations.Requirements.Fields;
using Tdms.Api.Components.Implementations.Requirements.Menu;
using Tdms.Api.Components.Implementations.Requirements.Table;
using Tdms.Api.Components.Implementations.Requirements.TreeView;

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

            var headerRequirement = new TableHeaderRequirement().ByNameEquality("Дата модификации").Perform();

            var menuItemRequirement = new MenuItemRequirement().ByNameEquality("Фильтр").Perform();

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

            //header.GetFilter().Perform().ClickOnTrigger().Perform().GetItem().WithRequirement(new DropdownListItemRequirement().ByNameEquality("Текущий месяц").Perform()).Perform().Click();

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

        [Test]
        public void TestTest()
        {
            LogIn("SYSADMIN", string.Empty);

            Context.GetComponent<LoadingComponent>().Perform().Wait(TimeSpan.FromSeconds(1));

            Context.GetComponent<ButtonComponent>()
                .WithRequirement(new ButtonRequirement<ButtonComponent>()
                .HasTip()
                .And()
                .ByTipEquality("Объекты")
                .Perform()).Perform().Click();

            Context
                .GetComponents<TreeViewItemComponent>()
                .WithRequirement(new TreeViewItemRequirement<TreeViewItemComponent>().IsDisplayed().And().IsExpandable().And().IsExpanded(false).Perform())
                .Perform().ToList().ForEach(elemet => elemet.Expand());

            Context
                .GetComponents<TreeViewItemComponent>()
                .WithRequirement(new TreeViewItemRequirement<TreeViewItemComponent>().IsDisplayed().And().IsExpandable().And().IsExpanded(false).Perform())
                .Perform().ToList().ForEach(elemet => elemet.Expand());
        }

        [Test]
        public void TestTest1()
        {
            var fieldRequirement = new FieldRequirement<FieldComponent>();

            var buttonRequirement = new ButtonRequirement<ButtonComponent>();

            var menuItemRequirement = new MenuItemRequirement<MenuItemComponent>();

            var windowRequirement = new WindowRequirement<WindowComponent>();

            var treeViewItemRequirement = new TreeViewItemRequirement<TreeViewItemComponent>().IsDisplayed().And().IsExpandable().And().IsExpanded(false);

            var usernameFieldRequirement = fieldRequirement.HasLabel().And().ByLabelEquality("Пользователь:").Perform();
            var passwordFieldRequirement = fieldRequirement.HasLabel().And().ByLabelEquality("Пароль:").Perform();

            var objectsButtonRequirement = buttonRequirement.HasTip().And().ByTipEquality("Объекты").Perform();
            var logInButtonRequirement = buttonRequirement.HasName().And().ByNameEquality("Войти").Perform();

            var ourOrganizationTreeViewItemRequirement = treeViewItemRequirement.And().ByNameEquality("Наша организация").Perform();

            var testTreeViewItemRequirement = treeViewItemRequirement.And().ByNameContent("Тестовый").Perform();

            var editMenuItemRequirement = menuItemRequirement.ByNameEquality("Редактировать карточку...").Perform();

            var editWindowRequirement = windowRequirement.ByTitleEquality("Редактирование объекта").Perform();

            IWebComponent.Context.GetComponent<FieldComponent>().WithRequirement(usernameFieldRequirement).Perform().SetValue("SYSADMIN");
            IWebComponent.Context.GetComponent<FieldComponent>().WithRequirement(passwordFieldRequirement).Perform().SetValue("");

            IWebComponent.Context.GetComponent<ButtonComponent>().WithRequirement(logInButtonRequirement).Perform().Click();

            IWebComponent.Context.GetComponent<LoadingComponent>().Perform().Wait(TimeSpan.FromSeconds(1));

            IWebComponent.Context.GetComponent<ButtonComponent>().WithRequirement(objectsButtonRequirement).Perform().Click();

            IWebComponent.Context.GetComponent<TreeViewItemComponent>().WithRequirement(ourOrganizationTreeViewItemRequirement).Perform().Expand();

            IWebComponent.Context.GetComponent<TreeViewItemComponent>().WithRequirement(testTreeViewItemRequirement).Perform().ContextClick();

            IWebComponent.Context.GetComponent<MenuComponent>().Perform().GetItem<MenuItemComponent>().WithRequirement(editMenuItemRequirement).Perform().Click();

            IWebComponent.Context.GetComponent<WindowComponent>().WithRequirement(editWindowRequirement).Perform().Close();

            IWebComponent.Context.GetComponent<TreeViewItemComponent>().WithRequirement(ourOrganizationTreeViewItemRequirement).Perform().Click();


        }

        [Test]
        public void FofTest()
        {
            var authorizationForm = IWebComponent.Context.GetComponent<AuthorizationFormComponent>().Perform();
            authorizationForm.LogIn("SYSADMIN", "");

            var application = IWebComponent.Context.GetComponent<Application>().Perform();

            application.GetLoading().Perform().Wait(TimeSpan.FromSeconds(1));

            application.Header.Search.SetValue("123");
            application.Header.Search.Search();
            application.Header.Search.Remove();
            application.Header.Search.AdvancedSearch();

            application.Body.ToolBar.ShowTreeViewButton.Click();
            application.Body.ToolBar.ShowPreviewPanelButton.Click();

        }
    }
}
