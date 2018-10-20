.class public Lcom/igg/sdk/payment/google/IGGDeviceInfoHeaderDelegate;
.super Ljava/lang/Object;
.source "IGGDeviceInfoHeaderDelegate.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$HeaderDelegate;


# static fields
.field static final TAG:Ljava/lang/String; = "IGGDeviceInfoHeaderDelegate"


# instance fields
.field private context:Landroid/content/Context;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 0
    .param p1, "context"    # Landroid/content/Context;

    .prologue
    .line 24
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 25
    iput-object p1, p0, Lcom/igg/sdk/payment/google/IGGDeviceInfoHeaderDelegate;->context:Landroid/content/Context;

    .line 26
    return-void
.end method

.method private makeQueryStringFromMap(Ljava/util/HashMap;)Ljava/lang/String;
    .locals 5
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;)",
            "Ljava/lang/String;"
        }
    .end annotation

    .prologue
    .line 67
    .local p1, "fields":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v0, "OS=Android"

    .line 68
    .local v0, "info":Ljava/lang/String;
    invoke-virtual {p1}, Ljava/util/HashMap;->keySet()Ljava/util/Set;

    move-result-object v2

    invoke-interface {v2}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v3

    :goto_0
    invoke-interface {v3}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_0

    invoke-interface {v3}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    .line 69
    .local v1, "key":Ljava/lang/String;
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v4, "&"

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v4, "="

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {p1, v1}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    invoke-virtual {v4, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 70
    goto :goto_0

    .line 72
    .end local v1    # "key":Ljava/lang/String;
    :cond_0
    return-object v0
.end method


# virtual methods
.method public getHeader()Ljava/util/HashMap;
    .locals 9
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .prologue
    .line 30
    new-instance v2, Ljava/util/HashMap;

    invoke-direct {v2}, Ljava/util/HashMap;-><init>()V

    .line 31
    .local v2, "fields":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    iget-object v7, p0, Lcom/igg/sdk/payment/google/IGGDeviceInfoHeaderDelegate;->context:Landroid/content/Context;

    invoke-static {v7}, Lcom/igg/util/DeviceUtil;->getFilterIMEI(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v4

    .line 32
    .local v4, "imei":Ljava/lang/String;
    if-nez v4, :cond_0

    .line 33
    const-string v4, ""

    .line 36
    :cond_0
    const-string v7, "imei"

    invoke-virtual {v2, v7, v4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 37
    iget-object v7, p0, Lcom/igg/sdk/payment/google/IGGDeviceInfoHeaderDelegate;->context:Landroid/content/Context;

    invoke-static {v7}, Lcom/igg/util/DeviceUtil;->getFilterLocalMacAddress(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v5

    .line 38
    .local v5, "mac":Ljava/lang/String;
    if-nez v5, :cond_1

    .line 39
    const-string v5, ""

    .line 42
    :cond_1
    const-string v7, "wifi_mac"

    invoke-virtual {v2, v7, v5}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 46
    :try_start_0
    iget-object v7, p0, Lcom/igg/sdk/payment/google/IGGDeviceInfoHeaderDelegate;->context:Landroid/content/Context;

    invoke-static {v7}, Lcom/google/android/gms/ads/identifier/AdvertisingIdClient;->getAdvertisingIdInfo(Landroid/content/Context;)Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;

    move-result-object v0

    .line 47
    .local v0, "adInfo":Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;
    invoke-virtual {v0}, Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;->getId()Ljava/lang/String;
    :try_end_0
    .catch Ljava/io/IOException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Lcom/google/android/gms/common/GooglePlayServicesNotAvailableException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Lcom/google/android/gms/common/GooglePlayServicesRepairableException; {:try_start_0 .. :try_end_0} :catch_2

    move-result-object v3

    .line 60
    .end local v0    # "adInfo":Lcom/google/android/gms/ads/identifier/AdvertisingIdClient$Info;
    .local v3, "gid":Ljava/lang/String;
    :goto_0
    const-string v7, "adid"

    invoke-virtual {v2, v7, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 61
    new-instance v6, Ljava/util/HashMap;

    invoke-direct {v6}, Ljava/util/HashMap;-><init>()V

    .line 62
    .local v6, "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v7, "X-IGG-DEVICE"

    invoke-direct {p0, v2}, Lcom/igg/sdk/payment/google/IGGDeviceInfoHeaderDelegate;->makeQueryStringFromMap(Ljava/util/HashMap;)Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v6, v7, v8}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 63
    return-object v6

    .line 48
    .end local v3    # "gid":Ljava/lang/String;
    .end local v6    # "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    :catch_0
    move-exception v1

    .line 51
    .local v1, "e":Ljava/io/IOException;
    const-string v3, ""

    .line 52
    .restart local v3    # "gid":Ljava/lang/String;
    const-string v7, "IGGDeviceInfoHeaderDelegate"

    const-string v8, "the old version of the service doesn\'t support getting AdvertisingId"

    invoke-static {v7, v8}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 53
    .end local v1    # "e":Ljava/io/IOException;
    .end local v3    # "gid":Ljava/lang/String;
    :catch_1
    move-exception v1

    .line 54
    .local v1, "e":Lcom/google/android/gms/common/GooglePlayServicesNotAvailableException;
    const-string v3, ""

    .line 55
    .restart local v3    # "gid":Ljava/lang/String;
    const-string v7, "IGGDeviceInfoHeaderDelegate"

    const-string v8, "Google Play services is not available entirely."

    invoke-static {v7, v8}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 56
    .end local v1    # "e":Lcom/google/android/gms/common/GooglePlayServicesNotAvailableException;
    .end local v3    # "gid":Ljava/lang/String;
    :catch_2
    move-exception v1

    .line 57
    .local v1, "e":Lcom/google/android/gms/common/GooglePlayServicesRepairableException;
    const-string v3, ""

    .restart local v3    # "gid":Ljava/lang/String;
    goto :goto_0
.end method
