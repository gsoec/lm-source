.class public Lcom/appsflyer/CreateOneLinkHttpTask;
.super Lcom/appsflyer/OneLinkHttpTask;
.source ""


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/appsflyer/CreateOneLinkHttpTask$ResponseListener;
    }
.end annotation


# instance fields
.field private ʽ:Landroid/content/Context;

.field private ˋ:Lcom/appsflyer/CreateOneLinkHttpTask$ResponseListener;

.field private ˎ:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private ˏ:Ljava/lang/String;

.field private ॱ:Ljava/lang/String;

.field private ᐝ:Z


# direct methods
.method public constructor <init>(Ljava/lang/String;Ljava/util/Map;Lcom/appsflyer/AppsFlyerLib;Landroid/content/Context;Z)V
    .locals 1
    .param p1    # Ljava/lang/String;
        .annotation build Landroid/support/annotation/NonNull;
        .end annotation
    .end param
    .param p2    # Ljava/util/Map;
        .annotation build Landroid/support/annotation/NonNull;
        .end annotation
    .end param
    .param p4    # Landroid/content/Context;
        .annotation build Landroid/support/annotation/NonNull;
        .end annotation
    .end param
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;",
            "Lcom/appsflyer/AppsFlyerLib;",
            "Landroid/content/Context;",
            "Z)V"
        }
    .end annotation

    .prologue
    .line 42
    invoke-direct {p0, p3}, Lcom/appsflyer/OneLinkHttpTask;-><init>(Lcom/appsflyer/AppsFlyerLib;)V

    .line 34
    const-string v0, ""

    iput-object v0, p0, Lcom/appsflyer/CreateOneLinkHttpTask;->ॱ:Ljava/lang/String;

    .line 36
    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/appsflyer/CreateOneLinkHttpTask;->ᐝ:Z

    .line 43
    iput-boolean p5, p0, Lcom/appsflyer/CreateOneLinkHttpTask;->ᐝ:Z

    .line 44
    iput-object p4, p0, Lcom/appsflyer/CreateOneLinkHttpTask;->ʽ:Landroid/content/Context;

    .line 46
    iget-object v0, p0, Lcom/appsflyer/CreateOneLinkHttpTask;->ʽ:Landroid/content/Context;

    if-eqz v0, :cond_0

    .line 47
    invoke-virtual {p4}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/appsflyer/CreateOneLinkHttpTask;->ॱ:Ljava/lang/String;

    .line 51
    :goto_0
    iput-object p1, p0, Lcom/appsflyer/OneLinkHttpTask;->ˊ:Ljava/lang/String;

    .line 52
    const-string v0, "-1"

    iput-object v0, p0, Lcom/appsflyer/CreateOneLinkHttpTask;->ˏ:Ljava/lang/String;

    .line 53
    iput-object p2, p0, Lcom/appsflyer/CreateOneLinkHttpTask;->ˎ:Ljava/util/Map;

    .line 54
    return-void

    .line 49
    :cond_0
    const-string v0, "CreateOneLinkHttpTask: context can\'t be null"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V

    goto :goto_0
.end method


# virtual methods
.method public setListener(Lcom/appsflyer/CreateOneLinkHttpTask$ResponseListener;)V
    .locals 0
    .param p1    # Lcom/appsflyer/CreateOneLinkHttpTask$ResponseListener;
        .annotation build Landroid/support/annotation/NonNull;
        .end annotation
    .end param

    .prologue
    .line 57
    iput-object p1, p0, Lcom/appsflyer/CreateOneLinkHttpTask;->ˋ:Lcom/appsflyer/CreateOneLinkHttpTask$ResponseListener;

    .line 58
    return-void
.end method

