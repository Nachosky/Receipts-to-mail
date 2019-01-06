using SimplerSettings;
using System.Collections.Generic;

namespace Receipts
{
    class Program
    {
        static void Main(string[] args)
        {
            var browser = Driver.DriverInit();
            var navigation = new Navigation();
            var subscriptionList = new Program().subscriptionList();
            List<string> fileList = new List<string>();

            browser.MaximiseWindow();
            browser.Visit("http://www.auth0.com");

            navigation.EnterLoginScreen(browser);

            navigation.LoginWithCredentials(browser);

            foreach (var subscriptionName in subscriptionList)
            {

                navigation.ChangeSubscription(browser, subscriptionName);
                navigation.GoToReceipts(browser);
                navigation.OpenReceipt(browser);
                var selenium = ((OpenQA.Selenium.Remote.RemoteWebDriver)browser.Native);
                var lista = selenium.WindowHandles;
                selenium.SwitchTo().Window(lista[1]);
                var filename = subscriptionName + ".png";
                fileList.Add(filename);
                browser.SaveScreenshot(filename, System.Drawing.Imaging.ImageFormat.Png);
                selenium.Close();
                selenium.SwitchTo().Window(lista[0]);

            }
            var sendMail = new SendMail();
            sendMail.SendEmail(fileList);

            browser.Dispose();

        }

        public List<string> subscriptionList()
        {
            var appSettingsSubscriptions = AppSettings.Get("subscriptions");
            var payedSubscriptionsList = new List<string>(appSettingsSubscriptions.Value.Split(';'));
            
            return payedSubscriptionsList;
        }
    }
    }

