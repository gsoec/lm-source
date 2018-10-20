.class public Lcom/appsflyer/AFLogger;
.super Ljava/lang/Object;
.source ""


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/appsflyer/AFLogger$LogLevel;
    }
.end annotation


# static fields
.field private static ˊ:J


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .prologue
    .line 18
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    sput-wide v0, Lcom/appsflyer/AFLogger;->ˊ:J

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .prologue
    .line 14
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static afDebugLog(Ljava/lang/String;)V
    .locals 6

    .prologue
    const/4 v1, 0x1

    const/4 v2, 0x0

    .line 25066
    sget-object v0, Lcom/appsflyer/AFLogger$LogLevel;->DEBUG:Lcom/appsflyer/AFLogger$LogLevel;

    .line 25102
    invoke-virtual {v0}, Lcom/appsflyer/AFLogger$LogLevel;->getLevel()I

    move-result v0

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    .line 25150
    const-string v4, "logLevel"

    sget-object v5, Lcom/appsflyer/AFLogger$LogLevel;->NONE:Lcom/appsflyer/AFLogger$LogLevel;

    invoke-virtual {v5}, Lcom/appsflyer/AFLogger$LogLevel;->getLevel()I

    move-result v5

    invoke-virtual {v3, v4, v5}, Lcom/appsflyer/AppsFlyerProperties;->getInt(Ljava/lang/String;I)I

    move-result v3

    .line 26102
    if-gt v0, v3, :cond_1

    move v0, v1

    .line 27066
    :goto_0
    if-eqz v0, :cond_0

    .line 27067
    const-string v0, "AppsFlyer_4.8.14"

    .line 29050
    invoke-static {p0, v2}, Lcom/appsflyer/AFLogger;->ˎ(Ljava/lang/String;Z)Ljava/lang/String;

    move-result-object v2

    .line 28067
    invoke-static {v0, v2}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 28070
    :cond_0
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v2, "D"

    invoke-static {p0, v1}, Lcom/appsflyer/AFLogger;->ˎ(Ljava/lang/String;Z)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v2, v1}, Lcom/appsflyer/w;->ॱ(Ljava/lang/String;Ljava/lang/String;)V

    .line 118
    return-void

    :cond_1
    move v0, v2

    .line 26102
    goto :goto_0
.end method

.method public static afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;)V
    .locals 1

    .prologue
    .line 125
    const/4 v0, 0x0

    invoke-static {p0, p1, v0}, Lcom/appsflyer/AFLogger;->ˏ(Ljava/lang/String;Ljava/lang/Throwable;Z)V

    .line 126
    return-void
.end method

.method public static afErrorLog(Ljava/lang/String;Ljava/lang/Throwable;Z)V
    .locals 0

    .prologue
    .line 129
    invoke-static {p0, p1, p2}, Lcom/appsflyer/AFLogger;->ˏ(Ljava/lang/String;Ljava/lang/Throwable;Z)V

    .line 130
    return-void
.end method

.method public static afInfoLog(Ljava/lang/String;)V
    .locals 1

    .prologue
    .line 121
    const/4 v0, 0x1

    invoke-static {p0, v0}, Lcom/appsflyer/AFLogger;->afInfoLog(Ljava/lang/String;Z)V

    .line 122
    return-void
.end method

.method public static afInfoLog(Ljava/lang/String;Z)V
    .locals 6

    .prologue
    const/4 v1, 0x1

    const/4 v2, 0x0

    .line 36
    sget-object v0, Lcom/appsflyer/AFLogger$LogLevel;->INFO:Lcom/appsflyer/AFLogger$LogLevel;

    .line 9102
    invoke-virtual {v0}, Lcom/appsflyer/AFLogger$LogLevel;->getLevel()I

    move-result v0

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    .line 9150
    const-string v4, "logLevel"

    sget-object v5, Lcom/appsflyer/AFLogger$LogLevel;->NONE:Lcom/appsflyer/AFLogger$LogLevel;

    invoke-virtual {v5}, Lcom/appsflyer/AFLogger$LogLevel;->getLevel()I

    move-result v5

    invoke-virtual {v3, v4, v5}, Lcom/appsflyer/AppsFlyerProperties;->getInt(Ljava/lang/String;I)I

    move-result v3

    .line 10102
    if-gt v0, v3, :cond_2

    move v0, v1

    .line 36
    :goto_0
    if-eqz v0, :cond_0

    .line 37
    const-string v0, "AppsFlyer_4.8.14"

    .line 12050
    invoke-static {p0, v2}, Lcom/appsflyer/AFLogger;->ˎ(Ljava/lang/String;Z)Ljava/lang/String;

    move-result-object v2

    .line 37
    invoke-static {v0, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 39
    :cond_0
    if-eqz p1, :cond_1

    .line 40
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v2, "I"

    invoke-static {p0, v1}, Lcom/appsflyer/AFLogger;->ˎ(Ljava/lang/String;Z)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v2, v1}, Lcom/appsflyer/w;->ॱ(Ljava/lang/String;Ljava/lang/String;)V

    .line 42
    :cond_1
    return-void

    :cond_2
    move v0, v2

    .line 10102
    goto :goto_0
