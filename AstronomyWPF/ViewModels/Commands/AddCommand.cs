using AstronomyDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AstronomyWPF.ViewModels.Commands
{
    public class AddCommand : ICommand
    {
        public event Action<Star> Add;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Star s = parameter as Star;  
            if (Add != null)
                Add(s);
        }
    }
}
