using System.ComponentModel;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Demo.Controls;
using Demo.Droid.Randerers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderEntry), typeof(BorderEntryRenderer))]
namespace Demo.Droid.Randerers
{
    public class BorderEntryRenderer : EntryRenderer
    {
        BorderEntry element;

        private BorderRenderer _renderer;
        private const GravityFlags DefaultGravity = GravityFlags.CenterVertical;
        public BorderEntryRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            element = (BorderEntry)this.Element;


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
            var entryEx = Element as BorderEntry;
            if (e.PropertyName == BorderEntry.BorderWidthProperty.PropertyName ||
                e.PropertyName == BorderEntry.BorderColorProperty.PropertyName ||
                e.PropertyName == BorderEntry.BorderRadiusProperty.PropertyName ||
                e.PropertyName == BorderEntry.BackgroundColorProperty.PropertyName)
            {
                UpdateBackground(entryEx);
            }
            else if (e.PropertyName == BorderEntry.LeftPaddingProperty.PropertyName ||
                e.PropertyName == BorderEntry.RightPaddingProperty.PropertyName)
            {
                UpdatePadding(entryEx);
            }
            else if (e.PropertyName == BorderEntry.HorizontalTextAlignmentProperty.PropertyName)
            {
                UpdateTextAlighnment(entryEx);
            }
            else if (e.PropertyName == BorderEntry.LineColorProperty.PropertyName)
            {
                SetColor(entryEx.LineColor.ToAndroid());
            }
        }
        public void SetColor(Android.Graphics.Color color)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Control.BackgroundTintList = ColorStateList.ValueOf(color);
            }
            else
            {
                Control.Background.SetColorFilter(color, PorterDuff.Mode.SrcAtop);
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



        private void UpdateBackground(BorderEntry entryEx)
        {
            if (_renderer != null)
            {
                _renderer.Dispose();
                _renderer = null;
            }
            _renderer = new BorderRenderer();

            Control.Background = _renderer.GetBorderBackground(entryEx.BorderColor, entryEx.FillColor, entryEx.BorderWidth, entryEx.BorderRadius);
        }

        private void UpdatePadding(BorderEntry entryEx)
        {
            Control.SetPadding((int)Forms.Context.ToPixels(entryEx.LeftPadding), 0,
                (int)Forms.Context.ToPixels(entryEx.RightPadding), 0);
        }

        private void UpdateTextAlighnment(BorderEntry entryEx)
        {
            var gravity = DefaultGravity;
            switch (entryEx.HorizontalTextAlignment)
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