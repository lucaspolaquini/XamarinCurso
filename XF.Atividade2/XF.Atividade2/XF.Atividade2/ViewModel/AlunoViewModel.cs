using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using XF.Atividade2.Global;
using XF.Atividade2.Model;
using XF.Atividade2.View;

namespace XF.Atividade2.ViewModel
{
    public class AlunoViewModel
    {
        #region Propriedades
        public ObservableCollection<Aluno> Alunos { get; set; } = new ObservableCollection<Aluno>();
        public Aluno Aluno { get; set; }
        #endregion

        #region Eventos
        public ICommand OnNovoAluno
        {
            get
            {
                return new Command(AdicionarAluno);
            }
        }

        public ICommand OnSalvarAluno
        {
            get
            {
                return new Command(SalvarAluno);
            }
        }
        #endregion

        public AlunoViewModel()
        {
            Aluno = new Aluno();

            Alunos.Add(new Aluno()
            {
                Id = Guid.NewGuid(),
                RM = "542621",
                Nome = "Anderson Silva",
                Email = "anderson@ufc.com"
            });

            Alunos.Add(new Aluno()
            {
                Id = Guid.NewGuid(),
                RM = "451287",
                Nome = "Felipe Berlini",
                Email = "felipe@ufc.com"
            });

            Alunos.Add(new Aluno()
            {
                Id = Guid.NewGuid(),
                RM = "985236",
                Nome = "Lucas",
                Email = "lucas@ufc.com"
            });
        }

        public async void AdicionarAluno()
        {
            if (Aluno == null)
            {
                Aluno = new Aluno();
            }
            else
            {
                Aluno.Id = new Guid();
                Aluno.RM = string.Empty;
                Aluno.Nome = string.Empty;
                Aluno.Email = string.Empty;
            }

            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new NovoAlunoView() { BindingContext = this });
        }

        public async void SalvarAluno()
        {
            if(Aluno != null)
            {
                Alunos.Add(new Aluno()
                {
                    Id = Aluno.Id,
                    RM = Aluno.RM,
                    Nome = Aluno.Nome,
                    Email = Aluno.Email
                });
            }

            await Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
