.class final Lcom/appsflyer/p;
.super Lcom/appsflyer/OneLinkHttpTask;
.source ""


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/appsflyer/p$a;
    }
.end annotation


# instance fields
.field private ˎ:Ljava/lang/String;

.field private ˏ:Lcom/appsflyer/p$a;


# direct methods
.method constructor <init>(Landroid/net/Uri;Lcom/appsflyer/AppsFlyerLib;)V
    .locals 3

    .prologue
    .line 30
    invoke-direct {p0, p2}, Lcom/appsflyer/OneLinkHttpTask;-><init>(Lcom/appsflyer/AppsFlyerLib;)V

    .line 31
    invoke-virtual {p1}, Landroid/net/Uri;->getHost()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_0

    invoke-virtual {p1}, Landroid/net/Uri;->getPath()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_0

    .line 32
    invoke-virtual {p1}, Landroid/net/Uri;->getPath()Ljava/lang/String;

    move-result-object v0

    const-string v1, "/"

    invoke-virtual {v0, v1}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v0

    .line 33
    invoke-virtual {p1}, Landroid/net/Uri;->getHost()Ljava/lang/String;

    move-result-object v1

    const-string v2, "onelink.me"

    invoke-virtual {v1, v2}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v1

    if-eqz v1, :cond_0

    array-length v1, v0

    const/4 v2, 0x3

    if-ne v1, v2, :cond_0

    .line 34
    const/4 v1, 0x1

    aget-object v1, v0, v1

    iput-object v1, p0, Lcom/appsflyer/OneLinkHttpTask;->ˊ:Ljava/lang/String;

    .line 35
    const/4 v1, 0x2

    aget-object v0, v0, v1

    iput-object v0, p0, Lcom/appsflyer/p;->ˎ:Ljava/lang/String;

    .line 38
    :cond_0
    return-void
.end method


# virtual methods
.method final ˊ()Ljava/lang/String;
    .locals 2

    .prologue
    .line 55
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "https://onelink.%s/shortlink-sdk/v1"

    invoke-static {v1}, Lcom/appsflyer/ServerConfigHandler;->getUrl(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "/"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v1, p0, Lcom/appsflyer/OneLinkHttpTask;->ˊ:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "?id="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v1, p0, Lcom/appsflyer/p;->ˎ:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method final ˊ(Lcom/appsflyer/p$a;)V
    .locals 0
    .param p1    # Lcom/appsflyer/p$a;
        .annotation build Landroid/support/annotation/NonNull;
        .end annotation
    .end param

    .prologue
    .line 41
    iput-object p1, p0, Lcom/appsflyer/p;->ˏ:Lcom/appsflyer/p$a;

    .line 42
    return-void
.end method

.method final ˎ(Ljava/lang/String;)V
    .locals 5

    .prologue
    .line 61
    :try_start_0
    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    .line 62
    new-instance v2, Lorg/json/JSONObject;

    invoke-direct {v2, p1}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 63
    invoke-virtual {v2}, Lorg/json/JSONObject;->keys()Ljava/util/Iterator;

    move-result-object v3

    .line 64
    :goto_0
    invoke-interface {v3}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 65
    invoke-interface {v3}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    .line 66
    invoke-virtual {v2, v0}, Lorg/json/JSONObject;->optString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-interface {v1, v0, v4}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 69
    :catch_0
    move-exception v0

    .line 70
    iget-object v1, p0, Lcom/appsflyer/p;->ˏ:Lcom/appsflyer/p$a;

    const-string v2, "Can\'t parse one link data"

    invoke-interface {v1, v2}, Lcom/appsflyer/p$a;->ˋ(Ljava/lang/String;)V

    .line 71
    const-string v1, "Error while parsing to json "

    invoke-static {p1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    .line 73
    :goto_1
    return-void

    .line 68
    :cond_0
    :try_start_1
    iget-object v0, p0, Lcom/appsflyer/p;->ˏ:Lcom/appsflyer/p$a;

    invoke-interface {v0, v1}, Lcom/appsflyer/p$a;->ˎ(Ljava/util/Map;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_1
.end method

.method final ˎ(Ljavax/net/ssl/HttpsURLConnection;)V
    .locals 1
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lorg/json/JSONException;,
            Ljava/io/IOException;
        }
    .end annotation

    .prologue
    .line 50
    const-string v0, "GET"

    invoke-virtual {p1, v0}, Ljava/net/HttpURLConnection;->setRequestMethod(Ljava/lang/String;)V

    .line 51
    return-void
.end method

.method final ˏ()Z
    .locals 1

    .prologue
    .line 45
    iget-object v0, p0, Lcom/appsflyer/OneLinkHttpTask;->ˊ:Ljava/lang/String;

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_0

    iget-object v0, p0, Lcom/appsflyer/p;->ˎ:Ljava/lang/String;

    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method final ॱ()V
    .locals 2

    .prologue
    .line 77
    iget-object v0, p0, Lcom/appsflyer/p;->ˏ:Lcom/appsflyer/p$a;

    const-string v1, "Can\'t get one link data"

    invoke-interface {v0, v1}, Lcom/appsflyer/p$a;->ˋ(Ljava/lang/String;)V

    .line 78
    return-void
.end method
