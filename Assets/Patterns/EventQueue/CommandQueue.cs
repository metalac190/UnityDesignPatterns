using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandQueue
{
    private Queue<ICommand> _queue = new Queue<ICommand>();

    public void Enqueue(ICommand command)
    {
        _queue.Enqueue(command);
    }

    public void ExecuteNextCommand()
    {
        if (_queue.Count <= 0)
            return;

        _queue.Dequeue().Execute();
    }
}
