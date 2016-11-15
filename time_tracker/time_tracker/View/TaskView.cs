using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using time_tracker.Model;
using time_tracker.ViewModel;
using Xamarin.Forms;

namespace time_tracker.View
{
    public class TaskView : ViewCell
    {
        private Label mLblDesc;
        private Label mLblHours;

        private StackLayout mStackLayout;

        public TaskView()
        {
            mLblDesc = new Label();
            try
            {
                mLblDesc.SetBinding<TaskViewModel>(Label.TextProperty, vm => vm.MTaskModel.Description, BindingMode.OneWay);
            }
            catch { }

            mLblHours = new Label();
            mLblHours.SetBinding<TaskViewModel>(Label.TextProperty, vm => vm.MTaskModel, BindingMode.OneWay, new TaskTimeConverter());

            mStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {mLblDesc, mLblHours}
            };

            View = mStackLayout;
        }

        private class TaskTimeConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                TaskModel tm = value as TaskModel;
                if(tm != null)
                {
                    return tm.GetTimeString();
                }
                else
                {
                    return "No times";
                }
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}
