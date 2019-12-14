using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModelLayaer.Commands
{
    public class OwnCommand : ICommand
    {
        private readonly Action m_Execute;
        public event EventHandler CanExecuteChanged;

        public OwnCommand(Action command)
        {
            this.m_Execute = command;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.m_Execute();
        }
    }
}
