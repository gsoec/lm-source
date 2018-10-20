.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/bj;
.super Lcom/igexin/push/extension/distribution/basic/i/c/ar;


# direct methods
.method constructor <init>(Ljava/lang/String;I)V
    .locals 1

    const/4 v0, 0x0

    invoke-direct {p0, p1, p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ar;-><init>(Ljava/lang/String;ILcom/igexin/push/extension/distribution/basic/i/c/as;)V

    return-void
.end method


# virtual methods
.method a(Lcom/igexin/push/extension/distribution/basic/i/c/aq;Lcom/igexin/push/extension/distribution/basic/i/c/a;)V
    .locals 2

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->n()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->h()V

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a:Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->c()C

    move-result v1

    invoke-static {v1}, Ljava/lang/Character;->toLowerCase(C)C

    move-result v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "<"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->c()C

    move-result v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Ljava/lang/String;)V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/bj;->B:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    :goto_0
    return-void

    :cond_0
    const/16 v0, 0x2f

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->b(C)Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->h()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/bj;->z:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :cond_1
    const/16 v0, 0x3c

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(C)V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/bj;->v:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0
.end method
