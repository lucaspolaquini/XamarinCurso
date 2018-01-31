using Newtonsoft.Json;

namespace XF.Atividade6.Models
{
    public class Aluno : EntityBase
    {
        string rm;
        string nome;
        string email;
        bool aprovado;

        [JsonProperty(PropertyName = "rm")]
        public string RM
        {
            get { return rm; }
            set { rm = value; }
        }

        [JsonProperty(PropertyName = "nome")]
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        [JsonProperty(PropertyName = "email")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [JsonProperty(PropertyName = "aprovado")]
        public bool Aprovado
        {
            get { return aprovado; }
            set { aprovado = value; }
        }

        
    }
}