.end method

.method public static afRDLog(Ljava/lang/String;)V
    .locals 6

    .prologue
    const/4 v1, 0x1

    const/4 v2, 0x0

    .line 94
    sget-object v0, Lcom/appsflyer/AFLogger$LogLevel;->VERBOSE:Lcom/appsflyer/AFLogger$LogLevel;

    .line 20102
    invoke-virtual {v0}, Lcom/appsflyer/AFLogger$LogLevel;->getLevel()I

    move-result v0

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    .line 20150
    const-string v4, "logLevel"

    sget-object v5, Lcom/appsflyer/AFLogger$LogLevel;->NONE:Lcom/appsflyer/AFLogger$LogLevel;

    invoke-virtual {v5}, Lcom/appsflyer/AFLogger$LogLevel;->getLevel()I

    move-result v5

    invoke-virtual {v3, v4, v5}, Lcom/appsflyer/AppsFlyerProperties;->getInt(Ljava/lang/String;I)I

    move-result v3

    .line 21102
    if-gt v0, v3, :cond_1

    move v0, v1

    .line 94
    :goto_0
    if-eqz v0, :cond_0

    .line 95
    const-string v0, "AppsFlyer_4.8.14"

    .line 23050
    invoke-static {p0, v2}, Lcom/appsflyer/AFLogger;->ˎ(Ljava/lang/String;Z)Ljava/lang/String;

    move-result-object v2

    .line 95
    invoke-static {v0, v2}, Landroid/util/Log;->v(Ljava/lang/String;Ljava/lang/String;)I

    .line 98
    :cond_0
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v2, "V"

    invoke-static {p0, v1}, Lcom/appsflyer/AFLogger;->ˎ(Ljava/lang/String;Z)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v2, v1}, Lcom/appsflyer/w;->ॱ(Ljava/lang/String;Ljava/lang/String;)V

    .line 99
    return-void

    :cond_1
    move v0, v2

    .line 21102
    goto :goto_0
.end method

.method public static afWarnLog(Ljava/lang/String;)V
    .locals 0

    .prologue
    .line 133
    invoke-static {p0}, Lcom/appsflyer/AFLogger;->ˋ(Ljava/lang/String;)V

    .line 134
    return-void
.end method

.method public static resetDeltaTime()V
    .locals 2

    .prologue
    .line 45
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v0

    sput-wide v0, Lcom/appsflyer/AFLogger;->ˊ:J

    .line 46
    return-void
.end method

