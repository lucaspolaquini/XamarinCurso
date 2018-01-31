using System;
using Xamarin.Forms;
using XF.Atividade1.Models;

namespace XF.Atividade1
{
    public partial class MainPage : ContentPage
    {
        public Email Email;

        public MainPage()
        {
            Email = new Email();
            InitializeComponent();
        }

        private async void btnConfiguracoes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConfigPage() { BindingContext = Email });
        }

        private void btnEnviarEmail_Clicked(object sender, EventArgs e)
        {
            if ((Email.Ativo) && (!string.IsNullOrEmpty(Email.ContaEmail)))
            {
                DisplayAlert("Mensagem", $"E-mail enviado para {Email.ContaEmail}", "Ok");
            }
            else
            {
                DisplayAlert("Mensagem", "Envio não autorizado", "Ok");
            }
        }
    }
}
