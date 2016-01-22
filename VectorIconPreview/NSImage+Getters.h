//
//  NSImage+Getters.h
//  VectorIconPreview
//
//  Created by Zeng Jinliang on 1/21/16.
//  Copyright © 2016 Microstrategy. All rights reserved.
//

#import <Cocoa/Cocoa.h>

@interface NSImage (Getters)

+ (NSImage *)grabImage:(NSView *)view;

- (NSImage*)imageWithColor:(NSColor *)iColor;
- (NSImage*)imageWithSize:(CGSize)size;

@end
