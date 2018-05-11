﻿using System.Windows;
using System.Windows.Controls;

namespace Commons.ControlLibrary
{
    public class AddButton : Button
    {
        static AddButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AddButton), new FrameworkPropertyMetadata(typeof(AddButton)));
        }
    }
}
