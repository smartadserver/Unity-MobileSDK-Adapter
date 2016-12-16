using System;
using UnityEngine;
using System.Collections;

namespace SmartAdServer.Unity.Library.Events
{
	public class RewardReceivedEventArgs : EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SmartAdServer.Unity.Library.Events.RewardReceivedEventArgs"/> class.
		/// </summary>
		/// <param name="currency">The currency of the reward (e.g coins, lives, points…).</param>
		/// <param name="amount">The amount of currency to be rewarded.</param>
		public RewardReceivedEventArgs (String currency, Double amount) : base()
		{
			this.Currency = currency;
			this.Amount = amount;
		}

		/// <summary>
		/// Let you know which currency should be rewarded. Useful to know what kind of behavior to trigger in your code if you use different currencies.
		/// </summary>
		/// <value>The currency of the reward (e.g coins, lives, points…).</value>
		public String Currency { get; set; }

		/// <summary>
		/// The amount of currency to be rewarded.
		/// </summary>
		/// <value>The amount of currency to be rewarded.</value>
		public Double Amount { get; set; }
	}
}
