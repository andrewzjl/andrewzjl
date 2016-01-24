//
//  MSIVectorIconHelper.m
//  VectorFont
//
//  Created by Zeng Jinliang on 12/18/15.
//  Copyright © 2015 Microstrategy. All rights reserved.
//

#import "MSIVectorIconHelper.h"
#import "NSColor+Getters.h"
#import "NSImage+Getters.h"

static NSString *VectorFont = @"iconfont";

@interface MSIVectorIcon : NSTextField

- (void)setIcon:(NSString *)text color:(NSColor *)color;
+ (NSString *)getUnicode:(NSString *)str;

@end

@implementation MSIVectorIcon

- (NSInteger)binarySearchForFontSizeForLabel:(NSTextField *)label withMinFontSize:(NSInteger)minFontSize withMaxFontSize:(NSInteger)maxFontSize withSize:(CGSize)size {
    // If the perfect size can't be found, return the shoddy fit size.
    if (maxFontSize < minFontSize) {
        return minFontSize;
    }
    
    // Find the middle
    NSInteger fontSize = (minFontSize + maxFontSize) / 2;
    
    // Find string size for current font size
    CGSize stringSize = [label.stringValue sizeWithAttributes:@{NSFontAttributeName : [NSFont fontWithName:VectorFont size:fontSize]}];
    
    // EDIT: The next block is modified from the original answer posted in SO to consider the width in the decision. This works much better for certain labels that are too thin and were giving bad results.
    if (stringSize.height >= (size.height - 3) && stringSize.width >= (size.width - 3) && stringSize.height <= (size.height) && stringSize.width <= (size.width)) {
        return fontSize;
    } else if (stringSize.height > size.height || stringSize.width > size.width) {
        return [self binarySearchForFontSizeForLabel:label withMinFontSize:minFontSize withMaxFontSize:fontSize - 1 withSize:size];
    } else {
        return [self binarySearchForFontSizeForLabel:label withMinFontSize:fontSize + 1 withMaxFontSize:maxFontSize withSize:size];
    }
}

#pragma mark - public API
- (void)setIcon:(NSString *)text color:(NSColor *)color {
    NSInteger maxFontSize = 1000;
    NSInteger minFontSize = 8;
    NSInteger fontSize = [self binarySearchForFontSizeForLabel:self withMinFontSize:minFontSize withMaxFontSize:maxFontSize withSize:self.frame.size];
    [self setFont:[NSFont fontWithName:VectorFont size: fontSize]];
    NSString *iconCode = [MSIVectorIcon getUnicode:text];
    [self setStringValue:iconCode];
    [self setTextColor:color];
}

// create unicode string like "\U0000e903" based on input "e903","\\Ue903" etc.
+ (NSString *)getUnicode:(NSString *)str {
    if (!str || [str isEqualToString:@""]) {
        return nil;
    }
    
    NSMutableString *utf8Str = [NSMutableString string];
    // remove the inputed \u, \U, &#x
    str = [str stringByReplacingOccurrencesOfString:@"\\u" withString:@"" options:NSCaseInsensitiveSearch range:(NSRange){0, utf8Str.length}];
    str = [str stringByReplacingOccurrencesOfString:@"&#x" withString:@"" options:NSCaseInsensitiveSearch range:(NSRange){0, utf8Str.length}];
    
    // complete the utf8 str to 8bytes
    NSInteger maskZeroCount = (8 - (str.length % 8)) % 8;
    for (; maskZeroCount > 0; maskZeroCount--) {
        [utf8Str appendString:@"0"];
    }
    [utf8Str appendString:str];
    // get the unicode value, which will generate 4 character shown by UTF8 into 1 Unicode character
    NSMutableString *unicodeStr = [NSMutableString string];
    for (int i = 0; i < utf8Str.length; i += 4) {
        NSString *substr = [utf8Str substringWithRange:(NSRange){i, 4}];
        unichar codeValue = (unichar) strtol([substr UTF8String], NULL, 16);
        // %C means wide character
        if (codeValue > 0) {
            [unicodeStr appendString:[NSString stringWithFormat:@"%C", codeValue]];
        }
    }
    
    return unicodeStr;
}

@end

@interface MSIVectorIconHelper ()

@property (nonatomic) NSString *configurePath;
@property (nonatomic) NSDictionary *configureDictionary;

// if dynamic refresh is YES, check the modified time to keep configure is fresh
@property (nonatomic) BOOL dynamicRefresh;
@property (nonatomic) NSDate *modificationDate;

// use the cached image
@property (nonatomic) NSMutableDictionary *cachedImage;

@end

@implementation MSIVectorIconHelper

static MSIVectorIconHelper* helper = nil;

- (instancetype)init {
    if (self = [super init]) {
        self.configurePath = nil;
        self.configureDictionary = nil;
        self.cachedImage = [[NSMutableDictionary alloc] init];
        
        self.dynamicRefresh = YES;
    }
    return self;
}

- (BOOL)needRefresh {
    if (self.dynamicRefresh) {
        NSDictionary* fileAttribs = [[NSFileManager defaultManager] attributesOfItemAtPath:self.configurePath error:nil];
        NSDate *result = [fileAttribs objectForKey:NSFileModificationDate];
        if (![result isEqualToDate:self.modificationDate]) {
            self.modificationDate = result;
            return YES;
        }
    }
    return NO;
}

+ (void)setConfigurePath:(nonnull NSString *)path {
    helper.configurePath = path;
}

