using System.IO;
using Xamarin.Forms;
using XF.Atividade3.Data;
using XF.Atividade3.Droid;

[assembly: Dependency(typeof(SQLite_Android))]
namespace XF.Atividade3.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {
        }

        public SQLite.SQLiteConnection GetConexao()
        {
            var arquivodb = "fiapdb.db3";

            string caminho = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var local = Path.Combine(caminho, arquivodb);

            var conexao = new SQLite.SQLiteConnection(local);

            return conexao;
        }
    }
}