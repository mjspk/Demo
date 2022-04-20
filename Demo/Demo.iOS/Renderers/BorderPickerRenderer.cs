using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using Demo.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Demo.iOS.Renderers;

[assembly: ExportRenderer(typeof(BorderPicker), typeof(BorderPickerRenderer))]
namespace Demo.iOS.Renderers
{
    public class BorderPickerRenderer : PickerRenderer
    {
        private BorderPicker element;

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            element = (BorderPicker)this.Element;
            Control.BorderStyle = UITextBorderStyle.None;
            UpdateBorderWidth();
            UpdateBorderColor();
            UpdateBorderRadius();
            Control.ClipsToBounds = true;


        }
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (this.Element == null)
                return;
            if (e.PropertyName == BorderPicker.BorderWidthProperty.PropertyName)
            {
                UpdateBorderWidth();
            }
            else if (e.PropertyName == BorderPicker.BorderColorProperty.PropertyName)
            {
                UpdateBorderColor();
            }
            else if (e.PropertyName == BorderPicker.BorderRadiusProperty.PropertyName)
            {
                UpdateBorderRadius();
            }
           
        }



        private void UpdateBorderWidth()
        {
            var PickerEx = this.Element as BorderPicker;
            Control.Layer.BorderWidth = PickerEx.BorderWidth;
        }

        private void UpdateBorderColor()
        {
            var PickerEx = this.Element as BorderPicker;
            Control.Layer.BorderColor = PickerEx.BorderColor.ToUIColor().CGColor;
        }

        private void UpdateBorderRadius()
        {
            var PickerEx = this.Element as BorderPicker;
            Control.Layer.CornerRadius = (nfloat)PickerEx.BorderRadius;
        }

       
    }
}