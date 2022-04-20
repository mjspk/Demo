using Demo.iOS;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(DatePicker), typeof(CustomDatePickerRender))]
namespace Demo.iOS
{
    class CustomDatePickerRender : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            var view = e.NewElement as DatePicker;
            this.Control.BorderStyle = UITextBorderStyle.None;
        }
    }
}
