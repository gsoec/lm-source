.class public Lcom/ta/utdid2/aid/a;
.super Ljava/lang/Object;
.source "SourceFile"


# static fields
.field public static final a:Ljava/lang/String;

.field private static c:Lcom/ta/utdid2/aid/a; = null

.field private static final d:I = 0x1


# instance fields
.field public b:Landroid/content/Context;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 22
    const/4 v0, 0x0

    sput-object v0, Lcom/ta/utdid2/aid/a;->c:Lcom/ta/utdid2/aid/a;

    .line 23
    const-class v0, Lcom/ta/utdid2/aid/a;

    invoke-virtual {v0}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object v0

    sput-object v0, Lcom/ta/utdid2/aid/a;->a:Ljava/lang/String;

    .line 25
    return-void
.end method

.method private constructor <init>(Landroid/content/Context;)V
    .locals 0

    .prologue
    .line 37
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 38
    iput-object p1, p0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    .line 39
    return-void
.end method

.method public static declared-synchronized a(Landroid/content/Context;)Lcom/ta/utdid2/aid/a;
    .locals 2

    .prologue
    .line 30
    const-class v1, Lcom/ta/utdid2/aid/a;

    monitor-enter v1

    :try_start_0
    sget-object v0, Lcom/ta/utdid2/aid/a;->c:Lcom/ta/utdid2/aid/a;

    if-nez v0, :cond_0

    .line 31
    new-instance v0, Lcom/ta/utdid2/aid/a;

    invoke-direct {v0, p0}, Lcom/ta/utdid2/aid/a;-><init>(Landroid/content/Context;)V

    sput-object v0, Lcom/ta/utdid2/aid/a;->c:Lcom/ta/utdid2/aid/a;

    .line 34
    :cond_0
    sget-object v0, Lcom/ta/utdid2/aid/a;->c:Lcom/ta/utdid2/aid/a;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit v1

    return-object v0

    .line 30
    :catchall_0
    move-exception v0

    monitor-exit v1

    throw v0
.end method

