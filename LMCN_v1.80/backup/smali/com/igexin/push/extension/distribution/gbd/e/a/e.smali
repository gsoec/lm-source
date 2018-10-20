.class public Lcom/igexin/push/extension/distribution/gbd/e/a/e;
.super Ljava/lang/Object;


# static fields
.field private static a:Lcom/igexin/push/extension/distribution/gbd/e/a/e;


# direct methods
.method public constructor <init>()V
    .locals 0

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static a()Lcom/igexin/push/extension/distribution/gbd/e/a/e;
    .locals 1

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a:Lcom/igexin/push/extension/distribution/gbd/e/a/e;

    if-nez v0, :cond_0

    new-instance v0, Lcom/igexin/push/extension/distribution/gbd/e/a/e;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;-><init>()V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a:Lcom/igexin/push/extension/distribution/gbd/e/a/e;

    :cond_0
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a:Lcom/igexin/push/extension/distribution/gbd/e/a/e;

    return-object v0
.end method

.method private a(ILjava/lang/String;)V
    .locals 4

    :try_start_0
    new-instance v0, Landroid/content/ContentValues;

    invoke-direct {v0}, Landroid/content/ContentValues;-><init>()V

    const-string v1, "key"

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/Integer;)V

    const-string v1, "value"

    invoke-virtual {v0, v1, p2}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/String;)V

    sget-object v1, Lcom/igexin/push/extension/distribution/gbd/c/c;->b:Lcom/igexin/push/extension/distribution/gbd/e/a;

    const-string v2, "runtime"

    const/4 v3, 0x0

    invoke-virtual {v1, v2, v3, v0}, Lcom/igexin/push/extension/distribution/gbd/e/a;->a(Ljava/lang/String;Ljava/lang/String;Landroid/content/ContentValues;)V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    :goto_0
    return-void

    :catch_0
    move-exception v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V

    goto :goto_0
.end method

.method private a(I[B)V
    .locals 4

    :try_start_0
    new-instance v0, Landroid/content/ContentValues;

    invoke-direct {v0}, Landroid/content/ContentValues;-><init>()V

    const-string v1, "key"

    invoke-static {p1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Landroid/content/ContentValues;->put(Ljava/lang/String;Ljava/lang/Integer;)V

    const-string v1, "value"

    invoke-virtual {v0, v1, p2}, Landroid/content/ContentValues;->put(Ljava/lang/String;[B)V

    sget-object v1, Lcom/igexin/push/extension/distribution/gbd/c/c;->b:Lcom/igexin/push/extension/distribution/gbd/e/a;

    const-string v2, "runtime"

    const/4 v3, 0x0

    invoke-virtual {v1, v2, v3, v0}, Lcom/igexin/push/extension/distribution/gbd/e/a;->a(Ljava/lang/String;Ljava/lang/String;Landroid/content/ContentValues;)V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    :goto_0
    return-void

    :catch_0
    move-exception v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V

    goto :goto_0
.end method

.method private f()Ljava/net/ServerSocket;
    .locals 3

    const/4 v1, 0x0

    :try_start_0
    new-instance v0, Ljava/net/ServerSocket;

    const v2, 0xbd30

    invoke-direct {v0, v2}, Ljava/net/ServerSocket;-><init>(I)V
    :try_end_0
    .catch Ljava/lang/Throwable; {:try_start_0 .. :try_end_0} :catch_0

    :goto_0
    return-object v0

    :catch_0
    move-exception v0

    const-string v0, "GBD_RDM"

    const-string v2, "open port error \uff01"

    invoke-static {v0, v2}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/String;Ljava/lang/String;)V

    move-object v0, v1

    goto :goto_0
.end method


# virtual methods
.method public a(I)V
    .locals 2

    const/16 v0, 0xa1

    invoke-static {p1}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(ILjava/lang/String;)V

    return-void
.end method

.method public a(J)V
    .locals 3

    sput-wide p1, Lcom/igexin/push/extension/distribution/gbd/c/c;->h:J

    const/16 v0, 0x66

    invoke-static {p1, p2}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(ILjava/lang/String;)V

    const-string v0, "GBD_RDM"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "saveTimeOffset = "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1, p2}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/String;Ljava/lang/String;)V

    return-void
.end method

