using Xamarin.Forms;
using XF.Atividade6.Infrastructure;
using XF.Atividade6.Repositories;
using XF.Atividade6.Views.Login;

namespace XF.Atividade6
{
    public class App : Application
	{
        public static IAuthenticate Authenticator { get; private set; }

        public App ()
		{
			// The root page of your application
			MainPage = new LoginView();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }

        static AlunoRepository alunoRepo;
        public static AlunoRepository AlunoRepo
        {
            get
            {
                if (alunoRepo == null)
                {
                    alunoRepo = new AlunoRepository();
                }
                return alunoRepo;
            }

        }
    }
}

