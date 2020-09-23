using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF_Crud_SQLite.Model;
using XF_Crud_SQLite.Persistencia;

namespace XF_Crud_SQLite.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlterarPage : ContentPage
    {
        //AcessoDB accdb = new AcessoDB();
        Usuario usuarioAlterado;

        public AlterarPage(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentException();

            usuarioAlterado = usuario;
            BindingContext = usuario;

            InitializeComponent();
        }

        private void Alterar_Clicked(object sender, EventArgs e)
        {
            usuarioAlterado.Nome = txtNome.Text;
            usuarioAlterado.Email = txtEmail.Text;
            usuarioAlterado.Ativo = bAtivo.On;
            Navigation.PopAsync();
        }

        private void Cancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}