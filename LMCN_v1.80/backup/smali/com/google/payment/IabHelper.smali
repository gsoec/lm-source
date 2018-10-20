.class public Lcom/google/payment/IabHelper;
.super Ljava/lang/Object;
.source "IabHelper.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/payment/IabHelper$QueryInventoryListener;,
        Lcom/google/payment/IabHelper$IabAsyncInProgressException;,
        Lcom/google/payment/IabHelper$OnConsumeMultiFinishedListener;,
        Lcom/google/payment/IabHelper$OnConsumeFinishedListener;,
        Lcom/google/payment/IabHelper$QueryInventoryFinishedListener;,
        Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;,
        Lcom/google/payment/IabHelper$OnIabSetupFinishedListener;
    }
.end annotation


# static fields
.field public static final BILLING_RESPONSE_RESULT_BILLING_UNAVAILABLE:I = 0x3

.field public static final BILLING_RESPONSE_RESULT_DEVELOPER_ERROR:I = 0x5

.field public static final BILLING_RESPONSE_RESULT_ERROR:I = 0x6

.field public static final BILLING_RESPONSE_RESULT_ITEM_ALREADY_OWNED:I = 0x7

.field public static final BILLING_RESPONSE_RESULT_ITEM_NOT_OWNED:I = 0x8

.field public static final BILLING_RESPONSE_RESULT_ITEM_UNAVAILABLE:I = 0x4

.field public static final BILLING_RESPONSE_RESULT_OK:I = 0x0

.field public static final BILLING_RESPONSE_RESULT_SERVICE_UNAVAILABLE:I = 0x2

.field public static final BILLING_RESPONSE_RESULT_USER_CANCELED:I = 0x1

.field public static final GET_SKU_DETAILS_ITEM_LIST:Ljava/lang/String; = "ITEM_ID_LIST"

.field public static final GET_SKU_DETAILS_ITEM_TYPE_LIST:Ljava/lang/String; = "ITEM_TYPE_LIST"

.field public static final IABHELPER_BAD_RESPONSE:I = -0x3ea

.field public static final IABHELPER_ERROR_BASE:I = -0x3e8

.field public static final IABHELPER_INVALID_CONSUMPTION:I = -0x3f2

.field public static final IABHELPER_MISSING_TOKEN:I = -0x3ef

.field public static final IABHELPER_REMOTE_EXCEPTION:I = -0x3e9

.field public static final IABHELPER_SEND_INTENT_FAILED:I = -0x3ec

.field public static final IABHELPER_SUBSCRIPTIONS_NOT_AVAILABLE:I = -0x3f1

.field public static final IABHELPER_SUBSCRIPTION_UPDATE_NOT_AVAILABLE:I = -0x3f3

.field public static final IABHELPER_UNKNOWN_ERROR:I = -0x3f0

.field public static final IABHELPER_UNKNOWN_PURCHASE_RESPONSE:I = -0x3ee

.field public static final IABHELPER_USER_CANCELLED:I = -0x3ed

.field public static final IABHELPER_VERIFICATION_FAILED:I = -0x3eb

.field public static final INAPP_CONTINUATION_TOKEN:Ljava/lang/String; = "INAPP_CONTINUATION_TOKEN"

.field public static final ITEM_TYPE_INAPP:Ljava/lang/String; = "inapp"

.field public static final ITEM_TYPE_SUBS:Ljava/lang/String; = "subs"

.field public static final RESPONSE_BUY_INTENT:Ljava/lang/String; = "BUY_INTENT"

.field public static final RESPONSE_CODE:Ljava/lang/String; = "RESPONSE_CODE"

.field public static final RESPONSE_GET_SKU_DETAILS_LIST:Ljava/lang/String; = "DETAILS_LIST"

.field public static final RESPONSE_INAPP_ITEM_LIST:Ljava/lang/String; = "INAPP_PURCHASE_ITEM_LIST"

.field public static final RESPONSE_INAPP_PURCHASE_DATA:Ljava/lang/String; = "INAPP_PURCHASE_DATA"

.field public static final RESPONSE_INAPP_PURCHASE_DATA_LIST:Ljava/lang/String; = "INAPP_PURCHASE_DATA_LIST"

.field public static final RESPONSE_INAPP_SIGNATURE:Ljava/lang/String; = "INAPP_DATA_SIGNATURE"

.field public static final RESPONSE_INAPP_SIGNATURE_LIST:Ljava/lang/String; = "INAPP_DATA_SIGNATURE_LIST"

.field private static helper:Lcom/google/payment/IabHelper;


# instance fields
.field mAsyncInProgress:Z

.field private final mAsyncInProgressLock:Ljava/lang/Object;

.field mAsyncOperation:Ljava/lang/String;

.field mContext:Landroid/content/Context;

.field mDebugLog:Z

.field mDebugTag:Ljava/lang/String;

.field mDisposeAfterAsync:Z

.field mDisposed:Z

.field mPurchaseListener:Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;

.field mPurchasingItemType:Ljava/lang/String;

.field mRequestCode:I

.field mService:Lcom/android/vending/billing/IInAppBillingService;

.field mServiceConn:Landroid/content/ServiceConnection;

.field mSetupDone:Z

.field mSignatureBase64:Ljava/lang/String;

.field mSubscriptionUpdateSupported:Z

.field mSubscriptionsSupported:Z

.field paymentType:Lcom/igg/sdk/IGGSDKConstant$PaymentType;


# direct methods
.method private constructor <init>()V
    .locals 2

    .prologue
    const/4 v1, 0x0

    .line 178
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 84
    iput-boolean v1, p0, Lcom/google/payment/IabHelper;->mDebugLog:Z

    .line 85
    const-string v0, "IabHelper"

    iput-object v0, p0, Lcom/google/payment/IabHelper;->mDebugTag:Ljava/lang/String;

    .line 88
    iput-boolean v1, p0, Lcom/google/payment/IabHelper;->mSetupDone:Z

    .line 91
    iput-boolean v1, p0, Lcom/google/payment/IabHelper;->mDisposed:Z

    .line 94
    iput-boolean v1, p0, Lcom/google/payment/IabHelper;->mDisposeAfterAsync:Z

    .line 97
    iput-boolean v1, p0, Lcom/google/payment/IabHelper;->mSubscriptionsSupported:Z

    .line 100
    iput-boolean v1, p0, Lcom/google/payment/IabHelper;->mSubscriptionUpdateSupported:Z

    .line 104
    iput-boolean v1, p0, Lcom/google/payment/IabHelper;->mAsyncInProgress:Z

    .line 107
    new-instance v0, Ljava/lang/Object;

    invoke-direct {v0}, Ljava/lang/Object;-><init>()V

    iput-object v0, p0, Lcom/google/payment/IabHelper;->mAsyncInProgressLock:Ljava/lang/Object;

    .line 111
    const-string v0, ""

    iput-object v0, p0, Lcom/google/payment/IabHelper;->mAsyncOperation:Ljava/lang/String;

    .line 127
    const/4 v0, 0x0

    iput-object v0, p0, Lcom/google/payment/IabHelper;->mSignatureBase64:Ljava/lang/String;

    .line 181
    const-string v0, "IAB helper created."

    invoke-virtual {p0, v0}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 182
    return-void
.end method

.method private checkNotDisposed()V
    .locals 2

    .prologue
    .line 438
    iget-boolean v0, p0, Lcom/google/payment/IabHelper;->mDisposed:Z

    if-eqz v0, :cond_0

    new-instance v0, Ljava/lang/IllegalStateException;

    const-string v1, "IabHelper was disposed of, so it cannot be used."

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 439
    :cond_0
    return-void
.end method

.method public static getResponseDesc(I)Ljava/lang/String;
    .locals 5
    .param p0, "code"    # I

    .prologue
    .line 1062
    const-string v3, "0:OK/1:User Canceled/2:Unknown/3:Billing Unavailable/4:Item unavailable/5:Developer Error/6:Error/7:Item Already Owned/8:Item not owned"

    const-string v4, "/"

    .line 1065
    invoke-virtual {v3, v4}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v0

    .line 1066
    .local v0, "iab_msgs":[Ljava/lang/String;
    const-string v3, "0:OK/-1001:Remote exception during initialization/-1002:Bad response received/-1003:Purchase signature verification failed/-1004:Send intent failed/-1005:User cancelled/-1006:Unknown purchase response/-1007:Missing token/-1008:Unknown error/-1009:Subscriptions not available/-1010:Invalid consumption attempt"

    const-string v4, "/"

    .line 1075
    invoke-virtual {v3, v4}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v1

    .line 1077
    .local v1, "iabhelper_msgs":[Ljava/lang/String;
    const/16 v3, -0x3e8

    if-gt p0, v3, :cond_1

    .line 1078
    rsub-int v2, p0, -0x3e8

    .line 1079
    .local v2, "index":I
    if-ltz v2, :cond_0

    array-length v3, v1

    if-ge v2, v3, :cond_0

    aget-object v3, v1, v2

    .line 1085
    .end local v2    # "index":I
    :goto_0
    return-object v3

    .line 1080
    .restart local v2    # "index":I
    :cond_0
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {p0}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, ":Unknown IAB Helper Error"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    goto :goto_0

    .line 1082
    .end local v2    # "index":I
    :cond_1
    if-ltz p0, :cond_2

    array-length v3, v0

    if-lt p0, v3, :cond_3

    .line 1083
    :cond_2
    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {p0}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, ":Unknown"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    goto :goto_0

    .line 1085
    :cond_3
    aget-object v3, v0, p0

    goto :goto_0
.end method

.method public static sharedInstance()Lcom/google/payment/IabHelper;
    .locals 2

    .prologue
    .line 187
    sget-object v0, Lcom/google/payment/IabHelper;->helper:Lcom/google/payment/IabHelper;

    if-nez v0, :cond_1

    .line 188
    const-class v1, Lcom/google/payment/IabHelper;

    monitor-enter v1

    .line 189
    :try_start_0
    sget-object v0, Lcom/google/payment/IabHelper;->helper:Lcom/google/payment/IabHelper;

    if-nez v0, :cond_0

    .line 190
    new-instance v0, Lcom/google/payment/IabHelper;

    invoke-direct {v0}, Lcom/google/payment/IabHelper;-><init>()V

    sput-object v0, Lcom/google/payment/IabHelper;->helper:Lcom/google/payment/IabHelper;

    .line 192
    :cond_0
    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 194
    :cond_1
    sget-object v0, Lcom/google/payment/IabHelper;->helper:Lcom/google/payment/IabHelper;

    return-object v0

    .line 192
    :catchall_0
    move-exception v0

    :try_start_1
    monitor-exit v1
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    throw v0
.end method


# virtual methods
.method checkSetupDone(Ljava/lang/String;)V
    .locals 3
    .param p1, "operation"    # Ljava/lang/String;

    .prologue
    .line 1091
    iget-boolean v0, p0, Lcom/google/payment/IabHelper;->mSetupDone:Z

    if-nez v0, :cond_0

    .line 1092
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Illegal state for operation ("

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "): IAB helper is not set up."

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/google/payment/IabHelper;->logError(Ljava/lang/String;)V

    .line 1093
    new-instance v0, Ljava/lang/IllegalStateException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "IAB helper is not set up. Can\'t perform operation: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 1095
    :cond_0
    return-void
.end method

.method consume(Lcom/google/payment/Purchase;)V
    .locals 8
    .param p1, "itemInfo"    # Lcom/google/payment/Purchase;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lcom/google/payment/IabException;
        }
    .end annotation

    .prologue
    .line 966
    invoke-direct {p0}, Lcom/google/payment/IabHelper;->checkNotDisposed()V

    .line 967
    const-string v4, "consume"

    invoke-virtual {p0, v4}, Lcom/google/payment/IabHelper;->checkSetupDone(Ljava/lang/String;)V

    .line 969
    iget-object v4, p1, Lcom/google/payment/Purchase;->mItemType:Ljava/lang/String;

    const-string v5, "inapp"

    invoke-virtual {v4, v5}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_0

    .line 970
    new-instance v4, Lcom/google/payment/IabException;

    const/16 v5, -0x3f2

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "Items of type \'"

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    iget-object v7, p1, Lcom/google/payment/Purchase;->mItemType:Ljava/lang/String;

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    const-string v7, "\' can\'t be consumed."

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-direct {v4, v5, v6}, Lcom/google/payment/IabException;-><init>(ILjava/lang/String;)V

    throw v4

    .line 975
    :cond_0
    :try_start_0
    invoke-virtual {p1}, Lcom/google/payment/Purchase;->getToken()Ljava/lang/String;

    move-result-object v3

    .line 976
    .local v3, "token":Ljava/lang/String;
    invoke-virtual {p1}, Lcom/google/payment/Purchase;->getSku()Ljava/lang/String;

    move-result-object v2

    .line 977
    .local v2, "sku":Ljava/lang/String;
    if-eqz v3, :cond_1

    const-string v4, ""

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_2

    .line 978
    :cond_1
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "Can\'t consume "

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, ". No token."

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {p0, v4}, Lcom/google/payment/IabHelper;->logError(Ljava/lang/String;)V

    .line 979
    new-instance v4, Lcom/google/payment/IabException;

    const/16 v5, -0x3ef

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "PurchaseInfo is missing token for sku: "

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    const-string v7, " "

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-direct {v4, v5, v6}, Lcom/google/payment/IabException;-><init>(ILjava/lang/String;)V

    throw v4
    :try_end_0
    .catch Landroid/os/RemoteException; {:try_start_0 .. :try_end_0} :catch_0

    .line 993
    .end local v2    # "sku":Ljava/lang/String;
    .end local v3    # "token":Ljava/lang/String;
    :catch_0
    move-exception v0

    .line 994
    .local v0, "e":Landroid/os/RemoteException;
    new-instance v4, Lcom/google/payment/IabException;

    const/16 v5, -0x3e9

    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "Remote exception while consuming. PurchaseInfo: "

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-direct {v4, v5, v6, v0}, Lcom/google/payment/IabException;-><init>(ILjava/lang/String;Ljava/lang/Exception;)V

    throw v4

    .line 983
    .end local v0    # "e":Landroid/os/RemoteException;
    .restart local v2    # "sku":Ljava/lang/String;
    .restart local v3    # "token":Ljava/lang/String;
    :cond_2
    :try_start_1
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "Consuming sku: "

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, ", token: "

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {p0, v4}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 984
    iget-object v4, p0, Lcom/google/payment/IabHelper;->mService:Lcom/android/vending/billing/IInAppBillingService;

    const/4 v5, 0x3

    iget-object v6, p0, Lcom/google/payment/IabHelper;->mContext:Landroid/content/Context;

    invoke-virtual {v6}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v6

    invoke-interface {v4, v5, v6, v3}, Lcom/android/vending/billing/IInAppBillingService;->consumePurchase(ILjava/lang/String;Ljava/lang/String;)I

    move-result v1

    .line 985
    .local v1, "response":I
    if-nez v1, :cond_3

    .line 986
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "Successfully consumed sku: "

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {p0, v4}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 996
    return-void

    .line 989
    :cond_3
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "Error consuming consuming sku "

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, ". "

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-static {v1}, Lcom/google/payment/IabHelper;->getResponseDesc(I)Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {p0, v4}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 990
    new-instance v4, Lcom/google/payment/IabException;

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "Error consuming sku "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-direct {v4, v1, v5}, Lcom/google/payment/IabException;-><init>(ILjava/lang/String;)V

    throw v4
    :try_end_1
    .catch Landroid/os/RemoteException; {:try_start_1 .. :try_end_1} :catch_0
.end method

.method public consumeAsync(Lcom/google/payment/Purchase;Lcom/google/payment/IabHelper$OnConsumeFinishedListener;)V
    .locals 2
    .param p1, "purchase"    # Lcom/google/payment/Purchase;
    .param p2, "listener"    # Lcom/google/payment/IabHelper$OnConsumeFinishedListener;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lcom/google/payment/IabHelper$IabAsyncInProgressException;
        }
    .end annotation

    .prologue
    .line 1035
    invoke-direct {p0}, Lcom/google/payment/IabHelper;->checkNotDisposed()V

    .line 1036
    const-string v1, "consume"

    invoke-virtual {p0, v1}, Lcom/google/payment/IabHelper;->checkSetupDone(Ljava/lang/String;)V

    .line 1037
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    .line 1038
    .local v0, "purchases":Ljava/util/List;, "Ljava/util/List<Lcom/google/payment/Purchase;>;"
    invoke-interface {v0, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 1039
    const/4 v1, 0x0

    invoke-virtual {p0, v0, p2, v1}, Lcom/google/payment/IabHelper;->consumeAsyncInternal(Ljava/util/List;Lcom/google/payment/IabHelper$OnConsumeFinishedListener;Lcom/google/payment/IabHelper$OnConsumeMultiFinishedListener;)V

    .line 1040
    return-void
.end method

.method public consumeAsync(Ljava/util/List;Lcom/google/payment/IabHelper$OnConsumeMultiFinishedListener;)V
    .locals 1
    .param p2, "listener"    # Lcom/google/payment/IabHelper$OnConsumeMultiFinishedListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Lcom/google/payment/Purchase;",
            ">;",
            "Lcom/google/payment/IabHelper$OnConsumeMultiFinishedListener;",
            ")V"
        }
    .end annotation

    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lcom/google/payment/IabHelper$IabAsyncInProgressException;
        }
    .end annotation

    .prologue
    .line 1049
    .local p1, "purchases":Ljava/util/List;, "Ljava/util/List<Lcom/google/payment/Purchase;>;"
    invoke-direct {p0}, Lcom/google/payment/IabHelper;->checkNotDisposed()V

    .line 1050
    const-string v0, "consume"

    invoke-virtual {p0, v0}, Lcom/google/payment/IabHelper;->checkSetupDone(Ljava/lang/String;)V

    .line 1051
    const/4 v0, 0x0

    invoke-virtual {p0, p1, v0, p2}, Lcom/google/payment/IabHelper;->consumeAsyncInternal(Ljava/util/List;Lcom/google/payment/IabHelper$OnConsumeFinishedListener;Lcom/google/payment/IabHelper$OnConsumeMultiFinishedListener;)V

    .line 1052
    return-void