.method static ˋ(Ljava/lang/String;)V
    .locals 6

    .prologue
    const/4 v1, 0x1

    const/4 v2, 0x0

    .line 85
    sget-object v0, Lcom/appsflyer/AFLogger$LogLevel;->WARNING:Lcom/appsflyer/AFLogger$LogLevel;

    .line 17102
    invoke-virtual {v0}, Lcom/appsflyer/AFLogger$LogLevel;->getLevel()I

    move-result v0

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v3

    .line 17150
    const-string v4, "logLevel"

    sget-object v5, Lcom/appsflyer/AFLogger$LogLevel;->NONE:Lcom/appsflyer/AFLogger$LogLevel;

    invoke-virtual {v5}, Lcom/appsflyer/AFLogger$LogLevel;->getLevel()I

    move-result v5

    invoke-virtual {v3, v4, v5}, Lcom/appsflyer/AppsFlyerProperties;->getInt(Ljava/lang/String;I)I

    move-result v3

    .line 18102
    if-gt v0, v3, :cond_1

    move v0, v1

    .line 85
    :goto_0
    if-eqz v0, :cond_0

    .line 86
    const-string v0, "AppsFlyer_4.8.14"

    .line 20050
    invoke-static {p0, v2}, Lcom/appsflyer/AFLogger;->ˎ(Ljava/lang/String;Z)Ljava/lang/String;

    move-result-object v2

    .line 86
    invoke-static {v0, v2}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 89
    :cond_0
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v2, "W"

    invoke-static {p0, v1}, Lcom/appsflyer/AFLogger;->ˎ(Ljava/lang/String;Z)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v2, v1}, Lcom/appsflyer/w;->ॱ(Ljava/lang/String;Ljava/lang/String;)V

    .line 91
    return-void

    :cond_1
    move v0, v2

    .line 18102
    goto :goto_0
.end method

.method private static ˎ(Ljava/lang/String;Z)Ljava/lang/String;
    .locals 6
    .annotation build Landroid/support/annotation/NonNull;
    .end annotation

    .prologue
    .line 56
    if-nez p1, :cond_0

    sget-object v0, Lcom/appsflyer/AFLogger$LogLevel;->VERBOSE:Lcom/appsflyer/AFLogger$LogLevel;

    invoke-virtual {v0}, Lcom/appsflyer/AFLogger$LogLevel;->getLevel()I

    move-result v0

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v1

    .line 12150
    const-string v2, "logLevel"

    sget-object v3, Lcom/appsflyer/AFLogger$LogLevel;->NONE:Lcom/appsflyer/AFLogger$LogLevel;

    invoke-virtual {v3}, Lcom/appsflyer/AFLogger$LogLevel;->getLevel()I

    move-result v3

    invoke-virtual {v1, v2, v3}, Lcom/appsflyer/AppsFlyerProperties;->getInt(Ljava/lang/String;I)I

    move-result v1

    .line 56
    if-gt v0, v1, :cond_1

    .line 57
    :cond_0
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "("

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    sget-wide v4, Lcom/appsflyer/AFLogger;->ˊ:J

    sub-long/2addr v2, v4

    invoke-static {v2, v3}, Lcom/appsflyer/AFLogger;->ॱ(J)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, ") ["

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 58
    invoke-static {}, Ljava/lang/Thread;->currentThread()Ljava/lang/Thread;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Thread;->getName()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "] "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object p0

    .line 61
    :cond_1
    return-object p0
.end method

.method static ˎ(Ljava/lang/String;)V
    .locals 2

    .prologue
    .line 23113
    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v0

    invoke-virtual {v0}, Lcom/appsflyer/AppsFlyerProperties;->isLogsDisabledCompletely()Z

    move-result v0

    .line 106
    if-nez v0, :cond_0

    .line 107
    const-string v0, "AppsFlyer_4.8.14"

    .line 25050
    const/4 v1, 0x0

    invoke-static {p0, v1}, Lcom/appsflyer/AFLogger;->ˎ(Ljava/lang/String;Z)Ljava/lang/String;

    move-result-object v1

    .line 107
    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 109
    :cond_0
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    const-string v1, "F"

    invoke-virtual {v0, v1, p0}, Lcom/appsflyer/w;->ॱ(Ljava/lang/String;Ljava/lang/String;)V

    .line 110
    return-void
.end method

