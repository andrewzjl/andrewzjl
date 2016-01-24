//
//  MSIIconInfo.h
//  VectorIconPreview
//
//  Created by zeng Jinliang on 1/24/16.
//  Copyright © 2016 Microstrategy. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface MSIIconInfo : NSObject

@property NSString *name;
@property NSString *code;
@property NSString *imageName;
@property NSString *color;
@property NSString *alpha;
@property NSString *imageWidth;
@property NSString *imageHeight;

@property (nonatomic) NSImage *image;

@end