.end method

.method consumeAsyncInternal(Ljava/util/List;Lcom/google/payment/IabHelper$OnConsumeFinishedListener;Lcom/google/payment/IabHelper$OnConsumeMultiFinishedListener;)V
    .locals 7
    .param p2, "singleListener"    # Lcom/google/payment/IabHelper$OnConsumeFinishedListener;
    .param p3, "multiListener"    # Lcom/google/payment/IabHelper$OnConsumeMultiFinishedListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Lcom/google/payment/Purchase;",
            ">;",
            "Lcom/google/payment/IabHelper$OnConsumeFinishedListener;",
            "Lcom/google/payment/IabHelper$OnConsumeMultiFinishedListener;",
            ")V"
        }
    .end annotation

    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lcom/google/payment/IabHelper$IabAsyncInProgressException;
        }
    .end annotation

    .prologue
    .line 1312
    .local p1, "purchases":Ljava/util/List;, "Ljava/util/List<Lcom/google/payment/Purchase;>;"
    new-instance v4, Landroid/os/Handler;

    invoke-direct {v4}, Landroid/os/Handler;-><init>()V

    .line 1313
    .local v4, "handler":Landroid/os/Handler;
    const-string v0, "consume"

    invoke-virtual {p0, v0}, Lcom/google/payment/IabHelper;->flagStartAsync(Ljava/lang/String;)V

    .line 1314
    new-instance v6, Ljava/lang/Thread;

    new-instance v0, Lcom/google/payment/IabHelper$5;

    move-object v1, p0

    move-object v2, p1

    move-object v3, p2

    move-object v5, p3

    invoke-direct/range {v0 .. v5}, Lcom/google/payment/IabHelper$5;-><init>(Lcom/google/payment/IabHelper;Ljava/util/List;Lcom/google/payment/IabHelper$OnConsumeFinishedListener;Landroid/os/Handler;Lcom/google/payment/IabHelper$OnConsumeMultiFinishedListener;)V

    invoke-direct {v6, v0}, Ljava/lang/Thread;-><init>(Ljava/lang/Runnable;)V

    .line 1343
    invoke-virtual {v6}, Ljava/lang/Thread;->start()V

    .line 1344
    return-void
.end method

.method public dispose()V
    .locals 5
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lcom/google/payment/IabHelper$IabAsyncInProgressException;
        }
    .end annotation

    .prologue
    const/4 v3, 0x0

    .line 391
    iget-object v2, p0, Lcom/google/payment/IabHelper;->mAsyncInProgressLock:Ljava/lang/Object;

    monitor-enter v2

    .line 392
    :try_start_0
    iget-boolean v1, p0, Lcom/google/payment/IabHelper;->mAsyncInProgress:Z

    if-eqz v1, :cond_0

    .line 393
    new-instance v1, Lcom/google/payment/IabHelper$IabAsyncInProgressException;

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "Can\'t dispose because an async operation ("

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    iget-object v4, p0, Lcom/google/payment/IabHelper;->mAsyncOperation:Ljava/lang/String;

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, ") is in progress."

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-direct {v1, v3}, Lcom/google/payment/IabHelper$IabAsyncInProgressException;-><init>(Ljava/lang/String;)V

    throw v1

    .line 396
    :catchall_0
    move-exception v1

    monitor-exit v2
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v1

    :cond_0
    :try_start_1
    monitor-exit v2
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    .line 397
    const-string v1, "Disposing."

    invoke-virtual {p0, v1}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 398
    const/4 v1, 0x0

    iput-boolean v1, p0, Lcom/google/payment/IabHelper;->mSetupDone:Z

    .line 399
    iget-object v1, p0, Lcom/google/payment/IabHelper;->mServiceConn:Landroid/content/ServiceConnection;

    if-eqz v1, :cond_1

    .line 400
    const-string v1, "Unbinding from service."

    invoke-virtual {p0, v1}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 402
    :try_start_2
    iget-object v1, p0, Lcom/google/payment/IabHelper;->mContext:Landroid/content/Context;

    if-eqz v1, :cond_1

    iget-object v1, p0, Lcom/google/payment/IabHelper;->mContext:Landroid/content/Context;

    iget-object v2, p0, Lcom/google/payment/IabHelper;->mServiceConn:Landroid/content/ServiceConnection;

    invoke-virtual {v1, v2}, Landroid/content/Context;->unbindService(Landroid/content/ServiceConnection;)V
    :try_end_2
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_0

    .line 408
    :cond_1
    :goto_0
    const/4 v1, 0x1

    iput-boolean v1, p0, Lcom/google/payment/IabHelper;->mDisposed:Z

    .line 409
    iput-object v3, p0, Lcom/google/payment/IabHelper;->mContext:Landroid/content/Context;

    .line 410
    iput-object v3, p0, Lcom/google/payment/IabHelper;->mServiceConn:Landroid/content/ServiceConnection;

    .line 411
    iput-object v3, p0, Lcom/google/payment/IabHelper;->mService:Lcom/android/vending/billing/IInAppBillingService;

    .line 412
    iput-object v3, p0, Lcom/google/payment/IabHelper;->mPurchaseListener:Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;

    .line 413
    return-void

    .line 403
    :catch_0
    move-exception v0

    .line 404
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0
.end method

.method public disposeWhenFinished()V
    .locals 2

    .prologue
    .line 420
    iget-object v1, p0, Lcom/google/payment/IabHelper;->mAsyncInProgressLock:Ljava/lang/Object;

    monitor-enter v1

    .line 421
    :try_start_0
    iget-boolean v0, p0, Lcom/google/payment/IabHelper;->mAsyncInProgress:Z

    if-eqz v0, :cond_0

    .line 422
    const-string v0, "Will dispose after async operation finishes."

    invoke-virtual {p0, v0}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 423
    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/google/payment/IabHelper;->mDisposeAfterAsync:Z

    .line 432
    :goto_0
    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 434
    const/4 v0, 0x0

    sput-object v0, Lcom/google/payment/IabHelper;->helper:Lcom/google/payment/IabHelper;

    .line 435
    return-void

    .line 426
    :cond_0
    :try_start_1
    invoke-virtual {p0}, Lcom/google/payment/IabHelper;->dispose()V
    :try_end_1
    .catch Lcom/google/payment/IabHelper$IabAsyncInProgressException; {:try_start_1 .. :try_end_1} :catch_0
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    goto :goto_0

    .line 427
    :catch_0
    move-exception v0

    goto :goto_0

    .line 432
    :catchall_0
    move-exception v0

    :try_start_2
    monitor-exit v1
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    throw v0
.end method

.method public enableDebugLogging(Z)V
    .locals 0
    .param p1, "enable"    # Z

    .prologue
    .line 245
    invoke-direct {p0}, Lcom/google/payment/IabHelper;->checkNotDisposed()V

    .line 246
    iput-boolean p1, p0, Lcom/google/payment/IabHelper;->mDebugLog:Z

    .line 247
    return-void
.end method

.method public enableDebugLogging(ZLjava/lang/String;)V
    .locals 0
    .param p1, "enable"    # Z
    .param p2, "tag"    # Ljava/lang/String;

    .prologue
    .line 239
    invoke-direct {p0}, Lcom/google/payment/IabHelper;->checkNotDisposed()V

    .line 240
    iput-boolean p1, p0, Lcom/google/payment/IabHelper;->mDebugLog:Z

    .line 241
    iput-object p2, p0, Lcom/google/payment/IabHelper;->mDebugTag:Ljava/lang/String;

    .line 242
    return-void
.end method

.method flagEndAsync()V
    .locals 3

    .prologue
    .line 1143
    iget-object v1, p0, Lcom/google/payment/IabHelper;->mAsyncInProgressLock:Ljava/lang/Object;

    monitor-enter v1

    .line 1144
    :try_start_0
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Ending async operation: "

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v2, p0, Lcom/google/payment/IabHelper;->mAsyncOperation:Ljava/lang/String;

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 1145
    const-string v0, ""

    iput-object v0, p0, Lcom/google/payment/IabHelper;->mAsyncOperation:Ljava/lang/String;

    .line 1146
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/google/payment/IabHelper;->mAsyncInProgress:Z

    .line 1147
    iget-boolean v0, p0, Lcom/google/payment/IabHelper;->mDisposeAfterAsync:Z
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    if-eqz v0, :cond_0

    .line 1149
    :try_start_1
    invoke-virtual {p0}, Lcom/google/payment/IabHelper;->dispose()V
    :try_end_1
    .catch Lcom/google/payment/IabHelper$IabAsyncInProgressException; {:try_start_1 .. :try_end_1} :catch_0
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    .line 1155
    :cond_0
    :goto_0
    :try_start_2
    monitor-exit v1

    .line 1156
    return-void

    .line 1155
    :catchall_0
    move-exception v0

    monitor-exit v1
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    throw v0

    .line 1150
    :catch_0
    move-exception v0

    goto :goto_0