.method private static ˏ(Ljava/lang/String;Ljava/lang/Throwable;Z)V
    .locals 5

    .prologue
    const/4 v1, 0x0

    .line 76
    sget-object v0, Lcom/appsflyer/AFLogger$LogLevel;->ERROR:Lcom/appsflyer/AFLogger$LogLevel;

    .line 14102
    invoke-virtual {v0}, Lcom/appsflyer/AFLogger$LogLevel;->getLevel()I

    move-result v0

    invoke-static {}, Lcom/appsflyer/AppsFlyerProperties;->getInstance()Lcom/appsflyer/AppsFlyerProperties;

    move-result-object v2

    .line 14150
    const-string v3, "logLevel"

    sget-object v4, Lcom/appsflyer/AFLogger$LogLevel;->NONE:Lcom/appsflyer/AFLogger$LogLevel;

    invoke-virtual {v4}, Lcom/appsflyer/AFLogger$LogLevel;->getLevel()I

    move-result v4

    invoke-virtual {v2, v3, v4}, Lcom/appsflyer/AppsFlyerProperties;->getInt(Ljava/lang/String;I)I

    move-result v2

    .line 15102
    if-gt v0, v2, :cond_1

    const/4 v0, 0x1

    .line 76
    :goto_0
    if-eqz v0, :cond_0

    if-eqz p2, :cond_0

    .line 77
    const-string v0, "AppsFlyer_4.8.14"

    .line 17050
    invoke-static {p0, v1}, Lcom/appsflyer/AFLogger;->ˎ(Ljava/lang/String;Z)Ljava/lang/String;

    move-result-object v1

    .line 77
    invoke-static {v0, v1, p1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)I

    .line 80
    :cond_0
    invoke-static {}, Lcom/appsflyer/w;->ˎ()Lcom/appsflyer/w;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/appsflyer/w;->ˊ(Ljava/lang/Throwable;)V

    .line 82
    return-void

    :cond_1
    move v0, v1

    .line 15102
    goto :goto_0
.end method

.method private static ॱ(J)Ljava/lang/String;
    .locals 12

    .prologue
    .line 138
    sget-object v0, Ljava/util/concurrent/TimeUnit;->MILLISECONDS:Ljava/util/concurrent/TimeUnit;

    invoke-virtual {v0, p0, p1}, Ljava/util/concurrent/TimeUnit;->toHours(J)J

    move-result-wide v0

    .line 139
    sget-object v2, Ljava/util/concurrent/TimeUnit;->HOURS:Ljava/util/concurrent/TimeUnit;

    invoke-virtual {v2, v0, v1}, Ljava/util/concurrent/TimeUnit;->toMillis(J)J

    move-result-wide v2

    sub-long v2, p0, v2

    .line 140
    sget-object v4, Ljava/util/concurrent/TimeUnit;->MILLISECONDS:Ljava/util/concurrent/TimeUnit;

    invoke-virtual {v4, v2, v3}, Ljava/util/concurrent/TimeUnit;->toMinutes(J)J

    move-result-wide v4

    .line 141
    sget-object v6, Ljava/util/concurrent/TimeUnit;->MINUTES:Ljava/util/concurrent/TimeUnit;

    invoke-virtual {v6, v4, v5}, Ljava/util/concurrent/TimeUnit;->toMillis(J)J

    move-result-wide v6

    sub-long/2addr v2, v6

    .line 142
    sget-object v6, Ljava/util/concurrent/TimeUnit;->MILLISECONDS:Ljava/util/concurrent/TimeUnit;

    invoke-virtual {v6, v2, v3}, Ljava/util/concurrent/TimeUnit;->toSeconds(J)J

    move-result-wide v6

    .line 143
    sget-object v8, Ljava/util/concurrent/TimeUnit;->SECONDS:Ljava/util/concurrent/TimeUnit;

    invoke-virtual {v8, v6, v7}, Ljava/util/concurrent/TimeUnit;->toMillis(J)J

    move-result-wide v8

    sub-long/2addr v2, v8

    .line 144
    sget-object v8, Ljava/util/concurrent/TimeUnit;->MILLISECONDS:Ljava/util/concurrent/TimeUnit;

    invoke-virtual {v8, v2, v3}, Ljava/util/concurrent/TimeUnit;->toMillis(J)J

    move-result-wide v2

    .line 146
    invoke-static {}, Ljava/util/Locale;->getDefault()Ljava/util/Locale;

    move-result-object v8

    const-string v9, "%02d:%02d:%02d:%03d"

    const/4 v10, 0x4

    new-array v10, v10, [Ljava/lang/Object;

    const/4 v11, 0x0

    invoke-static {v0, v1}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v0

    aput-object v0, v10, v11

    const/4 v0, 0x1

    invoke-static {v4, v5}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    aput-object v1, v10, v0

    const/4 v0, 0x2

    invoke-static {v6, v7}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    aput-object v1, v10, v0

    const/4 v0, 0x3

    invoke-static {v2, v3}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v1

    aput-object v1, v10, v0

    invoke-static {v8, v9, v10}, Ljava/lang/String;->format(Ljava/util/Locale;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
