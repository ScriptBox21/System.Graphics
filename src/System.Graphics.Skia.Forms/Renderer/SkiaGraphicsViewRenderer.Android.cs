﻿using System.ComponentModel;
using System.Graphics.Forms;
using System.Graphics.Skia.Forms;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(System.Graphics.Forms.SkiaGraphicsView), typeof(SkiaGraphicsViewRenderer))]
namespace System.Graphics.Skia.Forms
{
    [Preserve]
    public class SkiaGraphicsViewRenderer : ViewRenderer<SkiaGraphicsView, System.Graphics.Skia.Views.SkiaGraphicsView>
    {
        public SkiaGraphicsViewRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<SkiaGraphicsView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe from event handlers and cleanup any resources
                SetNativeControl(null);
            }

            if (e.NewElement != null)
            {
                SetNativeControl(new System.Graphics.Skia.Views.SkiaGraphicsView(Context));
            }
        }

        protected override void OnElementPropertyChanged(
            object sender,
            PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(SkiaGraphicsView.Drawable))
                UpdateDrawable();
        }

        private void UpdateDrawable()
        {
            Control.Drawable = Element.Drawable;
        }
    }
}