.class public final Lcom/igexin/push/extension/distribution/basic/i/d/k;
.super Lcom/igexin/push/extension/distribution/basic/i/d/g;


# instance fields
.field private a:Ljava/lang/String;


# direct methods
.method public constructor <init>(Ljava/lang/String;)V
    .locals 0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/g;-><init>()V

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/k;->a:Ljava/lang/String;

    return-void
.end method


# virtual methods
.method public a(Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z
    .locals 3

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->x()Lcom/igexin/push/extension/distribution/basic/i/b/b;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->b()Ljava/util/List;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :cond_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/a;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/a;->a()Ljava/lang/String;

    move-result-object v0

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/i/d/k;->a:Ljava/lang/String;

    invoke-virtual {v0, v2}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_1
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public toString()Ljava/lang/String;
    .locals 4

    const-string v0, "[^%s]"

    const/4 v1, 0x1

    new-array v1, v1, [Ljava/lang/Object;

    const/4 v2, 0x0

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/basic/i/d/k;->a:Ljava/lang/String;

    aput-object v3, v1, v2

    invoke-static {v0, v1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
