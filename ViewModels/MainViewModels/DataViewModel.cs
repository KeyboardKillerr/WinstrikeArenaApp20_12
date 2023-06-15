using DataModels;
using DataModels.Entities;
using MainViewModels.VMs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelBase.Commands.AsyncCommands;
using ViewModelBase.Commands.QuickCommands;
using static System.Net.Mime.MediaTypeNames;

namespace MainViewModels
{
    public class DataViewModel : ViewModelBase.ViewModelBase
    {
        //private readonly DataManager data = Helper.DataModel;
        //public Computers Computer { get; }
        public LoginReginViewModel LoginReginVM { get; init; }
        public GameViewModel GameVM { get; init; }  

        public DataViewModel()
        {
            LoginReginVM = new ();
            GameVM = new();
        }
    }
}
