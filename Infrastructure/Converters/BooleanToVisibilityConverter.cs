﻿using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TFS_UI_mvvm.Infrastructure.Converters;

public class BooleanToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (value is bool boolean && boolean) ? Visibility.Visible : Visibility.Collapsed;
    }



    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
