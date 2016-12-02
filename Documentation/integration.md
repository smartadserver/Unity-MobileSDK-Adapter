# Integration guide

> **WARNING**

> _Temporary documentation, please refer to the official documentation for now_

## Adding the adapter into an existing project

You can integrate the _Unity Adapter_ into you project by simply merging the ```Assets/Plugins``` directory found in this repository into your own _Assets_ directory. This directory contains all files necessary to display ads on _Android_ & _iOS_, included _Smart AdServer_ SDK for both platforms.

To simplify this step, you can export the whole _Plugins_ directory as an _Unity Package_ file by right-clicking it, then choosing _Export Package_. Leave everything selected in the pop up displayed next and choose a filename to complete the operation.

<p align="center">
  <img src="Images/package_export.png" alt="Exporting the Plugins directory as an Unity Package"/>
</p>

A _Unity Package_ can be imported into another project by double clicking on it from the _Explorer_ / _Finder_ (the project you want to import it into must be open).

## Displaying an ad

Ads are handled by native SDK using the _Unity's Native Plugin_ mechanism. But the app can instantiate and manipulate banners and interstitials directly through C# objects, that provide a simple and universal API to load them and display them.

> You can see a complete example on how to implement a banner and an interstitial in your app in the ```GameController.cs``` script of the sample.

The base object used to handle ads is the ```AdView``` class. However you will never use this class directly and use instead ```BannerView``` and ```InterstitialView``` depending of the kind of ad you want to display.

### Banner

A ```BannerView``` needs to be loaded and then displayed.

The loading of an ad requires an ```AdConfig``` object that can be instantiated with a _BaseURL_ / _SiteID_ / _FormatID_ / _PageID_ / _Targeting_:

    // Create an AdConfig object
    AdConfig adConfig = new AdConfig ("http://mobile.smartadserver.com", 57477, "(image_interstitial)", 12167, true, "");

When the ```AdConfig``` object is created, the banner can be loaded and events can be registered to know when the ad is available or if the ad loading has failed:

    // Load an ad
    _bannerView.LoadAd (adConfig);

    // Register success & failure events
    _bannerView.AdViewLoadingSuccess += BannerViewSuccess;
    _bannerView.AdViewLoadingFailure += BannerViewFailure;

When the _Success_ event is called, your banner is ready to be displayed. You can do it immediately or wait for a given event of your own game (for instance when the ship is destroyed in this sample).

A banner can only be displayed at the **top** or the **bottom** of the screen at the moment:

    // Displaying the banner at the bottom of the screen
    _bannerView.DisplayBanner (AdPosition.Bottom)

### Interstitial

_TODO_
