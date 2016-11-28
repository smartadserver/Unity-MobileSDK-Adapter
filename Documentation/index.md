# Smart AdServer / Unity — Integration Sample

## Table of content

1. Getting started
2. Implementation
3. FAQ
4. Known issues

## 1. Getting started

To get started, simply checkout this project and open it using the latest version of _Unity_ (tested on *Unity 5.4.0f3*).

This project is based on the official _Space Shooter_ tutorial available [in _Unity_ official documentation](https://unity3d.com/learn/tutorials/projects/space-shooter-tutorial). It has been modified to handle accelerometer input, thus making it playable on mobile devices.

When the project is run through the _Unity Editor_ or as any build target except _Android_ & _iOS_, the game will run properly without any ads being displayed. If the same project is run as an _Android_ or an _iOS_ target, a banner and an interstitial ad will be fetched using the embedded _Smart AdServer Display SDK_ and will be displayed to the player when he loses.

## 2. Implementation

### Main structure

#### Unity native plugin

The integration of a mobile SDK can be made using the native plugin capability provided by Unity: http://docs.unity3d.com/Manual/NativePlugins.html

Using this capability, _Unity_ will allow direct or indirect access to native code if the application is running on the targeted platform. This plugin feature will also allow us to make specific configurations depending on the platform currently used (to request permissions if the application on _Android_ for example).

This sample is divided in several layers:

1. the **Unity Game** itself
2. a **Smart AdServer API** layer to provide a standard C# API used to load and display ads
3. a **native ad view** layer that will instantiate and handle ad views for supported platforms (in this sample: _Android_, _iOS_ and _'Default'_)
4. a **C wrapper** layer that will provide a C interface for SDK that can't be accessed directly through managed code (only required for _iOS_ in this sample)
5. a **SDK** layer (the _Android_ and the _iOS_ SDK)

![Main Structure](Images/main_structure.png)

### Integration of the Android SDK

#### SDK integration

To display ads on _Android_, you need to embed the _Android SDK_ and the _Google Play Services_ library.

Embedding a file in the app for _Android_ is done by creating a directory in the _Plugins_ directory, in this case: ```Assets/Plugins/Android/```.

You also need to provide an _AndroidManifest.xml_, to setup the permissions for the _Android SDK_ (*ACCESS_NETWORK_STATE* and *INTERNET*). This manifest will be merged automatically with the _Unity_ manifest during compilation.

#### Interacting with Java classes from Unity

Interacting with _Android_ classes and objects is quite easy with _Unity_.

You can do it directly from _C#_ (without the need of a native _Java_ wrapper) using _Unity_ classes ```AndroidJavaClass``` and ```AndroidJavaObject```. You can also use the ```AndroidJavaProxy``` class to create a listener for a Java class with _C#_ code.

**Warning:** When you are executing Java code from _Unity_, you are not guaranteed that it will be executed in the application main thread. This can lead to crashes when interacting with views.

The class ```AndroidNativeAdView``` from this sample project shows you how to manipulate the _Java_ ```SASAdView``` class from _C#_ and how to run your code on the _Java_ main thread (look for the ```RunOnJavaUiThread``` method).

_In this sample, the code to interact with_ Java _classes can be found at ```Assets/Plugins/SmartAdServer/API/UI/Native/AndroidNativeAdView.cs```_

### Integration of the iOS SDK

#### SDK integration

To display ads on _iOS_, you need to embed the _iOS SDK_ in the ```Assets/Plugins/iOS/```:

* the ```.a``` Library
* all header files
* the bundle file

You will also need to import the right frameworks in the app and deactivate _Apple Transport Security_ (since the ad SDK does not support full HTTPS yet).

This is done in the ```iOSPostprocessBuild``` class, through the method ```LinkLibraries``` for the frameworks import and ```DeactivateATS``` for the _Apple Transport Security_ deactivation.

Since _Unity_ does not provide any API to manipulate _iOS_ projects, these two methods are directly modifying _Xcode_ project files.

#### Interacting with ObjC code from Unity

It is not possible to manipulate _ObjC_ classes directly from _C#_ code, so you will not be able to instantiate _iOS_ ```SASAdView``` objects from a _Unity_ class like it is done from _Android_.

This sample relies on a **C wrapper** that will instantiate, configure and display the ad view instances into the app. The ```iOSNativeAdView``` _Unity_ class will only be used to call the **C wrapper** functions.

Every ```SASAdView``` instances created in the _C wrapper_ is associated with an **ID** which will be returned to the ```iOSNativeAdView``` _Unity_ class.

The number of valid _IDs_ is fixed in the current _C wrapper_ implementation. This will probably be changed in a future version: in the meantime, if you want to change the number of _IDs_, you can edit the variable ```MAX_AD_VIEW``` in the file ```SmartImpl.mm```.

## 3. FAQ

### Is this Git repository a Smart AdServer Unity SDK?

No.

This sample shows you an example on how you can use existing _Smart AdServer SDK_ along with the _Unity native plugin API_ to display ads in your _Unity_ apps for mobile devices. It will not display any ads on platforms not supported by _Smart AdServer_ (_Android_ and _iOS_).

### HTML5 videos does not work on Android

This is a known limitation of this integration sample.

You can display interstitials and banners without issues on both _Android_ and _iOS_ using native video templates like _Video-Read banners_ and _Native Video interstitials_.

### The feature 'XXXX' from your SDK is missing in this sample?

This sample only shows an simple example of how to make your _Unity_ application interact with native _Smart AdServer SDK_ so only basic features are implemented.

You can expand it quite easily to support the feature you need since all the communication with the native SDK has already been implemented.

### Can I use _Smart AdServer_ SDK older than 6.5 with this wrapper?

Older _iOS_SDKs have not been tested with this wrapper so it is not advised to use them.

Older _Android_ SDKs will not be able to render some advanced formats (like some video formats) due to some incompatible components used: **you cannot use them in Unity**.

### How are _Google Play Services_ integrated into the sample?

_Google Play Services_ are included into this sample and used mainly for geolocation and advertising ID retrieval.

AAR files in _Assets/Plugins/Android_ are included automatically in the project using _PlayServicesResolver_ from Google. Exact services and versions required by the SDK are declared in the file _Assets/PlayServicesResolver/Editor/SmartAdServerDependencies.cs_. Dependencies are then automatically downloaded in the project as soon as the current build platform is set to _Android_ (if the automatic import is on, otherwise you need to right-click _PlayServicesResolver_ then _Google Play Services_ > _Resolve Client JAR_).

Automatic _Play Services_ resolution will only work if all the required _Android SDK_ dependencies are installed on your computer (using _SDK Manager_).

## 4. Known issues / Improvements needed

* **[ISSUE / Android]** HTML ads containing hardware accelerated components (like the ```<video/>``` tag) might not work properly.
* **[ISSUE / Android]** No blurred background will be displayed on _Go-To video interstitials_.
* **[ISSUE / Android]** Low frame rate on hardware accelerated animations (_Video Read_ open/close animations, _Swipe to dismiss_ interstitials, …).
* **[IMPROVEMENT / iOS]** The _iOS C wrapper_ is handling a fixed number of ```SASAdView``` instances.
