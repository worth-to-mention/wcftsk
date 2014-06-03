using System;
using System.Threading;
using System.Windows.Input;

namespace AdventureWorksClient.ViewModels
{
    /// <summary>
    /// A base class for commands.
    /// </summary>
    public class Command : ICommand
    {
        private readonly Action<object> action;
        private readonly Predicate<object> predicate;

        public Command(Action<object> action) : this(action, null) { }

        public Command(Action<object> action, Predicate<object> predicate)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            this.action = action;
            this.predicate = predicate;
        }

        #region ICommand

        public virtual bool CanExecute(object parameter)
        {
            return predicate == null ? true : predicate(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }

        #endregion
    }
}