.method public a(Ljava/lang/String;)V
    .locals 2

    invoke-static {p1}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-eqz v0, :cond_0

    :goto_0
    return-void

    :cond_0
    sput-object p1, Lcom/igexin/push/extension/distribution/gbd/c/c;->v:Ljava/lang/String;

    const/16 v0, 0x8b

    invoke-virtual {p1}, Ljava/lang/String;->getBytes()[B

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(I[B)V

    goto :goto_0
.end method

.method public a(Ljava/util/List;)V
    .locals 6
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Ljava/lang/Long;",
            ">;)V"
        }
    .end annotation

    :try_start_0
    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->i:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->clear()V

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const/4 v0, 0x0

    move v1, v0

    :goto_0
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    if-ge v1, v0, :cond_1

    invoke-interface {p1, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/Long;

    invoke-virtual {v0}, Ljava/lang/Long;->longValue()J

    move-result-wide v4

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->i:Ljava/util/List;

    invoke-static {v4, v5}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v3

    invoke-interface {v0, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    invoke-virtual {v2, v4, v5}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v0

    add-int/lit8 v0, v0, -0x1

    if-ge v1, v0, :cond_0

    const-string v0, ","

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    :cond_0
    add-int/lit8 v0, v1, 0x1

    move v1, v0

    goto :goto_0

    :cond_1
    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    const/16 v1, 0x67

    invoke-virtual {v0}, Ljava/lang/String;->getBytes()[B

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v0

    invoke-direct {p0, v1, v0}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(I[B)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :goto_1
    return-void

    :catch_0
    move-exception v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V

    goto :goto_1
.end method

.method public b()V
    .locals 14

    const-wide/16 v12, 0x0

    const/4 v5, 0x0

    const/4 v1, 0x0

    :try_start_0
    const-string v0, "select key, value from runtime order by key"

    sget-object v2, Lcom/igexin/push/extension/distribution/gbd/c/c;->b:Lcom/igexin/push/extension/distribution/gbd/e/a;

    const/4 v3, 0x0

    invoke-virtual {v2, v0, v3}, Lcom/igexin/push/extension/distribution/gbd/e/a;->a(Ljava/lang/String;[Ljava/lang/String;)Landroid/database/Cursor;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_3
    .catchall {:try_start_0 .. :try_end_0} :catchall_1

    move-result-object v6

    if-eqz v6, :cond_6

    move-object v2, v1

    move v3, v5

    :goto_0
    :try_start_1
    invoke-interface {v6}, Landroid/database/Cursor;->moveToNext()Z

    move-result v0

    if-eqz v0, :cond_6

    const/4 v0, 0x0

    const/4 v7, 0x1

    invoke-interface {v6, v0}, Landroid/database/Cursor;->getInt(I)I
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    move-result v4

    const/16 v0, 0x67

    if-eq v4, v0, :cond_0

    const/16 v0, 0x82

    if-eq v4, v0, :cond_0

    const/16 v0, 0x83

    if-eq v4, v0, :cond_0

    const/16 v0, 0x8b

    if-eq v4, v0, :cond_0

    const/16 v0, 0x97

    if-eq v4, v0, :cond_0

    const/16 v0, 0x9d

    if-ne v4, v0, :cond_1

    :cond_0
    :try_start_2
    invoke-interface {v6, v7}, Landroid/database/Cursor;->getBlob(I)[B

    move-result-object v2

    if-eqz v2, :cond_7

    invoke-static {v2}, Lcom/igexin/b/b/a;->c([B)[B

    move-result-object v0

    :goto_1
    if-nez v0, :cond_8

    move-object v2, v0

    goto :goto_0

    :cond_1
    invoke-interface {v6, v7}, Landroid/database/Cursor;->getString(I)Ljava/lang/String;
    :try_end_2
    .catch Ljava/lang/Throwable; {:try_start_2 .. :try_end_2} :catch_0
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_1
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    move-result-object v0

    :goto_2
    sparse-switch v4, :sswitch_data_0

    :cond_2
    :goto_3
    move v3, v4

    goto :goto_0

    :catch_0
    move-exception v0

    :try_start_3
    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V
    :try_end_3
    .catch Ljava/lang/Exception; {:try_start_3 .. :try_end_3} :catch_1
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    goto :goto_0

    :catch_1
    move-exception v0

    move v1, v3

    move-object v2, v6

    :goto_4
    :try_start_4
    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V

    const-string v3, "GBD_RDM"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "read DB exception = "

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v0}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v4, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v4, " "

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v3, v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->b(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_4
    .catchall {:try_start_4 .. :try_end_4} :catchall_2

    if-eqz v2, :cond_3

    invoke-interface {v2}, Landroid/database/Cursor;->close()V

    :cond_3
    :goto_5
    sget-wide v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->h:J

    cmp-long v0, v0, v12

    if-nez v0, :cond_4

    invoke-static {}, Ljava/lang/Math;->random()D

    move-result-wide v0

    const-wide/high16 v2, 0x4038000000000000L    # 24.0

    mul-double/2addr v0, v2

    const-wide v2, 0x40ac200000000000L    # 3600.0

    mul-double/2addr v0, v2

    const-wide v2, 0x408f400000000000L    # 1000.0

    mul-double/2addr v0, v2

    double-to-long v0, v0

    invoke-virtual {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(J)V

    :cond_4
    return-void

    :sswitch_0
    :try_start_5
    invoke-static {v0}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v8

    sput-wide v8, Lcom/igexin/push/extension/distribution/gbd/c/c;->h:J

    const-string v0, "GBD_RDM"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v7, "read timeOffset = "

    invoke-virtual {v3, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    sget-wide v8, Lcom/igexin/push/extension/distribution/gbd/c/c;->h:J

    invoke-virtual {v3, v8, v9}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v0, v3}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_3

    :catch_2
    move-exception v0

    move v1, v4

    move-object v2, v6

    goto :goto_4

    :sswitch_1
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    const-string v3, "GBD_RDM"

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "read recentWifi = "

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v3, v7}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/String;Ljava/lang/String;)V

    const-string v3, ","

    invoke-virtual {v0, v3}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v3

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->i:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->clear()V

    move v0, v5

    :goto_6
    array-length v7, v3

    if-ge v0, v7, :cond_2

    sget-object v7, Lcom/igexin/push/extension/distribution/gbd/c/c;->i:Ljava/util/List;

    aget-object v8, v3, v0

    invoke-static {v8}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v8

    invoke-static {v8, v9}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v8

    invoke-interface {v7, v8}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    add-int/lit8 v0, v0, 0x1

    goto :goto_6

    :sswitch_2
    invoke-static {v0}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v8

    sput-wide v8, Lcom/igexin/push/extension/distribution/gbd/c/c;->j:J
    :try_end_5
    .catch Ljava/lang/Exception; {:try_start_5 .. :try_end_5} :catch_2
    .catchall {:try_start_5 .. :try_end_5} :catchall_0

    goto/16 :goto_3

    :catchall_0
    move-exception v0

    :goto_7
    if-eqz v6, :cond_5

    invoke-interface {v6}, Landroid/database/Cursor;->close()V

    :cond_5
    throw v0

    :sswitch_3
    :try_start_6
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(Ljava/lang/String;)Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->m:I

    goto/16 :goto_3

    :sswitch_4
    invoke-static {v0}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v8

    sput-wide v8, Lcom/igexin/push/extension/distribution/gbd/c/c;->o:J

    sget-wide v8, Lcom/igexin/push/extension/distribution/gbd/c/c;->o:J

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v10

    cmp-long v0, v8, v10

    if-lez v0, :cond_2

    const-wide/16 v8, 0x0

    sput-wide v8, Lcom/igexin/push/extension/distribution/gbd/c/c;->o:J

    goto/16 :goto_3

    :sswitch_5
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->p:Ljava/lang/String;

    goto/16 :goto_3

    :sswitch_6
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->q:Ljava/lang/String;

    goto/16 :goto_3

    :sswitch_7
    invoke-static {v0}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v8

    sput-wide v8, Lcom/igexin/push/extension/distribution/gbd/c/c;->k:J

    goto/16 :goto_3

    :sswitch_8
    invoke-static {v0}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v8

    sput-wide v8, Lcom/igexin/push/extension/distribution/gbd/c/c;->t:J

    goto/16 :goto_3

    :sswitch_9
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->v:Ljava/lang/String;

    goto/16 :goto_3

    :sswitch_a
    invoke-static {v0}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v8

    sput-wide v8, Lcom/igexin/push/extension/distribution/gbd/c/c;->u:J

    goto/16 :goto_3

    :sswitch_b
    invoke-static {v0}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v8

    sput-wide v8, Lcom/igexin/push/extension/distribution/gbd/c/c;->w:J

    goto/16 :goto_3

    :sswitch_c
    invoke-static {v0}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v8

    sput-wide v8, Lcom/igexin/push/extension/distribution/gbd/c/c;->x:J

    goto/16 :goto_3

    :sswitch_d
    invoke-static {v0}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v8

    sput-wide v8, Lcom/igexin/push/extension/distribution/gbd/c/c;->y:J

    goto/16 :goto_3

    :sswitch_e
    invoke-static {v0}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v0

    sput v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->z:I

    goto/16 :goto_3

    :sswitch_f
    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->A:Ljava/lang/String;

    goto/16 :goto_3

    :sswitch_10
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->r:Ljava/lang/String;

    goto/16 :goto_3

    :sswitch_11
    invoke-static {v0}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v8

    sput-wide v8, Lcom/igexin/push/extension/distribution/gbd/c/c;->s:J

    goto/16 :goto_3

    :sswitch_12
    new-instance v0, Ljava/lang/String;

    invoke-direct {v0, v2}, Ljava/lang/String;-><init>([B)V

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->C:Ljava/lang/String;

    goto/16 :goto_3

    :sswitch_13
    invoke-static {v0}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v8

    sput-wide v8, Lcom/igexin/push/extension/distribution/gbd/c/c;->B:J
    :try_end_6
    .catch Ljava/lang/Exception; {:try_start_6 .. :try_end_6} :catch_2
    .catchall {:try_start_6 .. :try_end_6} :catchall_0

    goto/16 :goto_3

    :cond_6
    if-eqz v6, :cond_3

    invoke-interface {v6}, Landroid/database/Cursor;->close()V

    goto/16 :goto_5

    :catchall_1
    move-exception v0

    move-object v6, v1

    goto/16 :goto_7

    :catchall_2
    move-exception v0

    move-object v6, v2

    goto/16 :goto_7

    :catch_3
    move-exception v0

    move-object v2, v1

    move v1, v5

    goto/16 :goto_4

    :cond_7
    move-object v0, v2

    goto/16 :goto_1

    :cond_8
    move-object v2, v0

    move-object v0, v1

    goto/16 :goto_2

    :sswitch_data_0
    .sparse-switch
        0x66 -> :sswitch_0
        0x67 -> :sswitch_1
        0x68 -> :sswitch_2
        0x6b -> :sswitch_3
        0x7d -> :sswitch_4
        0x7e -> :sswitch_7
        0x82 -> :sswitch_5
        0x83 -> :sswitch_6
        0x8a -> :sswitch_8
        0x8b -> :sswitch_9
        0x8c -> :sswitch_a
        0x8d -> :sswitch_b
        0x8e -> :sswitch_c
        0x91 -> :sswitch_d
        0x97 -> :sswitch_10
        0x9a -> :sswitch_11
        0x9d -> :sswitch_12
        0x9e -> :sswitch_13
        0xa1 -> :sswitch_e
        0xa2 -> :sswitch_f
    .end sparse-switch
.end method

.method public b(J)V
    .locals 5

    sput-wide p1, Lcom/igexin/push/extension/distribution/gbd/c/c;->u:J

    const/16 v0, 0x8c

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/c;->u:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(ILjava/lang/String;)V

    return-void
.end method

.method public b(Ljava/lang/String;)V
    .locals 1

    if-nez p1, :cond_0

    :goto_0
    return-void

    :cond_0
    const/16 v0, 0xa2

    invoke-direct {p0, v0, p1}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(ILjava/lang/String;)V

    goto :goto_0
.end method

.method public c()V
    .locals 2

    const/16 v0, 0x82

    :try_start_0
    sget-object v1, Lcom/igexin/push/extension/distribution/gbd/c/c;->p:Ljava/lang/String;

    invoke-virtual {v1}, Ljava/lang/String;->getBytes()[B

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(I[B)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :goto_0
    return-void

    :catch_0
    move-exception v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V

    goto :goto_0
.end method

.method public c(J)V
    .locals 5

    sput-wide p1, Lcom/igexin/push/extension/distribution/gbd/c/c;->t:J

    const/16 v0, 0x8a

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/c;->t:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(ILjava/lang/String;)V

    return-void
.end method

.method public c(Ljava/lang/String;)V
    .locals 2

    invoke-static {p1}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-eqz v0, :cond_0

    :goto_0
    return-void

    :cond_0
    sput-object p1, Lcom/igexin/push/extension/distribution/gbd/c/c;->C:Ljava/lang/String;

    const/16 v0, 0x9d

    invoke-virtual {p1}, Ljava/lang/String;->getBytes()[B

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(I[B)V

    goto :goto_0
.end method

.method public d()V
    .locals 2

    const/16 v0, 0x83

    :try_start_0
    sget-object v1, Lcom/igexin/push/extension/distribution/gbd/c/c;->q:Ljava/lang/String;

    invoke-virtual {v1}, Ljava/lang/String;->getBytes()[B

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(I[B)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :goto_0
    return-void

    :catch_0
    move-exception v0

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/Throwable;)V

    goto :goto_0
.end method

.method public d(J)V
    .locals 5

    sput-wide p1, Lcom/igexin/push/extension/distribution/gbd/c/c;->w:J

    const/16 v0, 0x8d

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/c;->w:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(ILjava/lang/String;)V

    return-void
.end method

.method public d(Ljava/lang/String;)V
    .locals 2

    invoke-static {p1}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v0

    if-eqz v0, :cond_0

    :goto_0
    return-void

    :cond_0
    sput-object p1, Lcom/igexin/push/extension/distribution/gbd/c/c;->r:Ljava/lang/String;

    const/16 v0, 0x97

    invoke-virtual {p1}, Ljava/lang/String;->getBytes()[B

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/b/b/a;->b([B)[B

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(I[B)V

    goto :goto_0
.end method

.method public e(J)V
    .locals 5

    sput-wide p1, Lcom/igexin/push/extension/distribution/gbd/c/c;->x:J

    const/16 v0, 0x8e

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/c;->x:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(ILjava/lang/String;)V

    return-void
.end method

.method public e()Z
    .locals 2

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->e:Ljava/net/ServerSocket;

    if-eqz v0, :cond_0

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->e:Ljava/net/ServerSocket;

    invoke-virtual {v0}, Ljava/net/ServerSocket;->isClosed()Z

    move-result v0

    if-eqz v0, :cond_1

    :cond_0
    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->f()Ljava/net/ServerSocket;

    move-result-object v0

    sput-object v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->e:Ljava/net/ServerSocket;

    sget-object v0, Lcom/igexin/push/extension/distribution/gbd/c/c;->e:Ljava/net/ServerSocket;

    if-nez v0, :cond_1

    const/4 v0, 0x0

    :goto_0
    return v0

    :cond_1
    const-string v0, "GBD_RDM"

    const-string v1, "open port success !"

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/gbd/i/d;->a(Ljava/lang/String;Ljava/lang/String;)V

    const/4 v0, 0x1

    goto :goto_0
.end method

.method public f(J)V
    .locals 5

    sput-wide p1, Lcom/igexin/push/extension/distribution/gbd/c/c;->y:J

    const/16 v0, 0x91

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/c;->y:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(ILjava/lang/String;)V

    return-void
.end method

.method public g(J)V
    .locals 5

    sput-wide p1, Lcom/igexin/push/extension/distribution/gbd/c/c;->B:J

    const/16 v0, 0x9e

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/c;->B:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(ILjava/lang/String;)V

    return-void
.end method

.method public h(J)V
    .locals 3

    sput-wide p1, Lcom/igexin/push/extension/distribution/gbd/c/c;->j:J

    const/16 v0, 0x68

    invoke-static {p1, p2}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(ILjava/lang/String;)V

    return-void
.end method

.method public i(J)V
    .locals 3

    sput-wide p1, Lcom/igexin/push/extension/distribution/gbd/c/c;->k:J

    const/16 v0, 0x7e

    invoke-static {p1, p2}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(ILjava/lang/String;)V

    return-void
.end method

.method public j(J)V
    .locals 3

    sput-wide p1, Lcom/igexin/push/extension/distribution/gbd/c/c;->o:J

    const/16 v0, 0x7d

    invoke-static {p1, p2}, Ljava/lang/Long;->toString(J)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(ILjava/lang/String;)V

    return-void
.end method

.method public k(J)V
    .locals 5

    sput-wide p1, Lcom/igexin/push/extension/distribution/gbd/c/c;->s:J

    const/16 v0, 0x9a

    sget-wide v2, Lcom/igexin/push/extension/distribution/gbd/c/c;->s:J

    invoke-static {v2, v3}, Ljava/lang/String;->valueOf(J)Ljava/lang/String;

    move-result-object v1

    invoke-direct {p0, v0, v1}, Lcom/igexin/push/extension/distribution/gbd/e/a/e;->a(ILjava/lang/String;)V

    return-void
.end method
