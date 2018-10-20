.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/d;
.super Lcom/igexin/push/extension/distribution/basic/i/c/c;


# direct methods
.method constructor <init>(Ljava/lang/String;I)V
    .locals 1

    const/4 v0, 0x0

    invoke-direct {p0, p1, p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/c;-><init>(Ljava/lang/String;ILcom/igexin/push/extension/distribution/basic/i/c/d;)V

    return-void
.end method


# virtual methods
.method a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z
    .locals 7

    const/4 v0, 0x1

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v1

    if-eqz v1, :cond_0

    :goto_0
    return v0

    :cond_0
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->h()Z

    move-result v1

    if-eqz v1, :cond_1

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->i()Lcom/igexin/push/extension/distribution/basic/i/c/ai;

    move-result-object v1

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ai;)V

    goto :goto_0

    :cond_1
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->b()Z

    move-result v1

    if-eqz v1, :cond_3

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->c()Lcom/igexin/push/extension/distribution/basic/i/c/aj;

    move-result-object v1

    new-instance v2, Lcom/igexin/push/extension/distribution/basic/i/b/h;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->m()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->n()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->o()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->f()Ljava/lang/String;

    move-result-object v6

    invoke-direct {v2, v3, v4, v5, v6}, Lcom/igexin/push/extension/distribution/basic/i/b/h;-><init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e()Lcom/igexin/push/extension/distribution/basic/i/b/e;

    move-result-object v3

    invoke-virtual {v3, v2}, Lcom/igexin/push/extension/distribution/basic/i/b/e;->a(Lcom/igexin/push/extension/distribution/basic/i/b/l;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->p()Z

    move-result v1

    if-eqz v1, :cond_2

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e()Lcom/igexin/push/extension/distribution/basic/i/b/e;

    move-result-object v1

    sget-object v2, Lcom/igexin/push/extension/distribution/basic/i/b/g;->b:Lcom/igexin/push/extension/distribution/basic/i/b/g;

    invoke-virtual {v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/b/e;->a(Lcom/igexin/push/extension/distribution/basic/i/b/g;)Lcom/igexin/push/extension/distribution/basic/i/b/e;

    :cond_2
    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/c/d;->b:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto :goto_0

    :cond_3
    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/d;->b:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    invoke-virtual {p2, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v0

    goto :goto_0
.end method
