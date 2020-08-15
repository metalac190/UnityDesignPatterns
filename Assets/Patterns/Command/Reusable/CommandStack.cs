using System.Collections;
using System.Collections.Generic;

public class CommandStack
{
    private Stack<ICommand> _commandHistory = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
    }

    public void UndoLastCommand()
    {
        if (_commandHistory.Count <= 0)
            return;

        _commandHistory.Pop().Undo();
    }
}
