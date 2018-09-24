using SQLite;

namespace Welic.App.Services.ServicesViewModels
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