.end method

.method flagStartAsync(Ljava/lang/String;)V
    .locals 4
    .param p1, "operation"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lcom/google/payment/IabHelper$IabAsyncInProgressException;
        }
    .end annotation

    .prologue
    .line 1130
    iget-object v1, p0, Lcom/google/payment/IabHelper;->mAsyncInProgressLock:Ljava/lang/Object;

    monitor-enter v1

    .line 1131
    :try_start_0
    iget-boolean v0, p0, Lcom/google/payment/IabHelper;->mAsyncInProgress:Z

    if-eqz v0, :cond_0

    .line 1132
    new-instance v0, Lcom/google/payment/IabHelper$IabAsyncInProgressException;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Can\'t start async operation ("

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, ") because another async operation ("

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    iget-object v3, p0, Lcom/google/payment/IabHelper;->mAsyncOperation:Ljava/lang/String;

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, ") is in progress."

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-direct {v0, v2}, Lcom/google/payment/IabHelper$IabAsyncInProgressException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 1139
    :catchall_0
    move-exception v0

    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0

    .line 1136
    :cond_0
    :try_start_1
    iput-object p1, p0, Lcom/google/payment/IabHelper;->mAsyncOperation:Ljava/lang/String;

    .line 1137
    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/google/payment/IabHelper;->mAsyncInProgress:Z

    .line 1138
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Starting async operation: "

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 1139
    monitor-exit v1
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    .line 1140
    return-void
.end method

.method public getPaymentType()Lcom/igg/sdk/IGGSDKConstant$PaymentType;
    .locals 1

    .prologue
    .line 229
    iget-object v0, p0, Lcom/google/payment/IabHelper;->paymentType:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    if-nez v0, :cond_0

    .line 230
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$PaymentType;->GOOGLE_PLAY:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    iput-object v0, p0, Lcom/google/payment/IabHelper;->paymentType:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    .line 232
    :cond_0
    iget-object v0, p0, Lcom/google/payment/IabHelper;->paymentType:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    return-object v0
.end method

