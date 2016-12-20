# Integration guide

## Adding the adapter into an existing project

You can integrate the _Unity Adapter_ into you project by simply merging the ```Assets/Plugins``` directory found in this repository into your own _Assets_ directory. This directory contains all files necessary to display ads on _Android_ & _iOS_, included _Smart AdServer_ SDK for both platforms.

To simplify this step, you can export the whole _Plugins_ directory as an _Unity Package_ file by right-clicking it, then choosing _Export Package_. Leave everything selected in the pop up displayed next and choose a filename to complete the operation.

<p align="center">
  <img src="Images/package_export.png" alt="Exporting the Plugins directory as an Unity Package"/>
</p>

A _Unity Package_ can be imported into another project by double clicking on it from the _Explorer_ / _Finder_ (the project you want to import it into must be open).

## Displaying an ad

Ads are handled by native SDK using the _Unity's Native Plugin_ mechanism. But the app can instantiate and manipulate banners and interstitials directly through C# objects, that provide a simple and universal API to load and display them.

> You can see a complete example on how to implement a banner and an interstitial in your app in the ```GameController.cs``` script of the sample.

The base object used to handle ads is the ```AdView``` class. However you will never use this class directly and use instead ```BannerView``` and ```InterstitialView``` depending of the kind of ad you want to display.

### Banner

A ```BannerView``` needs to be instantiated, loaded and then displayed.

    _bannerView = new BannerView ();

The loading of an ad requires an ```AdConfig``` object that can be instantiated with a _BaseURL_ / _SiteID_ / _FormatID_ / _PageID_ / _Targeting_:

    // Create an AdConfig object
    AdConfig adConfig = new AdConfig ("http://mobile.smartadserver.com", 57477, "(image_banner)", 15140, true, "");

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

A ```InterstitialView``` needs to be instantiated and loaded.

    _interstitialView = new InterstitialView ();

The loading of an ad requires an ```AdConfig``` object that can be instantiated with a _BaseURL_ / _SiteID_ / _FormatID_ / _PageID_ / _Targeting_:

    // Create an AdConfig object
    AdConfig adConfig = new AdConfig ("http://mobile.smartadserver.com", 57477, "(image_interstitial)", 12167, true, "");

When the ```AdConfig``` object is created, the interstitial can be loaded and events can be registered to know when the ad is available or if the ad loading has failed:

    // Load an ad
    _interstitialView.LoadAd (adConfig);

	// Register success & failure events
	_interstitialView.AdViewLoadingSuccess += InterstitialViewSuccess;
	_interstitialView.AdViewLoadingFailure += InterstitialViewFailure;

Contrary to the ```BannerView```, the ```InterstitialView``` is automatically displayed in fullscreen as soon as the ad is loaded.

## AdView instance destruction

Since ```AdView``` instances represents low level objects, you must destroy them manually when you are not using them anymore (this is true for both ```BannerView``` and ```InterstitialView```). The instance destruction is done using the ```Destroy``` method:

    // Destroying an InterstitialView instance
    _interstitialView.Destroy ();

If you don't call Destroy on all your unused ```AdView``` instances, **you might experience memory leaks and crashes**!

## Rewarded interstitials

Some interstitials can be set up to reward the user when the ad is viewed until the end. In this case, a reward is sent by the ad view depending on what has been configured on the placement in the _Smart AdServer_ interface. The reward contains:

* an _Amount_, to know how many items the user has won,
* a _Currency_, to know what type of item the user has won.

The event ```AdViewRewardReceived``` is triggered when an user has received a reward. To use this feature, you must register this event:

    _interstitial.AdViewRewardReceived += RewardReceived;

You can cast the ```EventArgs``` to ```RewardReceivedEventArgs``` if you want to extract the _amount_ and the _currency_ of the reward:

    void RewardReceived (object sender, System.EventArgs e)
	{
		var reward = (RewardReceivedEventArgs)e;
		Debug.Log ("Reward Info: " + reward.Amount + " " + reward.Currency);
	}
