.class public Lcom/appsflyer/AppsFlyer2dXConversionCallback;
.super Ljava/lang/Object;
.source ""

# interfaces
.implements Lcom/appsflyer/AppsFlyerConversionListener;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 20
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private ॱ(Ljava/lang/String;Ljava/lang/String;)V
    .locals 3

    .prologue
    .line 45
    :try_start_0
    new-instance v1, Lorg/json/JSONObject;

    invoke-direct {v1}, Lorg/json/JSONObject;-><init>()V

    .line 46
    const-string v0, "status"

    const-string v2, "failure"

    invoke-virtual {v1, v0, v2}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 47
    const-string v0, "data"

    invoke-virtual {v1, v0, p2}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 49
    const/4 v0, -0x1

    invoke-virtual {p1}, Ljava/lang/Object;->hashCode()I

    move-result v2

    sparse-switch v2, :sswitch_data_0

    :cond_0
    :goto_0
    packed-switch v0, :pswitch_data_0

    .line 61
    :goto_1
    return-void

    .line 49
    :sswitch_0
    const-string v2, "onInstallConversionFailure"

    invoke-virtual {p1, v2}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_0

    const/4 v0, 0x0

    goto :goto_0

    :sswitch_1
    const-string v2, "onAttributionFailure"

    invoke-virtual {p1, v2}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_0

    const/4 v0, 0x1

    goto :goto_0

    .line 51
    :pswitch_0
    invoke-virtual {p0, v1}, Lcom/appsflyer/AppsFlyer2dXConversionCallback;->onInstallConversionFailureNative(Ljava/lang/Object;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_1

    .line 59
    :catch_0
    move-exception v0

    invoke-virtual {v0}, Ljava/lang/Throwable;->printStackTrace()V

    goto :goto_1

    .line 54
    :pswitch_1
    :try_start_1
    invoke-virtual {p0, v1}, Lcom/appsflyer/AppsFlyer2dXConversionCallback;->onAttributionFailureNative(Ljava/lang/Object;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_1

    .line 49
    :sswitch_data_0
    .sparse-switch
        -0x52d9d3b6 -> :sswitch_1
        0x3ea0a838 -> :sswitch_0
    .end sparse-switch

    :pswitch_data_0
    .packed-switch 0x0
        :pswitch_0
        :pswitch_1
    .end packed-switch
.end method


# virtual methods
.method public onAppOpenAttribution(Ljava/util/Map;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 34
    invoke-virtual {p0, p1}, Lcom/appsflyer/AppsFlyer2dXConversionCallback;->onAppOpenAttributionNative(Ljava/lang/Object;)V

    .line 35
    return-void
.end method

.method public native onAppOpenAttributionNative(Ljava/lang/Object;)V
.end method

.method public onAttributionFailure(Ljava/lang/String;)V
    .locals 1

    .prologue
    .line 39
    const-string v0, "onInstallConversionFailure"

    invoke-direct {p0, v0, p1}, Lcom/appsflyer/AppsFlyer2dXConversionCallback;->ॱ(Ljava/lang/String;Ljava/lang/String;)V

    .line 40
    return-void
.end method

.method public native onAttributionFailureNative(Ljava/lang/Object;)V
.end method

.method public onInstallConversionDataLoaded(Ljava/util/Map;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 24
    invoke-virtual {p0, p1}, Lcom/appsflyer/AppsFlyer2dXConversionCallback;->onInstallConversionDataLoadedNative(Ljava/lang/Object;)V

    .line 25
    return-void
.end method

.method public native onInstallConversionDataLoadedNative(Ljava/lang/Object;)V
.end method

.method public onInstallConversionFailure(Ljava/lang/String;)V
    .locals 1

    .prologue
    .line 29
    const-string v0, "onAttributionFailure"

    invoke-direct {p0, v0, p1}, Lcom/appsflyer/AppsFlyer2dXConversionCallback;->ॱ(Ljava/lang/String;Ljava/lang/String;)V

    .line 30
    return-void
.end method

.method public native onInstallConversionFailureNative(Ljava/lang/Object;)V
.end method
