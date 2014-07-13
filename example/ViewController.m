//
//  ViewController.m
//  RNFrostedSidebar
//
//  Created by Ryan Nystrom on 8/13/13.
//  Copyright (c) 2013 Ryan Nystrom. All rights reserved.
//

#import "ViewController.h"

@interface ViewController ()
@property (nonatomic, strong) NSMutableIndexSet *optionIndices;
@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.optionIndices = [[NSMutableIndexSet alloc] init];
}

- (IBAction)onBurger:(id)sender {
    NSArray *images = @[
                        [UIImage imageNamed:@"menu-icon-01"],
                        [UIImage imageNamed:@"menu-icon-02"],
                        [UIImage imageNamed:@"menu-icon-03"],
                        [UIImage imageNamed:@"menu-icon-04"],
                        ];
    NSArray *titles = @[
                          @"Activities",
                          @"Invite Friends",
                          @"Help",
                          @"Profile"];
    NSArray *colors = @[
                        [UIColor colorWithRed:255/255.f green:255/255.f blue:255/255.f alpha:1],
                        [UIColor colorWithRed:255/255.f green:255/255.f blue:255/255.f alpha:1],
                        [UIColor colorWithRed:255/255.f green:255/255.f blue:255/255.f alpha:1],
                        [UIColor colorWithRed:255/255.f green:255/255.f blue:255/255.f alpha:1],
                        ];
    
    RNFrostedSidebar *callout = [[RNFrostedSidebar alloc] initWithImages:images titles:titles selectedIndices:self.optionIndices borderColors:colors];
//    RNFrostedSidebar *callout = [[RNFrostedSidebar alloc] initWithImages:images];
    callout.delegate = self;
    callout.width = 100;
    callout.itemSize = CGSizeMake(60, 85);
    callout.itemBackgroundColor = [UIColor clearColor];
//    callout.showFromRight = YES;
    [callout show];
}

#pragma mark - RNFrostedSidebarDelegate

- (void)sidebar:(RNFrostedSidebar *)sidebar didTapItemAtIndex:(NSUInteger)index {
    NSLog(@"Tapped item at index %i",index);
    if (index == 3) {
        [sidebar dismissAnimated:YES completion:nil];
    }
}

- (void)sidebar:(RNFrostedSidebar *)sidebar didEnable:(BOOL)itemEnabled itemAtIndex:(NSUInteger)index {
    if (itemEnabled) {
        [self.optionIndices addIndex:index];
    }
    else {
        [self.optionIndices removeIndex:index];
    }
}

@end
