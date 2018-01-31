using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XF.Atividade6.Models;
using XF.Atividade6.Views.Aluno;

namespace XF.Atividade6.ViewModels
{
    public class AlunoViewModel : ViewModelBase
    {
        #region Propriedades
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string rm;
        public string RM
        {
            get { return rm; }
            set
            {
                rm = value;
                OnPropertyChanged("RM");
            }
        }

        private string nome;
        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                OnPropertyChanged("Nome");
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private bool aprovado;
        public bool Aprovado
        {
            get { return aprovado; }
            set
            {
                aprovado = value;
                OnPropertyChanged("Aprovado");
            }
        }

        private List<Aluno> alunos;
        public List<Aluno> Alunos
        {
            get {  return alunos; }
            set
            {
                alunos = value;
                OnPropertyChanged("Alunos");
            }
        }

        private Aluno alunoSelecionado;
        public Aluno AlunoSelecionado
        {
            get { return alunoSelecionado; }
            set
            {
                alunoSelecionado = value;
                OnPropertyChanged("AlunoSelecionado");
            }
        }

        #endregion

        #region Eventos
        public ICommand OnNovo
        {
            get
            {
                return new Command(() => AbrirNovo());
            }
        }

        public ICommand OnAlunoTapped
        {
            get
            {
                return new Command(() => AbrirEditar());
            }
        }

        public ICommand OnSalvar
        {
            get
            {
                return new Command(() => Salvar());
            }
        }

        public ICommand OnCancelar
        {
            get
            {
                return new Command(() => Cancelar());
            }
        }

        public ICommand OnRemover
        {
            get
            {
                return new Command(() => Excluir());
            }
        }
        #endregion

        public AlunoViewModel()
        {
            Alunos = App.AlunoRepo.GetAlunos().Result.OrderBy(o => o.Nome).ToList();
        }

        public async void AbrirNovo()
        {
            Limpar();

            await Application.Current.MainPage.Navigation.PushAsync(new NovoAlunoView() { BindingContext = this });
        }

        public async void AbrirEditar()
        {
            Id = AlunoSelecionado.Id;
            RM = AlunoSelecionado.RM;
            Nome = AlunoSelecionado.Nome;
            Email = AlunoSelecionado.Email;
            Aprovado = AlunoSelecionado.Aprovado;

            await Application.Current.MainPage.Navigation.PushAsync(new EditarAlunoView() { BindingContext = this });
        }

        public async void Salvar()
        {
            Aluno aluno = new Aluno
            {
                Nome = Nome,
                RM = RM,
                Email = Email,
                Aprovado = Aprovado,
                Id = Id
            };

            Limpar();

            App.AlunoRepo.SalvarAluno(aluno);

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async void Excluir()
        {
            App.AlunoRepo.RemoverAluno(AlunoSelecionado);

            Limpar();

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async void Cancelar()
        {
            Limpar();
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private void Limpar()
        {
            Nome = RM = Email = Id = string.Empty;
            Aprovado = false;
            AlunoSelecionado = null;
        }
    }
}
