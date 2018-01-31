using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XF.Atividade1.Models
{
    public class Email : INotifyPropertyChanged
    {
        private bool ativo;

        public bool Ativo
        {
            get { return ativo; }
            set
            {
                ativo = value;

                if(!ativo)
                {
                    ContaEmail = string.Empty;
                }

                EventPropertyChanged();
            }
        }

        private string contaEmail;

        public string ContaEmail
        {
            get { return contaEmail; }
            set
            {
                contaEmail = value;
                EventPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
