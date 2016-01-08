﻿# QuickStarts for Microsoft Azure Mobile Services

With Microsoft Azure Mobile Services you can add a scalable backend to your connected client applications in minutes.
To learn more, visit our [Developer Center](http://azure.microsoft.com/en-us/develop/mobile/).

## Getting Started

If you are new to Mobile Services, you can get started by following our tutorials for connecting your Mobile
Services cloud backend to [Windows Store apps](http://azure.microsoft.com/en-us/documentation/articles/mobile-services-windows-store-get-started/),
[Windows Phone 8 apps](http://azure.microsoft.com/en-us/documentation/articles/mobile-services-windows-phone-get-started/),
[iOS apps](http://azure.microsoft.com/en-us/documentation/articles/mobile-services-ios-get-started/),
and [Android apps](http://azure.microsoft.com/en-us/documentation/articles/mobile-services-android-get-started/).

## Download Source Code

To get the source code of our SDKs and samples via **git** just type:

    git clone https://github.com/Azure/azure-mobile-services-quickstarts.git
    cd ./azure-mobile-services-quickstarts/

## Building Quickstarts For Uploading To Azure Portal

Run "C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe .\Microsoft.WindowsAzure.Mobile.Build.msbuild"

Build script downloads latest official nuget packages, updates quickstarts with required versions and dependencies & packs required projects to appropriate quickstarts.

### Prerequisites

.Net Framework 4.0.

## Quickstarts Usage Instructions

### Cordova Client

To use the Azure Mobile Apps Cordova client quickstart:

  1. Edit ./client/cordova/ZUMOAPPNAME/www/js/index.js and replace the *ZUMOAPPURL* placeholder with your Mobile App URL.
  2. Change to the Cordova quickstart directory:

        cd ./client/cordova/ZUMOAPPNAME
  3. Add the platform you want to build the quickstart for:

        cordova platform add [android | ios | windows | wp8]
  4. Run the quickstart:

        cordova run [android | ios | windows | wp8]

### Prerequisites

* [Cordova CLI](https://cordova.apache.org/docs/en/latest/guide/cli/index.html)
* Target platform SDK.