.method getResponseCodeFromBundle(Landroid/os/Bundle;)I
    .locals 4
    .param p1, "b"    # Landroid/os/Bundle;

    .prologue
    .line 1099
    const-string v1, "RESPONSE_CODE"

    invoke-virtual {p1, v1}, Landroid/os/Bundle;->get(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    .line 1100
    .local v0, "o":Ljava/lang/Object;
    if-nez v0, :cond_0

    .line 1101
    const-string v1, "Bundle with null response code, assuming OK (known issue)"

    invoke-virtual {p0, v1}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 1102
    const/4 v1, 0x0

    .line 1105
    .end local v0    # "o":Ljava/lang/Object;
    :goto_0
    return v1

    .line 1104
    .restart local v0    # "o":Ljava/lang/Object;
    :cond_0
    instance-of v1, v0, Ljava/lang/Integer;

    if-eqz v1, :cond_1

    check-cast v0, Ljava/lang/Integer;

    .end local v0    # "o":Ljava/lang/Object;
    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v1

    goto :goto_0

    .line 1105
    .restart local v0    # "o":Ljava/lang/Object;
    :cond_1
    instance-of v1, v0, Ljava/lang/Long;

    if-eqz v1, :cond_2

    check-cast v0, Ljava/lang/Long;

    .end local v0    # "o":Ljava/lang/Object;
    invoke-virtual {v0}, Ljava/lang/Long;->longValue()J

    move-result-wide v2

    long-to-int v1, v2

    goto :goto_0

    .line 1107
    .restart local v0    # "o":Ljava/lang/Object;
    :cond_2
    const-string v1, "Unexpected type for bundle response code."

    invoke-virtual {p0, v1}, Lcom/google/payment/IabHelper;->logError(Ljava/lang/String;)V

    .line 1108
    invoke-virtual {v0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {p0, v1}, Lcom/google/payment/IabHelper;->logError(Ljava/lang/String;)V

    .line 1109
    new-instance v1, Ljava/lang/RuntimeException;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Unexpected type for bundle response code: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-direct {v1, v2}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v1
.end method

.method getResponseCodeFromIntent(Landroid/content/Intent;)I
    .locals 4
    .param p1, "i"    # Landroid/content/Intent;

    .prologue
    .line 1115
    invoke-virtual {p1}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v1

    const-string v2, "RESPONSE_CODE"

    invoke-virtual {v1, v2}, Landroid/os/Bundle;->get(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v0

    .line 1116
    .local v0, "o":Ljava/lang/Object;
    if-nez v0, :cond_0

    .line 1117
    const-string v1, "Intent with no response code, assuming OK (known issue)"

    invoke-virtual {p0, v1}, Lcom/google/payment/IabHelper;->logError(Ljava/lang/String;)V

    .line 1118
    const/4 v1, 0x0

    .line 1121
    .end local v0    # "o":Ljava/lang/Object;
    :goto_0
    return v1

    .line 1120
    .restart local v0    # "o":Ljava/lang/Object;
    :cond_0
    instance-of v1, v0, Ljava/lang/Integer;

    if-eqz v1, :cond_1

    check-cast v0, Ljava/lang/Integer;

    .end local v0    # "o":Ljava/lang/Object;
    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v1

    goto :goto_0

    .line 1121
    .restart local v0    # "o":Ljava/lang/Object;
    :cond_1
    instance-of v1, v0, Ljava/lang/Long;

    if-eqz v1, :cond_2

    check-cast v0, Ljava/lang/Long;

    .end local v0    # "o":Ljava/lang/Object;
    invoke-virtual {v0}, Ljava/lang/Long;->longValue()J

    move-result-wide v2

    long-to-int v1, v2

    goto :goto_0

    .line 1123
    .restart local v0    # "o":Ljava/lang/Object;
    :cond_2
    const-string v1, "Unexpected type for intent response code."

    invoke-virtual {p0, v1}, Lcom/google/payment/IabHelper;->logError(Ljava/lang/String;)V

    .line 1124
    invoke-virtual {v0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {p0, v1}, Lcom/google/payment/IabHelper;->logError(Ljava/lang/String;)V

    .line 1125
    new-instance v1, Ljava/lang/RuntimeException;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Unexpected type for intent response code: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v0}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-direct {v1, v2}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw v1
.end method

.method public handleActivityResult(IILandroid/content/Intent;)Z
    .locals 12
    .param p1, "requestCode"    # I
    .param p2, "resultCode"    # I
    .param p3, "data"    # Landroid/content/Intent;

    .prologue
    .line 597
    iget v8, p0, Lcom/google/payment/IabHelper;->mRequestCode:I

    if-eq p1, v8, :cond_0

    const/4 v8, 0x0

    .line 676
    :goto_0
    return v8

    .line 599
    :cond_0
    invoke-direct {p0}, Lcom/google/payment/IabHelper;->checkNotDisposed()V

    .line 600
    const-string v8, "handleActivityResult"

    invoke-virtual {p0, v8}, Lcom/google/payment/IabHelper;->checkSetupDone(Ljava/lang/String;)V

    .line 603
    invoke-virtual {p0}, Lcom/google/payment/IabHelper;->flagEndAsync()V

    .line 605
    if-nez p3, :cond_2

    .line 606
    const-string v8, "Null data in IAB activity result."

    invoke-virtual {p0, v8}, Lcom/google/payment/IabHelper;->logError(Ljava/lang/String;)V

    .line 607
    new-instance v6, Lcom/google/payment/IabResult;

    const/16 v8, -0x3ea

    const-string v9, "Null data in IAB result"

    invoke-direct {v6, v8, v9}, Lcom/google/payment/IabResult;-><init>(ILjava/lang/String;)V

    .line 608
    .local v6, "result":Lcom/google/payment/IabResult;
    iget-object v8, p0, Lcom/google/payment/IabHelper;->mPurchaseListener:Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;

    if-eqz v8, :cond_1

    iget-object v8, p0, Lcom/google/payment/IabHelper;->mPurchaseListener:Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;

    const/4 v9, 0x0

    invoke-interface {v8, v6, v9}, Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;->onIabPurchaseFinished(Lcom/google/payment/IabResult;Lcom/google/payment/Purchase;)V

    .line 609
    :cond_1
    const/4 v8, 0x1

    goto :goto_0

    .line 612
    .end local v6    # "result":Lcom/google/payment/IabResult;
    :cond_2
    invoke-virtual {p0, p3}, Lcom/google/payment/IabHelper;->getResponseCodeFromIntent(Landroid/content/Intent;)I

    move-result v5

    .line 613
    .local v5, "responseCode":I
    const-string v8, "INAPP_PURCHASE_DATA"

    invoke-virtual {p3, v8}, Landroid/content/Intent;->getStringExtra(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    .line 614
    .local v4, "purchaseData":Ljava/lang/String;
    const-string v8, "INAPP_DATA_SIGNATURE"

    invoke-virtual {p3, v8}, Landroid/content/Intent;->getStringExtra(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 616
    .local v0, "dataSignature":Ljava/lang/String;
    const/4 v8, -0x1

    if-ne p2, v8, :cond_a

    if-nez v5, :cond_a

    .line 617
    const-string v8, "Successful resultcode from purchase activity."

    invoke-virtual {p0, v8}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 618
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "Purchase data: "

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {p0, v8}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 619
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "Data signature: "

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {p0, v8}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 620
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "Extras: "

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {p3}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {p0, v8}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 621
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "Expected item type: "

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    iget-object v9, p0, Lcom/google/payment/IabHelper;->mPurchasingItemType:Ljava/lang/String;

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {p0, v8}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 623
    if-eqz v4, :cond_3

    if-nez v0, :cond_5

    .line 624
    :cond_3
    const-string v8, "BUG: either purchaseData or dataSignature is null."

    invoke-virtual {p0, v8}, Lcom/google/payment/IabHelper;->logError(Ljava/lang/String;)V

    .line 625
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "Extras: "

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {p3}, Landroid/content/Intent;->getExtras()Landroid/os/Bundle;

    move-result-object v9

    invoke-virtual {v9}, Landroid/os/Bundle;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {p0, v8}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 626
    new-instance v6, Lcom/google/payment/IabResult;

    const/16 v8, -0x3f0

    const-string v9, "IAB returned null purchaseData or dataSignature"

    invoke-direct {v6, v8, v9}, Lcom/google/payment/IabResult;-><init>(ILjava/lang/String;)V

    .line 627
    .restart local v6    # "result":Lcom/google/payment/IabResult;
    iget-object v8, p0, Lcom/google/payment/IabHelper;->mPurchaseListener:Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;

    if-eqz v8, :cond_4

    iget-object v8, p0, Lcom/google/payment/IabHelper;->mPurchaseListener:Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;

    const/4 v9, 0x0

    invoke-interface {v8, v6, v9}, Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;->onIabPurchaseFinished(Lcom/google/payment/IabResult;Lcom/google/payment/Purchase;)V

    .line 628
    :cond_4
    const/4 v8, 0x1

    goto/16 :goto_0

    .line 631
    .end local v6    # "result":Lcom/google/payment/IabResult;
    :cond_5
    const/4 v2, 0x0

    .line 633
    .local v2, "purchase":Lcom/google/payment/Purchase;
    :try_start_0
    new-instance v3, Lcom/google/payment/Purchase;

    iget-object v8, p0, Lcom/google/payment/IabHelper;->mPurchasingItemType:Ljava/lang/String;

    invoke-direct {v3, v8, v4, v0}, Lcom/google/payment/Purchase;-><init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    .line 634
    .end local v2    # "purchase":Lcom/google/payment/Purchase;
    .local v3, "purchase":Lcom/google/payment/Purchase;
    :try_start_1
    invoke-virtual {v3}, Lcom/google/payment/Purchase;->getSku()Ljava/lang/String;

    move-result-object v7

    .line 637
    .local v7, "sku":Ljava/lang/String;
    iget-object v8, p0, Lcom/google/payment/IabHelper;->mSignatureBase64:Ljava/lang/String;

    invoke-static {v8, v4, v0}, Lcom/google/payment/Security;->verifyPurchase(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Z

    move-result v8

    if-nez v8, :cond_7

    .line 638
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "Purchase signature verification FAILED for sku "

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {p0, v8}, Lcom/google/payment/IabHelper;->logError(Ljava/lang/String;)V

    .line 639
    new-instance v6, Lcom/google/payment/IabResult;

    const/16 v8, -0x3eb

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    const-string v10, "Signature verification failed for sku "

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-direct {v6, v8, v9}, Lcom/google/payment/IabResult;-><init>(ILjava/lang/String;)V

    .line 640
    .restart local v6    # "result":Lcom/google/payment/IabResult;
    iget-object v8, p0, Lcom/google/payment/IabHelper;->mPurchaseListener:Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;

    if-eqz v8, :cond_6

    iget-object v8, p0, Lcom/google/payment/IabHelper;->mPurchaseListener:Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;

    invoke-interface {v8, v6, v3}, Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;->onIabPurchaseFinished(Lcom/google/payment/IabResult;Lcom/google/payment/Purchase;)V

    .line 641
    :cond_6
    const/4 v8, 0x1

    goto/16 :goto_0

    .line 643
    .end local v6    # "result":Lcom/google/payment/IabResult;
    :cond_7
    const-string v8, "Purchase signature successfully verified."

    invoke-virtual {p0, v8}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_1

    .line 653
    iget-object v8, p0, Lcom/google/payment/IabHelper;->mPurchaseListener:Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;

    if-eqz v8, :cond_8

    .line 654
    iget-object v8, p0, Lcom/google/payment/IabHelper;->mPurchaseListener:Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;

    new-instance v9, Lcom/google/payment/IabResult;

    const/4 v10, 0x0

    const-string v11, "Success"

    invoke-direct {v9, v10, v11}, Lcom/google/payment/IabResult;-><init>(ILjava/lang/String;)V

    invoke-interface {v8, v9, v3}, Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;->onIabPurchaseFinished(Lcom/google/payment/IabResult;Lcom/google/payment/Purchase;)V

    .line 676
    .end local v3    # "purchase":Lcom/google/payment/Purchase;
    .end local v7    # "sku":Ljava/lang/String;
    :cond_8
    :goto_1
    const/4 v8, 0x1

    goto/16 :goto_0

    .line 645
    .restart local v2    # "purchase":Lcom/google/payment/Purchase;
    :catch_0
    move-exception v1

    .line 646
    .local v1, "e":Lorg/json/JSONException;
    :goto_2
    const-string v8, "Failed to parse purchase data."

    invoke-virtual {p0, v8}, Lcom/google/payment/IabHelper;->logError(Ljava/lang/String;)V

    .line 647
    invoke-virtual {v1}, Lorg/json/JSONException;->printStackTrace()V

    .line 648
    new-instance v6, Lcom/google/payment/IabResult;

    const/16 v8, -0x3ea

    const-string v9, "Failed to parse purchase data."

    invoke-direct {v6, v8, v9}, Lcom/google/payment/IabResult;-><init>(ILjava/lang/String;)V

    .line 649
    .restart local v6    # "result":Lcom/google/payment/IabResult;
    iget-object v8, p0, Lcom/google/payment/IabHelper;->mPurchaseListener:Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;

    if-eqz v8, :cond_9

    iget-object v8, p0, Lcom/google/payment/IabHelper;->mPurchaseListener:Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;

    const/4 v9, 0x0

    invoke-interface {v8, v6, v9}, Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;->onIabPurchaseFinished(Lcom/google/payment/IabResult;Lcom/google/payment/Purchase;)V

    .line 650
    :cond_9
    const/4 v8, 0x1

    goto/16 :goto_0

    .line 657
    .end local v1    # "e":Lorg/json/JSONException;
    .end local v2    # "purchase":Lcom/google/payment/Purchase;
    .end local v6    # "result":Lcom/google/payment/IabResult;
    :cond_a
    const/4 v8, -0x1

    if-ne p2, v8, :cond_b

    .line 659
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "Result code was OK but in-app billing response was not OK: "

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-static {v5}, Lcom/google/payment/IabHelper;->getResponseDesc(I)Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {p0, v8}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 660
    iget-object v8, p0, Lcom/google/payment/IabHelper;->mPurchaseListener:Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;

    if-eqz v8, :cond_8

    .line 661
    new-instance v6, Lcom/google/payment/IabResult;

    const-string v8, "Problem purchashing item."

    invoke-direct {v6, v5, v8}, Lcom/google/payment/IabResult;-><init>(ILjava/lang/String;)V

    .line 662
    .restart local v6    # "result":Lcom/google/payment/IabResult;
    iget-object v8, p0, Lcom/google/payment/IabHelper;->mPurchaseListener:Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;

    const/4 v9, 0x0

    invoke-interface {v8, v6, v9}, Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;->onIabPurchaseFinished(Lcom/google/payment/IabResult;Lcom/google/payment/Purchase;)V

    goto :goto_1

    .line 665
    .end local v6    # "result":Lcom/google/payment/IabResult;
    :cond_b
    if-nez p2, :cond_c

    .line 666
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "Purchase canceled - Response: "

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-static {v5}, Lcom/google/payment/IabHelper;->getResponseDesc(I)Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {p0, v8}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 667
    new-instance v6, Lcom/google/payment/IabResult;

    const/16 v8, -0x3ed

    const-string v9, "User canceled."

    invoke-direct {v6, v8, v9}, Lcom/google/payment/IabResult;-><init>(ILjava/lang/String;)V

    .line 668
    .restart local v6    # "result":Lcom/google/payment/IabResult;
    iget-object v8, p0, Lcom/google/payment/IabHelper;->mPurchaseListener:Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;

    if-eqz v8, :cond_8

    iget-object v8, p0, Lcom/google/payment/IabHelper;->mPurchaseListener:Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;

    const/4 v9, 0x0

    invoke-interface {v8, v6, v9}, Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;->onIabPurchaseFinished(Lcom/google/payment/IabResult;Lcom/google/payment/Purchase;)V

    goto :goto_1

    .line 671
    .end local v6    # "result":Lcom/google/payment/IabResult;
    :cond_c
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "Purchase failed. Result code: "

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-static {p2}, Ljava/lang/Integer;->toString(I)Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, ". Response: "

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    .line 672
    invoke-static {v5}, Lcom/google/payment/IabHelper;->getResponseDesc(I)Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    .line 671
    invoke-virtual {p0, v8}, Lcom/google/payment/IabHelper;->logError(Ljava/lang/String;)V

    .line 673
    new-instance v6, Lcom/google/payment/IabResult;

    const/16 v8, -0x3ee

    const-string v9, "Unknown purchase response."

    invoke-direct {v6, v8, v9}, Lcom/google/payment/IabResult;-><init>(ILjava/lang/String;)V

    .line 674
    .restart local v6    # "result":Lcom/google/payment/IabResult;
    iget-object v8, p0, Lcom/google/payment/IabHelper;->mPurchaseListener:Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;

    if-eqz v8, :cond_8

    iget-object v8, p0, Lcom/google/payment/IabHelper;->mPurchaseListener:Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;

    const/4 v9, 0x0

    invoke-interface {v8, v6, v9}, Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;->onIabPurchaseFinished(Lcom/google/payment/IabResult;Lcom/google/payment/Purchase;)V

    goto/16 :goto_1

    .line 645
    .end local v6    # "result":Lcom/google/payment/IabResult;
    .restart local v3    # "purchase":Lcom/google/payment/Purchase;
    :catch_1
    move-exception v1

    move-object v2, v3

    .end local v3    # "purchase":Lcom/google/payment/Purchase;
    .restart local v2    # "purchase":Lcom/google/payment/Purchase;
    goto/16 :goto_2
.end method

.method public isAsyncInProgress()Z
    .locals 1

    .prologue
    .line 1162
    iget-boolean v0, p0, Lcom/google/payment/IabHelper;->mAsyncInProgress:Z

    return v0
.end method

.method public launchPurchaseFlow(Landroid/app/Activity;Ljava/lang/String;ILcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;)V
    .locals 6
    .param p1, "act"    # Landroid/app/Activity;
    .param p2, "sku"    # Ljava/lang/String;
    .param p3, "requestCode"    # I
    .param p4, "listener"    # Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lcom/google/payment/IabHelper$IabAsyncInProgressException;
        }
    .end annotation

    .prologue
    .line 470
    const-string v5, ""

    move-object v0, p0

    move-object v1, p1

    move-object v2, p2

    move v3, p3

    move-object v4, p4

    invoke-virtual/range {v0 .. v5}, Lcom/google/payment/IabHelper;->launchPurchaseFlow(Landroid/app/Activity;Ljava/lang/String;ILcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;Ljava/lang/String;)V

    .line 471
    return-void
.end method

.method public launchPurchaseFlow(Landroid/app/Activity;Ljava/lang/String;ILcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;Ljava/lang/String;)V
    .locals 8
    .param p1, "act"    # Landroid/app/Activity;
    .param p2, "sku"    # Ljava/lang/String;
    .param p3, "requestCode"    # I
    .param p4, "listener"    # Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;
    .param p5, "extraData"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lcom/google/payment/IabHelper$IabAsyncInProgressException;
        }
    .end annotation

    .prologue
    .line 476
    const-string v3, "inapp"

    const/4 v4, 0x0

    move-object v0, p0

    move-object v1, p1

    move-object v2, p2

    move v5, p3

    move-object v6, p4

    move-object v7, p5

    invoke-virtual/range {v0 .. v7}, Lcom/google/payment/IabHelper;->launchPurchaseFlow(Landroid/app/Activity;Ljava/lang/String;Ljava/lang/String;Ljava/util/List;ILcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;Ljava/lang/String;)V

    .line 477
    return-void
.end method

.method public launchPurchaseFlow(Landroid/app/Activity;Ljava/lang/String;Ljava/lang/String;Ljava/util/List;ILcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;Ljava/lang/String;)V
    .locals 14
    .param p1, "act"    # Landroid/app/Activity;
    .param p2, "sku"    # Ljava/lang/String;
    .param p3, "itemType"    # Ljava/lang/String;
    .param p5, "requestCode"    # I
    .param p6, "listener"    # Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;
    .param p7, "extraData"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/app/Activity;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;I",
            "Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;",
            "Ljava/lang/String;",
            ")V"
        }
    .end annotation

    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lcom/google/payment/IabHelper$IabAsyncInProgressException;
        }
    .end annotation

    .prologue
    .line 513
    .local p4, "oldSkus":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    invoke-direct {p0}, Lcom/google/payment/IabHelper;->checkNotDisposed()V

    .line 514
    const-string v1, "launchPurchaseFlow"

    invoke-virtual {p0, v1}, Lcom/google/payment/IabHelper;->checkSetupDone(Ljava/lang/String;)V

    .line 515
    const-string v1, "launchPurchaseFlow"

    invoke-virtual {p0, v1}, Lcom/google/payment/IabHelper;->flagStartAsync(Ljava/lang/String;)V

    .line 518
    const-string v1, "subs"

    move-object/from16 v0, p3

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    iget-boolean v1, p0, Lcom/google/payment/IabHelper;->mSubscriptionsSupported:Z

    if-nez v1, :cond_1

    .line 519
    new-instance v11, Lcom/google/payment/IabResult;

    const/16 v1, -0x3f1

    const-string v2, "Subscriptions are not available."

    invoke-direct {v11, v1, v2}, Lcom/google/payment/IabResult;-><init>(ILjava/lang/String;)V

    .line 521
    .local v11, "r":Lcom/google/payment/IabResult;
    invoke-virtual {p0}, Lcom/google/payment/IabHelper;->flagEndAsync()V

    .line 522
    if-eqz p6, :cond_0

    const/4 v1, 0x0

    move-object/from16 v0, p6

    invoke-interface {v0, v11, v1}, Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;->onIabPurchaseFinished(Lcom/google/payment/IabResult;Lcom/google/payment/Purchase;)V

    .line 580
    .end local v11    # "r":Lcom/google/payment/IabResult;
    :cond_0
    :goto_0
    return-void

    .line 527
    :cond_1
    :try_start_0
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Constructing buy intent for "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    move-object/from16 v0, p2

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, ", item type: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    move-object/from16 v0, p3

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {p0, v1}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 529
    if-eqz p4, :cond_2

    invoke-interface/range {p4 .. p4}, Ljava/util/List;->isEmpty()Z

    move-result v1

    if-eqz v1, :cond_3

    .line 531
    :cond_2
    iget-object v1, p0, Lcom/google/payment/IabHelper;->mService:Lcom/android/vending/billing/IInAppBillingService;

    const/4 v2, 0x3

    iget-object v3, p0, Lcom/google/payment/IabHelper;->mContext:Landroid/content/Context;

    invoke-virtual {v3}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v3

    move-object/from16 v4, p2

    move-object/from16 v5, p3

    move-object/from16 v6, p7

    invoke-interface/range {v1 .. v6}, Lcom/android/vending/billing/IInAppBillingService;->getBuyIntent(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/os/Bundle;

    move-result-object v8

    .line 545
    .local v8, "buyIntentBundle":Landroid/os/Bundle;
    :goto_1
    invoke-virtual {p0, v8}, Lcom/google/payment/IabHelper;->getResponseCodeFromBundle(Landroid/os/Bundle;)I

    move-result v12

    .line 546
    .local v12, "response":I
    if-eqz v12, :cond_5

    .line 547
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Unable to buy item, Error response: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-static {v12}, Lcom/google/payment/IabHelper;->getResponseDesc(I)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {p0, v1}, Lcom/google/payment/IabHelper;->logError(Ljava/lang/String;)V

    .line 548
    invoke-virtual {p0}, Lcom/google/payment/IabHelper;->flagEndAsync()V

    .line 549
    new-instance v13, Lcom/google/payment/IabResult;

    const-string v1, "Unable to buy item"

    invoke-direct {v13, v12, v1}, Lcom/google/payment/IabResult;-><init>(ILjava/lang/String;)V

    .line 550
    .local v13, "result":Lcom/google/payment/IabResult;
    if-eqz p6, :cond_0

    const/4 v1, 0x0

    move-object/from16 v0, p6

    invoke-interface {v0, v13, v1}, Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;->onIabPurchaseFinished(Lcom/google/payment/IabResult;Lcom/google/payment/Purchase;)V
    :try_end_0
    .catch Landroid/content/IntentSender$SendIntentException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Landroid/os/RemoteException; {:try_start_0 .. :try_end_0} :catch_1

    goto :goto_0

    .line 564
    .end local v8    # "buyIntentBundle":Landroid/os/Bundle;
    .end local v12    # "response":I
    .end local v13    # "result":Lcom/google/payment/IabResult;
    :catch_0
    move-exception v9

    .line 565
    .local v9, "e":Landroid/content/IntentSender$SendIntentException;
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "SendIntentException while launching purchase flow for sku "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    move-object/from16 v0, p2

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {p0, v1}, Lcom/google/payment/IabHelper;->logError(Ljava/lang/String;)V

    .line 566
    invoke-virtual {v9}, Landroid/content/IntentSender$SendIntentException;->printStackTrace()V

    .line 567
    invoke-virtual {p0}, Lcom/google/payment/IabHelper;->flagEndAsync()V

    .line 569
    new-instance v13, Lcom/google/payment/IabResult;

    const/16 v1, -0x3ec

    const-string v2, "Failed to send intent."

    invoke-direct {v13, v1, v2}, Lcom/google/payment/IabResult;-><init>(ILjava/lang/String;)V

    .line 570
    .restart local v13    # "result":Lcom/google/payment/IabResult;
    if-eqz p6, :cond_0

    const/4 v1, 0x0

    move-object/from16 v0, p6

    invoke-interface {v0, v13, v1}, Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;->onIabPurchaseFinished(Lcom/google/payment/IabResult;Lcom/google/payment/Purchase;)V

    goto/16 :goto_0

    .line 535
    .end local v9    # "e":Landroid/content/IntentSender$SendIntentException;
    .end local v13    # "result":Lcom/google/payment/IabResult;
    :cond_3
    :try_start_1
    iget-boolean v1, p0, Lcom/google/payment/IabHelper;->mSubscriptionUpdateSupported:Z

    if-nez v1, :cond_4

    .line 536
    new-instance v11, Lcom/google/payment/IabResult;

    const/16 v1, -0x3f3

    const-string v2, "Subscription updates are not available."

    invoke-direct {v11, v1, v2}, Lcom/google/payment/IabResult;-><init>(ILjava/lang/String;)V

    .line 538
    .restart local v11    # "r":Lcom/google/payment/IabResult;
    invoke-virtual {p0}, Lcom/google/payment/IabHelper;->flagEndAsync()V

    .line 539
    if-eqz p6, :cond_0

    const/4 v1, 0x0

    move-object/from16 v0, p6

    invoke-interface {v0, v11, v1}, Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;->onIabPurchaseFinished(Lcom/google/payment/IabResult;Lcom/google/payment/Purchase;)V
    :try_end_1
    .catch Landroid/content/IntentSender$SendIntentException; {:try_start_1 .. :try_end_1} :catch_0
    .catch Landroid/os/RemoteException; {:try_start_1 .. :try_end_1} :catch_1

    goto/16 :goto_0

    .line 572
    .end local v11    # "r":Lcom/google/payment/IabResult;
    :catch_1
    move-exception v9

    .line 573
    .local v9, "e":Landroid/os/RemoteException;
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "RemoteException while launching purchase flow for sku "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    move-object/from16 v0, p2

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {p0, v1}, Lcom/google/payment/IabHelper;->logError(Ljava/lang/String;)V

    .line 574
    invoke-virtual {v9}, Landroid/os/RemoteException;->printStackTrace()V

    .line 575
    invoke-virtual {p0}, Lcom/google/payment/IabHelper;->flagEndAsync()V

    .line 577
    new-instance v13, Lcom/google/payment/IabResult;

    const/16 v1, -0x3e9

    const-string v2, "Remote exception while starting purchase flow"

    invoke-direct {v13, v1, v2}, Lcom/google/payment/IabResult;-><init>(ILjava/lang/String;)V

    .line 578
    .restart local v13    # "result":Lcom/google/payment/IabResult;
    if-eqz p6, :cond_0

    const/4 v1, 0x0

    move-object/from16 v0, p6

    invoke-interface {v0, v13, v1}, Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;->onIabPurchaseFinished(Lcom/google/payment/IabResult;Lcom/google/payment/Purchase;)V

    goto/16 :goto_0

    .line 542
    .end local v9    # "e":Landroid/os/RemoteException;
    .end local v13    # "result":Lcom/google/payment/IabResult;
    :cond_4
    :try_start_2
    iget-object v1, p0, Lcom/google/payment/IabHelper;->mService:Lcom/android/vending/billing/IInAppBillingService;

    const/4 v2, 0x5

    iget-object v3, p0, Lcom/google/payment/IabHelper;->mContext:Landroid/content/Context;

    invoke-virtual {v3}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v3

    move-object/from16 v4, p4

    move-object/from16 v5, p2

    move-object/from16 v6, p3

    move-object/from16 v7, p7

    invoke-interface/range {v1 .. v7}, Lcom/android/vending/billing/IInAppBillingService;->getBuyIntentToReplaceSkus(ILjava/lang/String;Ljava/util/List;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/os/Bundle;

    move-result-object v8

    .restart local v8    # "buyIntentBundle":Landroid/os/Bundle;
    goto/16 :goto_1

    .line 554
    .restart local v12    # "response":I
    :cond_5
    const-string v1, "BUY_INTENT"

    invoke-virtual {v8, v1}, Landroid/os/Bundle;->getParcelable(Ljava/lang/String;)Landroid/os/Parcelable;

    move-result-object v10

    check-cast v10, Landroid/app/PendingIntent;

    .line 555
    .local v10, "pendingIntent":Landroid/app/PendingIntent;
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Launching buy intent for "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    move-object/from16 v0, p2

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, ". Request code: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    move/from16 v0, p5

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {p0, v1}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 556
    move/from16 v0, p5

    iput v0, p0, Lcom/google/payment/IabHelper;->mRequestCode:I

    .line 557
    move-object/from16 v0, p6

    iput-object v0, p0, Lcom/google/payment/IabHelper;->mPurchaseListener:Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;

    .line 558
    move-object/from16 v0, p3

    iput-object v0, p0, Lcom/google/payment/IabHelper;->mPurchasingItemType:Ljava/lang/String;

    .line 559
    invoke-virtual {v10}, Landroid/app/PendingIntent;->getIntentSender()Landroid/content/IntentSender;

    move-result-object v2

    new-instance v4, Landroid/content/Intent;

    invoke-direct {v4}, Landroid/content/Intent;-><init>()V

    const/4 v1, 0x0

    .line 561
    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Integer;->intValue()I

    move-result v5

    const/4 v1, 0x0

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Integer;->intValue()I

    move-result v6

    const/4 v1, 0x0

    .line 562
    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Integer;->intValue()I

    move-result v7

    move-object v1, p1

    move/from16 v3, p5

    .line 559
    invoke-virtual/range {v1 .. v7}, Landroid/app/Activity;->startIntentSenderForResult(Landroid/content/IntentSender;ILandroid/content/Intent;III)V
    :try_end_2
    .catch Landroid/content/IntentSender$SendIntentException; {:try_start_2 .. :try_end_2} :catch_0
    .catch Landroid/os/RemoteException; {:try_start_2 .. :try_end_2} :catch_1

    goto/16 :goto_0
.end method

.method public launchSubscriptionPurchaseFlow(Landroid/app/Activity;Ljava/lang/String;ILcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;)V
    .locals 6
    .param p1, "act"    # Landroid/app/Activity;
    .param p2, "sku"    # Ljava/lang/String;
    .param p3, "requestCode"    # I
    .param p4, "listener"    # Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lcom/google/payment/IabHelper$IabAsyncInProgressException;
        }
    .end annotation

    .prologue
    .line 481
    const-string v5, ""

    move-object v0, p0

    move-object v1, p1

    move-object v2, p2

    move v3, p3

    move-object v4, p4

    invoke-virtual/range {v0 .. v5}, Lcom/google/payment/IabHelper;->launchSubscriptionPurchaseFlow(Landroid/app/Activity;Ljava/lang/String;ILcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;Ljava/lang/String;)V

    .line 482
    return-void
.end method

.method public launchSubscriptionPurchaseFlow(Landroid/app/Activity;Ljava/lang/String;ILcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;Ljava/lang/String;)V
    .locals 8
    .param p1, "act"    # Landroid/app/Activity;
    .param p2, "sku"    # Ljava/lang/String;
    .param p3, "requestCode"    # I
    .param p4, "listener"    # Lcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;
    .param p5, "extraData"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lcom/google/payment/IabHelper$IabAsyncInProgressException;
        }
    .end annotation

    .prologue
    .line 487
    const-string v3, "subs"

    const/4 v4, 0x0

    move-object v0, p0

    move-object v1, p1

    move-object v2, p2

    move v5, p3

    move-object v6, p4

    move-object v7, p5

    invoke-virtual/range {v0 .. v7}, Lcom/google/payment/IabHelper;->launchPurchaseFlow(Landroid/app/Activity;Ljava/lang/String;Ljava/lang/String;Ljava/util/List;ILcom/google/payment/IabHelper$OnIabPurchaseFinishedListener;Ljava/lang/String;)V

    .line 488
    return-void
.end method

.method logDebug(Ljava/lang/String;)V
    .locals 1
    .param p1, "msg"    # Ljava/lang/String;

    .prologue
    .line 1347
    iget-boolean v0, p0, Lcom/google/payment/IabHelper;->mDebugLog:Z

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/google/payment/IabHelper;->mDebugTag:Ljava/lang/String;

    invoke-static {v0, p1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 1348
    :cond_0
    return-void
.end method

.method logError(Ljava/lang/String;)V
    .locals 3
    .param p1, "msg"    # Ljava/lang/String;

    .prologue
    .line 1351
    iget-object v0, p0, Lcom/google/payment/IabHelper;->mDebugTag:Ljava/lang/String;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "In-app billing error: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 1352
    return-void
.end method

.method logWarn(Ljava/lang/String;)V
    .locals 3
    .param p1, "msg"    # Ljava/lang/String;

    .prologue
    .line 1355
    iget-object v0, p0, Lcom/google/payment/IabHelper;->mDebugTag:Ljava/lang/String;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "In-app billing warning: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 1356
    return-void
.end method

.method public queryInventory()Lcom/google/payment/Inventory;
    .locals 2
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lcom/google/payment/IabException;
        }
    .end annotation

    .prologue
    const/4 v1, 0x0

    .line 680
    const/4 v0, 0x0

    invoke-virtual {p0, v0, v1, v1}, Lcom/google/payment/IabHelper;->queryInventory(ZLjava/util/List;Ljava/util/List;)Lcom/google/payment/Inventory;

    move-result-object v0

    return-object v0
.end method

.method public queryInventory(ZLjava/util/List;Ljava/util/List;)Lcom/google/payment/Inventory;
    .locals 6
    .param p1, "querySkuDetails"    # Z
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(Z",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;)",
            "Lcom/google/payment/Inventory;"
        }
    .end annotation

    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lcom/google/payment/IabException;
        }
    .end annotation

    .prologue
    .line 698
    .local p2, "moreItemSkus":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    .local p3, "moreSubsSkus":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    invoke-direct {p0}, Lcom/google/payment/IabHelper;->checkNotDisposed()V

    .line 699
    const-string v3, "queryInventory"

    invoke-virtual {p0, v3}, Lcom/google/payment/IabHelper;->checkSetupDone(Ljava/lang/String;)V

    .line 701
    :try_start_0
    new-instance v1, Lcom/google/payment/Inventory;

    invoke-direct {v1}, Lcom/google/payment/Inventory;-><init>()V

    .line 702
    .local v1, "inv":Lcom/google/payment/Inventory;
    const-string v3, "inapp"

    invoke-virtual {p0, v1, v3}, Lcom/google/payment/IabHelper;->queryPurchases(Lcom/google/payment/Inventory;Ljava/lang/String;)I

    move-result v2

    .line 703
    .local v2, "r":I
    if-eqz v2, :cond_0

    .line 704
    new-instance v3, Lcom/google/payment/IabException;

    const-string v4, "Error refreshing inventory (querying owned items)."

    invoke-direct {v3, v2, v4}, Lcom/google/payment/IabException;-><init>(ILjava/lang/String;)V

    throw v3
    :try_end_0
    .catch Landroid/os/RemoteException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_2

    .line 731
    .end local v1    # "inv":Lcom/google/payment/Inventory;
    .end local v2    # "r":I
    :catch_0
    move-exception v0

    .line 732
    .local v0, "e":Landroid/os/RemoteException;
    invoke-virtual {v0}, Landroid/os/RemoteException;->printStackTrace()V

    .line 733
    new-instance v3, Lcom/google/payment/IabException;

    const/16 v4, -0x3e9

    const-string v5, "Remote exception while refreshing inventory."

    invoke-direct {v3, v4, v5, v0}, Lcom/google/payment/IabException;-><init>(ILjava/lang/String;Ljava/lang/Exception;)V

    throw v3

    .line 707
    .end local v0    # "e":Landroid/os/RemoteException;
    .restart local v1    # "inv":Lcom/google/payment/Inventory;
    .restart local v2    # "r":I
    :cond_0
    if-eqz p1, :cond_1

    .line 708
    :try_start_1
    const-string v3, "inapp"

    invoke-virtual {p0, v3, v1, p2}, Lcom/google/payment/IabHelper;->querySkuDetails(Ljava/lang/String;Lcom/google/payment/Inventory;Ljava/util/List;)I

    move-result v2

    .line 709
    if-eqz v2, :cond_1

    .line 710
    new-instance v3, Lcom/google/payment/IabException;

    const-string v4, "Error refreshing inventory (querying prices of items)."

    invoke-direct {v3, v2, v4}, Lcom/google/payment/IabException;-><init>(ILjava/lang/String;)V

    throw v3
    :try_end_1
    .catch Landroid/os/RemoteException; {:try_start_1 .. :try_end_1} :catch_0
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_2

    .line 735
    .end local v1    # "inv":Lcom/google/payment/Inventory;
    .end local v2    # "r":I
    :catch_1
    move-exception v0

    .line 736
    .local v0, "e":Lorg/json/JSONException;
    invoke-virtual {v0}, Lorg/json/JSONException;->printStackTrace()V

    .line 737
    new-instance v3, Lcom/google/payment/IabException;

    const/16 v4, -0x3ea

    const-string v5, "Error parsing JSON response while refreshing inventory."

    invoke-direct {v3, v4, v5, v0}, Lcom/google/payment/IabException;-><init>(ILjava/lang/String;Ljava/lang/Exception;)V

    throw v3

    .line 715
    .end local v0    # "e":Lorg/json/JSONException;
    .restart local v1    # "inv":Lcom/google/payment/Inventory;
    .restart local v2    # "r":I
    :cond_1
    :try_start_2
    iget-boolean v3, p0, Lcom/google/payment/IabHelper;->mSubscriptionsSupported:Z

    if-eqz v3, :cond_3

    .line 716
    const-string v3, "subs"

    invoke-virtual {p0, v1, v3}, Lcom/google/payment/IabHelper;->queryPurchases(Lcom/google/payment/Inventory;Ljava/lang/String;)I

    move-result v2

    .line 717
    if-eqz v2, :cond_2

    .line 718
    new-instance v3, Lcom/google/payment/IabException;

    const-string v4, "Error refreshing inventory (querying owned subscriptions)."

    invoke-direct {v3, v2, v4}, Lcom/google/payment/IabException;-><init>(ILjava/lang/String;)V

    throw v3
    :try_end_2
    .catch Landroid/os/RemoteException; {:try_start_2 .. :try_end_2} :catch_0
    .catch Lorg/json/JSONException; {:try_start_2 .. :try_end_2} :catch_1
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_2

    .line 740
    .end local v1    # "inv":Lcom/google/payment/Inventory;
    .end local v2    # "r":I
    :catch_2
    move-exception v0

    .line 741
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    .line 742
    new-instance v3, Lcom/google/payment/IabException;

    const/16 v4, -0x3f0

    const-string v5, "Unknown error while refreshing inventory."

    invoke-direct {v3, v4, v5, v0}, Lcom/google/payment/IabException;-><init>(ILjava/lang/String;Ljava/lang/Exception;)V

    throw v3

    .line 721
    .end local v0    # "e":Ljava/lang/Exception;
    .restart local v1    # "inv":Lcom/google/payment/Inventory;
    .restart local v2    # "r":I
    :cond_2
    if-eqz p1, :cond_3

    .line 722
    :try_start_3
    const-string v3, "subs"

    invoke-virtual {p0, v3, v1, p3}, Lcom/google/payment/IabHelper;->querySkuDetails(Ljava/lang/String;Lcom/google/payment/Inventory;Ljava/util/List;)I

    move-result v2

    .line 723
    if-eqz v2, :cond_3

    .line 724
    new-instance v3, Lcom/google/payment/IabException;

    const-string v4, "Error refreshing inventory (querying prices of subscriptions)."

    invoke-direct {v3, v2, v4}, Lcom/google/payment/IabException;-><init>(ILjava/lang/String;)V

    throw v3
    :try_end_3
    .catch Landroid/os/RemoteException; {:try_start_3 .. :try_end_3} :catch_0
    .catch Lorg/json/JSONException; {:try_start_3 .. :try_end_3} :catch_1
    .catch Ljava/lang/Exception; {:try_start_3 .. :try_end_3} :catch_2

    .line 729
    :cond_3
    return-object v1
.end method

.method public queryInventoryAsync(Lcom/google/payment/IabHelper$QueryInventoryFinishedListener;)V
    .locals 2
    .param p1, "listener"    # Lcom/google/payment/IabHelper$QueryInventoryFinishedListener;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lcom/google/payment/IabHelper$IabAsyncInProgressException;
        }
    .end annotation

    .prologue
    const/4 v1, 0x0

    .line 809
    const/4 v0, 0x0

    invoke-virtual {p0, v0, v1, v1, p1}, Lcom/google/payment/IabHelper;->queryInventoryAsync(ZLjava/util/List;Ljava/util/List;Lcom/google/payment/IabHelper$QueryInventoryFinishedListener;)V

    .line 810
    return-void
