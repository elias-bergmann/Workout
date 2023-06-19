﻿using Work0ut.Service;
using Work0ut.ViewModel;

namespace Work0ut;

public partial class MovementListPage : ContentPage
{
    public MovementListPage(MovementListViewModel exerciceListViewModel)
	{
		InitializeComponent();
		BindingContext = exerciceListViewModel;
	}
}

