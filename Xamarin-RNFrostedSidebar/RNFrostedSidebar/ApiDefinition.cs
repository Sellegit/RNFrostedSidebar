using System.Drawing;
using System;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace RNFrostedSidebarBinding {

  [Model, BaseType (typeof (NSObject)), Protocol]
  public partial interface RNFrostedSidebarDelegate {

    [Export ("sidebar:willShowOnScreenAnimated:")]
    void WillShowOnScreenAnimated (RNFrostedSidebar sidebar, bool animatedYesOrNo);

    [Export ("sidebar:didShowOnScreenAnimated:")]
    void DidShowOnScreenAnimated (RNFrostedSidebar sidebar, bool animatedYesOrNo);

    [Export ("sidebar:willDismissFromScreenAnimated:")]
    void WillDismissFromScreenAnimated (RNFrostedSidebar sidebar, bool animatedYesOrNo);

    [Export ("sidebar:didDismissFromScreenAnimated:")]
    void DidDismissFromScreenAnimated (RNFrostedSidebar sidebar, bool animatedYesOrNo);

    [Export ("sidebar:didTapItemAtIndex:")]
    void DidTapItemAtIndex (RNFrostedSidebar sidebar, uint index);

    [Export ("sidebar:didEnable:itemAtIndex:")]
    void DidEnable (RNFrostedSidebar sidebar, bool itemEnabled, uint index);

    [Export ("sidebar:blurImageForController:")]
    UIImage GetBlurImage (RNFrostedSidebar sidebar, UIViewController controller);
  }

  public delegate void DismissAnimatedCompletionBlock(bool finished);




  [BaseType (typeof (UIViewController))]
  public partial interface RNFrostedSidebar {

    [Static, Export ("visibleSidebar")]
    RNFrostedSidebar VisibleSidebar { get; }

    [Export ("width")]
    float Width { get; set; }

    [Export ("contentView", ArgumentSemantic.Retain)]
    UIScrollView ContentView { get; }

    [Export ("showFromRight")]
    bool ShowFromRight { get; set; }

    [Export ("animationDuration")]
    float AnimationDuration { get; set; }

    [Export ("itemSize", ArgumentSemantic.Assign)]
    SizeF ItemSize { get; set; }

    [Export ("tintColor", ArgumentSemantic.Retain)]
    UIColor TintColor { get; set; }

    [Export ("itemBackgroundColor", ArgumentSemantic.Retain)]
    UIColor ItemBackgroundColor { get; set; }

    [Export ("borderWidth")]
    uint BorderWidth { get; set; }

    [Export ("isSingleSelect")]
    bool IsSingleSelect { get; set; }

    [Export ("delegate", ArgumentSemantic.Assign)]
    NSObject WeakDelegate { get; set; }

    [Wrap ("WeakDelegate")]
    RNFrostedSidebarDelegate Delegate { get; set; }

    [Export ("initWithTitles:selectedIndices:borderColors:imageViews:")]
    IntPtr Constructor (string [] titles, NSIndexSet selectedIndices, UIColor [] colors, UIImageView[] imageViews);

    // deprecated
//    [Export ("initWithImages:titles:selectedIndices:")]
//    IntPtr Constructor (UIImage [] images, string [] titles, NSIndexSet selectedIndices);
//
//    [Export ("initWithImages:titles:")]
//    IntPtr Constructor (UIImage [] images, string [] titles);

    [Export ("show")]
    void Show ();

    [Export ("showAnimated:")]
    void ShowAnimated (bool animated);

    [Export ("showInViewController:animated:")]
    void ShowInViewController (UIViewController controller, bool animated);

    [Export ("dismiss")]
    void Dismiss ();

    [Export ("dismissAnimated:")]
    void DismissAnimated (bool animated);

    [Export ("dismissAnimated:completion:")]
    void DismissAnimated (bool animated, DismissAnimatedCompletionBlock completion);
  }

  [Category, BaseType (typeof (UIImage))]
  public partial interface Rn_Blur_UIImage {

    [Export ("applyBlurWithRadius:tintColor:saturationDeltaFactor:maskImage:")] 
    UIImage ApplyBlurWithRadius (float blurRadius, UIColor tintColor, float saturationDeltaFactor, [NullAllowed] UIImage maskImage);
  }
}
