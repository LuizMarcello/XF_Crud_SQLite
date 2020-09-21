using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF_Crud_SQLite.Pages;
using XF_Crud_SQLite.Persistencia;

namespace XF_Crud_SQLite
{
    public partial class App : Application
    {
        static AcessoDB dbContext;

        public static AcessoDB DataBase
        {
            get
            {
                if (dbContext == null)
                    dbContext = new AcessoDB();

                return dbContext;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new CadastroPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
