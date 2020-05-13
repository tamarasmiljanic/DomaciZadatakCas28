using System;
using NUnit.Framework;
using OpenQA.Selenium; 
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace DomaciTamaraSmiljanicCas28
{
    class SeleniumTests
    {
        IWebDriver driver;
        string url = "http://www.automationpractice.com";
        WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            driver.Navigate().GoToUrl(url);

        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
        [Test]
        public void TestOrder()
        {
            IWebElement searchQuery = wait.Until(EC.ElementIsVisible(By.Id("search_query_top")));
            if (searchQuery.Enabled)
            {
                searchQuery.SendKeys("faded");
                IWebElement searchButton = wait.Until(EC.ElementToBeClickable(By.Name("submit_search")));
                searchButton.Click();
            }

            IWebElement product = wait.Until(EC.ElementIsVisible(By.LinkText("Faded Short Sleeve T-shirts")));
            if (product.Displayed)
            {
                product.Click();
            }

            IWebElement productQuantity = wait.Until(EC.ElementIsVisible(By.Id("quantity_wanted")));
            if (productQuantity.Enabled)
            {
                productQuantity.Clear();
                productQuantity.SendKeys("2");
            }

            IWebElement productSize = driver.FindElement(By.Id("group_1"));
            if (productSize.Enabled)
            {
                SelectElement size = new SelectElement(productSize);
                size.SelectByText("L");
            }

            IWebElement AddToChartButton = wait.Until(EC.ElementToBeClickable(By.Name("Submit")));
            if (AddToChartButton.Enabled)
            {
                AddToChartButton.Click();
            }

         
                IWebElement verification = wait.Until(EC.ElementIsVisible(By.ClassName("icon-ok")));
                if (verification.Displayed)
                {
                    IWebElement continueShopingBtn = wait.Until(EC.ElementIsVisible(By.ClassName("icon-chevron-left")));
                    if (continueShopingBtn.Displayed)
                    {
                        continueShopingBtn.Click();
                        Assert.Pass("Test is passed - all elements function");
                    }
                }
                else
                {
                    Assert.Fail("Test failed - Shoping chart isn't verified");
                }
           
            
            System.Threading.Thread.Sleep(6000);
        }
    }
}
