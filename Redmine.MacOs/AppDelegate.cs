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
        }

        public override NSWindow MainWindow
        {
            get { return _window; }
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            Forms.Init();

            var resolver = new MacOsResolver();
            resolver.PlatformContainerInit();

            LoadApplication(new App());
            base.DidFinishLaunching(notification);
        }
    }
}
