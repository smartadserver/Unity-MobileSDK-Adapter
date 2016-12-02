# Integration guide

> **WARNING**

> _Temporary documentation, please refer to the official documentation for now_

## 1. Adding the adapter into an existing project

You can integrate the _Unity Adapter_ into you project by simply merging the ```Assets/Plugins``` directory found in this repository into your own _Assets_ directory. This directory contains all files necessary to display ads on _Android_ & _iOS_, included _Smart AdServer_ SDK for both platforms.

To simplify this step, you can export the whole _Plugins_ directory as an _Unity Package_ file by right-clicking it, then choosing _Export Package_. Leave everything selected in the pop up displayed next and choose a filename to complete the operation.

<p align="center">
  <img src="Images/package_export.png" alt="Exporting the Plugins directory as an Unity Package"/>
</p>

A _Unity Package_ can be imported into another project by double clicking on it from the _Explorer_ / _Finder_ (the project you want to import it into must be open).

## 2. Displaying an ad

Ads are handled by native SDK using the _Unity's Native Plugin_ mechanism. But the app can instantiate and manipulate banners and interstitials directly through C# objects, that provide a simple and universal API to load them and display them.

The base object used to handle ads is the ```AdView``` class. However you will never use this class directly and use instead ```BannerView``` and ```InterstitialView``` depending of the kind of ad you want to display.

> You can see a complete example on how to implement a banner and an interstitial in your app in the ```GameController.cs``` script of the sample.

### Banner

_TODO_

### Interstitial

_TODO_
