using SQLite;

namespace XF_Crud_SQLite.Model
{
    [Table("Usuarios")]
    public class Usuario : NotifyBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _nome;
        [MaxLength(100)]
        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
                OnPropertyChanged();
            }
        }

        private string _email;
        [MaxLength(150)]
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private bool _ativo;
        public bool Ativo
        {
            get { return _ativo; }
            set
            {
                _ativo = value;
                OnPropertyChanged();
            }
        }
    }
}






