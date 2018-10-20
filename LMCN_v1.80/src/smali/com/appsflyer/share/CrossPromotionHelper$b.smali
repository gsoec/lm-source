.class final Lcom/appsflyer/share/CrossPromotionHelper$b;
.super Landroid/os/AsyncTask;
.source ""


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/appsflyer/share/CrossPromotionHelper;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x8
    name = "b"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Landroid/os/AsyncTask",
        "<",
        "Ljava/lang/String;",
        "Ljava/lang/Void;",
        "Ljava/lang/Void;",
        ">;"
    }
.end annotation


# instance fields
.field private ˊ:Z

.field private ˏ:Lcom/appsflyer/share/d;

.field private ॱ:Ljava/lang/ref/WeakReference;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/lang/ref/WeakReference",
            "<",
            "Landroid/content/Context;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method constructor <init>(Lcom/appsflyer/share/d;Landroid/content/Context;Z)V
    .locals 1

    .prologue
    .line 105
    invoke-direct {p0}, Landroid/os/AsyncTask;-><init>()V

    .line 106
    iput-object p1, p0, Lcom/appsflyer/share/CrossPromotionHelper$b;->ˏ:Lcom/appsflyer/share/d;

    .line 107
    new-instance v0, Ljava/lang/ref/WeakReference;

    invoke-direct {v0, p2}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    iput-object v0, p0, Lcom/appsflyer/share/CrossPromotionHelper$b;->ॱ:Ljava/lang/ref/WeakReference;

    .line 108
    iput-boolean p3, p0, Lcom/appsflyer/share/CrossPromotionHelper$b;->ˊ:Z

    .line 109
    return-void
.end method

.method private varargs ˋ([Ljava/lang/String;)Ljava/lang/Void;
    .locals 7

    .prologue
    const/4 v2, 0x0

    .line 113
    iget-boolean v0, p0, Lcom/appsflyer/share/CrossPromotionHelper$b;->ˊ:Z

    if-eqz v0, :cond_1

    .line 145
    :cond_0
    :goto_0
    return-object v2

    .line 118
    :cond_1
    const/4 v0, 0x0

    :try_start_0
    aget-object v1, p1, v0

    .line 119
    new-instance v0, Ljava/net/URL;

    invoke-direct {v0, v1}, Ljava/net/URL;-><init>(Ljava/lang/String;)V

    .line 120
    invoke-virtual {v0}, Ljava/net/URL;->openConnection()Ljava/net/URLConnection;

    move-result-object v0

    check-cast v0, Ljava/net/HttpURLConnection;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_1
    .catchall {:try_start_0 .. :try_end_0} :catchall_1

    .line 121
    const/16 v3, 0x2710

    :try_start_1
    invoke-virtual {v0, v3}, Ljava/net/URLConnection;->setConnectTimeout(I)V

    .line 122
    const/4 v3, 0x0

    invoke-virtual {v0, v3}, Ljava/net/HttpURLConnection;->setInstanceFollowRedirects(Z)V

    .line 123
    invoke-virtual {v0}, Ljava/net/HttpURLConnection;->getResponseCode()I

    move-result v3

    .line 124
    const/16 v4, 0xc8

    if-ne v3, v4, :cond_3

    .line 125
    const-string v3, "Cross promotion impressions success: "

    invoke-static {v1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v3, v1}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const/4 v3, 0x0

    invoke-static {v1, v3}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;Z)V
    :try_end_1
    .catch Ljava/lang/Throwable; {:try_start_1 .. :try_end_1} :catch_0
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    .line 140
    :cond_2
    :goto_1
    if-eqz v0, :cond_0

    .line 141
    invoke-virtual {v0}, Ljava/net/HttpURLConnection;->disconnect()V

    goto :goto_0

    .line 126
    :cond_3
    const/16 v4, 0x12d

    if-eq v3, v4, :cond_4

    const/16 v4, 0x12e

    if-ne v3, v4, :cond_5

    .line 128
    :cond_4
    :try_start_2
    const-string v3, "Cross promotion redirection success: "

    invoke-static {v1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v3, v1}, Ljava/lang/String;->concat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const/4 v3, 0x0

    invoke-static {v1, v3}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;Z)V

    .line 129
    iget-object v1, p0, Lcom/appsflyer/share/CrossPromotionHelper$b;->ˏ:Lcom/appsflyer/share/d;

    if-eqz v1, :cond_2

    iget-object v1, p0, Lcom/appsflyer/share/CrossPromotionHelper$b;->ॱ:Ljava/lang/ref/WeakReference;

    invoke-virtual {v1}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v1

    if-eqz v1, :cond_2

    .line 130
    const-string v1, "Location"

    invoke-virtual {v0, v1}, Ljava/net/URLConnection;->getHeaderField(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    .line 131
    iget-object v3, p0, Lcom/appsflyer/share/CrossPromotionHelper$b;->ˏ:Lcom/appsflyer/share/d;

    invoke-virtual {v3, v1}, Lcom/appsflyer/share/d;->ˎ(Ljava/lang/String;)V

    .line 132
    iget-object v3, p0, Lcom/appsflyer/share/CrossPromotionHelper$b;->ˏ:Lcom/appsflyer/share/d;

    iget-object v1, p0, Lcom/appsflyer/share/CrossPromotionHelper$b;->ॱ:Ljava/lang/ref/WeakReference;

    invoke-virtual {v1}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Landroid/content/Context;

    invoke-virtual {v3, v1}, Lcom/appsflyer/share/d;->ˏ(Landroid/content/Context;)V
    :try_end_2
    .catch Ljava/lang/Throwable; {:try_start_2 .. :try_end_2} :catch_0
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    goto :goto_1

    .line 137
    :catch_0
    move-exception v1

    move-object v6, v1

    move-object v1, v0

    move-object v0, v6

    .line 138
    :goto_2
    :try_start_3
    invoke-virtual {v0}, Ljava/lang/Throwable;->getMessage()Ljava/lang/String;

    move-result-object v3

    const/4 v4, 0x1

    invoke-static {v3, v0, v4}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;Z)V
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_2

    .line 140
    if-eqz v1, :cond_0

    .line 141
    invoke-virtual {v1}, Ljava/net/HttpURLConnection;->disconnect()V

    goto :goto_0

    .line 135
    :cond_5
    :try_start_4
    new-instance v4, Ljava/lang/StringBuilder;

    const-string v5, "call to "

    invoke-direct {v4, v5}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v4, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v4, " failed: "

    invoke-virtual {v1, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V
    :try_end_4
    .catch Ljava/lang/Throwable; {:try_start_4 .. :try_end_4} :catch_0
    .catchall {:try_start_4 .. :try_end_4} :catchall_0

    goto :goto_1

    .line 140
    :catchall_0
    move-exception v1

    move-object v2, v0

    move-object v0, v1

    :goto_3
    if-eqz v2, :cond_6

    .line 141
    invoke-virtual {v2}, Ljava/net/HttpURLConnection;->disconnect()V

    :cond_6
    throw v0

    .line 140
    :catchall_1
    move-exception v0

    goto :goto_3

    :catchall_2
    move-exception v0

    move-object v2, v1

    goto :goto_3

    .line 137
    :catch_1
    move-exception v0

    move-object v1, v2

    goto :goto_2
.end method


# virtual methods
.method protected final synthetic doInBackground([Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    .prologue
    .line 99
    check-cast p1, [Ljava/lang/String;

    invoke-direct {p0, p1}, Lcom/appsflyer/share/CrossPromotionHelper$b;->ˋ([Ljava/lang/String;)Ljava/lang/Void;

    move-result-object v0

    return-object v0
.end method
