***PLEASE NOTE: SMART WILL NO LONGER SUPPORTS UNITY ADAPTERS BUT THE CURRENT PROJECT (SUPPORTING SDK 6.7) WILL REMAIN AVAILABLE FOR YOUR OWN DEVELOPMENT PURPOSES.**


# Smart AdServer / Unity — Integration Sample

## Introduction

[Smart AdServer](http://smartadserver.com) offers an ad serving SDK for both _iOS_ and _Android_ devices. However, there is no official SDK for _Unity_.

_Unity_ allows the development of custom native plugins that will be integrated to the final application depending of the targeted platform: this means that native mobile SDK can be used inside an _Unity_ project using the native plugin interface.

Since integrating a native SDK into a _Unity_ project is not easy and poorly documented, this sample will show you how to display simple banner and interstitial ads in an _Unity_ game while it is running on _iOS_ or _Android_. Using the plugins for these platforms doesn't remove the possibility to run the project on other platforms.

This sample is based on a modified version of the official _Space Shooter_ tutorial. You can find more informations about it on _Unity_'s website: https://unity3d.com/learn/tutorials/projects/space-shooter-tutorial

## Documentation

The complete documentation of this sample can be found [in the documentation directory](Documentation/index.md).

## License

This sample is distributed under the _MIT License_:

    The MIT License (MIT)

    Copyright (c) 2017 Smart AdServer

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NON INFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.

It embeds _PlayServicesResolver_ by _Google_, distributed under _Apache License Version 2.0_.
