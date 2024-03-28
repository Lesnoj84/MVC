using SQLite;
using System.IO;

namespace EvernoteClone.ViewModel.Helper
{
    public class DatabaseHelper
    {
        private static string dbFile = Path.Combine(Environment.CurrentDirectory, "notesDb.db3");

        public static bool Insert<T>(T item)
        {
            using (SQLiteConnection sQLiteConnection = new(dbFile))
            {
                sQLiteConnection.CreateTable<T>();

                int rows = sQLiteConnection.Insert(item);

                if (rows > 0)
                    return true;

                return false;
            }
        }

        public static bool Update<T>(T item)
        {
            using (SQLiteConnection sQLiteConnection = new(dbFile))
            {
                sQLiteConnection.CreateTable<T>();

                int rows = sQLiteConnection.Update(item);

                if (rows > 0)
                    return true;

                return false;
            }
        }

        public static List<T> Read<T>() where T : new()
        {
            List<T> list = new List<T>();

            using (SQLiteConnection sQLiteConnection = new(dbFile))
            {
                sQLiteConnection.CreateTable<T>();
                list = sQLiteConnection.Table<T>().ToList();

            }

            return list;
        }

        public static bool Delete<T>(T item)
        {
            using (SQLiteConnection sQLiteConnection = new(dbFile))
            {
                sQLiteConnection.CreateTable<T>();

                int rows = sQLiteConnection.Delete(item);

                if (rows > 0)
                    return true;

                return false;
            }
        }

    }
}
