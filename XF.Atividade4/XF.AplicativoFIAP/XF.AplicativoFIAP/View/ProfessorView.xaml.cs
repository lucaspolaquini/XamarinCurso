using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.AplicativoFIAP.ViewModel;

namespace XF.AplicativoFIAP.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfessorView : ContentPage
    {
        public ProfessorView()
        {
            BindingContext = ProfessorViewModel.Entity;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            lstProfessores.IsRefreshing = !lstProfessores.IsRefreshing;
            await ProfessorViewModel.Entity.Carregar();
            lstProfessores.IsRefreshing = !lstProfessores.IsRefreshing;
        }
    }
}