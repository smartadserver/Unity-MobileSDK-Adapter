//
//  SASAd.h
//  SmartAdServer
//
//  Created by Clémence Laurent on 03/06/14.
//
//

/**
 A SASAd object represents an ad's data, as it has been programmed in the Smart AdServer Manage interface.
 You can check some values like the width and the height to adapt your app's behavior to it.
 */

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

#define kSASDefaultCloseAppearanceDelay 0.2f


typedef NS_ENUM(NSInteger, SASSkipPosition) {
	SASSkipTopLeft,
	SASSkipTopRight,
	SASSkipBottomLeft,
	SASSkipBottomRight,
};

typedef NS_ENUM(NSInteger, SASCreativeType) {
	SASCreativeTypeImage,
	SASCreativeTypeAudio,
	SASCreativeTypeVideo,
	SASCreativeTypeHtml,
	SASCreativeTypeMRAIDAdSecondPart,
    SASCreativeTypeNoPremiumAd,
    SASCreativeTypeNativeVideo,
    SASCreativeTypeNativeParallax
};


@class SASMediationAd, SASNativeVideoAd;
@interface SASAd : NSObject <NSCopying, NSCoding>

///--------------------
/// @name Ad properties
///--------------------


/** The original portrait creative size.
 
 */

@property (nonatomic, readonly) CGSize portraitSize;


/** The original landscape creative size.
 
 */

@property (nonatomic, readonly) CGSize landscapeSize;


/** The ad duration (if applicable).
 
 */

@property (readonly) float duration;


/** The currently displayed mediation ad.
 
 */

@property (nonatomic, readonly, nullable, strong) SASMediationAd *currentMediationAd;


/** The array of mediation ads returned by the server.
 
 */

@property (nonatomic, readonly, nullable, strong) NSArray *mediationAds;


/** The dictionary used to add extra parameters that you can interpret in your app.
 
 */

@property (nonatomic, readonly, nullable, strong) NSDictionary *extraParameters;


/** The original aspect ratio of the creative.
 
 */

@property (nonatomic, readonly) CGFloat aspectRatio;


/** Returns the recommanded height to display the ad in a given container, according to the creative's aspect ratio.
 
 If no size is defined for the creative, this method will compute the recommanded height using a 32:5 aspect ratio (standard iOS banner ratio).
 
 @param container the container in which the ad will be displayed (if nil, the current window will be used instead)
 
 @return the optimized height for the ad view
 
 */

- (CGFloat)optimalAdHeightForContainer:(nullable UIView *)container;

@end