.end method

.method public queryInventoryAsync(Ljava/util/ArrayList;Lcom/google/payment/IabHelper$QueryInventoryListener;)V
    .locals 4
    .param p2, "listener"    # Lcom/google/payment/IabHelper$QueryInventoryListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/ArrayList",
            "<",
            "Lcom/igg/sdk/payment/bean/IGGGameItem;",
            ">;",
            "Lcom/google/payment/IabHelper$QueryInventoryListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 822
    .local p1, "items":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Lcom/igg/sdk/payment/bean/IGGGameItem;>;"
    new-instance v1, Landroid/os/Handler;

    invoke-direct {v1}, Landroid/os/Handler;-><init>()V

    .line 823
    .local v1, "handler":Landroid/os/Handler;
    invoke-direct {p0}, Lcom/google/payment/IabHelper;->checkNotDisposed()V

    .line 824
    const-string v2, "queryInventory"

    invoke-virtual {p0, v2}, Lcom/google/payment/IabHelper;->checkSetupDone(Ljava/lang/String;)V

    .line 826
    :try_start_0
    const-string v2, "refresh inventory"

    invoke-virtual {p0, v2}, Lcom/google/payment/IabHelper;->flagStartAsync(Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 841
    new-instance v2, Ljava/lang/Thread;

    new-instance v3, Lcom/google/payment/IabHelper$4;

    invoke-direct {v3, p0, p1, p2, v1}, Lcom/google/payment/IabHelper$4;-><init>(Lcom/google/payment/IabHelper;Ljava/util/ArrayList;Lcom/google/payment/IabHelper$QueryInventoryListener;Landroid/os/Handler;)V

    invoke-direct {v2, v3}, Ljava/lang/Thread;-><init>(Ljava/lang/Runnable;)V

    .line 951
    invoke-virtual {v2}, Ljava/lang/Thread;->start()V

    .line 952
    :cond_0
    :goto_0
    return-void

    .line 827
    :catch_0
    move-exception v0

    .line 828
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {p0}, Lcom/google/payment/IabHelper;->flagEndAsync()V

    .line 829
    iget-boolean v2, p0, Lcom/google/payment/IabHelper;->mDisposed:Z

    if-nez v2, :cond_0

    if-eqz p2, :cond_0

    .line 830
    new-instance v2, Lcom/google/payment/IabHelper$3;

    invoke-direct {v2, p0, p2}, Lcom/google/payment/IabHelper$3;-><init>(Lcom/google/payment/IabHelper;Lcom/google/payment/IabHelper$QueryInventoryListener;)V

    invoke-virtual {v1, v2}, Landroid/os/Handler;->post(Ljava/lang/Runnable;)Z

    goto :goto_0
.end method

.method public queryInventoryAsync(ZLjava/util/List;Ljava/util/List;Lcom/google/payment/IabHelper$QueryInventoryFinishedListener;)V
    .locals 8
    .param p1, "querySkuDetails"    # Z
    .param p4, "listener"    # Lcom/google/payment/IabHelper$QueryInventoryFinishedListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(Z",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;",
            "Lcom/google/payment/IabHelper$QueryInventoryFinishedListener;",
            ")V"
        }
    .end annotation

    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lcom/google/payment/IabHelper$IabAsyncInProgressException;
        }
    .end annotation

    .prologue
    .line 777
    .local p2, "moreItemSkus":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    .local p3, "moreSubsSkus":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    new-instance v6, Landroid/os/Handler;

    invoke-static {}, Landroid/os/Looper;->getMainLooper()Landroid/os/Looper;

    move-result-object v0

    invoke-direct {v6, v0}, Landroid/os/Handler;-><init>(Landroid/os/Looper;)V

    .line 778
    .local v6, "handler":Landroid/os/Handler;
    invoke-direct {p0}, Lcom/google/payment/IabHelper;->checkNotDisposed()V

    .line 779
    const-string v0, "queryInventory"

    invoke-virtual {p0, v0}, Lcom/google/payment/IabHelper;->checkSetupDone(Ljava/lang/String;)V

    .line 780
    const-string v0, "refresh inventory"

    invoke-virtual {p0, v0}, Lcom/google/payment/IabHelper;->flagStartAsync(Ljava/lang/String;)V

    .line 781
    new-instance v7, Ljava/lang/Thread;

    new-instance v0, Lcom/google/payment/IabHelper$2;

    move-object v1, p0

    move v2, p1

    move-object v3, p2

    move-object v4, p3

    move-object v5, p4

    invoke-direct/range {v0 .. v6}, Lcom/google/payment/IabHelper$2;-><init>(Lcom/google/payment/IabHelper;ZLjava/util/List;Ljava/util/List;Lcom/google/payment/IabHelper$QueryInventoryFinishedListener;Landroid/os/Handler;)V

    invoke-direct {v7, v0}, Ljava/lang/Thread;-><init>(Ljava/lang/Runnable;)V

    .line 804
    invoke-virtual {v7}, Ljava/lang/Thread;->start()V

    .line 805
    return-void
