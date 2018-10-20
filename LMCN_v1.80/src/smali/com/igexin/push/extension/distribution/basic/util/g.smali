.class public Lcom/igexin/push/extension/distribution/basic/util/g;
.super Ljava/lang/Object;


# direct methods
.method public static a(Ljava/lang/String;Ljava/lang/String;)I
    .locals 12

    :try_start_0
    const-string v0, "([a-zA-Z_-])*"

    invoke-static {v0}, Ljava/util/regex/Pattern;->compile(Ljava/lang/String;)Ljava/util/regex/Pattern;

    move-result-object v0

    const-string v1, "\\."

    invoke-virtual {p0, v1}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v8

    const-string v1, "\\."

    invoke-virtual {p1, v1}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v9

    if-eqz v8, :cond_6

    array-length v1, v8

    const/4 v2, 0x4

    if-lt v1, v2, :cond_6

    if-eqz v9, :cond_6

    array-length v1, v9

    const/4 v2, 0x4

    if-lt v1, v2, :cond_6

    const/4 v1, 0x3

    const/4 v2, 0x3

    aget-object v2, v8, v2

    invoke-virtual {v0, v2}, Ljava/util/regex/Pattern;->matcher(Ljava/lang/CharSequence;)Ljava/util/regex/Matcher;

    move-result-object v2

    const-string v3, ""

    invoke-virtual {v2, v3}, Ljava/util/regex/Matcher;->replaceAll(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    aput-object v2, v8, v1

    const/4 v1, 0x3

    const/4 v2, 0x3

    aget-object v2, v9, v2

    invoke-virtual {v0, v2}, Ljava/util/regex/Pattern;->matcher(Ljava/lang/CharSequence;)Ljava/util/regex/Matcher;

    move-result-object v0

    const-string v2, ""

    invoke-virtual {v0, v2}, Ljava/util/regex/Matcher;->replaceAll(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    aput-object v0, v9, v1

    const-wide/16 v6, 0x0

    const-wide/16 v4, 0x0

    const-wide/16 v2, 0x1

    const/4 v0, 0x0

    move v1, v0

    :goto_0
    const/4 v0, 0x4

    if-ge v1, v0, :cond_1

    const/4 v0, 0x0

    :goto_1
    rsub-int/lit8 v10, v1, 0x3

    if-ge v0, v10, :cond_0

    const-wide/16 v10, 0x64

    mul-long/2addr v2, v10

    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    :cond_0
    aget-object v0, v8, v1

    invoke-static {v0}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v10

    mul-long/2addr v2, v10

    add-long/2addr v6, v2

    const-wide/16 v2, 0x1

    add-int/lit8 v0, v1, 0x1

    move v1, v0

    goto :goto_0

    :cond_1
    const/4 v0, 0x0

    move v1, v0

    :goto_2
    const/4 v0, 0x4

    if-ge v1, v0, :cond_3

    const/4 v0, 0x0

    :goto_3
    rsub-int/lit8 v8, v1, 0x3

    if-ge v0, v8, :cond_2

    const-wide/16 v10, 0x64

    mul-long/2addr v2, v10

    add-int/lit8 v0, v0, 0x1

    goto :goto_3

    :cond_2
    aget-object v0, v9, v1

    invoke-static {v0}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-wide v10

    mul-long/2addr v2, v10

    add-long/2addr v4, v2

    const-wide/16 v2, 0x1

    add-int/lit8 v0, v1, 0x1

    move v1, v0

    goto :goto_2

    :cond_3
    cmp-long v0, v6, v4

    if-lez v0, :cond_4

    const/4 v0, 0x1

    :goto_4
    return v0

    :cond_4
    cmp-long v0, v6, v4

    if-nez v0, :cond_5

    const/4 v0, 0x0

    goto :goto_4

    :cond_5
    const/4 v0, -0x1

    goto :goto_4

    :cond_6
    const/4 v0, -0x1

    goto :goto_4

    :catch_0
    move-exception v0

    const/4 v0, -0x1

    goto :goto_4
.end method
