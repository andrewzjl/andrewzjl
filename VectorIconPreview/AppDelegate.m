//
//  AppDelegate.m
//  VectorIconPreview
//
//  Created by Zeng Jinliang on 1/21/16.
//  Copyright © 2016 Microstrategy. All rights reserved.
//

#import "AppDelegate.h"
#import "MSIIconInfo.h"

@interface AppDelegate ()

@property (weak) IBOutlet NSWindow *window;

@property (weak) IBOutlet NSTextField *folderOfIconFont;
@property (weak) IBOutlet NSButton *buttonToBrowse;

@property (weak) IBOutlet NSTextField *iconName;
@property (weak) IBOutlet NSTextField *iconCode;
@property (weak) IBOutlet NSTextField *iconColor;
@property (weak) IBOutlet NSTextField *iconAlpha;
@property (weak) IBOutlet NSTextField *iconWidth;
@property (weak) IBOutlet NSTextField *iconHeight;
@property (weak) IBOutlet NSTextField *iconImage;
@property (weak) IBOutlet NSButton *saveItemButton;

@property (nonatomic, strong) NSCollectionView *collectionView;

@property (weak, nonatomic) NSMutableArray *collectionViewArray;
@end

@implementation AppDelegate

@synthesize collectionView;
@synthesize collectionViewArray;

static NSString * CollectionViewCell = @"NSCollectionViewCell";

- (void)applicationDidFinishLaunching:(NSNotification *)aNotification {
    // Insert code here to initialize your application
    [[NSUserDefaults standardUserDefaults] setBool:YES forKey:@"NSConstraintBasedLayoutVisualizeMutuallyExclusiveConstraints"];
    
    [self setupCollectionView];
}

- (void)applicationWillTerminate:(NSNotification *)aNotification {
    // Insert code here to tear down your application
}

- (void)awakeFromNib {
    
    MSIIconInfo * pm1 = [[MSIIconInfo alloc] init];
    pm1.name = @"John Appleseed";
    pm1.image = [NSImage imageNamed:NSImageNameAdvanced];
    
    MSIIconInfo * pm2 = [[MSIIconInfo alloc] init];
    pm2.name = @"Jane Carson";
    pm2.image = [NSImage imageNamed:NSImageNameAdvanced];
    
    MSIIconInfo * pm3 = [[MSIIconInfo alloc] init];
    pm3.name = @"Ben Alexander";
    pm3.image = [NSImage imageNamed:NSImageNameAdvanced];
    
    NSMutableArray * tempArray = [NSMutableArray arrayWithObjects:pm1, pm2, pm3, nil];
    [self setCollectionViewArray:tempArray];
    
}

-(void)insertObject:(MSIIconInfo *)p inCollectionViewArrayAtIndex:(NSUInteger)index {
    [collectionViewArray insertObject:p atIndex:index];
}

-(void)removeObjectFromCollectionViewArrayAtIndex:(NSUInteger)index {
    [collectionViewArray removeObjectAtIndex:index];
}

-(void)setCollectionViewArrayArray:(NSMutableArray *)a {
    collectionViewArray = a;
}

-(NSArray*)collectionViewArray {
    return collectionViewArray;
}

- (void)setupCollectionView {
//    collectionView = [[NSCollectionView alloc] init];
//    //[collectionView registerClass:[NSCollectionViewItem class] forItemWithIdentifier:CollectionViewCell];
//    
//    // add constraint for auto layout
//    collectionView.translatesAutoresizingMaskIntoConstraints = NO;
//    NSView *parentView = [[self window] contentView];
//    [parentView addSubview:collectionView];
//    [parentView addConstraint:[NSLayoutConstraint constraintWithItem:collectionView attribute:NSLayoutAttributeBottom relatedBy:NSLayoutRelationEqual toItem:[self saveItemButton] attribute:NSLayoutAttributeBottom multiplier:1 constant:0]];
//    [parentView addConstraint:[NSLayoutConstraint constraintWithItem:collectionView attribute:NSLayoutAttributeLeft relatedBy:NSLayoutRelationEqual toItem: [self folderOfIconFont] attribute:NSLayoutAttributeLeft multiplier:1 constant:0]];
//    
//    [parentView addConstraint:[NSLayoutConstraint constraintWithItem:collectionView attribute:NSLayoutAttributeRight relatedBy:NSLayoutRelationEqual toItem:[self buttonToBrowse] attribute:NSLayoutAttributeRight multiplier:1 constant:0]];
//    [parentView addConstraint:[NSLayoutConstraint constraintWithItem:collectionView attribute:NSLayoutAttributeTop relatedBy:NSLayoutRelationEqual toItem: [self folderOfIconFont] attribute:NSLayoutAttributeBottom multiplier:1 constant:8]];
//    
//    NSMutableArray * imageList = [NSMutableArray arrayWithCapacity:10];
//    for (int i = 0; i < 10; i++) {
//        NSImage * image = [NSImage imageNamed:NSImageNameAdvanced];
//        [imageList addObject:image];
//        
//    }
//    [collectionView setContent:imageList];
//    collectionView.itemPrototype =  [self.storyboard instantiateControllerWithIdentifier: @ "collection_item"];;
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
        
        [self reloadData];
    }
}

- (void)reloadData {
    
}

@end
