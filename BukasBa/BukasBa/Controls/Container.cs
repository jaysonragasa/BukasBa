using Xamarin.Forms;

namespace BukasBa.UI.Controls
{
    public class Container : Grid
    {
        Grid _loader;
        ActivityIndicator _activityIndicator;

        public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(nameof(IsLoading), typeof(bool), typeof(Container), false, BindingMode.TwoWay, propertyChanged: OnIsLoadingChanged);
        public static readonly BindableProperty BackgroundProperty = BindableProperty.Create(nameof(Background), typeof(Color), typeof(Container), Color.FromHex("#1f000000"), BindingMode.TwoWay, propertyChanged: BackgroundChanged);
        public static readonly BindableProperty ActivityColorProperty = BindableProperty.Create(nameof(ActivityColor), typeof(Color), typeof(Container), Color.FromHex("#FFDD2C28"), BindingMode.TwoWay, propertyChanged: ActivityColorChanged);

        public bool IsLoading
        {
            get => (bool)GetValue(IsLoadingProperty);
            set => SetValue(IsLoadingProperty, value);
        }

        public Color Background
        {
            get => (Color)GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }

        public Color ActivityColor
        {
            get => (Color)GetValue(ActivityColorProperty);
            set => SetValue(ActivityColorProperty, value);
        }

        public static void OnIsLoadingChanged(BindableObject bindable, object oldValye, object newValue)
        {
            var ctl = (Container)bindable;
            if (ctl._loader == null) return;

            var newval = (bool)newValue;
            ctl._loader.IsVisible = newval;
        }

        public static void BackgroundChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var ctl = (Container)bindable;
            if (ctl._loader == null) return;

            var newval = (Color)newValue;
            ctl._loader.BackgroundColor = newval;
        }

        public static void ActivityColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var ctl = (Container)bindable;
            if (ctl._activityIndicator == null) return;

            var newval = (Color)newValue;
            ctl._activityIndicator.Color = newval;
        }

        public Container()
        {

        }

        public void Init()
        {
            _loader = new Grid()
            {
                BackgroundColor = this.Background,
                IsVisible = false
            };

            _activityIndicator = new ActivityIndicator()
            {
                WidthRequest = 64,
                HeightRequest = 64,
                IsEnabled = true,
                IsRunning = true,
                IsVisible = true,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Color = this.ActivityColor
            };


            _loader.Children.Add(_activityIndicator);

            this.Children.Add(_loader);
        }
    }
}