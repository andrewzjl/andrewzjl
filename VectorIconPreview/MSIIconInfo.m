//
//  MSIIconInfo.m
//  VectorIconPreview
//
//  Created by zeng Jinliang on 1/24/16.
//  Copyright © 2016 Microstrategy. All rights reserved.
//

#import "MSIIconInfo.h"
#import "MSIVectorIconHelper.h"

@implementation MSIIconInfo

- (NSImage *)image {
    if (!_image) {
        _image = [MSIVectorIconHelper generateImage:self.name];
    }
    return _image;
}

@end
