using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XF.Atividade6.Models;

namespace XF.Atividade6.Repositories
{
    public class AlunoRepository : RepositoryBase
    {
        IMobileServiceTable<Aluno> alunoTable;

        static AlunoRepository defaultInstance = new AlunoRepository();

        public static AlunoRepository DefaultManager
        {
            get
            {
                return defaultInstance;
            }
            private set
            {
                defaultInstance = value;
            }
        }

        public AlunoRepository() : base()
        {
            alunoTable = client.GetTable<Aluno>();
        }

        public async Task<ObservableCollection<Aluno>> GetAlunos()
        {
            IEnumerable<Aluno> items = await alunoTable.ToEnumerableAsync();

            return new ObservableCollection<Aluno>(items);
        }

        public async void SalvarAluno(Aluno aluno)
        {
            if (string.IsNullOrEmpty(aluno.Id))
            {
                await alunoTable.InsertAsync(aluno);
            }
            else
            {
                await alunoTable.UpdateAsync(aluno);
            }
        }

        public async Task<Aluno> GetAluno(string Id)
        {
            return await (Task<Aluno>)alunoTable.Where(c => c.Id == Id);
        }

        public async void RemoverAluno(Aluno aluno)
        {
            await alunoTable.DeleteAsync(aluno);
        }
    }
}