+ (NSDictionary *)configureDictionary {
    if (helper == nil) {
        helper = [[MSIVectorIconHelper alloc] init];
    }
    
    if ([helper.configurePath length] > 0) {
        if (!helper.configureDictionary || [helper needRefresh]) {
            helper.configureDictionary = [NSDictionary dictionaryWithContentsOfFile: helper.configurePath];
        }
    }
    
    return helper.configureDictionary;
}

+ (NSImage *)generateImage:(NSString *)iconName {
    return [MSIVectorIconHelper generateImage:iconName imageSize:CGSizeZero];
}


+ (NSImage *)generateImage:(NSString *)iconName imageSize:(CGSize)size {
    return [MSIVectorIconHelper generateImage:iconName imageSize:size color:nil];
}

+ (nullable NSImage *)generateImage:(nonnull NSString *)iconName colorWithInt:(NSInteger)colorInt {
    return [MSIVectorIconHelper generateImage:iconName colorWithInt:colorInt alpha:1.0];
}

+ (NSImage *)generateImage:(NSString *)iconName colorWithInt:(NSInteger)colorInt alpha:(CGFloat)alpha {
    return [MSIVectorIconHelper generateImage:iconName imageSize:CGSizeZero color:[NSColor colorWithInt:[NSNumber numberWithInteger:colorInt].intValue alpha:alpha]];
}

+ (NSImage *)generateImage:(NSString *)iconName imageSize:(CGSize)size color:(NSColor *)color {
    NSDictionary *cfgDict = [MSIVectorIconHelper configureDictionary];
    BOOL useVectorIcon = YES;
    
    CGSize defaultSize = {256, 256};
    if (CGSizeEqualToSize(size, CGSizeZero)) {
        size = defaultSize;
    }
    NSImage *resultImage = nil;
    // read the icon's configure info, try to use configured color to generate icon, or using image
    NSDictionary *conf = [cfgDict objectForKey:iconName];
    if (conf) {
        // get the color info from config
        NSString * rgbColor = [conf objectForKey:@"color"];
        if ([rgbColor length] > 0) {
            CGFloat alpha = 1.0;
            NSNumber *alphaStr = [conf objectForKey:@"alpha"];
            if (alphaStr) {
                alpha = alphaStr.doubleValue;
            }
            
            if ([rgbColor rangeOfString:@"0x" options:NSCaseInsensitiveSearch].length > 0) {
                unsigned int rgbInt;
                NSScanner* scanner = [NSScanner scannerWithString:rgbColor];
                [scanner scanHexInt:&rgbInt];
                color = [NSColor colorWithInt:rgbInt alpha:alpha];
            } else {
                color = [NSColor colorWithInt:rgbColor.intValue alpha:alpha];
            }
        }
        
        // get the size info from config
        NSString * imageWidth = [conf objectForKey:@"iconWidth"];
        if ([MSIVectorIconHelper isNotEmpty:imageWidth]) {
            size.width = imageWidth.floatValue;
        }
        NSString * imageHeight = [conf objectForKey:@"iconHeight"];
        if ([MSIVectorIconHelper isNotEmpty:imageHeight]) {
            size.height = imageHeight.floatValue;
        }
        
        NSString *vectorCode = [conf objectForKey:@"code"];
        if (useVectorIcon && [MSIVectorIconHelper isNotEmpty:vectorCode]) {
            MSIVectorIcon *vectorIcon = [[MSIVectorIcon alloc] initWithFrame:(CGRect){0, 0, defaultSize}];
            [vectorIcon setIcon:vectorCode color:color];
            resultImage = [[NSImage grabImage:vectorIcon] imageWithSize:size];
        } else {
            NSString *imageName = [conf objectForKey:@"image"];
            if (imageName && ![imageName isEqualToString:@""]) {
                resultImage = [[[NSImage imageNamed:imageName] imageWithColor:color] imageWithSize:size];
            }
        }
    }
    
    if (!resultImage) {
        // no vector icon or can't find the configured imageName image, try to return the image named by the icon name
        return [[[NSImage imageNamed:GetNameInFinalBundle(iconName)] imageWithColor:color] imageWithSize:size];
    } else {
        return resultImage;
    }
}

+ (NSAttributedString *)generateIconText:(NSString *)iconName fontSize:(NSInteger)size color:(NSColor *)color {
    NSDictionary *cfgDict = [MSIVectorIconHelper configureDictionary];
    NSDictionary *conf = [cfgDict objectForKey:iconName];
    if (!conf) {
        return nil;
    }
    
    // get the color info from config
    NSString * rgbColor = [conf objectForKey:@"color"];
    if ([MSIVectorIconHelper isNotEmpty:rgbColor]) {
        CGFloat alpha = 1.0;
        NSNumber *alphaStr = [conf objectForKey:@"alpha"];
        if (alphaStr) {
            alpha = alphaStr.doubleValue;
        }
        
        color = [NSColor colorWithInt:rgbColor.intValue alpha:alpha];
    }
    
    NSString *vectorCode = [conf objectForKey:@"code"];
    if ([MSIVectorIconHelper isEmpty:vectorCode]) {
        return nil;
    }
    
    NSMutableDictionary * attributeDic = [[NSMutableDictionary alloc] init];
    [attributeDic setObject:[NSFont fontWithName:VectorFont size:size] forKey:NSFontAttributeName];
    if (color) {
        [attributeDic setObject:color forKey:NSForegroundColorAttributeName];
    }
    return [[NSMutableAttributedString alloc] initWithString:[MSIVectorIcon getUnicode:vectorCode] attributes:attributeDic];
}

+ (BOOL)isNotEmpty:(NSString *)str {
    return [str length] > 0;
}

+ (BOOL)isEmpty:(NSString *)str {
    return [str length] == 0;
}

@end
