using System;
using System.Threading.Tasks;

namespace Firebase.Analytics {
    public sealed class FirebaseAnalytics {
        private static FirebaseApp app;

        private static FirebaseApp App {
            get {
                return FirebaseAnalytics.app;
            }
        }

        public static string EventAddPaymentInfo {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventAddPaymentInfo_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventAddToCart {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventAddToCart_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventAddToWishlist {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventAddToWishlist_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventAppOpen {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventAppOpen_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventBeginCheckout {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventBeginCheckout_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventCampaignDetails {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventCampaignDetails_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventCheckoutProgress {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventCheckoutProgress_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventEarnVirtualCurrency {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventEarnVirtualCurrency_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventEcommercePurchase {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventEcommercePurchase_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventGenerateLead {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventGenerateLead_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventJoinGroup {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventJoinGroup_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventLevelUp {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventLevelUp_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventLogin {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventLogin_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventPostScore {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventPostScore_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventPresentOffer {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventPresentOffer_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventPurchaseRefund {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventPurchaseRefund_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventRemoveFromCart {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventRemoveFromCart_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventSearch {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventSearch_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventSelectContent {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventSelectContent_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventSetCheckoutOption {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventSetCheckoutOption_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventShare {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventShare_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventSignUp {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventSignUp_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventSpendVirtualCurrency {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventSpendVirtualCurrency_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventTutorialBegin {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventTutorialBegin_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventTutorialComplete {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventTutorialComplete_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventUnlockAchievement {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventUnlockAchievement_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventViewItem {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventViewItem_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventViewItemList {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventViewItemList_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventViewSearchResults {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventViewSearchResults_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventLevelStart {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventLevelStart_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string EventLevelEnd {
            get {
                string result = FirebaseAnalyticsPINVOKE.kEventLevelEnd_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterAchievementId {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterAchievementId_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterAdNetworkClickID {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterAdNetworkClickID_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterAffiliation {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterAffiliation_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterCampaign {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterCampaign_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterCharacter {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterCharacter_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterCheckoutStep {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterCheckoutStep_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterCheckoutOption {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterCheckoutOption_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterContent {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterContent_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterContentType {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterContentType_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterCoupon {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterCoupon_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterCP1 {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterCP1_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterCreativeName {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterCreativeName_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterCreativeSlot {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterCreativeSlot_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterCurrency {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterCurrency_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterDestination {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterDestination_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterEndDate {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterEndDate_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterFlightNumber {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterFlightNumber_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterGroupId {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterGroupId_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterIndex {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterIndex_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterItemBrand {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterItemBrand_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterItemCategory {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterItemCategory_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterItemId {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterItemId_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterItemLocationId {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterItemLocationId_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterItemName {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterItemName_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterItemList {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterItemList_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterItemVariant {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterItemVariant_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterLevel {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterLevel_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterLocation {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterLocation_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterMedium {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterMedium_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterNumberOfNights {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterNumberOfNights_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterNumberOfPassengers {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterNumberOfPassengers_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterNumberOfRooms {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterNumberOfRooms_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterOrigin {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterOrigin_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterPrice {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterPrice_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterQuantity {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterQuantity_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterScore {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterScore_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterSearchTerm {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterSearchTerm_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterShipping {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterShipping_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterSignUpMethod {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterSignUpMethod_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterSource {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterSource_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterStartDate {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterStartDate_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterTax {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterTax_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterTerm {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterTerm_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterTransactionId {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterTransactionId_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterTravelClass {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterTravelClass_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterValue {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterValue_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterVirtualCurrencyName {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterVirtualCurrencyName_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterLevelName {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterLevelName_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string ParameterSuccess {
            get {
                string result = FirebaseAnalyticsPINVOKE.kParameterSuccess_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        public static string UserPropertySignUpMethod {
            get {
                string result = FirebaseAnalyticsPINVOKE.kUserPropertySignUpMethod_get();
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
                return result;
            }
        }

        static FirebaseAnalytics() {
            FirebaseAnalytics.app = FirebaseApp.DefaultInstance;
        }

        private FirebaseAnalytics() {
        }

        public static void SetMinimumSessionDuration(TimeSpan timeSpan) {
            FirebaseAnalytics.SetMinimumSessionDurationInternal((long)timeSpan.TotalMilliseconds);
        }

        public static void SetSessionTimeoutDuration(TimeSpan timeSpan) {
            FirebaseAnalytics.SetSessionTimeoutDurationInternal((long)timeSpan.TotalMilliseconds);
        }

        public static void SetAnalyticsCollectionEnabled(bool enabled) {
            FirebaseAnalyticsPINVOKE.SetAnalyticsCollectionEnabled(enabled);
            if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public static void LogEvent(string name, string parameterName, string parameterValue) {
            FirebaseAnalyticsPINVOKE.LogEvent__SWIG_0(name, parameterName, parameterValue);
            if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public static void LogEvent(string name, string parameterName, double parameterValue) {
            FirebaseAnalyticsPINVOKE.LogEvent__SWIG_1(name, parameterName, parameterValue);
            if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public static void LogEvent(string name, string parameterName, long parameterValue) {
            FirebaseAnalyticsPINVOKE.LogEvent__SWIG_2(name, parameterName, parameterValue);
            if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public static void LogEvent(string name, string parameterName, int parameterValue) {
            FirebaseAnalyticsPINVOKE.LogEvent__SWIG_3(name, parameterName, parameterValue);
            if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public static void LogEvent(string name) {
            FirebaseAnalyticsPINVOKE.LogEvent__SWIG_4(name);
            if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public unsafe static void LogEvent(string name, params Parameter[] parameters) {
            IntPtr[] array = new IntPtr[parameters.Length];
            for (int i = 0; i < parameters.Length; i++) {
                array[i] = (IntPtr)Parameter.getCPtr(parameters[i]);
            }
            fixed (IntPtr* value = (array != null && array.Length != 0) ? ref array[0] : ref *null) {
                FirebaseAnalyticsPINVOKE.LogEvent__SWIG_5(name, (IntPtr)((void*)value), parameters.Length);
                if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                    throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
                }
            }
        }

        public static void SetUserProperty(string name, string property) {
            FirebaseAnalyticsPINVOKE.SetUserProperty(name, property);
            if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public static void SetUserId(string userId) {
            FirebaseAnalyticsPINVOKE.SetUserId(userId);
            if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        internal static void SetMinimumSessionDurationInternal(long milliseconds) {
            FirebaseAnalyticsPINVOKE.SetMinimumSessionDurationInternal(milliseconds);
            if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        internal static void SetSessionTimeoutDurationInternal(long milliseconds) {
            FirebaseAnalyticsPINVOKE.SetSessionTimeoutDurationInternal(milliseconds);
            if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public static void SetCurrentScreen(string screenName, string screenClass) {
            FirebaseAnalyticsPINVOKE.SetCurrentScreen(screenName, screenClass);
            if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public static void ResetAnalyticsData() {
            FirebaseAnalyticsPINVOKE.ResetAnalyticsData();
            if (AppUtilPINVOKE.SWIGPendingException.Pending) {
                throw AppUtilPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public static Task<string> GetAnalyticsInstanceIdAsync() {
            return FutureString.GetTask(new FutureString(FirebaseAnalyticsPINVOKE.GetAnalyticsInstanceId(), true));
        }
    }
}
