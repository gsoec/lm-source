.class final Lcom/appsflyer/b;
.super Ljava/lang/Object;
.source ""


# instance fields
.field private final ˊ:Ljava/lang/Object;

.field private ˋ:J

.field private ॱ:Ljava/lang/String;


# direct methods
.method constructor <init>()V
    .locals 0

    .prologue
    .line 12
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method constructor <init>(JLjava/lang/String;)V
    .locals 3

    .prologue
    .line 5015
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 5011
    new-instance v0, Ljava/lang/Object;

    invoke-direct {v0}, Ljava/lang/Object;-><init>()V

    iput-object v0, p0, Lcom/appsflyer/b;->ˊ:Ljava/lang/Object;

    .line 5012
    const-wide/16 v0, 0x0

    iput-wide v0, p0, Lcom/appsflyer/b;->ˋ:J

    .line 5013
    const-string v0, ""

    iput-object v0, p0, Lcom/appsflyer/b;->ॱ:Ljava/lang/String;

    .line 5016
    iput-wide p1, p0, Lcom/appsflyer/b;->ˋ:J

    .line 5017
    iput-object p3, p0, Lcom/appsflyer/b;->ॱ:Ljava/lang/String;

    .line 5018
    return-void
.end method

.method constructor <init>(Ljava/lang/String;)V
    .locals 2

    .prologue
    .line 5021
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    invoke-direct {p0, v0, v1, p1}, Lcom/appsflyer/b;-><init>(JLjava/lang/String;)V

    .line 5022
    return-void
.end method

.method private ˋ(JLjava/lang/String;)Z
    .locals 9

    .prologue
    const/4 v0, 0x1

    const/4 v1, 0x0

    .line 11051
    iget-object v3, p0, Lcom/appsflyer/b;->ˊ:Ljava/lang/Object;

    monitor-enter v3

    .line 11052
    if-eqz p3, :cond_1

    :try_start_0
    iget-object v2, p0, Lcom/appsflyer/b;->ॱ:Ljava/lang/String;

    invoke-virtual {p3, v2}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-nez v2, :cond_1

    .line 11062
    iget-wide v4, p0, Lcom/appsflyer/b;->ˋ:J

    sub-long v4, p1, v4

    const-wide/16 v6, 0x7d0

    cmp-long v2, v4, v6

    if-lez v2, :cond_0

    move v2, v0

    .line 12052
    :goto_0
    if-eqz v2, :cond_1

    .line 12053
    iput-wide p1, p0, Lcom/appsflyer/b;->ˋ:J

    .line 12054
    iput-object p3, p0, Lcom/appsflyer/b;->ॱ:Ljava/lang/String;

    .line 12055
    monitor-exit v3
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 12057
    :goto_1
    return v0

    :cond_0
    move v2, v1

    .line 11062
    goto :goto_0

    .line 12057
    :cond_1
    monitor-exit v3

    move v0, v1

    goto :goto_1

    .line 12058
    :catchall_0
    move-exception v0

    monitor-exit v3

    throw v0
.end method

.method static ˏ(Ljava/lang/String;)Lcom/appsflyer/b;
    .locals 6
    .annotation build Landroid/support/annotation/NonNull;
    .end annotation

    .prologue
    const-wide/16 v4, 0x0

    .line 5026
    if-nez p0, :cond_0

    .line 5037
    new-instance v0, Lcom/appsflyer/b;

    const-string v1, ""

    invoke-direct {v0, v4, v5, v1}, Lcom/appsflyer/b;-><init>(JLjava/lang/String;)V

    .line 7033
    :goto_0
    return-object v0

    .line 6029
    :cond_0
    const-string v0, ","

    invoke-virtual {p0, v0}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v1

    .line 6030
    array-length v0, v1

    const/4 v2, 0x2

    if-ge v0, v2, :cond_1

    .line 7037
    new-instance v0, Lcom/appsflyer/b;

    const-string v1, ""

    invoke-direct {v0, v4, v5, v1}, Lcom/appsflyer/b;-><init>(JLjava/lang/String;)V

    goto :goto_0

    .line 7033
    :cond_1
    new-instance v0, Lcom/appsflyer/b;

    const/4 v2, 0x0

    aget-object v2, v1, v2

    invoke-static {v2}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v2

    const/4 v4, 0x1

    aget-object v1, v1, v4

    invoke-direct {v0, v2, v3, v1}, Lcom/appsflyer/b;-><init>(JLjava/lang/String;)V

    goto :goto_0
