.class public Lcom/appsflyer/share/CrossPromotionHelper;
.super Ljava/lang/Object;
.source ""


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/appsflyer/share/CrossPromotionHelper$b;
    }
.end annotation


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 22
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static trackAndOpenStore(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V
    .locals 1

    .prologue
    .line 28
    const/4 v0, 0x0

    invoke-static {p0, p1, p2, v0}, Lcom/appsflyer/share/CrossPromotionHelper;->trackAndOpenStore(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/util/Map;)V

    .line 29
    return-void
.end method

.method public static trackAndOpenStore(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/util/Map;)V
    .locals 6
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/content/Context;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .prologue
    const/4 v5, 0x1

    const/4 v4, 0x0

    .line 35
    const-string v0, "https://app.%s"

    .line 39
    invoke-static {v0}, Lcom/appsflyer/ServerConfigHandler;->getUrl(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 35
    invoke-static {p0, p1, p2, p3, v0}, Lcom/appsflyer/share/CrossPromotionHelper;->ˊ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/util/Map;Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;

    move-result-object v0

    .line 41
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    const-string v2, "waitForCustomerId"

    .line 42
    invoke-virtual {v1, v2, v4}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v1

    if-eqz v1, :cond_0

    .line 43
    const-string v0, "CustomerUserId not set, track And Open Store is disabled"

    invoke-static {v0, v5}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;Z)V

    .line 56
    :goto_0
    return-void

    .line 47
    :cond_0
    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    .line 48
    if-eqz p3, :cond_1

    .line 49
    invoke-interface {v1, p3}, Ljava/util/Map;->putAll(Ljava/util/Map;)V

    .line 51
    :cond_1
    const-string v2, "af_campaign"

    invoke-interface {v1, v2, p2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 52
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v2

    const-string v3, "af_cross_promotion"

    invoke-virtual {v2, p0, v3, v1}, Lcom/appsflyer/AppsFlyerLib;->trackEvent(Landroid/content/Context;Ljava/lang/String;Ljava/util/Map;)V

    .line 54
    new-instance v1, Lcom/appsflyer/share/d;

    invoke-direct {v1}, Lcom/appsflyer/share/d;-><init>()V

    .line 55
    new-instance v2, Lcom/appsflyer/share/CrossPromotionHelper$b;

    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v3

    invoke-virtual {v3}, Lcom/appsflyer/AppsFlyerLib;->isTrackingStopped()Z

    move-result v3

    invoke-direct {v2, v1, p0, v3}, Lcom/appsflyer/share/CrossPromotionHelper$b;-><init>(Lcom/appsflyer/share/d;Landroid/content/Context;Z)V

    new-array v1, v5, [Ljava/lang/String;

    invoke-virtual {v0}, Lcom/appsflyer/share/LinkGenerator;->generateLink()Ljava/lang/String;

    move-result-object v0

    aput-object v0, v1, v4

    invoke-virtual {v2, v1}, Landroid/os/AsyncTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    goto :goto_0
.end method

.method public static trackCrossPromoteImpression(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V
    .locals 6

    .prologue
    const/4 v5, 0x1

    const/4 v4, 0x0

    const/4 v3, 0x0

    .line 63
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "waitForCustomerId"

    .line 64
    invoke-virtual {v0, v1, v4}, Lcom/appsflyer/AppsFlyerProperties;->getBoolean(Ljava/lang/String;Z)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 65
    const-string v0, "CustomerUserId not set, Promote Impression is disabled"

    invoke-static {v0, v5}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;Z)V

    .line 75
    :goto_0
    return-void

    .line 69
    :cond_0
    const-string v0, "https://impression.%s"

    .line 73
    invoke-static {v0}, Lcom/appsflyer/ServerConfigHandler;->getUrl(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 69
    invoke-static {p0, p1, p2, v3, v0}, Lcom/appsflyer/share/CrossPromotionHelper;->ˊ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/util/Map;Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;

    move-result-object v0

    .line 74
    new-instance v1, Lcom/appsflyer/share/CrossPromotionHelper$b;

    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v2

    invoke-virtual {v2}, Lcom/appsflyer/AppsFlyerLib;->isTrackingStopped()Z

    move-result v2

    invoke-direct {v1, v3, v3, v2}, Lcom/appsflyer/share/CrossPromotionHelper$b;-><init>(Lcom/appsflyer/share/d;Landroid/content/Context;Z)V

    new-array v2, v5, [Ljava/lang/String;

    invoke-virtual {v0}, Lcom/appsflyer/share/LinkGenerator;->generateLink()Ljava/lang/String;

    move-result-object v0

    aput-object v0, v2, v4

    invoke-virtual {v1, v2}, Landroid/os/AsyncTask;->execute([Ljava/lang/Object;)Landroid/os/AsyncTask;

    goto :goto_0
.end method

.method private static ˊ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/util/Map;Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/content/Context;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;",
            "Ljava/lang/String;",
            ")",
            "Lcom/appsflyer/share/LinkGenerator;"
        }
    .end annotation

    .prologue
    .line 82
    new-instance v0, Lcom/appsflyer/share/LinkGenerator;

    const-string v1, "af_cross_promotion"

    invoke-direct {v0, v1}, Lcom/appsflyer/share/LinkGenerator;-><init>(Ljava/lang/String;)V

    .line 83
    invoke-virtual {v0, p4}, Lcom/appsflyer/share/LinkGenerator;->ˏ(Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;

    move-result-object v1

    .line 84
    invoke-virtual {v1, p1}, Lcom/appsflyer/share/LinkGenerator;->ˎ(Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;

    move-result-object v1

    const-string v2, "af_siteid"

    .line 85
    invoke-virtual {p0}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Lcom/appsflyer/share/LinkGenerator;->addParameter(Ljava/lang/String;Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;

    .line 86
    if-eqz p2, :cond_0

    .line 87
    invoke-virtual {v0, p2}, Lcom/appsflyer/share/LinkGenerator;->setCampaign(Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;

    .line 89
    :cond_0
    if-eqz p3, :cond_1

    .line 90
    invoke-virtual {v0, p3}, Lcom/appsflyer/share/LinkGenerator;->addParameters(Ljava/util/Map;)Lcom/appsflyer/share/LinkGenerator;

    .line 92
    :cond_1
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    const-string v2, "advertiserId"

    invoke-virtual {v1, v2}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 93
    if-eqz v1, :cond_2

    .line 94
    const-string v2, "advertising_id"

    invoke-virtual {v0, v2, v1}, Lcom/appsflyer/share/LinkGenerator;->addParameter(Ljava/lang/String;Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;

    .line 96
    :cond_2
    return-object v0
.end method
