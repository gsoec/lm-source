.class public Lcom/ta/utdid2/android/utils/b;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/ta/utdid2/android/utils/b$a;,
        Lcom/ta/utdid2/android/utils/b$b;,
        Lcom/ta/utdid2/android/utils/b$c;
    }
.end annotation


# static fields
.field public static final a:I = 0x0

.field public static final b:I = 0x1

.field public static final c:I = 0x2

.field public static final d:I = 0x4

.field public static final e:I = 0x8

.field public static final f:I = 0x10

.field static final synthetic g:Z


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 28
    const-class v0, Lcom/ta/utdid2/android/utils/b;

    invoke-virtual {v0}, Ljava/lang/Class;->desiredAssertionStatus()Z

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    sput-boolean v0, Lcom/ta/utdid2/android/utils/b;->g:Z

    .line 64
    return-void

    .line 28
    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method private constructor <init>()V
    .locals 0

    .prologue
    .line 763
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 764
    return-void
.end method

.method public static a([BI)Ljava/lang/String;
    .locals 3

    .prologue
    .line 465
    :try_start_0
    new-instance v0, Ljava/lang/String;

    .line 2507
    const/4 v1, 0x0

    array-length v2, p0

    invoke-static {p0, v1, v2, p1}, Lcom/ta/utdid2/android/utils/b;->b([BIII)[B

    move-result-object v1

    .line 465
    const-string v2, "US-ASCII"

    invoke-direct {v0, v1, v2}, Ljava/lang/String;-><init>([BLjava/lang/String;)V
    :try_end_0
    .catch Ljava/io/UnsupportedEncodingException; {:try_start_0 .. :try_end_0} :catch_0

    return-object v0

    .line 466
    :catch_0
    move-exception v0

    .line 468
    new-instance v1, Ljava/lang/AssertionError;

    invoke-direct {v1, v0}, Ljava/lang/AssertionError;-><init>(Ljava/lang/Object;)V

    throw v1
.end method

.method private static a([BIII)Ljava/lang/String;
    .locals 3

    .prologue
    .line 489
    :try_start_0
    new-instance v0, Ljava/lang/String;

    invoke-static {p0, p1, p2, p3}, Lcom/ta/utdid2/android/utils/b;->b([BIII)[B

    move-result-object v1

    const-string v2, "US-ASCII"

    invoke-direct {v0, v1, v2}, Ljava/lang/String;-><init>([BLjava/lang/String;)V
    :try_end_0
    .catch Ljava/io/UnsupportedEncodingException; {:try_start_0 .. :try_end_0} :catch_0

    return-object v0

    .line 490
    :catch_0
    move-exception v0

    .line 492
    new-instance v1, Ljava/lang/AssertionError;

    invoke-direct {v1, v0}, Ljava/lang/AssertionError;-><init>(Ljava/lang/Object;)V

    throw v1
.end method

.method public static a(Ljava/lang/String;)[B
    .locals 5

    .prologue
    const/4 v4, 0x0

    .line 121
    invoke-virtual {p0}, Ljava/lang/String;->getBytes()[B

    move-result-object v0

    .line 1142
    array-length v1, v0

    .line 1169
    new-instance v2, Lcom/ta/utdid2/android/utils/b$b;

    mul-int/lit8 v3, v1, 0x3

    div-int/lit8 v3, v3, 0x4

    new-array v3, v3, [B

    invoke-direct {v2, v4, v3}, Lcom/ta/utdid2/android/utils/b$b;-><init>(I[B)V

    .line 1171
    invoke-virtual {v2, v0, v4, v1}, Lcom/ta/utdid2/android/utils/b$b;->a([BII)Z

    move-result v0

    if-nez v0, :cond_0

    .line 1172
    new-instance v0, Ljava/lang/IllegalArgumentException;

    const-string v1, "bad base-64"

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 1176
    :cond_0
    iget v0, v2, Lcom/ta/utdid2/android/utils/b$b;->b:I

    iget-object v1, v2, Lcom/ta/utdid2/android/utils/b$b;->a:[B

    array-length v1, v1

    if-ne v0, v1, :cond_1

    .line 1177
    iget-object v0, v2, Lcom/ta/utdid2/android/utils/b$b;->a:[B

    :goto_0
    return-object v0

    .line 1182
    :cond_1
    iget v0, v2, Lcom/ta/utdid2/android/utils/b$b;->b:I

    new-array v0, v0, [B

    .line 1183
    iget-object v1, v2, Lcom/ta/utdid2/android/utils/b$b;->a:[B

    iget v2, v2, Lcom/ta/utdid2/android/utils/b$b;->b:I

    invoke-static {v1, v4, v0, v4, v2}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    goto :goto_0
.end method

.method private static a([BII)[B
    .locals 4

    .prologue
    const/4 v3, 0x0

    .line 169
    new-instance v1, Lcom/ta/utdid2/android/utils/b$b;

    mul-int/lit8 v0, p1, 0x3

    div-int/lit8 v0, v0, 0x4

    new-array v0, v0, [B

    invoke-direct {v1, p2, v0}, Lcom/ta/utdid2/android/utils/b$b;-><init>(I[B)V

    .line 171
    invoke-virtual {v1, p0, v3, p1}, Lcom/ta/utdid2/android/utils/b$b;->a([BII)Z

    move-result v0

    if-nez v0, :cond_0

    .line 172
    new-instance v0, Ljava/lang/IllegalArgumentException;

    const-string v1, "bad base-64"

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 176
    :cond_0
    iget v0, v1, Lcom/ta/utdid2/android/utils/b$b;->b:I

    iget-object v2, v1, Lcom/ta/utdid2/android/utils/b$b;->a:[B

    array-length v2, v2

    if-ne v0, v2, :cond_1

    .line 177
    iget-object v0, v1, Lcom/ta/utdid2/android/utils/b$b;->a:[B

    .line 184
    :goto_0
    return-object v0

    .line 182
    :cond_1
    iget v0, v1, Lcom/ta/utdid2/android/utils/b$b;->b:I

    new-array v0, v0, [B

    .line 183
    iget-object v2, v1, Lcom/ta/utdid2/android/utils/b$b;->a:[B

    iget v1, v1, Lcom/ta/utdid2/android/utils/b$b;->b:I

    invoke-static {v2, v3, v0, v3, v1}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    goto :goto_0
.end method

.method private static b([BI)[B
    .locals 4

    .prologue
    const/4 v3, 0x0

    .line 142
    array-length v0, p0

    .line 2169
    new-instance v1, Lcom/ta/utdid2/android/utils/b$b;

    mul-int/lit8 v2, v0, 0x3

    div-int/lit8 v2, v2, 0x4

    new-array v2, v2, [B

    invoke-direct {v1, p1, v2}, Lcom/ta/utdid2/android/utils/b$b;-><init>(I[B)V

    .line 2171
    invoke-virtual {v1, p0, v3, v0}, Lcom/ta/utdid2/android/utils/b$b;->a([BII)Z

    move-result v0

    if-nez v0, :cond_0

    .line 2172
    new-instance v0, Ljava/lang/IllegalArgumentException;

    const-string v1, "bad base-64"

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 2176
    :cond_0
    iget v0, v1, Lcom/ta/utdid2/android/utils/b$b;->b:I

    iget-object v2, v1, Lcom/ta/utdid2/android/utils/b$b;->a:[B

    array-length v2, v2

    if-ne v0, v2, :cond_1

    .line 2177
    iget-object v0, v1, Lcom/ta/utdid2/android/utils/b$b;->a:[B

    :goto_0
    return-object v0

    .line 2182
    :cond_1
    iget v0, v1, Lcom/ta/utdid2/android/utils/b$b;->b:I

    new-array v0, v0, [B

    .line 2183
    iget-object v2, v1, Lcom/ta/utdid2/android/utils/b$b;->a:[B

    iget v1, v1, Lcom/ta/utdid2/android/utils/b$b;->b:I

    invoke-static {v2, v3, v0, v3, v1}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    goto :goto_0
.end method

.method private static b([BIII)[B
    .locals 4

    .prologue
    .line 525
    new-instance v2, Lcom/ta/utdid2/android/utils/b$c;

    invoke-direct {v2, p3}, Lcom/ta/utdid2/android/utils/b$c;-><init>(I)V

    .line 528
    div-int/lit8 v0, p2, 0x3

    mul-int/lit8 v0, v0, 0x4

    .line 531
    iget-boolean v1, v2, Lcom/ta/utdid2/android/utils/b$c;->e:Z

    if-eqz v1, :cond_2

    .line 532
    rem-int/lit8 v1, p2, 0x3

    if-lez v1, :cond_0

    .line 533
    add-int/lit8 v0, v0, 0x4

    .line 549
    :cond_0
    :goto_0
    :pswitch_0
    iget-boolean v1, v2, Lcom/ta/utdid2/android/utils/b$c;->f:Z

    if-eqz v1, :cond_1

    if-lez p2, :cond_1

    .line 550
    add-int/lit8 v1, p2, -0x1

    div-int/lit8 v1, v1, 0x39

    add-int/lit8 v3, v1, 0x1

    .line 551
    iget-boolean v1, v2, Lcom/ta/utdid2/android/utils/b$c;->g:Z

    if-eqz v1, :cond_3

    const/4 v1, 0x2

    :goto_1
    mul-int/2addr v1, v3

    add-int/2addr v0, v1

    .line 554
    :cond_1
    new-array v1, v0, [B

    iput-object v1, v2, Lcom/ta/utdid2/android/utils/b$c;->a:[B

    .line 555
    invoke-virtual {v2, p0, p1, p2}, Lcom/ta/utdid2/android/utils/b$c;->a([BII)Z

    .line 557
    sget-boolean v1, Lcom/ta/utdid2/android/utils/b;->g:Z

    if-nez v1, :cond_4

    iget v1, v2, Lcom/ta/utdid2/android/utils/b$c;->b:I

    if-eq v1, v0, :cond_4

    new-instance v0, Ljava/lang/AssertionError;

    invoke-direct {v0}, Ljava/lang/AssertionError;-><init>()V

    throw v0

    .line 536
    :cond_2
    rem-int/lit8 v1, p2, 0x3

    packed-switch v1, :pswitch_data_0

    goto :goto_0

    .line 540
    :pswitch_1
    add-int/lit8 v0, v0, 0x2

    .line 541
    goto :goto_0

    .line 543
    :pswitch_2
    add-int/lit8 v0, v0, 0x3

    goto :goto_0

    .line 551
    :cond_3
    const/4 v1, 0x1

    goto :goto_1

    .line 559
    :cond_4
    iget-object v0, v2, Lcom/ta/utdid2/android/utils/b$c;->a:[B

    return-object v0

    .line 536
    :pswitch_data_0
    .packed-switch 0x0
        :pswitch_0
        :pswitch_1
        :pswitch_2
    .end packed-switch
.end method

.method private static c([BI)[B
    .locals 2

    .prologue
    .line 507
    const/4 v0, 0x0

    array-length v1, p0

    invoke-static {p0, v0, v1, p1}, Lcom/ta/utdid2/android/utils/b;->b([BIII)[B

    move-result-object v0

    return-object v0
.end method
