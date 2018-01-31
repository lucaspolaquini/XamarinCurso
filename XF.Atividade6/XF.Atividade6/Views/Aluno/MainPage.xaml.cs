using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Atividade6.ViewModels;

namespace XF.Atividade6.Views.Aluno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new AlunoViewModel();

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            BindingContext = new AlunoViewModel();

            base.OnAppearing();
        }
    }
}