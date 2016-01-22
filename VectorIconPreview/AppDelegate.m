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

- (IBAction)openFolder:(NSButton *)sender {
    // Create the File Open Dialog class.
    NSOpenPanel* openDlg = [NSOpenPanel openPanel];
    
    // Enable the selection of directory in the dialog.
    [openDlg setCanChooseDirectories:YES];
    
    // Can't select a file
    [openDlg setCanChooseFiles:NO];
    
    // Multiple files not allowed
    [openDlg setAllowsMultipleSelection:NO];
    
    // Display the dialog. If the OK button was pressed,
    // process the files.
    if ([openDlg runModal] == NSModalResponseOK)
    {
        // Get an array containing the full filenames of all
        // files and directories selected.
        NSArray* urls = [openDlg URLs];
        
        // Loop through all the files and process them.
        for(int i = 0; i < [urls count]; i++ )
        {
            NSURL* url = [urls objectAtIndex:i];
            NSLog(@"Url: %@", url);
            [self.folderOfIconFont setStringValue:url.path];
        }
    }
}

@end
