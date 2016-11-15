using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using time_tracker.Model;

namespace time_tracker.ViewModel
{
    class TaskViewModel : ViewModelBase
    {
        private TaskModel mTaskModel;
        public TaskModel MTaskModel
        {
            get { return mTaskModel; }
            set { Set(() => MTaskModel, ref mTaskModel, value); }
        }
    }
}
