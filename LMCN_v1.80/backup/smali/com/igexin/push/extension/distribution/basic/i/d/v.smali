.class public final Lcom/igexin/push/extension/distribution/basic/i/d/v;
.super Lcom/igexin/push/extension/distribution/basic/i/d/w;


# direct methods
.method public constructor <init>(I)V
    .locals 0

    invoke-direct {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/d/w;-><init>(I)V

    return-void
.end method


# virtual methods
.method public a(Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z
    .locals 2

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->o()Ljava/lang/Integer;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Integer;->intValue()I

    move-result v0

    iget v1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/v;->a:I

    if-ne v0, v1, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public toString()Ljava/lang/String;
    .locals 4

    const-string v0, ":eq(%d)"

    const/4 v1, 0x1

    new-array v1, v1, [Ljava/lang/Object;

    const/4 v2, 0x0

    iget v3, p0, Lcom/igexin/push/extension/distribution/basic/i/d/v;->a:I

    invoke-static {v3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v3

    aput-object v3, v1, v2

    invoke-static {v0, v1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
