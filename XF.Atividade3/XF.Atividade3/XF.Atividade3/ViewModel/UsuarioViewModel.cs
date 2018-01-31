using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows.Input;
using System.Xml.Linq;
using Xamarin.Forms;
using XF.Atividade3.Model;

namespace XF.Atividade3.ViewModel
{
    public class UsuarioViewModel : ViewModelBase
    {
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public ICommand OnLogin
        {
            get
            {
                return new Command(() => Login());
            }
        }

        public async void Login()
        {
            Usuario usuario = new Usuario()
            {
                Username = Username,
                Password = Password
            };

            var autorizado = IsAutorizado(usuario);

            if (autorizado)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.Aluno.MainPage());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Atenção", "Usuário não autorizado", "Ok");
            }
        }

        public bool IsAutorizado(Usuario paramLogin)
        {
            var httpRequest = new HttpClient();
            var stream = httpRequest.GetStringAsync("http://wopek.com/xml/usuarios.xml").Result;
            XElement xmlUsuarios = XElement.Parse(stream);

            var usuarios = new List<Usuario>();

            foreach (var item in xmlUsuarios.Elements("usuario"))
            {
                Usuario usuario = new Usuario()
                {
                    Username = item.Element("username").Value,
                    Password = item.Element("password").Value
                };

                usuarios.Add(usuario);
            }

            return usuarios.Any(user => user.Username == paramLogin.Username && user.Password == paramLogin.Password);
        }
    }
}
