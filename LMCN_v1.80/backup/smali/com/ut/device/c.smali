.class public final Lcom/ut/device/c;
.super Ljava/lang/Object;
.source "SourceFile"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 8
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private static a(Landroid/content/Context;)Ljava/lang/String;
    .locals 1

    .prologue
    .line 16
    invoke-static {p0}, Lcom/ta/utdid2/device/c;->a(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method private static a(Ljava/lang/String;Ljava/lang/String;Landroid/content/Context;)Ljava/lang/String;
    .locals 8

    .prologue
    const/4 v2, 0x1

    const/4 v1, 0x0

    .line 29
    invoke-static {p2}, Lcom/ta/utdid2/aid/a;->a(Landroid/content/Context;)Lcom/ta/utdid2/aid/a;

    move-result-object v3

    .line 1016
    invoke-static {p2}, Lcom/ta/utdid2/device/c;->a(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v4

    .line 1070
    iget-object v0, v3, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    if-eqz v0, :cond_0

    invoke-static {p0}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_0

    invoke-static {p1}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_4

    .line 1071
    :cond_0
    sget-object v4, Lcom/ta/utdid2/aid/a;->a:Ljava/lang/String;

    new-instance v0, Ljava/lang/StringBuilder;

    const-string v5, "mContext:"

    invoke-direct {v0, v5}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v3, v3, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-virtual {v0, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v3, "; has appName:"

    invoke-virtual {v0, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-static {p0}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_2

    move v0, v1

    :goto_0
    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 1072
    const-string v3, "; has token:"

    invoke-virtual {v0, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-static {p1}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_3

    :goto_1
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 1071
    invoke-static {v4, v0}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 1073
    const-string v0, ""

    .line 1083
    :cond_1
    :goto_2
    return-object v0

    :cond_2
    move v0, v2

    .line 1071
    goto :goto_0

    :cond_3
    move v1, v2

    .line 1072
    goto :goto_1

    .line 1077
    :cond_4
    iget-object v0, v3, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-static {v0, p0, p1}, Lcom/ta/utdid2/aid/c;->a(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 1078
    invoke-static {v0}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v1

    if-nez v1, :cond_5

    .line 1079
    iget-object v1, v3, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-static {v1, p0, p1}, Lcom/ta/utdid2/aid/c;->b(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)J

    move-result-wide v6

    invoke-static {v6, v7}, Lcom/ta/utdid2/android/utils/k;->a(J)Z

    move-result v1

    if-nez v1, :cond_1

    .line 1082
    :cond_5
    iget-object v1, v3, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-static {v1}, Lcom/ta/utdid2/android/utils/f;->a(Landroid/content/Context;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 1083
    invoke-virtual {v3, p0, p1, v4}, Lcom/ta/utdid2/aid/a;->a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    goto :goto_2
.end method

.method private static a(Ljava/lang/String;Ljava/lang/String;Landroid/content/Context;Lcom/ut/device/a;)V
    .locals 8

    .prologue
    const/4 v2, 0x1

    const/4 v1, 0x0

    .line 42
    invoke-static {p2}, Lcom/ta/utdid2/aid/a;->a(Landroid/content/Context;)Lcom/ta/utdid2/aid/a;

    move-result-object v0

    .line 2016
    invoke-static {p2}, Lcom/ta/utdid2/device/c;->a(Landroid/content/Context;)Ljava/lang/String;

    move-result-object v3

    .line 2042
    if-nez p3, :cond_1

    .line 2043
    sget-object v0, Lcom/ta/utdid2/aid/a;->a:Ljava/lang/String;

    const-string v1, "callback is null!"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 2049
    :cond_0
    :goto_0
    return-void

    .line 2045
    :cond_1
    iget-object v4, v0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    if-eqz v4, :cond_2

    invoke-static {p0}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v4

    if-nez v4, :cond_2

    invoke-static {p1}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v4

    if-eqz v4, :cond_5

    .line 2046
    :cond_2
    sget-object v3, Lcom/ta/utdid2/aid/a;->a:Ljava/lang/String;

    new-instance v4, Ljava/lang/StringBuilder;

    const-string v5, "mContext:"

    invoke-direct {v4, v5}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v0, v0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v4, "; callback:"

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 2047
    const-string v4, "; has appName:"

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-static {p0}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_3

    move v0, v1

    :goto_1
    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v4, "; has token:"

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-static {p1}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v4

    if-eqz v4, :cond_4

    :goto_2
    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 2046
    invoke-static {v3, v0}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    :cond_3
    move v0, v2

    .line 2047
    goto :goto_1

    :cond_4
    move v1, v2

    goto :goto_2

    .line 2052
    :cond_5
    iget-object v1, v0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-static {v1, p0, p1}, Lcom/ta/utdid2/aid/c;->a(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    .line 2055
    invoke-static {v4}, Lcom/ta/utdid2/android/utils/i;->a(Ljava/lang/String;)Z

    move-result v1

    if-nez v1, :cond_6

    .line 2056
    iget-object v1, v0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-static {v1, p0, p1}, Lcom/ta/utdid2/aid/c;->b(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)J

    move-result-wide v6

    invoke-static {v6, v7}, Lcom/ta/utdid2/android/utils/k;->a(J)Z

    move-result v1

    if-nez v1, :cond_0

    .line 2059
    :cond_6
    iget-object v1, v0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-static {v1}, Lcom/ta/utdid2/android/utils/f;->a(Landroid/content/Context;)Z

    move-result v1

    if-eqz v1, :cond_0

    .line 2060
    iget-object v0, v0, Lcom/ta/utdid2/aid/a;->b:Landroid/content/Context;

    invoke-static {v0}, Lcom/ta/utdid2/aid/b;->a(Landroid/content/Context;)Lcom/ta/utdid2/aid/b;

    move-result-object v1

    .line 2181
    invoke-static {p0, p1, v3, v4}, Lcom/ta/utdid2/aid/b;->b(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    .line 2182
    sget-boolean v2, Lcom/ta/utdid2/android/utils/d;->a:Z

    if-eqz v2, :cond_7

    .line 2183
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

    .line 2185
    :cond_7
    new-instance v2, Lorg/apache/http/client/methods/HttpPost;

    invoke-direct {v2, v0}, Lorg/apache/http/client/methods/HttpPost;-><init>(Ljava/lang/String;)V

    .line 2187
    new-instance v0, Lcom/ta/utdid2/aid/b$a;

    move-object v3, p3

    move-object v5, p0

    move-object v6, p1

    invoke-direct/range {v0 .. v6}, Lcom/ta/utdid2/aid/b$a;-><init>(Lcom/ta/utdid2/aid/b;Lorg/apache/http/client/methods/HttpPost;Lcom/ut/device/a;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    .line 2188
    invoke-virtual {v0}, Lcom/ta/utdid2/aid/b$a;->start()V

    goto/16 :goto_0
.end method
