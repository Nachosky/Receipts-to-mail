using Coypu;
using SimplerSettings;

namespace Receipts
{
    public class Navigation
    {
        public void EnterLoginScreen(BrowserSession browser)
        {
            browser.FindXPath("//button[@class='_2Vg9 QN_e']").Click();
        }

        public void LoginWithCredentials(BrowserSession browser)
        {
            browser
                .FindXPath("//input[@name='email']")
                .FillInWith(AppSettings.Get("userEmail"));

            browser
                .FindXPath("//input[@name='password']")
                .FillInWith(AppSettings.Get("userPassword"));

            browser.FindXPath("//button[@type='submit']")
                .Click();
        }

        public void ChangeSubscription(BrowserSession browser, string subscription)
        {
            while (browser.FindXPath("//span[@class='username-text']").Text != subscription)
            {
                browser
                    .FindXPath("//span[@data-toggle='dropdown']").Click();

                browser
                    .FindXPath("//a[@class='tenant-switch-btn']").Click();

                browser
                    .FindXPath("//a[@title='" + subscription + " (Europe)']").Click();
            }
            
        }
        

        public void GoToReceipts(BrowserSession browser)
        {
            browser
                .FindXPath("//span[@data-toggle='dropdown']").Click();

            browser
                .FindXPath("//a[contains(text(),'Settings')]").Click();

            browser
                .FindId("nav-payment").Click();
            
        }

        public void OpenReceipt(BrowserSession browser)
        {
            browser.FindXPath("//tr[@class='charge'][1]/td[1]/a").Click();
        }
        

    }
}
