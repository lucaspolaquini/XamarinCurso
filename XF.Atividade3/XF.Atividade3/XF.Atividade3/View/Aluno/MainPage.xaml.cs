using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Atividade3.ViewModel;

namespace XF.Atividade3.View.Aluno
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
        public MainPage ()
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