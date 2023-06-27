using Empyrean.Core.Extensions;
using Empyrean.Core.Implementations;
using Example.Test.Drivers;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using Tdms.Api.Components.Implementations.Components.Buttons;
using Tdms.Api.Components.Implementations.Requirements.Buttons;
using Tdms.Api.Components.Interfaces.Components.Forms;

namespace Example.Test
{
    [AllureSuite("Тесты авторизации")]
    public class AuthorizationTest : WebApplicationTest
    {
        protected override IWebDriver Driver => Chrome.Remote(Host);

        protected override string Address => "http://10.0.11.18:8081/client/";

        private static readonly object[] _VALIDATED_USERS = new object[]
        {
            new object[] { "SYSADMIN", "" },
            new object[] { "SYSADMIN_0", "" }
        };

        private static readonly object[] _INVALIDATED_USERS = new object[]
        {
            new object[] { "SYSADMIN_0", "" },
            new object[] { "SYSADMIN", "" }
        };

        [Test]
        [AllureSubSuite("Успешные авторизации")]
        [AllureOwner("Артём Тисло Максимович")]
        [AllureName("Успешная авторизация")]
        [TestCaseSource(nameof(_VALIDATED_USERS))]
        public void AuthorizationSuccessTest(string username, string password)
        {
            LogIn(username, password);

            var buttonRequirement = new ButtonRequirement<ButtonComponent>();

            var userButtonRequirement = buttonRequirement
                .HasName()
                .And()
                .ByNameEquality(username)
                .Perform();

            var userButton = Context
                .GetComponent<ButtonComponent>()
                .WithRequirement(userButtonRequirement)
                .Perform();

            userButton.Should(buttonRequirement.IsAvalable().Perform(), TimeSpan.FromSeconds(5));
        }

        [Test]
        [AllureSubSuite("Неудачные авторизации")]
        [AllureOwner("Артём Тисло Максимович")]
        [AllureName("Неудачная авторизация")]
        [TestCaseSource(nameof(_INVALIDATED_USERS))]
        public void AuthorizationUnsuccessTest(string username, string password)
        {
            var authorizationForm = LogIn(username, password);

            var requirement = new WebComponentRequirement<IAuthorizationFormComponent>();

            authorizationForm.ShouldUntil(requirement.IsAvalable().Perform(), TimeSpan.FromSeconds(2));
        }
    }
}