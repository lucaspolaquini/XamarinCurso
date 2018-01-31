using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Atividade2.ViewModel;

namespace XF.Atividade2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlunoView : ContentPage
    {
        public AlunoView()
        {
            BindingContext = new AlunoViewModel();

            InitializeComponent();
        }
    }
}