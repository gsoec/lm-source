.class final Lcom/appsflyer/u$a;
.super Landroid/os/AsyncTask;
.source ""


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/appsflyer/u;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x8
    name = "a"
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Landroid/os/AsyncTask",
        "<",
        "Ljava/lang/Void;",
        "Ljava/lang/Void;",
        "Ljava/lang/String;",
        ">;"
    }
.end annotation


# instance fields
.field private final ˊ:Ljava/lang/ref/WeakReference;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/lang/ref/WeakReference",
            "<",
            "Landroid/content/Context;",
            ">;"
        }
    .end annotation
.end field

.field private ॱ:Ljava/lang/String;


# direct methods
.method constructor <init>(Ljava/lang/ref/WeakReference;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/ref/WeakReference",
            "<",
            "Landroid/content/Context;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 140
    invoke-direct {p0}, Landroid/os/AsyncTask;-><init>()V

    .line 141
    iput-object p1, p0, Lcom/appsflyer/u$a;->ˊ:Ljava/lang/ref/WeakReference;

    .line 142
    return-void
.end method

.method private varargs ˏ()Ljava/lang/String;
    .locals 3

    .prologue
    const/4 v0, 0x0

    .line 153
    .line 154
    :try_start_0
    iget-object v1, p0, Lcom/appsflyer/u$a;->ॱ:Ljava/lang/String;

    if-eqz v1, :cond_0

    .line 155
    iget-object v1, p0, Lcom/appsflyer/u$a;->ˊ:Ljava/lang/ref/WeakReference;

    iget-object v2, p0, Lcom/appsflyer/u$a;->ॱ:Ljava/lang/String;

    invoke-static {v1, v2}, Lcom/appsflyer/u;->ˋ(Ljava/lang/ref/WeakReference;Ljava/lang/String;)Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v0

    .line 161
    :cond_0
    :goto_0
    return-object v0

    .line 158
    :catch_0
    move-exception v1

    .line 159
    const-string v2, "Error registering for uninstall feature"

    invoke-static {v2, v1}, Lcom/appsflyer/AFLogger;->afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V

    goto :goto_0
.end method


# virtual methods
.method protected final synthetic doInBackground([Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    .prologue
    .line 136
    invoke-direct {p0}, Lcom/appsflyer/u$a;->ˏ()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method protected final synthetic onPostExecute(Ljava/lang/Object;)V
    .locals 3

    .prologue
    .line 136
    check-cast p1, Ljava/lang/String;

    .line 3166
    invoke-static {p1}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-nez v0, :cond_0

    .line 3168
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "afUninstallToken"

    invoke-virtual {v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 3169
    new-instance v1, Lcom/appsflyer/b;

    invoke-direct {v1, p1}, Lcom/appsflyer/b;-><init>(Ljava/lang/String;)V

    .line 3170
    if-nez v0, :cond_1

    .line 3171
    iget-object v0, p0, Lcom/appsflyer/u$a;->ˊ:Ljava/lang/ref/WeakReference;

    invoke-virtual {v0}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;

    invoke-static {v0, v1}, Lcom/appsflyer/u;->ˋ(Landroid/content/Context;Lcom/appsflyer/b;)V

    :cond_0
    :goto_0
    return-void

    .line 3173
    :cond_1
    invoke-static {v0}, Lcom/appsflyer/b;->ˏ(Ljava/lang/String;)Lcom/appsflyer/b;

    move-result-object v2

    .line 3176
    invoke-virtual {v2, v1}, Lcom/appsflyer/b;->ˎ(Lcom/appsflyer/b;)Z

    move-result v0

    .line 3177
    if-eqz v0, :cond_0

    .line 3178
    iget-object v0, p0, Lcom/appsflyer/u$a;->ˊ:Ljava/lang/ref/WeakReference;

    invoke-virtual {v0}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;

    invoke-static {v0, v2}, Lcom/appsflyer/u;->ˋ(Landroid/content/Context;Lcom/appsflyer/b;)V

    goto :goto_0
.end method

.method protected final onPreExecute()V
    .locals 2

    .prologue
    .line 146
    invoke-super {p0}, Landroid/os/AsyncTask;->onPreExecute()V

    .line 147
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "gcmProjectNumber"

    invoke-virtual {v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/appsflyer/u$a;->ॱ:Ljava/lang/String;

    .line 148
    return-void
.end method
