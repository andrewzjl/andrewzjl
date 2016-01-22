//
//  NSColor+Getters.m
//  VectorIconPreview
//
//  Created by Zeng Jinliang on 1/22/16.
//  Copyright © 2016 Microstrategy. All rights reserved.
//

#import "NSColor+Getters.h"

@implementation NSColor (Getters)

+ (NSColor*) colorWithInt: (int) colorInt alpha:(CGFloat)alpha		// as 0x00RRGGBB
{
    float	red   = (colorInt >> 16) & 0xff;
    float	green = (colorInt >> 8)  & 0xff;
    float	blue  =  colorInt		 & 0xff;
    
    return [NSColor colorWithRed: red / 255.0
                           green: green / 255.0
                            blue: blue / 255.0
                           alpha: alpha ];
}

@end
