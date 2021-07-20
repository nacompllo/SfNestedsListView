using AppKit;
using Foundation;
using Syncfusion.ListView.XForms.MacOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;
// also add a using for the Xamarin.Forms project, if the namespace is different to this file

namespace SfNestedsListView.MacOS
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        NSWindow window;
        public AppDelegate()
        {
            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;

            var rect = new CoreGraphics.CGRect(200, 1000, 1024, 768);
            window = new NSWindow(rect, style, NSBackingStore.Buffered, false);
            window.Title = "Xamarin.Forms on Mac!"; // choose your own Title here
            window.TitleVisibility = NSWindowTitleVisibility.Hidden;
        }

        public override NSWindow MainWindow
        {
            get { return window; }
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            Forms.Init();
            LoadApplication(new App());
            SfListViewRenderer.Init();
            base.DidFinishLaunching(notification);
        }
    }
}