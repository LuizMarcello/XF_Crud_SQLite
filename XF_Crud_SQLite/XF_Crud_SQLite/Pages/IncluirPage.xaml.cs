using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF_Crud_SQLite.Model;

namespace XF_Crud_SQLite.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncluirPage : ContentPage
    {
        //AcessoDB accdb = new AcessoDB();
        ObservableCollection<Usuario> colecaoUsuarios;

        public IncluirPage(ObservableCollection<Usuario> _usuarios)
        {
            colecaoUsuarios = _usuarios;
            InitializeComponent();
        }

        private void Salvar_Clicked(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = txtNome.Text;
            usuario.Email = txtEmail.Text;
            usuario.Ativo = bAtivo.On;

            //accdb.InserirUsuario(usuario);
            App.DataBase.InserirUsuario(usuario);

            colecaoUsuarios.Add(usuario);
            Navigation.PopAsync();
        }

        private void Cancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}

