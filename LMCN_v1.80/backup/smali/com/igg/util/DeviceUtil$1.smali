.class final Lcom/igg/util/DeviceUtil$1;
.super Landroid/os/AsyncTask;
.source "DeviceUtil.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/util/DeviceUtil;->getAdvertisingId(Lcom/igg/util/DeviceUtil$getAdvertisingIdListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x8
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Landroid/os/AsyncTask",
        "<",
        "Ljava/lang/Object;",
        "Ljava/lang/Integer;",
        "Ljava/lang/Object;",
        ">;"
    }
.end annotation


# instance fields
.field final synthetic val$listener:Lcom/igg/util/DeviceUtil$getAdvertisingIdListener;


# direct methods
.method constructor <init>(Lcom/igg/util/DeviceUtil$getAdvertisingIdListener;)V
    .locals 0

    .prologue
    .line 349
    iput-object p1, p0, Lcom/igg/util/DeviceUtil$1;->val$listener:Lcom/igg/util/DeviceUtil$getAdvertisingIdListener;

    invoke-direct {p0}, Landroid/os/AsyncTask;-><init>()V

    return-void
.end method


# virtual methods
.method protected varargs doInBackground([Ljava/lang/Object;)Ljava/lang/Object;
    .locals 4
    .param p1, "params"    # [Ljava/lang/Object;

    .prologue
    .line 353
    const-string v0, ""

    .line 357
    .local v0, "adId":Ljava/lang/String;
    :try_start_0
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v3

    invoke-static {v3}, Lcom/igg/util/DeviceUtil;->getAdvertisingIdInfo(Landroid/content/Context;)Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;

    move-result-object v2

    .line 358
    .local v2, "info":Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;
    if-eqz v2, :cond_0

    .line 359
    invoke-virtual {v2}, Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;->getId()Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v0

    :cond_0
    move-object v3, v0

    .line 364
    .end local v2    # "info":Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;
    :goto_0
    return-object v3

    .line 363
    :catch_0
    move-exception v1

    .line 364
    .local v1, "e":Ljava/lang/Exception;
    const-string v3, ""

    goto :goto_0
.end method

.method protected onPostExecute(Ljava/lang/Object;)V
    .locals 2
    .param p1, "str"    # Ljava/lang/Object;

    .prologue
    .line 371
    move-object v0, p1

    check-cast v0, Ljava/lang/String;

    .line 372
    .local v0, "adId":Ljava/lang/String;
    iget-object v1, p0, Lcom/igg/util/DeviceUtil$1;->val$listener:Lcom/igg/util/DeviceUtil$getAdvertisingIdListener;

    invoke-interface {v1, v0}, Lcom/igg/util/DeviceUtil$getAdvertisingIdListener;->onRequestFinished(Ljava/lang/String;)V

    .line 373
    return-void
.end method
