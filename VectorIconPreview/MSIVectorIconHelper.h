//
//  MSIVectorIconHelper.h
//  VectorFont
//
//  Created by Zeng Jinliang on 12/18/15.
//  Copyright © 2015 Microstrategy. All rights reserved.
//

#import <AppKit/AppKit.h>

#ifndef GetNameInFinalBundle
#define GetNameInFinalBundle(file) [@"FinalBundle.bundle/Contents/Resources/" stringByAppendingPathComponent:file]
#endif

@interface MSIVectorIconHelper : NSObject

+ (void)setConfigurePath:(nonnull NSString *)path;
/*
 If Vector Icon is available, generate image from configure of MSTRVectorIcon.plist
 -[vectorIconName] example: data_modified
    -code  identify code in ttf, to use vector icon, it's reqNSrment. Example: e912
    -color optional. Example: 0xFFFFFF
    -alpha optional. Range: 0.0~1.0.
    -image To customize an icon by image. It works when code is empty or vector icon is disabled.
    -iconWidth / iconHeight optional.
 
 If no input image size or size is CGZero, default size will be 256*256. Bigger size is less clearity.
 If no color/alpha configured in plist, generated image will apply the input default color.
*/
+ (nullable NSImage *)generateImage:(nonnull NSString *)iconName;
+ (nullable NSImage *)generateImage:(nonnull NSString *)iconName imageSize:(CGSize)size;
+ (nullable NSImage *)generateImage:(nonnull NSString *)iconName colorWithInt:(NSInteger)colorInt;
+ (nullable NSImage *)generateImage:(nonnull NSString *)iconName colorWithInt:(NSInteger)colorInt alpha:(CGFloat)alpha;
+ (nullable NSImage *)generateImage:(nonnull NSString *)iconName imageSize:(CGSize)size color:(nullable NSColor *)defaultColor;

// Use vector icon as text. It's based on vector icon code only.
+ (nullable NSAttributedString *)generateIconText:(nonnull NSString *)iconName fontSize:(NSInteger)size color:(nullable NSColor *)color;

@end
