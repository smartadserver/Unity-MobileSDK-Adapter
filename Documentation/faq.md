# Frequently asked questions

## Is this Git repository a Smart AdServer Unity SDK?

No.

This sample shows you an example on how you can use existing _Smart AdServer SDK_ along with the _Unity native plugin API_ to display ads in your _Unity_ apps for mobile devices. It will not display any ads on platforms not supported by _Smart AdServer_ (_Android_ and _iOS_).

## HTML5 videos does not work on Android

This is a known limitation of this integration sample.

You can display interstitials and banners without issues on both _Android_ and _iOS_ using native video templates like _Video-Read banners_ and _Native Video interstitials_.

## The feature 'XXXX' from your SDK is missing in this sample?

This sample only shows an simple example of how to make your _Unity_ application interact with native _Smart AdServer SDK_ so only basic features are implemented.

You can expand it quite easily to support the feature you need since all the communication with the native SDK has already been implemented.

## Can I use _Smart AdServer_ SDK older than 6.5 with this wrapper?

Older _iOS_SDKs have not been tested with this wrapper so it is not advised to use them.

Older _Android_ SDKs will not be able to render some advanced formats (like some video formats) due to some incompatible components used: **you cannot use them in Unity**.

## How are _Google Play Services_ integrated into the sample?

_Google Play Services_ are included into this sample and used mainly for geolocation and advertising ID retrieval.

AAR files in _Assets/Plugins/Android_ are included automatically in the project using _PlayServicesResolver_ from Google. Exact services and versions required by the SDK are declared in the file _Assets/PlayServicesResolver/Editor/SmartAdServerDependencies.cs_. Dependencies are then automatically downloaded in the project as soon as the current build platform is set to _Android_ (if the automatic import is on, otherwise you need to right-click _PlayServicesResolver_ then _Google Play Services_ > _Resolve Client JAR_).

Automatic _Play Services_ resolution will only work if all the required _Android SDK_ dependencies are installed on your computer (using _SDK Manager_).
