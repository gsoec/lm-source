.class public final Lcom/ta/utdid2/device/b;
.super Ljava/lang/Object;
.source "SourceFile"


# static fields
.field static a:Ljava/lang/String; = null

.field static final b:Ljava/lang/Object;

.field static final c:B = 0x1t

.field private static d:Lcom/ta/utdid2/device/a;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 12
    const/4 v0, 0x0

    sput-object v0, Lcom/ta/utdid2/device/b;->d:Lcom/ta/utdid2/device/a;

    .line 13
    const-string v0, "d6fc3a4a06adbde89223bvefedc24fecde188aaa9161"

    sput-object v0, Lcom/ta/utdid2/device/b;->a:Ljava/lang/String;

    .line 14
    new-instance v0, Ljava/lang/Object;

    invoke-direct {v0}, Ljava/lang/Object;-><init>()V

    sput-object v0, Lcom/ta/utdid2/device/b;->b:Ljava/lang/Object;

    .line 15
    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .prologue
    .line 10
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private static a(Lcom/ta/utdid2/device/a;)J
    .locals 6

    .prologue
    .line 25
    const-string v0, "%s%s%s%s%s"

    const/4 v1, 0x5

    new-array v1, v1, [Ljava/lang/Object;

    const/4 v2, 0x0

    .line 1059
    iget-object v3, p0, Lcom/ta/utdid2/device/a;->d:Ljava/lang/String;

    .line 26
    aput-object v3, v1, v2

    const/4 v2, 0x1

    .line 2051
    iget-object v3, p0, Lcom/ta/utdid2/device/a;->c:Ljava/lang/String;

    .line 26
    aput-object v3, v1, v2

    const/4 v2, 0x2

    .line 3027
    iget-wide v4, p0, Lcom/ta/utdid2/device/a;->e:J

    .line 27
    invoke-static {v4, v5}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v3

    aput-object v3, v1, v2

    const/4 v2, 0x3

    .line 3043
    iget-object v3, p0, Lcom/ta/utdid2/device/a;->b:Ljava/lang/String;

    .line 27
    aput-object v3, v1, v2

    const/4 v2, 0x4

    .line 4035
    iget-object v3, p0, Lcom/ta/utdid2/device/a;->a:Ljava/lang/String;

    .line 28
    aput-object v3, v1, v2

    .line 25
    invoke-static {v0, v1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    .line 29
    invoke-static {v0}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v1

    if-nez v1, :cond_0

    .line 30
    new-instance v1, Ljava/util/zip/Adler32;

    invoke-direct {v1}, Ljava/util/zip/Adler32;-><init>()V

    .line 31
    invoke-virtual {v1}, Ljava/util/zip/Adler32;->reset()V

    .line 32
    invoke-virtual {v0}, Ljava/lang/String;->getBytes()[B

    move-result-object v0

    invoke-virtual {v1, v0}, Ljava/util/zip/Adler32;->update([B)V

    .line 33
    invoke-virtual {v1}, Ljava/util/zip/Adler32;->getValue()J

    move-result-wide v0

    .line 37
    :goto_0
    return-wide v0

    :cond_0
    const-wide/16 v0, 0x0

    goto :goto_0
.end method

.method public static declared-synchronized a(Landroid/content/Context;)Lcom/ta/utdid2/device/a;
    .locals 2

    .prologue
    .line 80
    const-class v1, Lcom/ta/utdid2/device/b;

    monitor-enter v1

    :try_start_0
    sget-object v0, Lcom/ta/utdid2/device/b;->d:Lcom/ta/utdid2/device/a;

    if-eqz v0, :cond_0

    .line 81
    sget-object v0, Lcom/ta/utdid2/device/b;->d:Lcom/ta/utdid2/device/a;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 88
    :goto_0
    monitor-exit v1

    return-object v0

    .line 83
    :cond_0
    if-eqz p0, :cond_1

    .line 84
    :try_start_1
    invoke-static {p0}, Lcom/ta/utdid2/device/b;->b(Landroid/content/Context;)Lcom/ta/utdid2/device/a;

    move-result-object v0

    .line 85
    sput-object v0, Lcom/ta/utdid2/device/b;->d:Lcom/ta/utdid2/device/a;
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    goto :goto_0

    .line 80
    :catchall_0
    move-exception v0

    monitor-exit v1

    throw v0

    .line 88
    :cond_1
    const/4 v0, 0x0

    goto :goto_0
.end method

.method private static b(Landroid/content/Context;)Lcom/ta/utdid2/device/a;
    .locals 8

    .prologue
    .line 47
    if-eqz p0, :cond_2

    .line 48
    new-instance v0, Lcom/ta/utdid2/device/a;

    invoke-direct {v0}, Lcom/ta/utdid2/device/a;-><init>()V

    .line 49
    sget-object v4, Lcom/ta/utdid2/device/b;->b:Ljava/lang/Object;

    monitor-enter v4

    .line 50
    :try_start_0
    invoke-static {p0}, Lcom/ta/utdid2/device/d;->a(Landroid/content/Context;)Lcom/ta/utdid2/device/d;

    move-result-object v0

    invoke-virtual {v0}, Lcom/ta/utdid2/device/d;->a()Ljava/lang/String;

    move-result-object v0

    .line 51
    invoke-static {v0}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v1

    if-nez v1, :cond_1

    .line 53
    const-string v1, "\n"

    invoke-virtual {v0, v1}, Ljava/lang/String;->endsWith(Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_3

    .line 54
    const/4 v1, 0x0

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v2

    add-int/lit8 v2, v2, -0x1

    invoke-virtual {v0, v1, v2}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v0

    move-object v1, v0

    .line 56
    :goto_0
    new-instance v0, Lcom/ta/utdid2/device/a;

    invoke-direct {v0}, Lcom/ta/utdid2/device/a;-><init>()V

    .line 57
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v2

    .line 58
    invoke-static {p0}, Lcom/ta/utdid2/android/utils/g;->a(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v5

    .line 59
    invoke-static {p0}, Lcom/ta/utdid2/android/utils/g;->b(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v6

    .line 4055
    iput-object v5, v0, Lcom/ta/utdid2/device/a;->c:Ljava/lang/String;

    .line 5039
    iput-object v5, v0, Lcom/ta/utdid2/device/a;->a:Ljava/lang/String;

    .line 6031
    iput-wide v2, v0, Lcom/ta/utdid2/device/a;->e:J

    .line 6047
    iput-object v6, v0, Lcom/ta/utdid2/device/a;->b:Ljava/lang/String;

    .line 6063
    iput-object v1, v0, Lcom/ta/utdid2/device/a;->d:Ljava/lang/String;

    .line 7025
    const-string v1, "%s%s%s%s%s"

    const/4 v2, 0x5

    new-array v2, v2, [Ljava/lang/Object;

    const/4 v3, 0x0

    .line 7059
    iget-object v5, v0, Lcom/ta/utdid2/device/a;->d:Ljava/lang/String;

    .line 7026
    aput-object v5, v2, v3

    const/4 v3, 0x1

    .line 8051
    iget-object v5, v0, Lcom/ta/utdid2/device/a;->c:Ljava/lang/String;

    .line 7026
    aput-object v5, v2, v3

    const/4 v3, 0x2

    .line 9027
    iget-wide v6, v0, Lcom/ta/utdid2/device/a;->e:J

    .line 7027
    invoke-static {v6, v7}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v5

    aput-object v5, v2, v3

    const/4 v3, 0x3

    .line 9043
    iget-object v5, v0, Lcom/ta/utdid2/device/a;->b:Ljava/lang/String;

    .line 7027
    aput-object v5, v2, v3

    const/4 v3, 0x4

    .line 10035
    iget-object v5, v0, Lcom/ta/utdid2/device/a;->a:Ljava/lang/String;

    .line 7028
    aput-object v5, v2, v3

    .line 7025
    invoke-static {v1, v2}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v1

    .line 7029
    invoke-static {v1}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v2

    if-nez v2, :cond_0

    .line 7030
    new-instance v2, Ljava/util/zip/Adler32;

    invoke-direct {v2}, Ljava/util/zip/Adler32;-><init>()V

    .line 7031
    invoke-virtual {v2}, Ljava/util/zip/Adler32;->reset()V

    .line 7032
    invoke-virtual {v1}, Ljava/lang/String;->getBytes()[B

    move-result-object v1

    invoke-virtual {v2, v1}, Ljava/util/zip/Adler32;->update([B)V

    .line 7033
    invoke-virtual {v2}, Ljava/util/zip/Adler32;->getValue()J

    move-result-wide v2

    .line 11023
    :goto_1
    iput-wide v2, v0, Lcom/ta/utdid2/device/a;->f:J

    .line 66
    monitor-exit v4

    .line 70
    :goto_2
    return-object v0

    .line 7037
    :cond_0
    const-wide/16 v2, 0x0

    goto :goto_1

    .line 49
    :cond_1
    monitor-exit v4

    .line 70
    :cond_2
    const/4 v0, 0x0

    goto :goto_2

    .line 49
    :catchall_0
    move-exception v0

    monitor-exit v4
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    throw v0

    :cond_3
    move-object v1, v0

    goto :goto_0
.end method
