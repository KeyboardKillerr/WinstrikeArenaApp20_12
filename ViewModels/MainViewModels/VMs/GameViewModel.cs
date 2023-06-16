using DataModels;
using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModelBase.Commands.AsyncCommands;
using ViewModelBase.Commands.QuickCommands;

namespace MainViewModels.VMs
{
    public class GameViewModel : ViewModelBase.ViewModelBase
    {
        private readonly DataManager data = Helper.DataModel;
        public ObservableCollection<Games> GamesList { get; private set; }
        public AsyncCommand AddGameAsync { get; }
        public AsyncCommand DeleteGameAsync { get; }
        public GameViewModel()
        {
            AddGameAsync = new AsyncCommand(addNewGame, addGameCanExecute, Helper.ErrorHandler);
            DeleteGameAsync = new AsyncCommand(deleteGame, deleteGameCanExecute, Helper.ErrorHandler);
            GamesList = new ObservableCollection<Games>(data.Game.Items);
        }

        public void Refresh()
        {
            GamesList = new(data.Game.Items);
            _selectedGame = null;
            _selectedGenre = null;
            _gameName = "";
            _gameDescription = "";
            _gameSize = 0;
        }
        private async Task addNewGame(CancellationToken _)
        {
            var game = new Games()
            {
                Name = _gameName,
                Description = _gameDescription,
                SizeMb = _gameSize
            };
            game.GamesGenres.Add(_selectedGenre);
            await data.Game.UpdateAsync(game);
            Refresh();
        }
        private async Task deleteGame(CancellationToken _)
        {
            await data.Game.DeleteAsync(_selectedGame.Id);
            Refresh();
        }

        private bool addGameCanExecute()
        {
            var game = data.Game.Items.FirstOrDefault(g => g.Name == _gameName);
            if (game != null) return false;
            return true;
        }
        private bool deleteGameCanExecute()
        {
            var game = data.Game.Items.FirstOrDefault(g => g.Name == _selectedGame.Name);
            if (game == null) return false;
            return true;
        }
        private bool CanExecute()
        {
            return true;
        }

        private Games? _selectedGame = null;
        public Games? SelectedGame
        {
            get { return _selectedGame; }
            set
            {
                if (Set(ref _selectedGame, value))
                {
                    DeleteGameAsync.RaiseCanExecuteChanged();
                }
            }
        }

        private Genres? _selectedGenre = null;
        public Genres? SelectedGenre
        {
            get { return _selectedGenre; }
            set
            {
                if (Set(ref _selectedGenre, value))
                {
                }
            }
        }

        private string _gameName = "";
        public string GameName
        {
            get { return _gameName; }
            set
            {
                if (Set(ref _gameName, value))
                {
                    AddGameAsync.RaiseCanExecuteChanged();
                }
            }
        }

        private string _gameDescription = "";
        public string GameDescription
        {
            get { return _gameDescription; }
            set
            {
                if (Set(ref _gameDescription, value))
                {
                }
            }
        }

        private int _gameSize = 0;
        public int GameSize
        {
            get { return _gameSize; }
            set
            {
                if (Set(ref _gameSize, value))
                {
                }
            }
        }
    }
}
