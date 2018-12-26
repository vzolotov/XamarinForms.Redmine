using System;
using System.Collections.Generic;
using AppKit;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

namespace Redmine.MacOs
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        NSWindow _window;
        public AppDelegate()
        {
            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;

            var rect = new CoreGraphics.CGRect(200, 1000, 1024, 768);
            _window = new NSWindow(rect, style, NSBackingStore.Buffered, false)
            {
                Title = "Xamarin.Forms on Mac!",
                TitleVisibility = NSWindowTitleVisibility.Hidden
            };

           

        //    NSMenuItem appMenuItem = new NSMenuItem();
        //    menubar.AddItem(appMenuItem);

        //    NSMenuItem appMenuItem1 = new NSMenuItem();
        //    menubar.AddItem(appMenuItem1);

        //    NSMenu appMenu = new NSMenu();
        //    string quitTitle = String.Format("Quit {0}", "-----" );
        //    NSMenuItem quitMenuItem = new NSMenuItem(quitTitle, "q", delegate {
        //        NSApplication.SharedApplication.Terminate(menubar);
        //    });
        //    appMenu.AddItem(quitMenuItem);
        //    appMenuItem.Submenu = appMenu;

        //    NSMenu appMenu1 = new NSMenu("222");
        //    string quitTitle1 = String.Format("Quit {0}", "-----");
        //    NSMenuItem quitMenuItem1 = new NSMenuItem(quitTitle1, "q", delegate {
        //        NSApplication.SharedApplication.Terminate(menubar);
        //    });
        //    appMenu1.AddItem(quitMenuItem1);
        //    appMenuItem1.Submenu = appMenu1;
        //    NSMenuItem u = new NSMenuItem();
           
        //    //menubar.AddItem(appMenuItem);

        //    NSApplication.SharedApplication.MainMenu = menubar;
        }

        public override NSWindow MainWindow
        {
            get { return _window; }
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            Forms.Init();
            LoadApplication(new App());
            base.DidFinishLaunching(notification);
        }
    }
}
