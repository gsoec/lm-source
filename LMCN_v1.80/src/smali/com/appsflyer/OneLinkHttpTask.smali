.class public abstract Lcom/appsflyer/OneLinkHttpTask;
.super Ljava/lang/Object;
.source ""

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/appsflyer/OneLinkHttpTask$HttpsUrlConnectionProvider;
    }
.end annotation


# instance fields
.field ˊ:Ljava/lang/String;

.field private ˋ:Lcom/appsflyer/OneLinkHttpTask$HttpsUrlConnectionProvider;

.field private ॱ:Lcom/appsflyer/AppsFlyerLib;


# direct methods
.method constructor <init>(Lcom/appsflyer/AppsFlyerLib;)V
    .locals 0

    .prologue
    .line 27
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 28
    iput-object p1, p0, Lcom/appsflyer/OneLinkHttpTask;->ॱ:Lcom/appsflyer/AppsFlyerLib;

    .line 29
    return-void
.end method


# virtual methods
.method public run()V
    .locals 10

    .prologue
    .line 37
    .line 3042
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    const-wide/16 v2, 0x3e8

    div-long v2, v0, v2

    .line 3044
    const-string v1, ""

    .line 3045
    const-string v0, ""

    .line 3046
    invoke-virtual {p0}, Lcom/appsflyer/OneLinkHttpTask;->ˊ()Ljava/lang/String;

    move-result-object v4

    .line 3048
    const-string v5, "oneLinkUrl: "

    invoke-static {v4}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    invoke-static {v5}, Lcom/appsflyer/AFLogger;->afRDLog(Ljava/lang/String;)V

    .line 3050
    :try_start_0
    invoke-static {v4}, Lcom/appsflyer/OneLinkHttpTask$HttpsUrlConnectionProvider;->ॱ(Ljava/lang/String;)Ljavax/net/ssl/HttpsURLConnection;

    move-result-object v5

    .line 3051
    const-string v6, "content-type"

    const-string v7, "application/json"

    invoke-virtual {v5, v6, v7}, Ljava/net/URLConnection;->addRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    .line 3052
    const-string v6, "authorization"

    .line 3106
    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    .line 3107
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v8

    const-string v9, "AppsFlyerKey"

    invoke-virtual {v8, v9}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    .line 3108
    invoke-virtual {v8, v2, v3}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    .line 3110
    invoke-virtual {v7}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v7}, Lcom/appsflyer/s;->ˎ(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v7

    .line 4052
    invoke-virtual {v5, v6, v7}, Ljava/net/URLConnection;->addRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    .line 4053
    const-string v6, "af-timestamp"

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v5, v6, v2}, Ljava/net/URLConnection;->addRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    .line 4054
    const/16 v2, 0xbb8

    invoke-virtual {v5, v2}, Ljava/net/URLConnection;->setReadTimeout(I)V

    .line 4055
    const/16 v2, 0xbb8

    invoke-virtual {v5, v2}, Ljava/net/URLConnection;->setConnectTimeout(I)V

    .line 4057
    invoke-virtual {p0, v5}, Lcom/appsflyer/OneLinkHttpTask;->ˎ(Ljavax/net/ssl/HttpsURLConnection;)V

    .line 4059
    invoke-virtual {v5}, Ljava/net/HttpURLConnection;->getResponseCode()I

    move-result v2

    .line 4060
    invoke-static {v5}, Lcom/appsflyer/AppsFlyerLib;->ॱ(Ljava/net/HttpURLConnection;)Ljava/lang/String;

    move-result-object v1

    .line 4062
    const/16 v3, 0xc8

    if-ne v2, v3, :cond_0

    .line 4063
    const-string v2, "Status 200 ok"

    invoke-static {v2}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    .line 4071
    :goto_0
    invoke-static {v0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v2

    if-eqz v2, :cond_1

    .line 4072
    const-string v0, "Connection call succeeded: "

    invoke-static {v1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v2}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 4073
    invoke-virtual {p0, v1}, Lcom/appsflyer/OneLinkHttpTask;->ˎ(Ljava/lang/String;)V

    :goto_1
    return-void

    .line 4065
    :cond_0
    :try_start_1
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v3, "Response code = "

    invoke-direct {v0, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v2, " content = "

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;
    :try_end_1
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_0

    move-result-object v0

    goto :goto_0

    .line 4067
    :catch_0
    move-exception v0

    .line 4068
    const-string v2, "Error while calling "

    invoke-static {v4}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v2, v0}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    .line 4069
    new-instance v2, Ljava/lang/StringBuilder;

    const-string v3, "Error while calling "

    invoke-direct {v2, v3}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v2, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, " stacktrace: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    goto :goto_0

    .line 4075
    :cond_1
    const-string v1, "Connection error: "

    invoke-static {v0}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v1, v0}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afWarnLog(Ljava/lang/String;)V

    .line 4076
    invoke-virtual {p0}, Lcom/appsflyer/OneLinkHttpTask;->ॱ()V

    goto :goto_1
.end method

.method public setConnProvider(Lcom/appsflyer/OneLinkHttpTask$HttpsUrlConnectionProvider;)V
    .locals 0

    .prologue
    .line 32
    iput-object p1, p0, Lcom/appsflyer/OneLinkHttpTask;->ˋ:Lcom/appsflyer/OneLinkHttpTask$HttpsUrlConnectionProvider;

    .line 33
    return-void
.end method

.method abstract ˊ()Ljava/lang/String;
.end method

.method abstract ˎ(Ljava/lang/String;)V
.end method

.method abstract ˎ(Ljavax/net/ssl/HttpsURLConnection;)V
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lorg/json/JSONException;,
            Ljava/io/IOException;
        }
    .end annotation
.end method

.method abstract ॱ()V
.end method
