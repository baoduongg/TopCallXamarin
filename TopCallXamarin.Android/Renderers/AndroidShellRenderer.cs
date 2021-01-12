using System;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Google.Android.Material.BottomNavigation;
using Java.Lang;
using TopCallXamarin.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Shell), typeof(AndroidShellRenderer))]
namespace TopCallXamarin.Droid.Renderers
{
    public class AndroidShellRenderer : ShellRenderer
    {
        public AndroidShellRenderer(Context context) : base(context)
        {
        }

        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem shellItem)
        {
            return new AndroidShellItemRenderer(this);
        }
    }

    public class AndroidShellItemRenderer : ShellItemRenderer
    {
        BottomNavigationView _bottomView;

        public AndroidShellItemRenderer(IShellContext shellContext) : base(shellContext)
        {
        }

        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var outerlayout = base.OnCreateView(inflater, container, savedInstanceState);

            _bottomView = outerlayout.FindViewById<BottomNavigationView>(Resource.Id.bottomtab_tabbar);
            _bottomView.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilityLabeled;
            BottomNavigationMenuView menuView = (BottomNavigationMenuView)_bottomView.GetChildAt(0);
            menuView.UpdateMenuView();
            outerlayout.Invalidate();
            return outerlayout;
        }
    }

}
