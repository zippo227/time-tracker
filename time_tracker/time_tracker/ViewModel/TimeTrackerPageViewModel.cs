using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using time_tracker.Model;

namespace time_tracker.ViewModel
{
    class TimeTrackerPageViewModel : ViewModelBase
    {
        private ObservableCollection<TaskViewModel> mObsColTaskViewModels = new ObservableCollection<TaskViewModel>();
        public ObservableCollection<TaskViewModel> ObsColTaskViewModels
        {
            get { return mObsColTaskViewModels; }
        }

        private RelayCommand<string> mAddTaskCommand;
        public RelayCommand<string> AddTaskCommand
        {
            get
            {
                return mAddTaskCommand ??
                  (mAddTaskCommand = new RelayCommand<string>(HandleAddTask));
            }
        }

        private void HandleAddTask(string taskDesc)
        {
            TaskViewModel tvm = new TaskViewModel();
            tvm.MTaskModel = new TaskModel(taskDesc);

            ObsColTaskViewModels.Add(tvm);
        }
    }
}
