//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("mymovies.Views.Home.xaml", "Views/Home.xaml", typeof(global::mymovies.Views.Home))]

namespace mymovies.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views\\Home.xaml")]
    public partial class Home : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.SearchBar Searchbar;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.CollectionView MoviesListView;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(Home));
            Searchbar = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.SearchBar>(this, "Searchbar");
            MoviesListView = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.CollectionView>(this, "MoviesListView");
        }
    }
}
