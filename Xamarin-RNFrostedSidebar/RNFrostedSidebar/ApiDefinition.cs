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

    [Export ("initWithImages:titles:selectedIndices:borderColors:")]
    IntPtr Constructor (UIImage [] images, string [] titles, NSIndexSet selectedIndices, UIColor [] colors);

    [Export ("initWithImages:titles:selectedIndices:")]
    IntPtr Constructor (UIImage [] images, string [] titles, NSIndexSet selectedIndices);

    [Export ("initWithImages:titles:")]
    IntPtr Constructor (UIImage [] images, string [] titles);

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
}
