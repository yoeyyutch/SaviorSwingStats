﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using IPA.Config.Stores;
using IPA.Config.Stores.Attributes;
using IPA.Config.Stores.Converters;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace SaviorSwingStats
{
	internal class PluginConfig
	{
		public static PluginConfig Instance { get; set; }

		public class SubThingsObject
		{
			public virtual double DoubleValue { get; set; } = 2.718281828459045;
		}

		public virtual int IntValue { get; set; } = 42;

		public virtual float FloatValue { get; set; } = 3.14159f;

		[NonNullable]
		public virtual SubThingsObject SubThings { get; set; } = new SubThingsObject();

		[UseConverter(typeof(ListConverter<string>))]
		public virtual List<string> ListValue { get; set; } = new List<string>();

		[UseConverter(typeof(CollectionConverter<string, HashSet<string>>))]
		public virtual HashSet<string> SetValue { get; set; } = new HashSet<string>();

		public virtual void Changed()
		{
			// this is called whenever one of the virtual properties is changed
			// can be called to signal that the content has been changed
		}

		public virtual void OnReload()
		{
			// this is called whenever the config file is reloaded from disk
			// use it to tell all of your systems that something has changed

			// this is called off of the main thread, and is not safe to interact
			//   with Unity in
		}
	}
}