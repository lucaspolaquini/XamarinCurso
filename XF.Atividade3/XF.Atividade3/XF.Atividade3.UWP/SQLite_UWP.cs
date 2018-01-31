using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using XF.Atividade3.Data;
using XF.Atividade3.UWP;

[assembly: Dependency(typeof(SQLite_UWP))]
namespace XF.Atividade3.UWP
{
    public class SQLite_UWP : ISQLite
    {
        public SQLite_UWP() { }
        public SQLite.SQLiteConnection GetConexao()
        {
            var arquivodb = "fiapdb.db3";
            string caminho = Path.Combine(
            ApplicationData.Current.LocalFolder.Path, arquivodb);
            var conexao = new SQLite.SQLiteConnection(caminho);
            return conexao;
        }
    }
}
