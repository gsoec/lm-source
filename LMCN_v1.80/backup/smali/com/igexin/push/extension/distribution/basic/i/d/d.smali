.class final Lcom/igexin/push/extension/distribution/basic/i/d/d;
.super Lcom/igexin/push/extension/distribution/basic/i/d/c;


# direct methods
.method constructor <init>(Ljava/util/Collection;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Collection",
            "<",
            "Lcom/igexin/push/extension/distribution/basic/i/d/g;",
            ">;)V"
        }
    .end annotation

    invoke-direct {p0, p1}, Lcom/igexin/push/extension/distribution/basic/i/d/c;-><init>(Ljava/util/Collection;)V

    return-void
.end method

.method varargs constructor <init>([Lcom/igexin/push/extension/distribution/basic/i/d/g;)V
    .locals 1

    invoke-static {p1}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v0

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/d;-><init>(Ljava/util/Collection;)V

    return-void
.end method


# virtual methods
.method public a(Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/d;->a:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :cond_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/d/g;

    invoke-virtual {v0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/d/g;->a(Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x0

    :goto_0
    return v0

    :cond_1
    const/4 v0, 0x1

    goto :goto_0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/d;->a:Ljava/util/List;

    const-string v1, " "

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/util/Collection;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