.method final ˊ()Ljava/lang/String;
    .locals 2

    .prologue
    .line 82
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

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method final ˎ(Ljava/lang/String;)V
    .locals 4

    .prologue
    .line 88
    :try_start_0
    new-instance v1, Lorg/json/JSONObject;

    invoke-direct {v1, p1}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 89
    invoke-virtual {v1}, Lorg/json/JSONObject;->keys()Ljava/util/Iterator;

    move-result-object v2

    .line 90
    :goto_0
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 91
    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    .line 92
    iget-object v3, p0, Lcom/appsflyer/CreateOneLinkHttpTask;->ˋ:Lcom/appsflyer/CreateOneLinkHttpTask$ResponseListener;

    invoke-virtual {v1, v0}, Lorg/json/JSONObject;->optString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-interface {v3, v0}, Lcom/appsflyer/CreateOneLinkHttpTask$ResponseListener;->onResponse(Ljava/lang/String;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 94
    :catch_0
    move-exception v0

    .line 95
    iget-object v1, p0, Lcom/appsflyer/CreateOneLinkHttpTask;->ˋ:Lcom/appsflyer/CreateOneLinkHttpTask$ResponseListener;

    const-string v2, "Can\'t parse one link data"

    invoke-interface {v1, v2}, Lcom/appsflyer/CreateOneLinkHttpTask$ResponseListener;->onResponseError(Ljava/lang/String;)V

    .line 96
    const-string v1, "Error while parsing to json "

    invoke-static {p1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-static {v1, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    .line 98
    :cond_0
    return-void
.end method

.method final ˎ(Ljavax/net/ssl/HttpsURLConnection;)V
    .locals 4
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lorg/json/JSONException;,
            Ljava/io/IOException;
        }
    .end annotation

    .prologue
    const/4 v1, 0x1

    .line 61
    iget-boolean v0, p0, Lcom/appsflyer/CreateOneLinkHttpTask;->ᐝ:Z

    if-eqz v0, :cond_0

    .line 78
    :goto_0
    return-void

    .line 64
    :cond_0
    const-string v0, "POST"

    invoke-virtual {p1, v0}, Ljava/net/HttpURLConnection;->setRequestMethod(Ljava/lang/String;)V

    .line 65
    invoke-virtual {p1, v1}, Ljava/net/URLConnection;->setDoInput(Z)V

    .line 66
    invoke-virtual {p1, v1}, Ljava/net/URLConnection;->setDoOutput(Z)V

    .line 67
    const/4 v0, 0x0

    invoke-virtual {p1, v0}, Ljava/net/URLConnection;->setUseCaches(Z)V

    .line 68
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0}, Lorg/json/JSONObject;-><init>()V

    .line 69
    new-instance v1, Lorg/json/JSONObject;

    iget-object v2, p0, Lcom/appsflyer/CreateOneLinkHttpTask;->ˎ:Ljava/util/Map;

    invoke-direct {v1, v2}, Lorg/json/JSONObject;-><init>(Ljava/util/Map;)V

    .line 70
    const-string v2, "ttl"

    iget-object v3, p0, Lcom/appsflyer/CreateOneLinkHttpTask;->ˏ:Ljava/lang/String;

    invoke-virtual {v0, v2, v3}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 71
    const-string v2, "data"

    invoke-virtual {v0, v2, v1}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 72
    invoke-virtual {p1}, Ljava/net/URLConnection;->connect()V

    .line 74
    new-instance v1, Ljava/io/DataOutputStream;

    invoke-virtual {p1}, Ljava/net/URLConnection;->getOutputStream()Ljava/io/OutputStream;

    move-result-object v2

    invoke-direct {v1, v2}, Ljava/io/DataOutputStream;-><init>(Ljava/io/OutputStream;)V

    .line 75
    invoke-virtual {v0}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v1, v0}, Ljava/io/DataOutputStream;->writeBytes(Ljava/lang/String;)V

    .line 76
    invoke-virtual {v1}, Ljava/io/OutputStream;->flush()V

    .line 77
    invoke-virtual {v1}, Ljava/io/OutputStream;->close()V

    goto :goto_0
.end method

.method final ॱ()V
    .locals 4

    .prologue
    .line 103
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "onelinkDomain"

    invoke-virtual {v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 105
    new-instance v1, Lcom/appsflyer/share/LinkGenerator;

    const-string v2, "af_app_invites"

    invoke-direct {v1, v2}, Lcom/appsflyer/share/LinkGenerator;-><init>(Ljava/lang/String;)V

    iget-object v2, p0, Lcom/appsflyer/OneLinkHttpTask;->ˊ:Ljava/lang/String;

    iget-object v3, p0, Lcom/appsflyer/CreateOneLinkHttpTask;->ॱ:Ljava/lang/String;

    .line 106
    invoke-virtual {v1, v2, v0, v3}, Lcom/appsflyer/share/LinkGenerator;->setBaseURL(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;

    move-result-object v0

    const-string v1, "af_siteid"

    iget-object v2, p0, Lcom/appsflyer/CreateOneLinkHttpTask;->ॱ:Ljava/lang/String;

    .line 107
    invoke-virtual {v0, v1, v2}, Lcom/appsflyer/share/LinkGenerator;->addParameter(Ljava/lang/String;Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;

    move-result-object v0

    iget-object v1, p0, Lcom/appsflyer/CreateOneLinkHttpTask;->ˎ:Ljava/util/Map;

    .line 108
    invoke-virtual {v0, v1}, Lcom/appsflyer/share/LinkGenerator;->addParameters(Ljava/util/Map;)Lcom/appsflyer/share/LinkGenerator;

    move-result-object v0

    .line 110
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    const-string v2, "AppUserId"

    invoke-virtual {v1, v2}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 112
    if-eqz v1, :cond_0

    .line 113
    invoke-virtual {v0, v1}, Lcom/appsflyer/share/LinkGenerator;->setReferrerCustomerId(Ljava/lang/String;)Lcom/appsflyer/share/LinkGenerator;

    .line 115
    :cond_0
    invoke-virtual {v0}, Lcom/appsflyer/share/LinkGenerator;->generateLink()Ljava/lang/String;

    move-result-object v0

    .line 118
    iget-object v1, p0, Lcom/appsflyer/CreateOneLinkHttpTask;->ˋ:Lcom/appsflyer/CreateOneLinkHttpTask$ResponseListener;

    invoke-interface {v1, v0}, Lcom/appsflyer/CreateOneLinkHttpTask$ResponseListener;->onResponse(Ljava/lang/String;)V

    .line 119
    return-void
.end method
