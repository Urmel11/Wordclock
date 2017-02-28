using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Wordclock.Mobile.ViewModel
{
	class NumberValidatorBehavior : Behavior<Entry>
	{
		static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(NumberValidatorBehavior), false);

		public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

		public bool IsValid
		{
			get { return (bool)base.GetValue(IsValidProperty); }
			private set { base.SetValue(IsValidPropertyKey, value); }
		}

		protected override void OnDetachingFrom(Entry bindable)
		{
			bindable.TextChanged -= OnTextChanged;
		}

		private void OnTextChanged(object sender, TextChangedEventArgs e)
		{
			int test = 0;
			IsValid = int.TryParse(e.NewTextValue, out test) && (test > 0);

			((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
		}

		protected override void OnAttachedTo(Entry bindable)
		{
			bindable.TextChanged += OnTextChanged;
		}
	}
}
