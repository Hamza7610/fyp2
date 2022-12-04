using mymovies.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mymovies
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShellOffline : Xamarin.Forms.Shell
    {
        public AppShellOffline()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DownloadPage), typeof(DownloadPage));
        }
    }
}