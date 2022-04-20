using System.ComponentModel;
using Android.Content;
using Android.Views;
using Demo.Controls;
using Demo.Droid.Randerers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderTimePicker), typeof(BorderTimePickerRenderer))]
namespace Demo.Droid.Randerers
{

    public class BorderTimePickerRenderer : TimePickerRenderer
    {
        BorderTimePicker element;

        private BorderRenderer _renderer;
        private const GravityFlags DefaultGravity = GravityFlags.CenterVertical;
        public BorderTimePickerRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            element = (BorderTimePicker)this.Element;


            var editText = this.Control;
            Control.Gravity = DefaultGravity;
            UpdateBackground(element);
            UpdatePadding(element);
            UpdateTextAlighnment(element);
            editText.CompoundDrawablePadding = 25;

        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Element == null)
                return;
            var TimePickerEx = Element as BorderTimePicker;
            if (e.PropertyName == BorderTimePicker.BorderWidthProperty.PropertyName ||
                e.PropertyName == BorderTimePicker.BorderColorProperty.PropertyName ||
                e.PropertyName == BorderTimePicker.BorderRadiusProperty.PropertyName ||
                e.PropertyName == BorderTimePicker.BackgroundColorProperty.PropertyName)
            {
                UpdateBackground(TimePickerEx);
            }
            else if (e.PropertyName == BorderTimePicker.LeftPaddingProperty.PropertyName ||
                e.PropertyName == BorderTimePicker.RightPaddingProperty.PropertyName)
            {
                UpdatePadding(TimePickerEx);
            }
            else if (e.PropertyName == BorderTimePicker.HorizontalTextAlignmentProperty.PropertyName)
            {
                UpdateTextAlighnment(TimePickerEx);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (_renderer != null)
                {
                    _renderer.Dispose();
                    _renderer = null;
                }
            }
        }



        private void UpdateBackground(BorderTimePicker TimePickerEx)
        {
            if (_renderer != null)
            {
                _renderer.Dispose();
                _renderer = null;
            }
            _renderer = new BorderRenderer();

            Control.Background = _renderer.GetBorderBackground(TimePickerEx.BorderColor, TimePickerEx.FillColor, TimePickerEx.BorderWidth, TimePickerEx.BorderRadius);
        }

        private void UpdatePadding(BorderTimePicker TimePickerEx)
        {
            Control.SetPadding((int)Forms.Context.ToPixels(TimePickerEx.LeftPadding), 0,
                (int)Forms.Context.ToPixels(TimePickerEx.RightPadding), 0);
        }

        private void UpdateTextAlighnment(BorderTimePicker TimePickerEx)
        {
            var gravity = DefaultGravity;
            switch (TimePickerEx.HorizontalTextAlignment)
            {
                case Xamarin.Forms.TextAlignment.Start:
                    gravity |= GravityFlags.Start;
                    break;
                case Xamarin.Forms.TextAlignment.Center:
                    gravity |= GravityFlags.CenterHorizontal;
                    break;
                case Xamarin.Forms.TextAlignment.End:
                    gravity |= GravityFlags.End;
                    break;
            }
            Control.Gravity = gravity;
        }


    }
}