using System.ComponentModel;
using Android.Content;
using Android.Views;
using Demo.Controls;
using Demo.Droid.Randerers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderPicker), typeof(BorderPickerRenderer))]
namespace Demo.Droid.Randerers
{

    public class BorderPickerRenderer : PickerRenderer
    {
        BorderPicker element;

        private BorderRenderer _renderer;
        private const GravityFlags DefaultGravity = GravityFlags.CenterVertical;
        public BorderPickerRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            element = (BorderPicker)this.Element;


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
            var PickerEx = Element as BorderPicker;
            if (e.PropertyName == BorderPicker.BorderWidthProperty.PropertyName ||
                e.PropertyName == BorderPicker.BorderColorProperty.PropertyName ||
                e.PropertyName == BorderPicker.BorderRadiusProperty.PropertyName ||
                e.PropertyName == BorderPicker.BackgroundColorProperty.PropertyName)
            {
                UpdateBackground(PickerEx);
            }
            else if (e.PropertyName == BorderPicker.LeftPaddingProperty.PropertyName ||
                e.PropertyName == BorderPicker.RightPaddingProperty.PropertyName)
            {
                UpdatePadding(PickerEx);
            }
            else if (e.PropertyName == Picker.HorizontalTextAlignmentProperty.PropertyName)
            {
                UpdateTextAlighnment(PickerEx);
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



        private void UpdateBackground(BorderPicker PickerEx)
        {
            if (_renderer != null)
            {
                _renderer.Dispose();
                _renderer = null;
            }
            _renderer = new BorderRenderer();

            Control.Background = _renderer.GetBorderBackground(PickerEx.BorderColor, PickerEx.FillColor, PickerEx.BorderWidth, PickerEx.BorderRadius);
        }

        private void UpdatePadding(BorderPicker PickerEx)
        {
            Control.SetPadding((int)Forms.Context.ToPixels(PickerEx.LeftPadding), 0,
                (int)Forms.Context.ToPixels(PickerEx.RightPadding), 0);
        }

        private void UpdateTextAlighnment(BorderPicker PickerEx)
        {
            var gravity = DefaultGravity;
            switch (PickerEx.HorizontalTextAlignment)
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