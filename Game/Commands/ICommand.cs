using System;

namespace MainGame.Commands
{
    public interface ICommand
    {
        void Execute();
        void UnExecute();
    }
}

