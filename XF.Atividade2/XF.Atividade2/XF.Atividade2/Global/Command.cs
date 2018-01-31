using System;
using System.Windows.Input;

namespace XF.Atividade2.Global
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action methodToExecute;

        public Command(Action methodToExecute)
        {
            this.methodToExecute = methodToExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            methodToExecute.Invoke();
        }
    }
}
