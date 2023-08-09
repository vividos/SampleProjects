namespace WebViewLocalFilesMauiApp;

public partial class MainPage : ContentPage
{
    public WebViewSource Source { get; private set; }

    public MainPage()
    {
        BindingContext = this;

        // this shows the text, but the image isn't loaded and is broken
        // it seems the BaseUrl doesn't set up the virtual folder path correctly
        //Source = new HtmlWebViewSource
        //{
        //    Html = "<html><body><h1>Hello World!</h1>" +
        //            "<img src='dotnet_bot.png' />" +
        //            "</body></html>",
        //    BaseUrl = "https://appdir/",
        //};

        // this first shows "Hmmm… can't reach this page", then reloads the
        // page and the image is shown correctly
        Source = new UrlWebViewSource
        {
            Url = "https://appdir/info.html",
        };

        InitializeComponent();
    }

#if WINDOWS
    private static readonly Lazy<bool> _isPackagedAppLazy = new Lazy<bool>(() =>
    {
        try
        {
            if (Windows.ApplicationModel.Package.Current != null)
                return true;
        }
        catch
        {
            // no-op
        }

        return false;
    });

    private static bool IsPackagedApp => _isPackagedAppLazy.Value;

    private static string ApplicationPath => IsPackagedApp
        ? Windows.ApplicationModel.Package.Current.InstalledLocation.Path
        : AppContext.BaseDirectory;
#endif

    private async void WebView_HandlerChanged(object sender, EventArgs e)
    {
        // comment this return to enable a workaround for the second example,
        // for the case when the Source is a UrlWebViewSource; code copied from:
        // https://github.com/dotnet/maui/pull/7672#issuecomment-1162885604
        return;

#if WINDOWS10_0_19041_0_OR_GREATER
        Microsoft.Maui.Platform.MauiWebView mauiWebView =
            (sender as WebView).Handler.PlatformView as Microsoft.Maui.Platform.MauiWebView;

        await mauiWebView.EnsureCoreWebView2Async();

        mauiWebView.CoreWebView2.SetVirtualHostNameToFolderMapping(
            "appdir",
            ApplicationPath,
            Microsoft.Web.WebView2.Core.CoreWebView2HostResourceAccessKind.Allow);

        mauiWebView.LoadUrl($"https://appdir/info.html");
#endif
    }
}
