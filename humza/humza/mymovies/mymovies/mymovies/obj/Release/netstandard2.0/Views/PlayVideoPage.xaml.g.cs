//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("mymovies.Views.PlayVideoPage.xaml", "Views/PlayVideoPage.xaml", typeof(global::mymovies.Views.PlayVideoPage))]

namespace mymovies.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views\\PlayVideoPage.xaml")]
    public partial class PlayVideoPage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xam.Forms.VideoPlayer.VideoPlayer videoPlayer;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(PlayVideoPage));
            videoPlayer = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xam.Forms.VideoPlayer.VideoPlayer>(this, "videoPlayer");
        }
    }
}
