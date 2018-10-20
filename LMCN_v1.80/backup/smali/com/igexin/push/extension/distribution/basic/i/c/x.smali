.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/x;
.super Lcom/igexin/push/extension/distribution/basic/i/c/c;


# direct methods
.method constructor <init>(Ljava/lang/String;I)V
    .locals 1

    const/4 v0, 0x0

    invoke-direct {p0, p1, p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/c;-><init>(Ljava/lang/String;ILcom/igexin/push/extension/distribution/basic/i/c/d;)V

    return-void
.end method

.method private b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z
    .locals 2

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/am;

    const-string v1, "body"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/am;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    const/4 v0, 0x1

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Z)V

    invoke-virtual {p2, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v0

    return v0
.end method


# virtual methods
.method a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z
    .locals 6

    const/4 v5, 0x2

    const/4 v1, 0x1

    const/4 v0, 0x0

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v2

    if-eqz v2, :cond_0

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->k()Lcom/igexin/push/extension/distribution/basic/i/c/ah;

    move-result-object v0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ah;)V

    :goto_0
    move v0, v1

    :goto_1
    return v0

    :cond_0
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->h()Z

    move-result v2

    if-eqz v2, :cond_1

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->i()Lcom/igexin/push/extension/distribution/basic/i/c/ai;

    move-result-object v0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ai;)V

    goto :goto_0

    :cond_1
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->b()Z

    move-result v2

    if-eqz v2, :cond_2

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto :goto_0

    :cond_2
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->d()Z

    move-result v2

    if-eqz v2, :cond_8

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->e()Lcom/igexin/push/extension/distribution/basic/i/c/am;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/am;->o()Ljava/lang/String;

    move-result-object v3

    const-string v4, "html"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_3

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/x;->g:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/c;)Z

    move-result v0

    goto :goto_1

    :cond_3
    const-string v4, "body"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_4

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Z)V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/x;->g:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto :goto_0

    :cond_4
    const-string v4, "frameset"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_5

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/x;->s:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto :goto_0

    :cond_5
    const/16 v2, 0x9

    new-array v2, v2, [Ljava/lang/String;

    const-string v4, "base"

    aput-object v4, v2, v0

    const-string v4, "basefont"

    aput-object v4, v2, v1

    const-string v4, "bgsound"

    aput-object v4, v2, v5

    const/4 v4, 0x3

    const-string v5, "link"

    aput-object v5, v2, v4

    const/4 v4, 0x4

    const-string v5, "meta"

    aput-object v5, v2, v4

    const/4 v4, 0x5

    const-string v5, "noframes"

    aput-object v5, v2, v4

    const/4 v4, 0x6

    const-string v5, "script"

    aput-object v5, v2, v4

    const/4 v4, 0x7

    const-string v5, "style"

    aput-object v5, v2, v4

    const/16 v4, 0x8

    const-string v5, "title"

    aput-object v5, v2, v4

    invoke-static {v3, v2}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_6

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->n()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    sget-object v2, Lcom/igexin/push/extension/distribution/basic/i/c/x;->d:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, p1, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/c;)Z

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->e(Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    goto/16 :goto_0

    :cond_6
    const-string v2, "head"

    invoke-virtual {v3, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_7

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_1

    :cond_7
    invoke-direct {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/x;->b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z

    goto/16 :goto_0

    :cond_8
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->f()Z

    move-result v2

    if-eqz v2, :cond_a

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->g()Lcom/igexin/push/extension/distribution/basic/i/c/al;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/al;->o()Ljava/lang/String;

    move-result-object v2

    new-array v3, v5, [Ljava/lang/String;

    const-string v4, "body"

    aput-object v4, v3, v0

    const-string v4, "html"

    aput-object v4, v3, v1

    invoke-static {v2, v3}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_9

    invoke-direct {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/x;->b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z

    goto/16 :goto_0

    :cond_9
    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_1

    :cond_a
    invoke-direct {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/x;->b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z

    goto/16 :goto_0
.end method