.end method

.method queryPurchases(Lcom/google/payment/Inventory;Ljava/lang/String;)I
    .locals 16
    .param p1, "inv"    # Lcom/google/payment/Inventory;
    .param p2, "itemType"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lorg/json/JSONException;,
            Landroid/os/RemoteException;
        }
    .end annotation

    .prologue
    .line 1179
    new-instance v13, Ljava/lang/StringBuilder;

    invoke-direct {v13}, Ljava/lang/StringBuilder;-><init>()V

    const-string v14, "Querying owned items, item type: "

    invoke-virtual {v13, v14}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    move-object/from16 v0, p2

    invoke-virtual {v13, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v13

    move-object/from16 v0, p0

    invoke-virtual {v0, v13}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 1180
    new-instance v13, Ljava/lang/StringBuilder;

    invoke-direct {v13}, Ljava/lang/StringBuilder;-><init>()V

    const-string v14, "Package name: "

    invoke-virtual {v13, v14}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    move-object/from16 v0, p0

    iget-object v14, v0, Lcom/google/payment/IabHelper;->mContext:Landroid/content/Context;

    invoke-virtual {v14}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v14

    invoke-virtual {v13, v14}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v13

    move-object/from16 v0, p0

    invoke-virtual {v0, v13}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 1181
    const/4 v12, 0x0

    .line 1182
    .local v12, "verificationFailed":Z
    const/4 v1, 0x0

    .line 1185
    .local v1, "continueToken":Ljava/lang/String;
    :cond_0
    new-instance v13, Ljava/lang/StringBuilder;

    invoke-direct {v13}, Ljava/lang/StringBuilder;-><init>()V

    const-string v14, "Calling getPurchases with continuation token: "

    invoke-virtual {v13, v14}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v13

    move-object/from16 v0, p0

    invoke-virtual {v0, v13}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 1186
    move-object/from16 v0, p0

    iget-object v13, v0, Lcom/google/payment/IabHelper;->mService:Lcom/android/vending/billing/IInAppBillingService;

    const/4 v14, 0x3

    move-object/from16 v0, p0

    iget-object v15, v0, Lcom/google/payment/IabHelper;->mContext:Landroid/content/Context;

    invoke-virtual {v15}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v15

    move-object/from16 v0, p2

    invoke-interface {v13, v14, v15, v0, v1}, Lcom/android/vending/billing/IInAppBillingService;->getPurchases(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Landroid/os/Bundle;

    move-result-object v3

    .line 1189
    .local v3, "ownedItems":Landroid/os/Bundle;
    move-object/from16 v0, p0

    invoke-virtual {v0, v3}, Lcom/google/payment/IabHelper;->getResponseCodeFromBundle(Landroid/os/Bundle;)I

    move-result v8

    .line 1190
    .local v8, "response":I
    new-instance v13, Ljava/lang/StringBuilder;

    invoke-direct {v13}, Ljava/lang/StringBuilder;-><init>()V

    const-string v14, "Owned items response: "

    invoke-virtual {v13, v14}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-static {v8}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v14

    invoke-virtual {v13, v14}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v13

    move-object/from16 v0, p0

    invoke-virtual {v0, v13}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 1191
    if-eqz v8, :cond_1

    .line 1192
    new-instance v13, Ljava/lang/StringBuilder;

    invoke-direct {v13}, Ljava/lang/StringBuilder;-><init>()V

    const-string v14, "getPurchases() failed: "

    invoke-virtual {v13, v14}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-static {v8}, Lcom/google/payment/IabHelper;->getResponseDesc(I)Ljava/lang/String;

    move-result-object v14

    invoke-virtual {v13, v14}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v13

    move-object/from16 v0, p0

    invoke-virtual {v0, v13}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 1237
    .end local v8    # "response":I
    :goto_0
    return v8

    .line 1195
    .restart local v8    # "response":I
    :cond_1
    const-string v13, "INAPP_PURCHASE_ITEM_LIST"

    invoke-virtual {v3, v13}, Landroid/os/Bundle;->containsKey(Ljava/lang/String;)Z

    move-result v13

    if-eqz v13, :cond_2

    const-string v13, "INAPP_PURCHASE_DATA_LIST"

    .line 1196
    invoke-virtual {v3, v13}, Landroid/os/Bundle;->containsKey(Ljava/lang/String;)Z

    move-result v13

    if-eqz v13, :cond_2

    const-string v13, "INAPP_DATA_SIGNATURE_LIST"

    .line 1197
    invoke-virtual {v3, v13}, Landroid/os/Bundle;->containsKey(Ljava/lang/String;)Z

    move-result v13

    if-nez v13, :cond_3

    .line 1198
    :cond_2
    const-string v13, "Bundle returned from getPurchases() doesn\'t contain required fields."

    move-object/from16 v0, p0

    invoke-virtual {v0, v13}, Lcom/google/payment/IabHelper;->logError(Ljava/lang/String;)V

    .line 1199
    const/16 v8, -0x3ea

    goto :goto_0

    .line 1202
    :cond_3
    const-string v13, "INAPP_PURCHASE_ITEM_LIST"

    invoke-virtual {v3, v13}, Landroid/os/Bundle;->getStringArrayList(Ljava/lang/String;)Ljava/util/ArrayList;

    move-result-object v4

    .line 1204
    .local v4, "ownedSkus":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/String;>;"
    const-string v13, "INAPP_PURCHASE_DATA_LIST"

    invoke-virtual {v3, v13}, Landroid/os/Bundle;->getStringArrayList(Ljava/lang/String;)Ljava/util/ArrayList;

    move-result-object v7

    .line 1206
    .local v7, "purchaseDataList":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/String;>;"
    const-string v13, "INAPP_DATA_SIGNATURE_LIST"

    invoke-virtual {v3, v13}, Landroid/os/Bundle;->getStringArrayList(Ljava/lang/String;)Ljava/util/ArrayList;

    move-result-object v10

    .line 1209
    .local v10, "signatureList":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/String;>;"
    const/4 v2, 0x0

    .local v2, "i":I
    :goto_1
    invoke-virtual {v7}, Ljava/util/ArrayList;->size()I

    move-result v13

    if-ge v2, v13, :cond_6

    .line 1210
    invoke-virtual {v7, v2}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Ljava/lang/String;

    .line 1211
    .local v6, "purchaseData":Ljava/lang/String;
    invoke-virtual {v10, v2}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v9

    check-cast v9, Ljava/lang/String;

    .line 1212
    .local v9, "signature":Ljava/lang/String;
    invoke-virtual {v4, v2}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v11

    check-cast v11, Ljava/lang/String;

    .line 1213
    .local v11, "sku":Ljava/lang/String;
    move-object/from16 v0, p0

    iget-object v13, v0, Lcom/google/payment/IabHelper;->mSignatureBase64:Ljava/lang/String;

    invoke-static {v13, v6, v9}, Lcom/google/payment/Security;->verifyPurchase(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Z

    move-result v13

    if-eqz v13, :cond_5

    .line 1214
    new-instance v13, Ljava/lang/StringBuilder;

    invoke-direct {v13}, Ljava/lang/StringBuilder;-><init>()V

    const-string v14, "Sku is owned: "

    invoke-virtual {v13, v14}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v13

    move-object/from16 v0, p0

    invoke-virtual {v0, v13}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 1215
    new-instance v5, Lcom/google/payment/Purchase;

    move-object/from16 v0, p2

    invoke-direct {v5, v0, v6, v9}, Lcom/google/payment/Purchase;-><init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 1217
    .local v5, "purchase":Lcom/google/payment/Purchase;
    invoke-virtual {v5}, Lcom/google/payment/Purchase;->getToken()Ljava/lang/String;

    move-result-object v13

    invoke-static {v13}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v13

    if-eqz v13, :cond_4

    .line 1218
    const-string v13, "BUG: empty/null token!"

    move-object/from16 v0, p0

    invoke-virtual {v0, v13}, Lcom/google/payment/IabHelper;->logWarn(Ljava/lang/String;)V

    .line 1219
    new-instance v13, Ljava/lang/StringBuilder;

    invoke-direct {v13}, Ljava/lang/StringBuilder;-><init>()V

    const-string v14, "Purchase data: "

    invoke-virtual {v13, v14}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v13

    move-object/from16 v0, p0

    invoke-virtual {v0, v13}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 1223
    :cond_4
    move-object/from16 v0, p1

    invoke-virtual {v0, v5}, Lcom/google/payment/Inventory;->addPurchase(Lcom/google/payment/Purchase;)V

    .line 1209
    .end local v5    # "purchase":Lcom/google/payment/Purchase;
    :goto_2
    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    .line 1226
    :cond_5
    const-string v13, "Purchase signature verification **FAILED**. Not adding item."

    move-object/from16 v0, p0

    invoke-virtual {v0, v13}, Lcom/google/payment/IabHelper;->logWarn(Ljava/lang/String;)V

    .line 1227
    new-instance v13, Ljava/lang/StringBuilder;

    invoke-direct {v13}, Ljava/lang/StringBuilder;-><init>()V

    const-string v14, "   Purchase data: "

    invoke-virtual {v13, v14}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v13

    move-object/from16 v0, p0

    invoke-virtual {v0, v13}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 1228
    new-instance v13, Ljava/lang/StringBuilder;

    invoke-direct {v13}, Ljava/lang/StringBuilder;-><init>()V

    const-string v14, "   Signature: "

    invoke-virtual {v13, v14}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v13

    move-object/from16 v0, p0

    invoke-virtual {v0, v13}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 1229
    const/4 v12, 0x1

    goto :goto_2

    .line 1233
    .end local v6    # "purchaseData":Ljava/lang/String;
    .end local v9    # "signature":Ljava/lang/String;
    .end local v11    # "sku":Ljava/lang/String;
    :cond_6
    const-string v13, "INAPP_CONTINUATION_TOKEN"

    invoke-virtual {v3, v13}, Landroid/os/Bundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 1234
    new-instance v13, Ljava/lang/StringBuilder;

    invoke-direct {v13}, Ljava/lang/StringBuilder;-><init>()V

    const-string v14, "Continuation token: "

    invoke-virtual {v13, v14}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v13}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v13

    move-object/from16 v0, p0

    invoke-virtual {v0, v13}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 1235
    invoke-static {v1}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v13

    if-eqz v13, :cond_0

    .line 1237
    if-eqz v12, :cond_7

    const/16 v13, -0x3eb

    :goto_3
    move v8, v13

    goto/16 :goto_0

    :cond_7
    const/4 v13, 0x0

    goto :goto_3
.end method

.method querySkuDetails(Ljava/lang/String;Lcom/google/payment/Inventory;Ljava/util/List;)I
    .locals 23
    .param p1, "itemType"    # Ljava/lang/String;
    .param p2, "inv"    # Lcom/google/payment/Inventory;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Lcom/google/payment/Inventory;",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;)I"
        }
    .end annotation

    .annotation system Ldalvik/annotation/Throws;
        value = {
            Landroid/os/RemoteException;,
            Lorg/json/JSONException;
        }
    .end annotation

    .prologue
    .line 1242
    .local p3, "moreSkus":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    const-string v19, "Querying SKU details."

    move-object/from16 v0, p0

    move-object/from16 v1, v19

    invoke-virtual {v0, v1}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 1243
    new-instance v15, Ljava/util/ArrayList;

    invoke-direct {v15}, Ljava/util/ArrayList;-><init>()V

    .line 1244
    .local v15, "skuList":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/String;>;"
    move-object/from16 v0, p2

    move-object/from16 v1, p1

    invoke-virtual {v0, v1}, Lcom/google/payment/Inventory;->getAllOwnedSkus(Ljava/lang/String;)Ljava/util/List;

    move-result-object v19

    move-object/from16 v0, v19

    invoke-virtual {v15, v0}, Ljava/util/ArrayList;->addAll(Ljava/util/Collection;)Z

    .line 1245
    if-eqz p3, :cond_1

    .line 1246
    invoke-interface/range {p3 .. p3}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v19

    :cond_0
    :goto_0
    invoke-interface/range {v19 .. v19}, Ljava/util/Iterator;->hasNext()Z

    move-result v20

    if-eqz v20, :cond_1

    invoke-interface/range {v19 .. v19}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v13

    check-cast v13, Ljava/lang/String;

    .line 1247
    .local v13, "sku":Ljava/lang/String;
    invoke-virtual {v15, v13}, Ljava/util/ArrayList;->contains(Ljava/lang/Object;)Z

    move-result v20

    if-nez v20, :cond_0

    .line 1248
    invoke-virtual {v15, v13}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto :goto_0

    .line 1253
    .end local v13    # "sku":Ljava/lang/String;
    :cond_1
    invoke-virtual {v15}, Ljava/util/ArrayList;->size()I

    move-result v19

    if-nez v19, :cond_2

    .line 1254
    const-string v19, "queryPrices: nothing to do because there are no SKUs."

    move-object/from16 v0, p0

    move-object/from16 v1, v19

    invoke-virtual {v0, v1}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 1255
    const/4 v10, 0x0

    .line 1305
    :goto_1
    return v10

    .line 1259
    :cond_2
    new-instance v8, Ljava/util/ArrayList;

    invoke-direct {v8}, Ljava/util/ArrayList;-><init>()V

    .line 1261
    .local v8, "packs":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/util/ArrayList<Ljava/lang/String;>;>;"
    invoke-virtual {v15}, Ljava/util/ArrayList;->size()I

    move-result v19

    div-int/lit8 v7, v19, 0x14

    .line 1262
    .local v7, "n":I
    invoke-virtual {v15}, Ljava/util/ArrayList;->size()I

    move-result v19

    rem-int/lit8 v6, v19, 0x14

    .line 1263
    .local v6, "mod":I
    const/4 v5, 0x0

    .local v5, "i":I
    :goto_2
    if-ge v5, v7, :cond_4

    .line 1264
    new-instance v17, Ljava/util/ArrayList;

    invoke-direct/range {v17 .. v17}, Ljava/util/ArrayList;-><init>()V

    .line 1265
    .local v17, "tempList":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/String;>;"
    mul-int/lit8 v19, v5, 0x14

    mul-int/lit8 v20, v5, 0x14

    add-int/lit8 v20, v20, 0x14

    move/from16 v0, v19

    move/from16 v1, v20

    invoke-virtual {v15, v0, v1}, Ljava/util/ArrayList;->subList(II)Ljava/util/List;

    move-result-object v19

    invoke-interface/range {v19 .. v19}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v19

    :goto_3
    invoke-interface/range {v19 .. v19}, Ljava/util/Iterator;->hasNext()Z

    move-result v20

    if-eqz v20, :cond_3

    invoke-interface/range {v19 .. v19}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v12

    check-cast v12, Ljava/lang/String;

    .line 1266
    .local v12, "s":Ljava/lang/String;
    move-object/from16 v0, v17

    invoke-virtual {v0, v12}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto :goto_3

    .line 1268
    .end local v12    # "s":Ljava/lang/String;
    :cond_3
    move-object/from16 v0, v17

    invoke-virtual {v8, v0}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 1263
    add-int/lit8 v5, v5, 0x1

    goto :goto_2

    .line 1270
    .end local v17    # "tempList":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/String;>;"
    :cond_4
    if-eqz v6, :cond_6

    .line 1271
    new-instance v17, Ljava/util/ArrayList;

    invoke-direct/range {v17 .. v17}, Ljava/util/ArrayList;-><init>()V

    .line 1272
    .restart local v17    # "tempList":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/String;>;"
    mul-int/lit8 v19, v7, 0x14

    mul-int/lit8 v20, v7, 0x14

    add-int v20, v20, v6

    move/from16 v0, v19

    move/from16 v1, v20

    invoke-virtual {v15, v0, v1}, Ljava/util/ArrayList;->subList(II)Ljava/util/List;

    move-result-object v19

    invoke-interface/range {v19 .. v19}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v19

    :goto_4
    invoke-interface/range {v19 .. v19}, Ljava/util/Iterator;->hasNext()Z

    move-result v20

    if-eqz v20, :cond_5

    invoke-interface/range {v19 .. v19}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v12

    check-cast v12, Ljava/lang/String;

    .line 1273
    .restart local v12    # "s":Ljava/lang/String;
    move-object/from16 v0, v17

    invoke-virtual {v0, v12}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    goto :goto_4

    .line 1275
    .end local v12    # "s":Ljava/lang/String;
    :cond_5
    move-object/from16 v0, v17

    invoke-virtual {v8, v0}, Ljava/util/ArrayList;->add(Ljava/lang/Object;)Z

    .line 1278
    .end local v17    # "tempList":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/String;>;"
    :cond_6
    invoke-virtual {v8}, Ljava/util/ArrayList;->iterator()Ljava/util/Iterator;

    move-result-object v19

    :cond_7
    invoke-interface/range {v19 .. v19}, Ljava/util/Iterator;->hasNext()Z

    move-result v20

    if-eqz v20, :cond_a

    invoke-interface/range {v19 .. v19}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v16

    check-cast v16, Ljava/util/ArrayList;

    .line 1279
    .local v16, "skuPartList":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/String;>;"
    new-instance v9, Landroid/os/Bundle;

    invoke-direct {v9}, Landroid/os/Bundle;-><init>()V

    .line 1280
    .local v9, "querySkus":Landroid/os/Bundle;
    const-string v20, "ITEM_ID_LIST"

    move-object/from16 v0, v20

    move-object/from16 v1, v16

    invoke-virtual {v9, v0, v1}, Landroid/os/Bundle;->putStringArrayList(Ljava/lang/String;Ljava/util/ArrayList;)V

    .line 1281
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper;->mService:Lcom/android/vending/billing/IInAppBillingService;

    move-object/from16 v20, v0

    const/16 v21, 0x3

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/google/payment/IabHelper;->mContext:Landroid/content/Context;

    move-object/from16 v22, v0

    invoke-virtual/range {v22 .. v22}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v22

    move-object/from16 v0, v20

    move/from16 v1, v21

    move-object/from16 v2, v22

    move-object/from16 v3, p1

    invoke-interface {v0, v1, v2, v3, v9}, Lcom/android/vending/billing/IInAppBillingService;->getSkuDetails(ILjava/lang/String;Ljava/lang/String;Landroid/os/Bundle;)Landroid/os/Bundle;

    move-result-object v14

    .line 1284
    .local v14, "skuDetails":Landroid/os/Bundle;
    const-string v20, "DETAILS_LIST"

    move-object/from16 v0, v20

    invoke-virtual {v14, v0}, Landroid/os/Bundle;->containsKey(Ljava/lang/String;)Z

    move-result v20

    if-nez v20, :cond_9

    .line 1285
    move-object/from16 v0, p0

    invoke-virtual {v0, v14}, Lcom/google/payment/IabHelper;->getResponseCodeFromBundle(Landroid/os/Bundle;)I

    move-result v10

    .line 1286
    .local v10, "response":I
    if-eqz v10, :cond_8

    .line 1287
    new-instance v19, Ljava/lang/StringBuilder;

    invoke-direct/range {v19 .. v19}, Ljava/lang/StringBuilder;-><init>()V

    const-string v20, "getSkuDetails() failed: "

    invoke-virtual/range {v19 .. v20}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v19

    invoke-static {v10}, Lcom/google/payment/IabHelper;->getResponseDesc(I)Ljava/lang/String;

    move-result-object v20

    invoke-virtual/range {v19 .. v20}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v19

    invoke-virtual/range {v19 .. v19}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v19

    move-object/from16 v0, p0

    move-object/from16 v1, v19

    invoke-virtual {v0, v1}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    goto/16 :goto_1

    .line 1290
    :cond_8
    const-string v19, "getSkuDetails() returned a bundle with neither an error nor a detail list."

    move-object/from16 v0, p0

    move-object/from16 v1, v19

    invoke-virtual {v0, v1}, Lcom/google/payment/IabHelper;->logError(Ljava/lang/String;)V

    .line 1291
    const/16 v10, -0x3ea

    goto/16 :goto_1

    .line 1295
    .end local v10    # "response":I
    :cond_9
    const-string v20, "DETAILS_LIST"

    move-object/from16 v0, v20

    invoke-virtual {v14, v0}, Landroid/os/Bundle;->getStringArrayList(Ljava/lang/String;)Ljava/util/ArrayList;

    move-result-object v11

    .line 1298
    .local v11, "responseList":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/String;>;"
    invoke-virtual {v11}, Ljava/util/ArrayList;->iterator()Ljava/util/Iterator;

    move-result-object v20

    :goto_5
    invoke-interface/range {v20 .. v20}, Ljava/util/Iterator;->hasNext()Z

    move-result v21

    if-eqz v21, :cond_7

    invoke-interface/range {v20 .. v20}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v18

    check-cast v18, Ljava/lang/String;

    .line 1299
    .local v18, "thisResponse":Ljava/lang/String;
    new-instance v4, Lcom/google/payment/SkuDetails;

    move-object/from16 v0, p1

    move-object/from16 v1, v18

    invoke-direct {v4, v0, v1}, Lcom/google/payment/SkuDetails;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    .line 1300
    .local v4, "d":Lcom/google/payment/SkuDetails;
    new-instance v21, Ljava/lang/StringBuilder;

    invoke-direct/range {v21 .. v21}, Ljava/lang/StringBuilder;-><init>()V

    const-string v22, "Got sku details: "

    invoke-virtual/range {v21 .. v22}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v21

    move-object/from16 v0, v21

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v21

    invoke-virtual/range {v21 .. v21}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v21

    move-object/from16 v0, p0

    move-object/from16 v1, v21

    invoke-virtual {v0, v1}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 1301
    move-object/from16 v0, p2

    invoke-virtual {v0, v4}, Lcom/google/payment/Inventory;->addSkuDetails(Lcom/google/payment/SkuDetails;)V

    goto :goto_5

    .line 1305
    .end local v4    # "d":Lcom/google/payment/SkuDetails;
    .end local v9    # "querySkus":Landroid/os/Bundle;
    .end local v11    # "responseList":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/String;>;"
    .end local v14    # "skuDetails":Landroid/os/Bundle;
    .end local v16    # "skuPartList":Ljava/util/ArrayList;, "Ljava/util/ArrayList<Ljava/lang/String;>;"
    .end local v18    # "thisResponse":Ljava/lang/String;
    :cond_a
    const/4 v10, 0x0

    goto/16 :goto_1
.end method

.method public setContext(Landroid/content/Context;)V
    .locals 0
    .param p1, "context"    # Landroid/content/Context;

    .prologue
    .line 202
    iput-object p1, p0, Lcom/google/payment/IabHelper;->mContext:Landroid/content/Context;

    .line 203
    return-void
.end method

.method public setPaymentType(Lcom/igg/sdk/IGGSDKConstant$PaymentType;)V
    .locals 0
    .param p1, "paymentType"    # Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    .prologue
    .line 221
    iput-object p1, p0, Lcom/google/payment/IabHelper;->paymentType:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    .line 222
    return-void
.end method

.method public setSignatureBase64(Ljava/lang/String;)V
    .locals 0
    .param p1, "signatureBase64"    # Ljava/lang/String;

    .prologue
    .line 213
    iput-object p1, p0, Lcom/google/payment/IabHelper;->mSignatureBase64:Ljava/lang/String;

    .line 214
    return-void
.end method

.method public startSetup(Lcom/google/payment/IabHelper$OnIabSetupFinishedListener;)V
    .locals 7
    .param p1, "listener"    # Lcom/google/payment/IabHelper$OnIabSetupFinishedListener;

    .prologue
    const/4 v6, 0x3

    .line 271
    invoke-direct {p0}, Lcom/google/payment/IabHelper;->checkNotDisposed()V

    .line 272
    iget-boolean v3, p0, Lcom/google/payment/IabHelper;->mSetupDone:Z

    if-eqz v3, :cond_0

    new-instance v3, Ljava/lang/IllegalStateException;

    const-string v4, "IAB helper is already set up."

    invoke-direct {v3, v4}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v3

    .line 275
    :cond_0
    const-string v3, "Starting in-app billing setup."

    invoke-virtual {p0, v3}, Lcom/google/payment/IabHelper;->logDebug(Ljava/lang/String;)V

    .line 276
    new-instance v3, Lcom/google/payment/IabHelper$1;

    invoke-direct {v3, p0, p1}, Lcom/google/payment/IabHelper$1;-><init>(Lcom/google/payment/IabHelper;Lcom/google/payment/IabHelper$OnIabSetupFinishedListener;)V

    iput-object v3, p0, Lcom/google/payment/IabHelper;->mServiceConn:Landroid/content/ServiceConnection;

    .line 353
    invoke-virtual {p0}, Lcom/google/payment/IabHelper;->getPaymentType()Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    move-result-object v3

    sget-object v4, Lcom/igg/sdk/IGGSDKConstant$PaymentType;->BAZAAR:Lcom/igg/sdk/IGGSDKConstant$PaymentType;

    if-ne v3, v4, :cond_2

    .line 354
    new-instance v2, Landroid/content/Intent;

    const-string v3, "ir.cafebazaar.pardakht.InAppBillingService.BIND"

    invoke-direct {v2, v3}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 355
    .local v2, "serviceIntent":Landroid/content/Intent;
    const-string v3, "com.farsitel.bazaar"

    invoke-virtual {v2, v3}, Landroid/content/Intent;->setPackage(Ljava/lang/String;)Landroid/content/Intent;

    .line 361
    :goto_0
    iget-object v3, p0, Lcom/google/payment/IabHelper;->mContext:Landroid/content/Context;

    invoke-virtual {v3}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v3

    const/4 v4, 0x0

    invoke-virtual {v3, v2, v4}, Landroid/content/pm/PackageManager;->queryIntentServices(Landroid/content/Intent;I)Ljava/util/List;

    move-result-object v1

    .line 362
    .local v1, "intentServices":Ljava/util/List;, "Ljava/util/List<Landroid/content/pm/ResolveInfo;>;"
    if-eqz v1, :cond_3

    invoke-interface {v1}, Ljava/util/List;->isEmpty()Z

    move-result v3

    if-nez v3, :cond_3

    .line 366
    :try_start_0
    iget-object v3, p0, Lcom/google/payment/IabHelper;->mContext:Landroid/content/Context;

    iget-object v4, p0, Lcom/google/payment/IabHelper;->mServiceConn:Landroid/content/ServiceConnection;

    const/4 v5, 0x1

    invoke-virtual {v3, v2, v4, v5}, Landroid/content/Context;->bindService(Landroid/content/Intent;Landroid/content/ServiceConnection;I)Z
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 382
    :cond_1
    :goto_1
    return-void

    .line 357
    .end local v1    # "intentServices":Ljava/util/List;, "Ljava/util/List<Landroid/content/pm/ResolveInfo;>;"
    .end local v2    # "serviceIntent":Landroid/content/Intent;
    :cond_2
    new-instance v2, Landroid/content/Intent;

    const-string v3, "com.android.vending.billing.InAppBillingService.BIND"

    invoke-direct {v2, v3}, Landroid/content/Intent;-><init>(Ljava/lang/String;)V

    .line 358
    .restart local v2    # "serviceIntent":Landroid/content/Intent;
    const-string v3, "com.android.vending"

    invoke-virtual {v2, v3}, Landroid/content/Intent;->setPackage(Ljava/lang/String;)Landroid/content/Intent;

    goto :goto_0

    .line 367
    .restart local v1    # "intentServices":Ljava/util/List;, "Ljava/util/List<Landroid/content/pm/ResolveInfo;>;"
    :catch_0
    move-exception v0

    .line 368
    .local v0, "e":Ljava/lang/Exception;
    if-eqz p1, :cond_1

    .line 369
    new-instance v3, Lcom/google/payment/IabResult;

    const-string v4, "bindService error on device."

    invoke-direct {v3, v6, v4}, Lcom/google/payment/IabResult;-><init>(ILjava/lang/String;)V

    invoke-interface {p1, v3}, Lcom/google/payment/IabHelper$OnIabSetupFinishedListener;->onIabSetupFinished(Lcom/google/payment/IabResult;)V

    goto :goto_1

    .line 376
    .end local v0    # "e":Ljava/lang/Exception;
    :cond_3
    if-eqz p1, :cond_1

    .line 377
    new-instance v3, Lcom/google/payment/IabResult;

    const-string v4, "Billing service unavailable on device."

    invoke-direct {v3, v6, v4}, Lcom/google/payment/IabResult;-><init>(ILjava/lang/String;)V

    invoke-interface {p1, v3}, Lcom/google/payment/IabHelper$OnIabSetupFinishedListener;->onIabSetupFinished(Lcom/google/payment/IabResult;)V

    goto :goto_1
.end method

.method public subscriptionsSupported()Z
    .locals 1

    .prologue
    .line 443
    invoke-direct {p0}, Lcom/google/payment/IabHelper;->checkNotDisposed()V

    .line 444
    iget-boolean v0, p0, Lcom/google/payment/IabHelper;->mSubscriptionsSupported:Z

    return v0
.end method
