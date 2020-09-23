using SQLite;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XF_Crud_SQLite.Model;

namespace XF_Crud_SQLite.Persistencia
{
    public class AcessoDB : IDisposable
    {
        protected static object locker = new object();

        private SQLiteConnection db;

        public AcessoDB()
        {
            db = DependencyService.Get<ISQLiteDb>().GetConnection();
            db.CreateTable<Usuario>();
        }

        public void InserirUsuario(Usuario usuario)
        {
            lock (locker)
            {
                db.Insert(usuario);
            }
        }

        public void DeletarUsuario(Usuario usuario)
        {
            lock (locker)
            {
                db.Delete(usuario);
            }
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            lock (locker)
            {
                db.Update(usuario);
            }
        }

        public Usuario GetUsuario(int codigo)
        {
            lock (locker)
            {
                return db.Table<Usuario>().Where(u => u.Id == codigo).FirstOrDefault();
            }
        }

        public List<Usuario> GetUsuarios()
        {
            lock (locker)
            {
                return db.Table<Usuario>().ToList();
            }
        }

        public List<Usuario> GetUsuarios(string criterio)
        {
            lock (locker)
            {
                return db.Table<Usuario>().Where(u => u.Nome.Contains(criterio)).ToList();
            }
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}


