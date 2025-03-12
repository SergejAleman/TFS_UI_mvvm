
namespace TFS_UI_mvvm.ViewModels.BaseClasses
{
    public class RelayCommand : BaseCommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public RelayCommand(Action<object> Execute, Func<object, bool> CanExecute = null!)
        {
            execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            canExecute = CanExecute ?? (_ => true);
        }

        public override bool CanExecute(object? parameter) => canExecute?.Invoke(parameter ?? new object()) ?? true;

        public override void Execute(object? parameter) => execute(parameter ?? new object());
    }
}
