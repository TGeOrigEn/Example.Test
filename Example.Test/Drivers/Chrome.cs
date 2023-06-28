﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace Example.Test.Drivers
{
    public static class Chrome
    {
        public static IWebDriver Remote(string host)
        {
            var chromeOptions = new ChromeOptions()
            {
                BrowserVersion = "latest"
            };

            var selenoidOptions = new Dictionary<string, object>
            {
                { "enableVideo", true },
                { "enableVNC", true }
            };

            chromeOptions.AddAdditionalOption("selenoid:options", selenoidOptions);

            return new RemoteWebDriver(new Uri($"{host}wd/hub"), chromeOptions);
        }

        public static IWebDriver Local()
        {
/*            var chromeOptions = new ChromeOptions()
            {
                //BrowserVersion = "latest"
            };

            var selenoidOptions = new Dictionary<string, object>
            {
               // { "enableVideo", true },
                //{ "enableVNC", true }
            };

            chromeOptions.AddAdditionalOption("selenoid:options", selenoidOptions);*/

            return new ChromeDriver(/*chromeOptions*/);
        }
    }
}
