using SQLite;
using System;
using System.IO;
using XF_Crud_SQLite.iOS.Persistencia;
using XF_Crud_SQLite.Persistencia;

//Fazendo o registro: Em qual assembly foi definido a 
//implementação do método "GetConnection":
[assembly: Xamarin.Forms.Dependency(typeof(SQLiteDb))]
namespace XF_Crud_SQLite.iOS.Persistencia
{
    class SQLiteDb : ISQLiteDb
    {
        public SQLiteConnection GetConnection()
        {
            var caminhoPasta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var caminho = Path.Combine(caminhoPasta, "Cadastro.db3");
            return new SQLiteConnection(caminho);
        }
    }
}
