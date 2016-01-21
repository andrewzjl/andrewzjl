//
//  AppDelegate.m
//  VectorIconPreview
//
//  Created by Zeng Jinliang on 1/21/16.
//  Copyright © 2016 Microstrategy. All rights reserved.
//

#import "AppDelegate.h"

@interface AppDelegate ()

@property (weak) IBOutlet NSWindow *window;

@property (weak) IBOutlet NSTextField *folderOfIconFont;
@property (weak) IBOutlet NSButton *buttonToBrowse;

@property (weak) IBOutlet NSScrollView *iconCollectionView;

@property (weak) IBOutlet NSTextField *iconName;
@property (weak) IBOutlet NSTextField *iconCode;
@property (weak) IBOutlet NSTextField *iconColor;
@property (weak) IBOutlet NSTextField *iconAlpha;
@property (weak) IBOutlet NSTextField *iconWidth;
@property (weak) IBOutlet NSTextField *iconHeight;
@property (weak) IBOutlet NSTextField *iconImage;

@end

@implementation AppDelegate

- (void)applicationDidFinishLaunching:(NSNotification *)aNotification {
    // Insert code here to initialize your application
}

- (void)applicationWillTerminate:(NSNotification *)aNotification {
    // Insert code here to tear down your application
}

@end
