.class final Lcom/appsflyer/j$1;
.super Ljava/lang/Object;
.source ""

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/appsflyer/j;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# static fields
.field private static ˎ:Ljava/lang/String;

.field private static ˏ:Ljava/lang/String;


# instance fields
.field private synthetic ॱ:Lcom/appsflyer/j;


# direct methods
.method constructor <init>()V
    .locals 0

    .prologue
    .line 3006
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method constructor <init>(Lcom/appsflyer/j;)V
    .locals 0

    .prologue
    .line 43
    iput-object p1, p0, Lcom/appsflyer/j$1;->ॱ:Lcom/appsflyer/j;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method static ˋ(Ljava/lang/String;)V
    .locals 3

    .prologue
    .line 3029
    sput-object p0, Lcom/appsflyer/j$1;->ˎ:Ljava/lang/String;

    .line 3031
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    .line 3033
    const/4 v0, 0x0

    :goto_0
    invoke-virtual {p0}, Ljava/lang/String;->length()I

    move-result v2

    if-ge v0, v2, :cond_2

    .line 3034
    if-eqz v0, :cond_0

    invoke-virtual {p0}, Ljava/lang/String;->length()I

    move-result v2

    add-int/lit8 v2, v2, -0x1

    if-ne v0, v2, :cond_1

    .line 3035
    :cond_0
    invoke-virtual {p0, v0}, Ljava/lang/String;->charAt(I)C

    move-result v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 3033
    :goto_1
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 3038
    :cond_1
    const-string v2, "*"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    goto :goto_1

    .line 3041
    :cond_2
    invoke-virtual {v1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/appsflyer/j$1;->ˏ:Ljava/lang/String;

    .line 3042
    return-void
.end method

.method static ˏ(Ljava/lang/String;)V
    .locals 2

    .prologue
    .line 3046
    sget-object v0, Lcom/appsflyer/j$1;->ˎ:Ljava/lang/String;

    if-nez v0, :cond_0

    .line 3047
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    const-string v1, "AppsFlyerKey"

    invoke-virtual {v0, v1}, Lcom/appsflyer/AppsFlyerProperties;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/j$1;->ˋ(Ljava/lang/String;)V

    .line 3050
    :cond_0
    sget-object v0, Lcom/appsflyer/j$1;->ˎ:Ljava/lang/String;

    if-eqz v0, :cond_1

    sget-object v0, Lcom/appsflyer/j$1;->ˎ:Ljava/lang/String;

    invoke-virtual {p0, v0}, Ljava/lang/String;->contains(Ljava/lang/CharSequence;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 3051
    sget-object v0, Lcom/appsflyer/j$1;->ˎ:Ljava/lang/String;

    sget-object v1, Lcom/appsflyer/j$1;->ˏ:Ljava/lang/String;

    invoke-virtual {p0, v0, v1}, Ljava/lang/String;->replace(Ljava/lang/CharSequence;Ljava/lang/CharSequence;)Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;)V

    .line 3054
    :cond_1
    return-void
.end method


# virtual methods
.method public final run()V
    .locals 6

    .prologue
    .line 46
    iget-object v0, p0, Lcom/appsflyer/j$1;->ॱ:Lcom/appsflyer/j;

    iget-object v1, v0, Lcom/appsflyer/j;->ˊ:Ljava/lang/Object;

    monitor-enter v1

    .line 47
    :try_start_0
    iget-object v0, p0, Lcom/appsflyer/j$1;->ॱ:Lcom/appsflyer/j;

    invoke-virtual {v0}, Lcom/appsflyer/j;->ॱ()V

    .line 48
    iget-object v0, p0, Lcom/appsflyer/j$1;->ॱ:Lcom/appsflyer/j;

    iget-object v0, v0, Lcom/appsflyer/j;->ˋ:Landroid/os/Handler;

    iget-object v2, p0, Lcom/appsflyer/j$1;->ॱ:Lcom/appsflyer/j;

    iget-object v2, v2, Lcom/appsflyer/j;->ˏ:Ljava/lang/Runnable;

    const-wide/32 v4, 0x1b7740

    invoke-virtual {v0, v2, v4, v5}, Landroid/os/Handler;->postDelayed(Ljava/lang/Runnable;J)Z

    .line 49
    monitor-exit v1
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    return-void

    :catchall_0
    move-exception v0

    monitor-exit v1

    throw v0
.end method
