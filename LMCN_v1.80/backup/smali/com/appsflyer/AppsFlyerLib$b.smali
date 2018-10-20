.class final Lcom/appsflyer/AppsFlyerLib$b;
.super Lcom/appsflyer/AppsFlyerLib$e;
.source ""


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/appsflyer/AppsFlyerLib;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = "b"
.end annotation


# instance fields
.field private synthetic ˋ:Lcom/appsflyer/AppsFlyerLib;


# direct methods
.method public constructor <init>(Lcom/appsflyer/AppsFlyerLib;Landroid/content/Context;Ljava/lang/String;Ljava/util/concurrent/ScheduledExecutorService;)V
    .locals 0

    .prologue
    .line 3081
    iput-object p1, p0, Lcom/appsflyer/AppsFlyerLib$b;->ˋ:Lcom/appsflyer/AppsFlyerLib;

    .line 3082
    invoke-direct {p0, p1, p2, p3, p4}, Lcom/appsflyer/AppsFlyerLib$e;-><init>(Lcom/appsflyer/AppsFlyerLib;Landroid/content/Context;Ljava/lang/String;Ljava/util/concurrent/ScheduledExecutorService;)V

    .line 3083
    return-void
.end method


# virtual methods
.method public final ˋ()Ljava/lang/String;
    .locals 1

    .prologue
    .line 3087
    const-string v0, "https://api.%s/install_data/v3/"

    invoke-static {v0}, Lcom/appsflyer/ServerConfigHandler;->getUrl(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method protected final ˋ(Ljava/lang/String;I)V
    .locals 3

    .prologue
    .line 3097
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->ॱ()Lcom/appsflyer/AppsFlyerConversionListener;

    move-result-object v0

    invoke-interface {v0, p1}, Lcom/appsflyer/AppsFlyerConversionListener;->onInstallConversionFailure(Ljava/lang/String;)V

    .line 3099
    const/16 v0, 0x190

    if-lt p2, v0, :cond_0

    const/16 v0, 0x1f4

    if-ge p2, v0, :cond_0

    .line 3100
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$e;->ˎ:Ljava/lang/ref/WeakReference;

    invoke-virtual {v0}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;

    invoke-static {v0}, Lcom/appsflyer/AppsFlyerLib;->ˏ(Landroid/content/Context;)Landroid/content/SharedPreferences;

    move-result-object v0

    .line 3101
    const-string v1, "appsflyerConversionDataRequestRetries"

    const/4 v2, 0x0

    invoke-interface {v0, v1, v2}, Landroid/content/SharedPreferences;->getInt(Ljava/lang/String;I)I

    move-result v1

    .line 3102
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$e;->ˎ:Ljava/lang/ref/WeakReference;

    invoke-virtual {v0}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;

    const-string v2, "appsflyerConversionDataRequestRetries"

    add-int/lit8 v1, v1, 0x1

    invoke-static {v0, v2, v1}, Lcom/appsflyer/AppsFlyerLib;->ˊ(Landroid/content/Context;Ljava/lang/String;I)V

    .line 3105
    :cond_0
    return-void
.end method

.method protected final ˎ(Ljava/util/Map;)V
    .locals 3
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
    .line 3091
    const-string v0, "is_first_launch"

    const/4 v1, 0x1

    invoke-static {v1}, Ljava/lang/Boolean;->toString(Z)Ljava/lang/String;

    move-result-object v1

    invoke-interface {p1, v0, v1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 3092
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->ॱ()Lcom/appsflyer/AppsFlyerConversionListener;

    move-result-object v0

    invoke-interface {v0, p1}, Lcom/appsflyer/AppsFlyerConversionListener;->onInstallConversionDataLoaded(Ljava/util/Map;)V

    .line 3093
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$e;->ˎ:Ljava/lang/ref/WeakReference;

    invoke-virtual {v0}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;

    const-string v1, "appsflyerConversionDataRequestRetries"

    const/4 v2, 0x0

    invoke-static {v0, v1, v2}, Lcom/appsflyer/AppsFlyerLib;->ˊ(Landroid/content/Context;Ljava/lang/String;I)V

    .line 3094
    return-void
.end method
