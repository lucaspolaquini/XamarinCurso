using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XF.Atividade3.Model;
using XF.Atividade3.View.Aluno;

namespace XF.Atividade3.ViewModel
{
    public class AlunoViewModel : ViewModelBase
    {
        #region Propriedades
        private int id;
        public int Id
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


        public List<Aluno> Alunos
        {
            get
            {
                return App.AlunoModel.GetAlunos().OrderBy(o => o.Nome).ToList();
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

            App.AlunoModel.SalvarAluno(aluno);

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async void Excluir()
        {
            App.AlunoModel.RemoverAluno(Id);

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
            Nome = RM = Email = string.Empty;
            Id = 0;
            Aprovado = false;
            AlunoSelecionado = null;
        }
    }
}
