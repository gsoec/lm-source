.class Lcom/igexin/push/extension/distribution/basic/i/c/ac;
.super Ljava/util/ArrayList;


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/util/ArrayList",
        "<",
        "Lcom/igexin/push/extension/distribution/basic/i/c/ab;",
        ">;"
    }
.end annotation


# instance fields
.field private final a:I


# direct methods
.method constructor <init>(II)V
    .locals 0

    invoke-direct {p0, p1}, Ljava/util/ArrayList;-><init>(I)V

    iput p2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ac;->a:I

    return-void
.end method

.method static a(I)Lcom/igexin/push/extension/distribution/basic/i/c/ac;
    .locals 2

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/ac;

    const/16 v1, 0x10

    invoke-direct {v0, v1, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ac;-><init>(II)V

    return-object v0
.end method

.method static b()Lcom/igexin/push/extension/distribution/basic/i/c/ac;
    .locals 2

    const/4 v1, 0x0

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/ac;

    invoke-direct {v0, v1, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/ac;-><init>(II)V

    return-object v0
.end method


# virtual methods
.method a()Z
    .locals 2

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ac;->size()I

    move-result v0

    iget v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ac;->a:I

    if-ge v0, v1, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method
