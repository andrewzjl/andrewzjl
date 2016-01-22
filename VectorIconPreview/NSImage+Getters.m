//
//  NSImage+Getters.m
//  VectorIconPreview
//
//  Created by Zeng Jinliang on 1/21/16.
//  Copyright © 2016 Microstrategy. All rights reserved.
//

#import "NSImage+Getters.h"

@implementation NSImage (Getters)

+ (NSImage *)grabImage:(NSView *)view {
    // create a "canvas" (image context) to draw in
    NSImage *image = [[NSImage alloc] initWithSize:view.bounds.size];
    [image lockFocus];
    
    // Make the CALayer to draw in our "canvas"
    CGContextRef ctx = [NSGraphicsContext currentContext].graphicsPort;
    
    // Fetch an UIImage of our "canvas"
    [view.layer renderInContext:ctx];
    
    // stop the "canvas" from accepting any input
    [image unlockFocus];
    
    return image;
}

- (NSImage*)imageWithColor:(NSColor *)iColor {
    CGSize size = self.size;
    [self lockFocus];
    [iColor drawSwatchInRect:NSMakeRect(0, 0, size.width, size.height)];
    [self unlockFocus];
    return self;
}

- (NSImage*)imageWithSize:(CGSize)size {
    return self;
}

@end
