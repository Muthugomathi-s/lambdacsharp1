// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Interactions;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;

using System.Configuration;
using System.Runtime.CompilerServices;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
[assembly:Parallelizable(ParallelScope.Fixtures)]

namespace Csharp
{

    [TestFixture("chrome", "88.0", "Windows 10")]
    [TestFixture("MicrosoftEdge", "87.0", "macOS Sierra")]
    [TestFixture("Firefox", "82.0", "Windows 7")]
    [TestFixture("Internet Explorer", "11.0", "Windows 10")]


    class TestClass
    {
        private IWebDriver driver;
        private String ltUserName;
        private String ltAppKey;
        private String _os;
        private String _browser;
        private String _Version;

        public TestClass(String browser, String version, String os)
        {
            _browser = browser;
            _Version = version;
            _os= os;
            ltUserName = "muthugomathis2024";
            ltAppKey = "j8SkC0xSV5Z90yk9gc9CCMVXhGisNzaiFNeBT6JKlUTBRne6UM";




        }
        [SetUp]
        public void Setup()
        {
            dynamic capability = GetBrowserOptions(_browser);
            
            if (_browser != "MicrosoftEdge")
            {
                capability.AddAdditionalCapability("platform", _os, true);
                capability.AddAdditionalCapability("Name", _browser, true); // name of your browser to be defined in App.Config
                capability.AddAdditionalCapability("version", _Version, true); // version of your selected browser to be defined in App.Config
               
                capability.AddAdditionalCapability("build", "LambdaTestSampleApp", true);
                capability.AddAdditionalCapability("user", ltUserName, true); // LambdaTest Username to be defined in App.Config
                capability.AddAdditionalCapability("accessKey", ltAppKey, true);
            }
            else
            {
                capability.AddAdditionalCapability("platform", _os);
                capability .AddAdditionalCapability("browserName", _browser); // name of your browser to be defined in App.Config
                capability.AddAdditionalCapability("version", _Version); // version of your selected browser to be defined in App.Config
                capability.AddAdditionalCapability("name", "CSharpTestSample");
                capability.AddAdditionalCapability("build", "LambdaTestSampleApp");
                capability.AddAdditionalCapability("user", ltUserName); // LambdaTest Username to be defined in App.Config
                capability.AddAdditionalCapability("accessKey", ltAppKey);
            }
            driver = new RemoteWebDriver(new Uri("https://gomathiabi2000:WhzkcL3dvdA5Z54ESIk8QqsEqLIL3lPyF56uS2Xd18cVDiVtnZ@hub.lambdatest.com/wd/hub"), capability.ToCapabilities(), TimeSpan.FromSeconds(600));

        }


        [Test]
        public void TestMethod()
        {

            driver.Url = "https://www.lambdatest.com/selenium-playground";
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("span[class='cookie__bar__close hover:underline smtablet:hidden']")).Click();
            IWebElement email = driver.FindElement(By.CssSelector("#__next > div.wrapper > section.my-50 > div > div > div:nth-child(1) > div:nth-child(1) > ul > li:nth-child(1) > a"));
            email.Click();
            driver.FindElement(By.CssSelector("span[class='cookie__bar__close hover:underline smtablet:hidden']")).Click();
            String currentURL = driver.Url;
            if (currentURL.Contains("simple-form-demo"))
                Console.WriteLine("Yes");


            else
            {
                Console.WriteLine("No");
            }
            String msg = "Welcome to LambdaTest";
            driver.FindElement(By.XPath("//input[@id='user-message']")).SendKeys(msg);
            driver.FindElement(By.XPath("//button[@id='showInput']")).Click();
            IWebElement msg2 = driver.FindElement(By.XPath("//p[@id='message']"));
            if (msg2.Equals(msg))
            {
                Console.WriteLine("Yes");
            }
            Thread.Sleep(2000);
            driver.Quit();


        }

