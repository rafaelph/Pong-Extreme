using GoogleMobileAds.Api;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AdScript {

	public void requestBanner() {
		#if UNITY_EDITOR
			string adUnitId = "unused";
		#elif UNITY_ANDROID
			string adUnitId = "ca-app-pub-3490576924828867/9637786031";
		#elif UNITY_IPHONE
			string adUnitId = "unused";
		#else
			string adUnitId = "unexpected_platform";
		#endif

		BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
		AdRequest.Builder builder = new AdRequest.Builder();
		if (Debug.isDebugBuild) {
			AdRequest request = builder.AddTestDevice ("atestdevice").Build ();
			bannerView.LoadAd (request);
		} else {
			AdRequest request = builder.Build();
			bannerView.LoadAd (request);
		}

		bannerView.Show ();

	}
}