.end method

.method static ˏ(Landroid/content/Context;)V
    .locals 3

    .prologue
    .line 23
    invoke-virtual {p0}, Landroid/content/Context;->getApplicationContext()Landroid/content/Context;

    move-result-object v0

    .line 24
    const-string v1, "onBecameBackground"

    invoke-static {v1}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 25
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v1

    invoke-virtual {v1}, Lcom/appsflyer/AppsFlyerLib;->ˎ()V

    .line 26
    const-string v1, "callStatsBackground background call"

    invoke-static {v1}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 27
    new-instance v1, Ljava/lang/ref/WeakReference;

    invoke-direct {v1, v0}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    .line 28
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->getInstance()Lcom/appsflyer/AppsFlyerLib;

    move-result-object v2

    invoke-virtual {v2, v1}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Ljava/lang/ref/WeakReference;)V

    .line 29
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v1

    .line 30
    invoke-virtual {v1}, Lcom/appsflyer/w;->ʻ()Z

    move-result v2

    if-eqz v2, :cond_1

    .line 31
    invoke-virtual {v1}, Lcom/appsflyer/w;->ˏ()V

    .line 32
    if-eqz v0, :cond_0

    .line 33
    invoke-virtual {v0}, Landroid/content/Context;->getPackageName()Ljava/lang/String;

    move-result-object v2

    .line 34
    invoke-virtual {v0}, Landroid/content/Context;->getPackageManager()Landroid/content/pm/PackageManager;

    move-result-object v0

    .line 35
    invoke-static {v2, v0}, Lcom/appsflyer/w;->ˊ(Ljava/lang/String;Landroid/content/pm/PackageManager;)V

    .line 37
    :cond_0
    invoke-virtual {v1}, Lcom/appsflyer/w;->ˋ()V

    .line 42
    :goto_0
    invoke-static {}, Lcom/appsflyer/AFExecutor;->getInstance()Lcom/appsflyer/AFExecutor;

    move-result-object v0

    invoke-virtual {v0}, Lcom/appsflyer/AFExecutor;->ˎ()V

    .line 43
    return-void

    .line 39
    :cond_1
    const-string v0, "RD status is OFF"

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afDebugLog(Ljava/lang/String;)V

    goto :goto_0
.end method


# virtual methods
.method public final toString()Ljava/lang/String;
    .locals 4

    .prologue
    .line 12067
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    iget-wide v2, p0, Lcom/appsflyer/b;->ˋ:J

    invoke-virtual {v0, v2, v3}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, ","

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v1, p0, Lcom/appsflyer/b;->ॱ:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method final ˎ()Ljava/lang/String;
    .locals 1

    .prologue
    .line 12075
    iget-object v0, p0, Lcom/appsflyer/b;->ॱ:Ljava/lang/String;

    return-object v0
.end method

.method final ˎ(Lcom/appsflyer/b;)Z
    .locals 3

    .prologue
    .line 8042
    .line 8071
    iget-wide v0, p1, Lcom/appsflyer/b;->ˋ:J

    .line 9075
    iget-object v2, p1, Lcom/appsflyer/b;->ॱ:Ljava/lang/String;

    .line 10042
    invoke-direct {p0, v0, v1, v2}, Lcom/appsflyer/b;->ˋ(JLjava/lang/String;)Z

    move-result v0

    return v0
.end method
