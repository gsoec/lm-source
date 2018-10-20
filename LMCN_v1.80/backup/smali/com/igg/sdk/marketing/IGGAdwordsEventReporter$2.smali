.class Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$2;
.super Ljava/lang/Object;
.source "IGGAdwordsEventReporter.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;->report(Ljava/util/HashMap;Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;

.field final synthetic val$params:Ljava/util/HashMap;

.field final synthetic val$requestListener:Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;

    .prologue
    .line 127
    iput-object p1, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$2;->this$0:Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;

    iput-object p2, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$2;->val$params:Ljava/util/HashMap;

    iput-object p3, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$2;->val$requestListener:Lcom/igg/sdk/service/IGGService$GeneralRequestListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 8

    .prologue
    .line 132
    :try_start_0
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v4

    invoke-static {v4}, Lcom/google/android/gms/common/GooglePlayServicesUtil;->isGooglePlayServicesAvailable(Landroid/content/Context;)I

    move-result v3

    .line 133
    .local v3, "resultCode":I
    if-nez v3, :cond_0

    .line 134
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v4

    invoke-static {v4}, Lcom/google/android/gms/ads/identifier/AdvertisingIdClient;->getAdvertisingIdInfo(Landroid/content/Context;)Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;

    move-result-object v4

    invoke-virtual {v4}, Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;->getId()Ljava/lang/String;

    move-result-object v0

    .line 135
    .local v0, "adId":Ljava/lang/String;
    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v4

    if-nez v4, :cond_0

    .line 136
    iget-object v4, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$2;->val$params:Ljava/util/HashMap;

    const-string v5, "adid"

    invoke-virtual {v4, v5, v0}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 143
    .end local v0    # "adId":Ljava/lang/String;
    .end local v3    # "resultCode":I
    :cond_0
    :goto_0
    iget-object v4, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$2;->this$0:Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;

    invoke-static {v4}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;->access$100(Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;)Ljava/lang/String;

    move-result-object v2

    .line 144
    .local v2, "muId":Ljava/lang/String;
    invoke-static {v2}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v4

    if-nez v4, :cond_1

    .line 145
    iget-object v4, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$2;->val$params:Ljava/util/HashMap;

    const-string v5, "muid"

    invoke-virtual {v4, v5, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 148
    :cond_1
    new-instance v4, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v4}, Lcom/igg/sdk/service/IGGService;-><init>()V

    iget-object v5, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$2;->this$0:Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;

    invoke-static {v5}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;->access$200(Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;)Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    move-result-object v5

    invoke-static {v5}, Lcom/igg/sdk/IGGURLHelper;->getGoogleAdwordsAPI(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)Ljava/lang/String;

    move-result-object v5

    iget-object v6, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$2;->val$params:Ljava/util/HashMap;

    iget-object v7, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$2;->val$requestListener:Lcom/igg/sdk/service/IGGService$GeneralRequestListener;

    invoke-virtual {v4, v5, v6, v7}, Lcom/igg/sdk/service/IGGService;->getRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 149
    return-void

    .line 139
    .end local v2    # "muId":Ljava/lang/String;
    :catch_0
    move-exception v1

    .line 140
    .local v1, "e":Ljava/lang/Exception;
    invoke-virtual {v1}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0
.end method
