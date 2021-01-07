using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using static Lab6.data.repositories.projects.models.Project;

namespace Lab5.presentation.UserEditScreen.converters
{
    class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (ProjectStatus)value;

            switch (status)
            {
                case ProjectStatus.PENDING:
                    {
                        return "Pending";
                    };
                case ProjectStatus.WAITING:
                    {
                        return "Waiting";
                    }
                case ProjectStatus.IN_PROGRESS:
                    {
                        return "In progress";
                    }
                case ProjectStatus.VERIFIED:
                    {
                        return "Verified";
                    }
                case ProjectStatus.COMPLETED:
                    {
                        return "Completed";
                    }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var statusString = (string)value;

            switch (statusString)
            {
                case "Pending":
                    {
                        return ProjectStatus.PENDING;
                    }
                case "Waiting":
                    {
                        return ProjectStatus.WAITING;
                    }
                case "In progress":
                    {
                        return ProjectStatus.IN_PROGRESS;
                    }
                case "Verified":
                    {
                        return ProjectStatus.VERIFIED;
                    }
                case "Completed":
                    {
                        return ProjectStatus.COMPLETED;
                    }
            }

            return null;
        }
    }
}
