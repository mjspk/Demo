using Demo.iOS.Renderers;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Material.iOS;
using Xamarin.Forms.Platform.iOS;
//[assembly: ExportRenderer(typeof(Button), typeof(ButtonCustomRenderer))]
namespace Demo.iOS.Renderers
{
    public class ButtonCustomRenderer : MaterialButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Element != null)
            {
                Element.TextTransform = TextTransform.None;
            }
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            // Left-align the image and center the text
            // Taken from https://stackoverflow.com/a/71044012/238419
            if (Element.ContentLayout.Position == Button.ButtonContentLayout.ImagePosition.Right)
            {
                const int imageMargin = 10; // This might need to get multiplied by the screen density, not sure yet.  I'll update this later if it does.
                nfloat imageOffset = Control.ImageView.Frame.Right + imageMargin;
                Control.ImageEdgeInsets = new UIEdgeInsets(0, imageOffset, 0, imageOffset);

                nfloat textOffset = Control.TitleLabel.Frame.Right + (Control.Frame.Width - Control.TitleLabel.Frame.Width) / 2;
                Control.TitleEdgeInsets = new UIEdgeInsets(0, textOffset, 0,textOffset);
            }
        }
    }
}