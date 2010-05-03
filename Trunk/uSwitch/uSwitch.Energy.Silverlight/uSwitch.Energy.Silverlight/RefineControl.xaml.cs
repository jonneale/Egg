using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using uSwitch.Energy.Silverlight.Presenters;
using uSwitch.Energy.Silverlight.Views;

namespace uSwitch.Energy.Silverlight
{
	public partial class RefineControl : UserControl, IRefineView
	{
		public RefineControl()
		{
			InitializeComponent();

			Loaded += RefineControl_Loaded;
		}

		void RefineControl_Loaded(object sender, RoutedEventArgs e)
		{
			var presenter = new RefinePresenter(this, Dispatcher);
			presenter.Loaded();
		}

		public IEnumerable<string> PaymentMethods
		{
			get
			{
				return (IEnumerable<string>) paymentMethodsCombo.ItemsSource;
			}
			set
			{
				paymentMethodsCombo.ItemsSource = value;
			}
		}

		public bool IsVisible
		{
			get
			{
				return Visibility == Visibility.Visible;
			}
			set
			{
				Visibility = value ? Visibility.Visible : Visibility.Collapsed;
			}
		}
	}
}
