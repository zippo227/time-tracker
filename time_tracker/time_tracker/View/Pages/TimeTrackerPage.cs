using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using time_tracker.ViewModel;
using Xamarin.Forms;

namespace time_tracker.View.Pages
{
    public class TimeTrackerPage : ContentPage
    {
        //Task Input View
        private Editor mEdrTask;
        private Button mBtnTask;
        private StackLayout mStkTask;

        private StackLayout mStkVertical;
        private ListView mListViewTaskViews;

        private TimeTrackerPageViewModel mTimeTrackerPageViewModel;

        public TimeTrackerPage()
        {
            mTimeTrackerPageViewModel = new TimeTrackerPageViewModel();

            mEdrTask = new Editor
            {
                Keyboard = Keyboard.Default,
                WidthRequest = 400
            };

            mBtnTask = new Button
            {
                Text = "Add",
                WidthRequest = 50
            };

            mBtnTask.Clicked += MBtnTask_Clicked;

            mStkTask = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { mEdrTask, mBtnTask }
            };

            mListViewTaskViews = new ListView
            {
                ItemTemplate = new DataTemplate(typeof(TaskView)),
                ItemsSource = mTimeTrackerPageViewModel.ObsColTaskViewModels
            };

            mStkVertical = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { mStkTask, mListViewTaskViews }
            };

            Content = mStkVertical;
        }

        private void MBtnTask_Clicked(object sender, EventArgs e)
        {
            mTimeTrackerPageViewModel.AddTaskCommand.Execute(mBtnTask.Text);
        }
    }
}
