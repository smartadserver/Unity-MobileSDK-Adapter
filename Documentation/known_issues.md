# Known issues / Improvements needed

* **[ISSUE / Android]** HTML ads containing hardware accelerated components (like the ```<video/>``` tag) might not work properly.
* **[ISSUE / Android]** No blurred background will be displayed on _Go-To video interstitials_.
* **[ISSUE / Android]** Low frame rate on hardware accelerated animations (_Video Read_ open/close animations, _Swipe to dismiss_ interstitials, …).
* **[IMPROVEMENT / iOS]** The _iOS C wrapper_ is handling a fixed number of ```SASAdView``` instances.
* **[IMPROVEMENT / All platforms]** Methods to set and get the _current timeout_ on an ad view are not implemented and will not do anything.
* **[IMPROVEMENT / All platforms]** Methods to set and get the _SDK logging status_ are not implemented and will not do anything.
