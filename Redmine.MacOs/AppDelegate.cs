using System;
using System.Collections.Generic;
using AppKit;
using CoreSpotlight;
using DryIoc;
using Foundation;
using Redmine.Models;
using Redmine.Services.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

namespace Redmine.MacOs
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        NSWindow _window;
        const string activityName = "com.xamarin.monkeys.monkey";
        public SpotlightSearch SpotlightSearch { get; private set; }
        List<TodoItem> todoItems;

        public AppDelegate()
        {
            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;

            var rect = new CoreGraphics.CGRect(200, 1000, 1024, 768);
            _window = new NSWindow(rect, style, NSBackingStore.Buffered, false)
            {
                Title = "Xamarin.Forms on Mac!",
                TitleVisibility = NSWindowTitleVisibility.Hidden
            };
            todoItems = new List<TodoItem>
            {
                new TodoItem
                {
                    Name = "qwertyuiop",
                    Done = true,
                    Notes = "222",
                    ID = "333"
                }
            };
        }

        public override NSWindow MainWindow => _window;

        public override void DidFinishLaunching(NSNotification notification)
        {
            Forms.Init();
            var resolver = new MacOsResolver();
            resolver.PlatformContainerInit();

            LoadApplication(resolver.GetApp());

            SpotlightSearch = new SpotlightSearch(todoItems);
            base.DidFinishLaunching(notification);
        }

        [Export("application:continueUserActivity:restorationHandler:")]
        public override bool ContinueUserActivity(NSApplication application, NSUserActivity userActivity, ContinueUserActivityRestorationHandler restorationHandler)
        {
            if (userActivity.ActivityType == CSSearchableItem.ActionType)
            {
                string id = userActivity.UserInfo.ObjectForKey(CSSearchableItem.ActivityIdentifier).ToString();
                if (!string.IsNullOrEmpty(id))
                {
                }
            }
            return true;
        }
    }
}
