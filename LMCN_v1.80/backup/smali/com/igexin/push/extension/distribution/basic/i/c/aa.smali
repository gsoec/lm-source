.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/aa;
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
    .locals 8

    const/4 v7, 0x3

    const/4 v6, 0x2

    const/4 v0, 0x1

    const/4 v1, 0x0

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->j()Z

    move-result v2

    if-eqz v2, :cond_1

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->q()V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/aa;->j:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    invoke-virtual {p2, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v0

    :cond_0
    :goto_0
    return v0

    :cond_1
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->h()Z

    move-result v2

    if-eqz v2, :cond_2

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->i()Lcom/igexin/push/extension/distribution/basic/i/c/ai;

    move-result-object v1

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ai;)V

    goto :goto_0

    :cond_2
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->b()Z

    move-result v2

    if-eqz v2, :cond_3

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    move v0, v1

    goto :goto_0

    :cond_3
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->d()Z

    move-result v2

    if-eqz v2, :cond_10

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->e()Lcom/igexin/push/extension/distribution/basic/i/c/am;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/am;->o()Ljava/lang/String;

    move-result-object v3

    const-string v4, "caption"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_5

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->j()V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->v()V

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/aa;->k:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    :cond_4
    :goto_1
    invoke-virtual {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/aa;->b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z

    move-result v0

    goto :goto_0

    :cond_5
    const-string v4, "colgroup"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_6

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->j()V

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/aa;->l:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto :goto_1

    :cond_6
    const-string v4, "col"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_7

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/am;

    const-string v1, "colgroup"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/am;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    invoke-virtual {p2, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v0

    goto :goto_0

    :cond_7
    new-array v4, v7, [Ljava/lang/String;

    const-string v5, "tbody"

    aput-object v5, v4, v1

    const-string v5, "tfoot"

    aput-object v5, v4, v0

    const-string v5, "thead"

    aput-object v5, v4, v6

    invoke-static {v3, v4}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v4

    if-eqz v4, :cond_8

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->j()V

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/aa;->m:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto :goto_1

    :cond_8
    new-array v4, v7, [Ljava/lang/String;

    const-string v5, "td"

    aput-object v5, v4, v1

    const-string v5, "th"

    aput-object v5, v4, v0

    const-string v5, "tr"

    aput-object v5, v4, v6

    invoke-static {v3, v4}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v4

    if-eqz v4, :cond_9

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/am;

    const-string v1, "tbody"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/am;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    invoke-virtual {p2, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v0

    goto/16 :goto_0

    :cond_9
    const-string v4, "table"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_a

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "table"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v0

    if-eqz v0, :cond_4

    invoke-virtual {p2, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v0

    goto/16 :goto_0

    :cond_a
    new-array v4, v6, [Ljava/lang/String;

    const-string v5, "style"

    aput-object v5, v4, v1

    const-string v5, "script"

    aput-object v5, v4, v0

    invoke-static {v3, v4}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_b

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/aa;->d:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/c;)Z

    move-result v0

    goto/16 :goto_0

    :cond_b
    const-string v0, "input"

    invoke-virtual {v3, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_d

    iget-object v0, v2, Lcom/igexin/push/extension/distribution/basic/i/c/am;->d:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    const-string v1, "type"

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    const-string v1, "hidden"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equalsIgnoreCase(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_c

    invoke-virtual {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/aa;->b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z

    move-result v0

    goto/16 :goto_0

    :cond_c
    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto/16 :goto_1

    :cond_d
    const-string v0, "form"

    invoke-virtual {v3, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_f

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->p()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    if-eqz v0, :cond_e

    move v0, v1

    goto/16 :goto_0

    :cond_e
    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->h(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    goto/16 :goto_1

    :cond_f
    invoke-virtual {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/aa;->b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z

    move-result v0

    goto/16 :goto_0

    :cond_10
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->f()Z

    move-result v2

    if-eqz v2, :cond_14

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->g()Lcom/igexin/push/extension/distribution/basic/i/c/al;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/al;->o()Ljava/lang/String;

    move-result-object v2

    const-string v3, "table"

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_12

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->h(Ljava/lang/String;)Z

    move-result v0

    if-nez v0, :cond_11

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    move v0, v1

    goto/16 :goto_0

    :cond_11
    const-string v0, "table"

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c(Ljava/lang/String;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->m()V

    goto/16 :goto_1

    :cond_12
    const/16 v3, 0xb

    new-array v3, v3, [Ljava/lang/String;

    const-string v4, "body"

    aput-object v4, v3, v1

    const-string v4, "caption"

    aput-object v4, v3, v0

    const-string v0, "col"

    aput-object v0, v3, v6

    const-string v0, "colgroup"

    aput-object v0, v3, v7

    const/4 v0, 0x4

    const-string v4, "html"

    aput-object v4, v3, v0

    const/4 v0, 0x5

    const-string v4, "tbody"

    aput-object v4, v3, v0

    const/4 v0, 0x6

    const-string v4, "td"

    aput-object v4, v3, v0

    const/4 v0, 0x7

    const-string v4, "tfoot"

    aput-object v4, v3, v0

    const/16 v0, 0x8

    const-string v4, "th"

    aput-object v4, v3, v0

    const/16 v0, 0x9

    const-string v4, "thead"

    aput-object v4, v3, v0

    const/16 v0, 0xa

    const-string v4, "tr"

    aput-object v4, v3, v0

    invoke-static {v2, v3}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_13

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    move v0, v1

    goto/16 :goto_0

    :cond_13
    invoke-virtual {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/aa;->b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z

    move-result v0

    goto/16 :goto_0

    :cond_14
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->l()Z

    move-result v1

    if-eqz v1, :cond_4

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v1

    const-string v2, "html"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_0

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_0
.end method

.method b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z
    .locals 6

    const/4 v5, 0x1

    const/4 v4, 0x0

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v0

    const/4 v1, 0x5

    new-array v1, v1, [Ljava/lang/String;

    const-string v2, "table"

    aput-object v2, v1, v4

    const-string v2, "tbody"

    aput-object v2, v1, v5

    const/4 v2, 0x2

    const-string v3, "tfoot"

    aput-object v3, v1, v2

    const/4 v2, 0x3

    const-string v3, "thead"

    aput-object v3, v1, v2

    const/4 v2, 0x4

    const-string v3, "tr"

    aput-object v3, v1, v2

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p2, v5}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Z)V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/aa;->g:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/c;)Z

    move-result v0

    invoke-virtual {p2, v4}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Z)V

    :goto_0
    return v0

    :cond_0
    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/aa;->g:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/c;)Z

    move-result v0

    goto :goto_0
.end method