        [Test]
        public void TestMethod1()
        {

            driver.Url = "https://www.lambdatest.com/selenium-playground";
            driver.FindElement(By.CssSelector("span[class='cookie__bar__close hover:underline smtablet:hidden']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#__next > div.wrapper > section.my-50 > div > div > div:nth-child(1) > div:nth-child(2) > ul > li:nth-child(3) > a")).Click();
            driver.FindElement(By.CssSelector("span[class='cookie__bar__close hover:underline smtablet:hidden']")).Click();
            IWebElement middle = driver.FindElement(By.XPath("//div[@id='slider3']/div/input[@class='sp__range']"));
            var action = new Actions(driver);
            action
              .DragAndDropToOffset(middle, 119, 0)
              .Build()
              .Perform();
            Thread.Sleep(2000);
            IWebElement range = driver.FindElement(By.Id("rangeSuccess"));
            Console.WriteLine(range);
            if (range.Equals("95"))
            {
                Console.WriteLine("Same value is displayed in the rangesuccess");

            }
            else
            {
                Console.WriteLine("Same value is not displayed in the rangesuccess");
            }
            //Assert.assertEquals("95", range);
            Thread.Sleep(2000);
            driver.Quit();

        }
        [Test]
        public void TestMethod3()
        {


            driver.Url = "https://www.lambdatest.com/selenium-playground";
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("span[class='cookie__bar__close hover:underline smtablet:hidden']")).Click();
            IWebElement inptbtn = driver.FindElement(By.XPath("//a[normalize-space()='Input Form Submit']"));
            inptbtn.Click();
            driver.FindElement(By.CssSelector("span[class='cookie__bar__close hover:underline smtablet:hidden']")).Click();
            Thread.Sleep(2000);
            IWebElement sbtbutton = driver.FindElement((By.XPath("//button[@type='submit']")));
            sbtbutton.Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement ele = driver.FindElement(By.Id("name"));

            String ActualTitle = (String)js.ExecuteScript("return arguments[0].validationMessage;", ele);
            String ExpectedTitle = "Please fill out this field.";
            Console.WriteLine("The Title shown are same:" + ActualTitle.Equals(ExpectedTitle));
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//input[@placeholder='Name']")).SendKeys("Muthugomathi");
            driver.FindElement(By.XPath("//input[@placeholder='Email']")).SendKeys("gomathiabi2000@gmail.com");
            driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("12588");
            driver.FindElement(By.XPath("//input[@ placeholder='Company']")).SendKeys("cts");
            driver.FindElement(By.XPath("//input[@placeholder='Website']")).SendKeys("www.cts.com");

            SelectElement oSelect = new SelectElement(driver.FindElement(By.XPath("//select[@name='country']")));
            Thread.Sleep(2000);
            oSelect.SelectByText("United States");
            driver.FindElement(By.XPath("//input[@ placeholder='City']")).SendKeys("Rajapalayam");
            driver.FindElement(By.XPath("//input[@placeholder='Address 1']")).SendKeys("127/153 mukill vannam strt");
            driver.FindElement(By.XPath("//input[@placeholder='Address 2']")).SendKeys("27/153 mukill vannam strt");
            driver.FindElement(By.XPath("//input[@id='inputState']")).SendKeys("Tamilnadu");
            driver.FindElement(By.Id("inputZip")).SendKeys("626117");

            IWebElement sbtbutton1 = driver.FindElement((By.XPath("//button[@type='submit']")));
            sbtbutton1.Click();
            //js2.executeScript("arguments[0].click();", sbtbutton1);
            IWebElement successmsg = driver.FindElement(By.XPath("//p[@class='success-msg hidden']"));
            Console.WriteLine(successmsg);
            Console.WriteLine(successmsg.Equals("Thanks for contacting us, we will get back to you shortly."));
            //Assert.AreEqual(successmsg, "Thanks for contacting us, we will get back to you shortly.");
            Thread.Sleep(2000);
            driver.Quit();
        }


        private dynamic GetBrowserOptions(string browsername)
        {
            if (browsername == "Chrome")
                return new ChromeOptions();
            if (browsername == "Firefox")
                return new FirefoxOptions();
            if (browsername == "MicrosoftEdge")
                return new EdgeOptions();
            if (browsername == "Internet Explorer")
                return new InternetExplorerOptions();

            return  new ChromeOptions();
        }
    }
}  