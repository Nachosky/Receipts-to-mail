using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coypu;

namespace Receipts
{
    public class Driver
    {       
        public static BrowserSession DriverInit()
        {            
            var browserSession = new BrowserSession(
                new SessionConfiguration
                {                    
                    Browser = Coypu.Drivers.Browser.Chrome,                    
                    Timeout = TimeSpan.FromSeconds(30),
                    RetryInterval = TimeSpan.FromSeconds(0.2)
                });
            
            return browserSession;

        }

        public void DriverDispose(BrowserSession browser)
        {
            browser.Dispose();            
        }
        

    }
}
