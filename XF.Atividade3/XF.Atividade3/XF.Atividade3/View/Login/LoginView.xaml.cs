using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Atividade3.ViewModel;

namespace XF.Atividade3.View.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginView : ContentPage
	{
		public LoginView ()
		{
            BindingContext = new UsuarioViewModel();

			InitializeComponent ();
		}
	}
}