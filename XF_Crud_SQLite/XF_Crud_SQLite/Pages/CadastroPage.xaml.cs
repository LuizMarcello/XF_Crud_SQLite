using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF_Crud_SQLite.Model;

namespace XF_Crud_SQLite.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroPage : ContentPage
    {
        private ObservableCollection<Usuario> _usuarios;
        //private AcessoDB accdb = new AcessoDB();

        public CadastroPage()
        {
            InitializeComponent();
            //var usuarios = accdb.GetUsuarios();
            var usuarios = App.DataBase.GetUsuarios();
            _usuarios = new ObservableCollection<Usuario>(usuarios);
            lvwUsuarios.ItemsSource = _usuarios;
        }

        //Evento da toolBar
        private void Novo_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new IncluirPage(_usuarios));
        }

        //Evento da textCell/MenuItem
        private void Alterar_Clicked(object sender, EventArgs e)
        {
            //var menuItem = sender as MenuItem;
            //var usuario = menuItem.CommandParameter as Usuario;
            //ou:
            var usuario = (sender as MenuItem).CommandParameter as Usuario;
            Navigation.PushAsync(new AlterarPage(usuario));
        }

        //Evento da textCell/MenuItem
        private async void Deletar_Clicked(object sender, EventArgs e)
        {
            var menuitem = sender as MenuItem;
            var usuario = menuitem.CommandParameter as Usuario;
            //ou:
            //var usuario = (sender as MenuItem).CommandParameter as Usuario; 
            var resposta = await DisplayAlert("Confirma exclusão deste registro ?", usuario.Nome, "Sim", "Não");
            if (resposta)
            {
                //accdb.DeletarUsuario(usuario);
                App.DataBase.DeletarUsuario(usuario);
                _usuarios.Remove(usuario);
            }
        }

        //Evento da searchBar
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //accdb.GetUsuarios(e.NewTextValues);
            lvwUsuarios.ItemsSource = App.DataBase.GetUsuarios(e.NewTextValue);
        }
    }
}





