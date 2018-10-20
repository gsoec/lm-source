.class public Lcom/igexin/push/extension/distribution/basic/util/j;
.super Ljava/lang/Object;


# static fields
.field static final synthetic a:Z


# direct methods
.method static constructor <clinit>()V
    .locals 1

    const-class v0, Lcom/igexin/push/extension/distribution/basic/util/j;

    invoke-virtual {v0}, Ljava/lang/Class;->desiredAssertionStatus()Z

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    sput-boolean v0, Lcom/igexin/push/extension/distribution/basic/util/j;->a:Z

    return-void

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method private constructor <init>()V
    .locals 0

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static a([BI)[B
    .locals 2

    const/4 v0, 0x0

    array-length v1, p0

    invoke-static {p0, v0, v1, p1}, Lcom/igexin/push/extension/distribution/basic/util/j;->a([BIII)[B

    move-result-object v0

    return-object v0
.end method

.method public static a([BIII)[B
    .locals 4

    const/4 v3, 0x0

    new-instance v1, Lcom/igexin/push/extension/distribution/basic/util/l;

    mul-int/lit8 v0, p2, 0x3

    div-int/lit8 v0, v0, 0x4

    new-array v0, v0, [B

    invoke-direct {v1, p3, v0}, Lcom/igexin/push/extension/distribution/basic/util/l;-><init>(I[B)V

    const/4 v0, 0x1

    invoke-virtual {v1, p0, p1, p2, v0}, Lcom/igexin/push/extension/distribution/basic/util/l;->a([BIIZ)Z

    move-result v0

    if-nez v0, :cond_0

    new-instance v0, Ljava/lang/IllegalArgumentException;

    const-string v1, "bad base-64"

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    :cond_0
    iget v0, v1, Lcom/igexin/push/extension/distribution/basic/util/l;->b:I

    iget-object v2, v1, Lcom/igexin/push/extension/distribution/basic/util/l;->a:[B

    array-length v2, v2

    if-ne v0, v2, :cond_1

    iget-object v0, v1, Lcom/igexin/push/extension/distribution/basic/util/l;->a:[B

    :goto_0
    return-object v0

    :cond_1
    iget v0, v1, Lcom/igexin/push/extension/distribution/basic/util/l;->b:I

    new-array v0, v0, [B

    iget-object v2, v1, Lcom/igexin/push/extension/distribution/basic/util/l;->a:[B

    iget v1, v1, Lcom/igexin/push/extension/distribution/basic/util/l;->b:I

    invoke-static {v2, v3, v0, v3, v1}, Ljava/lang/System;->arraycopy(Ljava/lang/Object;ILjava/lang/Object;II)V

    goto :goto_0
.end method
