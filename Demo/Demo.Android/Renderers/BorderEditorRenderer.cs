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

[assembly: ExportRenderer(typeof(BorderEditor), typeof(BorderEditorRenderer))]
namespace Demo.Droid.Randerers
{
    public class BorderEditorRenderer : EditorRenderer
    {
        BorderEditor element;

        private BorderRenderer _renderer;
        private const GravityFlags DefaultGravity = GravityFlags.CenterVertical;
        public BorderEditorRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            element = (BorderEditor)this.Element;


            var editText = this.Control;
            Control.Gravity = DefaultGravity;
            UpdateBackground(element);
            UpdatePadding(element);
            editText.CompoundDrawablePadding = 25;

        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Element == null)
                return;
            var EditorEx = Element as BorderEditor;
            if (e.PropertyName == BorderEditor.BorderWidthProperty.PropertyName ||
                e.PropertyName == BorderEditor.BorderColorProperty.PropertyName ||
                e.PropertyName == BorderEditor.BorderRadiusProperty.PropertyName ||
                e.PropertyName == BorderEditor.BackgroundColorProperty.PropertyName)
            {
                UpdateBackground(EditorEx);
            }
            else if (e.PropertyName == BorderEditor.LeftPaddingProperty.PropertyName ||
                e.PropertyName == BorderEditor.RightPaddingProperty.PropertyName)
            {
                UpdatePadding(EditorEx);
            }
          
            else if (e.PropertyName == BorderEditor.LineColorProperty.PropertyName)
            {
                SetColor(EditorEx.LineColor.ToAndroid());
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



        private void UpdateBackground(BorderEditor EditorEx)
        {
            if (_renderer != null)
            {
                _renderer.Dispose();
                _renderer = null;
            }
            _renderer = new BorderRenderer();

            Control.Background = _renderer.GetBorderBackground(EditorEx.BorderColor, EditorEx.FillColor, EditorEx.BorderWidth, EditorEx.BorderRadius);
        }

        private void UpdatePadding(BorderEditor EditorEx)
        {
            Control.SetPadding((int)Forms.Context.ToPixels(EditorEx.LeftPadding), 0,
                (int)Forms.Context.ToPixels(EditorEx.RightPadding), 0);
        }



    }
}