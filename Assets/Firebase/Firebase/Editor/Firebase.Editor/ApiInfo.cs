using System;
using UnityEditor;
using UnityEngine;

namespace Firebase.Editor
{
	internal class ApiInfo
	{
		public Texture2D Image
		{
			get;
			protected set;
		}

		public virtual DocStrings.DocRef Name
		{
			get;
			set;
		}

		public virtual DocStrings.DocRef Description
		{
			get;
			set;
		}

		public virtual DocStrings.Link ApiReference
		{
			get;
			set;
		}

		public virtual DocStrings.DocRef GuideButton
		{
			get;
			set;
		}

		public virtual DocStrings.Link GuideLink
		{
			get;
			set;
		}

		public ApiInfo(string image_path)
		{
			this.Image = (Texture2D)EditorGUIUtility.Load("Firebase/fb_" + image_path + ((!EditorGUIUtility.isProSkin) ? string.Empty : "_dark") + ".png");
		}

		public static ApiInfo Analytics()
		{
			return new ApiInfo("analytics")
			{
				Name = DocStrings.DocRef.AnalyticsName,
				Description = DocStrings.DocRef.AnalyticsDescription,
				ApiReference = DocStrings.Link.AnalyticsReference,
				GuideButton = DocStrings.DocRef.AnalyticsGuideSummary,
				GuideLink = DocStrings.Link.AnalyticsGuide
			};
		}

		public static ApiInfo Auth()
		{
			return new ApiInfo("auth")
			{
				Name = DocStrings.DocRef.AuthName,
				Description = DocStrings.DocRef.AuthDescription,
				ApiReference = DocStrings.Link.AuthReference,
				GuideButton = DocStrings.DocRef.AuthGuideSummary,
				GuideLink = DocStrings.Link.AuthGuide
			};
		}

		public static ApiInfo CloudMessaging()
		{
			return new ApiInfo("cloud_messaging")
			{
				Name = DocStrings.DocRef.CloudMessagingName,
				Description = DocStrings.DocRef.CloudMessagingDescription,
				ApiReference = DocStrings.Link.CloudMessagingReference,
				GuideButton = DocStrings.DocRef.CloudMessagingGuideSummary,
				GuideLink = DocStrings.Link.CloudMessagingGuide
			};
		}

		public static ApiInfo Database()
		{
			return new ApiInfo("database")
			{
				Name = DocStrings.DocRef.DatabaseName,
				Description = DocStrings.DocRef.DatabaseDescription,
				ApiReference = DocStrings.Link.DatabaseReference,
				GuideButton = DocStrings.DocRef.DatabaseGuideSummary,
				GuideLink = DocStrings.Link.DatabaseGuide
			};
		}

		public static ApiInfo DynamicLinks()
		{
			return new ApiInfo("dynamic_links")
			{
				Name = DocStrings.DocRef.DynamicLinksName,
				Description = DocStrings.DocRef.DynamicLinksDescription,
				ApiReference = DocStrings.Link.DynamicLinksReference,
				GuideButton = DocStrings.DocRef.DynamicLinksGuideSummary,
				GuideLink = DocStrings.Link.DynamicLinksGuide
			};
		}

		public static ApiInfo Functions()
		{
			return new ApiInfo("functions")
			{
				Name = DocStrings.DocRef.FunctionsName,
				Description = DocStrings.DocRef.FunctionsDescription,
				ApiReference = DocStrings.Link.FunctionsReference,
				GuideButton = DocStrings.DocRef.FunctionsGuideSummary,
				GuideLink = DocStrings.Link.FunctionsGuide
			};
		}

		public static ApiInfo Invites()
		{
			return new ApiInfo("invites")
			{
				Name = DocStrings.DocRef.InvitesName,
				Description = DocStrings.DocRef.InvitesDescription,
				ApiReference = DocStrings.Link.InvitesReference,
				GuideButton = DocStrings.DocRef.InvitesGuideSummary,
				GuideLink = DocStrings.Link.InvitesGuide
			};
		}

		public static ApiInfo RemoteConfig()
		{
			return new ApiInfo("config")
			{
				Name = DocStrings.DocRef.RemoteConfigName,
				Description = DocStrings.DocRef.RemoteConfigDescription,
				ApiReference = DocStrings.Link.RemoteConfigReference,
				GuideButton = DocStrings.DocRef.RemoteConfigGuideSummary,
				GuideLink = DocStrings.Link.RemoteConfigGuide
			};
		}

		public static ApiInfo Storage()
		{
			return new ApiInfo("storage")
			{
				Name = DocStrings.DocRef.StorageName,
				Description = DocStrings.DocRef.StorageDescription,
				ApiReference = DocStrings.Link.StorageReference,
				GuideButton = DocStrings.DocRef.StorageGuideSummary,
				GuideLink = DocStrings.Link.StorageGuide
			};
		}
	}
}
