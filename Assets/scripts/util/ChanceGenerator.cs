using System.Collections;
using System.Collections.Generic;
using System;

public class ChanceGenerator {

	private static Random random = new Random ();

	public static bool IsFailure(int successFailureOver100) {
		return !ChanceGenerator.IsSuccessful (successFailureOver100);
	}

	public static bool IsSuccessful(int successPercentageOver100) {
		if (successPercentageOver100 >= 100) {
			return true;
		} else if (successPercentageOver100 <= 0) {
			return false;
		} else {
			ArrayList arrayOfPercentage = new ArrayList ();
			for (var i = 0; i < successPercentageOver100; ++i) {
				arrayOfPercentage.Add (true);
			}
			for (var i = 0; i < 100 - successPercentageOver100; ++i) {
				arrayOfPercentage.Add (false);
			}
			return (bool)arrayOfPercentage[random.Next(99)];
		}
	}

}
