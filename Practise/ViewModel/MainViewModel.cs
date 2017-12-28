using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using LeetCodePractise.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractise.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Messenger.Default.Register<ViewModelBase>(this, (viewModel) => RegisterViewModel(viewModel));
        }

        private void RegisterViewModel(ViewModelBase viewModel)
        {
            SolutionList.Add(viewModel);
        }

        private ObservableCollection<ViewModelBase> _solutionsList = new ObservableCollection<ViewModelBase>();

        public ObservableCollection<ViewModelBase> SolutionList
        {
            get { return _solutionsList; }
            set
            {
                _solutionsList = value;
                RaisePropertyChanged();
            }
        }
    }
}
