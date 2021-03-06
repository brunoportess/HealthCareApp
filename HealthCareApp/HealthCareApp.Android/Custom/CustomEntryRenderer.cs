﻿using Android.Content;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Util;
using HealthCareApp.Custom;
using HealthCareApp.Droid.Custom;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace HealthCareApp.Droid.Custom
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        { }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {

                var view = (CustomEntry)Element;
                var _gradientBackground = new GradientDrawable();
                if (view.IsCurvedCornersEnabled)
                {


                    // creating gradient drawable for the curved background  

                    _gradientBackground.SetShape(ShapeType.Rectangle);
                    _gradientBackground.SetColor(view.BackgroundColor.ToAndroid());

                    // Thickness of the stroke line  
                    _gradientBackground.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());

                    // Radius for the curves  
                    _gradientBackground.SetCornerRadius(
                        DpToPixels(this.Context, Convert.ToSingle(view.CornerRadius)));
                }

                if (view.HideUnderline)
                {
                    _gradientBackground.SetColor(global::Android.Graphics.Color.Transparent);

                    Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);

                }


                // set the background of the   
                Control.SetBackground(_gradientBackground);

                // Set padding for the internal text from border  
                Control.SetPadding(
                    (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingTop,
                    (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingBottom);

            }
        }
        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}