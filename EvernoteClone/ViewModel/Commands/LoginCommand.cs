﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        LoginVM vm;

        public LoginCommand(LoginVM loginVM)
        {
            vm = loginVM;

        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }


        public void Execute(object? parameter)
        {
            //TODO:
        }
    }
}