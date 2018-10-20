.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/au;
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

    const/16 v0, 0x2f

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->b(C)Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->h()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/au;->l:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    :goto_0
    return-void

    :cond_0
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->n()Z

    move-result v0

    if-eqz v0, :cond_1

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "</"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->j()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->f(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_1

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->j()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    iput-object v0, p1, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->b:Lcom/igexin/push/extension/distribution/basic/i/c/an;

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->c()V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/a;->e()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/au;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0

    :cond_1
    const-string v0, "<"

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Ljava/lang/String;)V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/au;->c:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    goto :goto_0
.end method
