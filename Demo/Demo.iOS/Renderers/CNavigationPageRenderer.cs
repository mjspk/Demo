
using Demo.iOS.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CNavigationPageRenderer))]

namespace Demo.iOS.Renderers
{
	public class CNavigationPageRenderer : NavigationRenderer
	{

        protected override Task<bool> OnPopToRoot(Page page, bool animated)
        {
            return base.OnPopToRoot(page, false);
        }
        protected override Task<bool> OnPushAsync(Page view, bool animated)
		{
			return base.OnPushAsync(view, false);
		}

		protected override Task<bool> OnPopViewAsync(Page page, bool animated)
		{
			return base.OnPopViewAsync(page, false);
		}

		
	}
}