using System;
using System.Collections.Generic;

namespace Firebase
{
	internal static class VariantExtension
	{
		internal enum KeyOptions
		{
			UseObjectKeys,
			UseStringKeys
		}

		private const VariantExtension.KeyOptions DefaultKeyOptions = VariantExtension.KeyOptions.UseObjectKeys;

		public static object ToObject(this Variant variant)
		{
			return variant.ToObject(VariantExtension.KeyOptions.UseObjectKeys);
		}

		public static object ToObject(this Variant variant, VariantExtension.KeyOptions options)
		{
			switch (variant.type())
			{
			case Variant.Type.Int64:
				return variant.int64_value();
			case Variant.Type.Double:
				return variant.double_value();
			case Variant.Type.Bool:
				return variant.bool_value();
			case Variant.Type.StaticString:
			case Variant.Type.MutableString:
				return variant.string_value();
			case Variant.Type.Vector:
			{
				List<object> list = new List<object>();
				foreach (Variant current in variant.vector())
				{
					list.Add(current.ToObject(options));
				}
				return list;
			}
			case Variant.Type.Map:
			{
				if (options == VariantExtension.KeyOptions.UseStringKeys)
				{
					return variant.map().ToStringVariantMap(options);
				}
				Dictionary<object, object> dictionary = new Dictionary<object, object>();
				foreach (KeyValuePair<Variant, Variant> current2 in variant.map())
				{
					object key = current2.Key.ToObject(options);
					object value = current2.Value.ToObject(options);
					dictionary[key] = value;
				}
				return dictionary;
			}
			case Variant.Type.StaticBlob:
			case Variant.Type.MutableBlob:
				return variant.blob_as_bytes();
			}
			return null;
		}

		public static IDictionary<string, object> ToStringVariantMap(this VariantVariantMap originalMap)
		{
			return originalMap.ToStringVariantMap(VariantExtension.KeyOptions.UseObjectKeys);
		}

		public static IDictionary<string, object> ToStringVariantMap(this VariantVariantMap originalMap, VariantExtension.KeyOptions options)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			foreach (KeyValuePair<Variant, Variant> current in originalMap)
			{
				string key;
				if (current.Key.is_string())
				{
					key = current.Key.string_value();
				}
				else
				{
					if (!current.Key.is_fundamental_type())
					{
						throw new InvalidCastException("Unable to convert dictionary keys to string");
					}
					key = current.Key.AsString().string_value();
				}
				object value = current.Value.ToObject(options);
				dictionary[key] = value;
			}
			return dictionary;
		}
	}
}
