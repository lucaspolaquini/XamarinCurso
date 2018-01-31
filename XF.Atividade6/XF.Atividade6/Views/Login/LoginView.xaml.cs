using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Atividade6.ViewModels;

namespace XF.Atividade6.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            BindingContext = new UsuarioViewModel();

            InitializeComponent();
        }
    }
}