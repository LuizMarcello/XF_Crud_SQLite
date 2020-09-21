using SQLite;

namespace XF_Crud_SQLite.Persistencia
{
    public interface ISQLiteDb
    {
        SQLiteConnection GetConnection();
    }
}