.method private a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/ut/device/a;)V
    .locals 7

    .prologue
    const/4 v2, 0x1

    const/4 v1, 0x0

    .line 42
    if-nez p4, :cond_1

    .line 43
    sget-object v0, Lcom/ta/utdid2/aid/a;->a:Ljava/lang/String;

    const-string v1, "callback is null!"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 67
    :cond_0
    :goto_0
    return-void

    .line 45
    :cond_1
    iget-object v0, p0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    if-eqz v0, :cond_2

    invoke-static {p1}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_2

    invoke-static {p2}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_5

    .line 46
    :cond_2
    sget-object v3, Lcom/ta/utdid2/aid/a;->a:Ljava/lang/String;

    new-instance v0, Ljava/lang/StringBuilder;

    const-string v4, "mContext:"

    invoke-direct {v0, v4}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v4, p0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v4, "; callback:"

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p4}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 47
    const-string v4, "; has appName:"

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-static {p1}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_3

    move v0, v1

    :goto_1
    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v4, "; has token:"

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-static {p2}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v4

    if-eqz v4, :cond_4

    :goto_2
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 46
    invoke-static {v3, v0}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    :cond_3
    move v0, v2

    .line 47
    goto :goto_1

    :cond_4
    move v1, v2

    goto :goto_2

    .line 52
    :cond_5
    iget-object v0, p0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-static {v0, p1, p2}, Lcom/ta/utdid2/aid/c;->a(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    .line 55
    invoke-static {v4}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_6

    .line 56
    iget-object v0, p0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-static {v0, p1, p2}, Lcom/ta/utdid2/aid/c;->b(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)J

    move-result-wide v0

    invoke-static {v0, v1}, Lcom/ta/utdid2/android/utils/k;->a(J)Z

    move-result v0

    if-nez v0, :cond_0

    .line 59
    :cond_6
    iget-object v0, p0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-static {v0}, Lcom/ta/utdid2/android/utils/f;->a(Landroid/content/Context;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 60
    iget-object v0, p0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-static {v0}, Lcom/ta/utdid2/aid/b;->a(Landroid/content/Context;)Lcom/ta/utdid2/aid/b;

    move-result-object v1

    .line 1181
    invoke-static {p1, p2, p3, v4}, Lcom/ta/utdid2/aid/b;->b(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 1182
    sget-boolean v2, Lcom/ta/utdid2/android/utils/d;->a:Z

    if-eqz v2, :cond_7

    .line 1183
    sget-object v2, Lcom/ta/utdid2/aid/b;->a:Ljava/lang/String;

    new-instance v3, Ljava/lang/StringBuilder;

    const-string v5, "url:"

    invoke-direct {v3, v5}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v5, "; len:"

    invoke-virtual {v3, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v5

    invoke-virtual {v3, v5}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 1185
    :cond_7
    new-instance v2, Lorg/apache/http/client/methods/HttpPost;

    invoke-direct {v2, v0}, Lorg/apache/http/client/methods/HttpPost;-><init>(Ljava/lang/String;)V

    .line 1187
    new-instance v0, Lcom/ta/utdid2/aid/b$a;

    move-object v3, p4

    move-object v5, p1

    move-object v6, p2

    invoke-direct/range {v0 .. v6}, Lcom/ta/utdid2/aid/b$a;-><init>(Lcom/ta/utdid2/aid/b;Lorg/apache/http/client/methods/HttpPost;Lcom/ut/device/a;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 1188
    invoke-virtual {v0}, Lcom/ta/utdid2/aid/b$a;->start()V

    goto/16 :goto_0
.end method

.method private b(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .locals 5

    .prologue
    const/4 v2, 0x1

    const/4 v1, 0x0

    .line 70
    iget-object v0, p0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    if-eqz v0, :cond_0

    invoke-static {p1}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_0

    invoke-static {p2}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_4

    .line 71
    :cond_0
    sget-object v3, Lcom/ta/utdid2/aid/a;->a:Ljava/lang/String;

    new-instance v0, Ljava/lang/StringBuilder;

    const-string v4, "mContext:"

    invoke-direct {v0, v4}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v4, p0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v4, "; has appName:"

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-static {p1}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_2

    move v0, v1

    :goto_0
    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 72
    const-string v4, "; has token:"

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-static {p2}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v4

    if-eqz v4, :cond_3

    :goto_1
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 71
    invoke-static {v3, v0}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 73
    const-string v0, ""

    .line 85
    :cond_1
    :goto_2
    return-object v0

    :cond_2
    move v0, v2

    .line 71
    goto :goto_0

    :cond_3
    move v1, v2

    .line 72
    goto :goto_1

    .line 77
    :cond_4
    iget-object v0, p0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-static {v0, p1, p2}, Lcom/ta/utdid2/aid/c;->a(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 78
    invoke-static {v0}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v1

    if-nez v1, :cond_5

    .line 79
    iget-object v1, p0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-static {v1, p1, p2}, Lcom/ta/utdid2/aid/c;->b(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)J

    move-result-wide v2

    invoke-static {v2, v3}, Lcom/ta/utdid2/android/utils/k;->a(J)Z

    move-result v1

    if-nez v1, :cond_1

    .line 82
    :cond_5
    iget-object v1, p0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-static {v1}, Lcom/ta/utdid2/android/utils/f;->a(Landroid/content/Context;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 83
    invoke-virtual {p0, p1, p2, p3}, Lcom/ta/utdid2/aid/a;->a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    goto :goto_2
.end method


# virtual methods
.method public final declared-synchronized a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .locals 2

    .prologue
    .line 91
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    if-nez v0, :cond_0

    .line 92
    sget-object v0, Lcom/ta/utdid2/aid/a;->a:Ljava/lang/String;

    const-string v1, "no context!"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 93
    const-string v0, ""
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 104
    :goto_0
    monitor-exit p0

    return-object v0

    .line 96
    :cond_0
    :try_start_1
    const-string v0, ""

    .line 98
    iget-object v1, p0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-static {v1}, Lcom/ta/utdid2/android/utils/f;->a(Landroid/content/Context;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 99
    iget-object v0, p0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-static {v0}, Lcom/ta/utdid2/aid/b;->a(Landroid/content/Context;)Lcom/ta/utdid2/aid/b;

    move-result-object v0

    .line 100
    iget-object v1, p0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-static {v1, p1, p2}, Lcom/ta/utdid2/aid/c;->a(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, p1, p2, p3, v1}, Lcom/ta/utdid2/aid/b;->a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 102
    :cond_1
    iget-object v1, p0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-static {v1, p1, v0, p2}, Lcom/ta/utdid2/aid/c;->a(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    goto :goto_0

    .line 91
    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method
