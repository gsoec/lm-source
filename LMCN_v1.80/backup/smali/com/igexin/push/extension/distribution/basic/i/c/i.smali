.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/i;
.super Lcom/igexin/push/extension/distribution/basic/i/c/c;


# direct methods
.method constructor <init>(Ljava/lang/String;I)V
    .locals 1

    const/4 v0, 0x0

    invoke-direct {p0, p1, p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/c;-><init>(Ljava/lang/String;ILcom/igexin/push/extension/distribution/basic/i/c/d;)V

    return-void
.end method

.method private a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/dh;)Z
    .locals 2

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "tr"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p2, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v0

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method private b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z
    .locals 1

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/i;->i:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/c;)Z

    move-result v0

    return v0
.end method


# virtual methods
.method a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z
    .locals 9

    const/4 v8, 0x4

    const/4 v7, 0x3

    const/4 v6, 0x2

    const/4 v1, 0x1

    const/4 v0, 0x0

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->d()Z

    move-result v2

    if-eqz v2, :cond_2

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->e()Lcom/igexin/push/extension/distribution/basic/i/c/am;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/am;->o()Ljava/lang/String;

    move-result-object v3

    new-array v4, v6, [Ljava/lang/String;

    const-string v5, "th"

    aput-object v5, v4, v0

    const-string v5, "td"

    aput-object v5, v4, v1

    invoke-static {v3, v4}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v4

    if-eqz v4, :cond_0

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->l()V

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/i;->o:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->v()V

    :goto_0
    move v0, v1

    :goto_1
    return v0

    :cond_0
    const/4 v2, 0x7

    new-array v2, v2, [Ljava/lang/String;

    const-string v4, "caption"

    aput-object v4, v2, v0

    const-string v0, "col"

    aput-object v0, v2, v1

    const-string v0, "colgroup"

    aput-object v0, v2, v6

    const-string v0, "tbody"

    aput-object v0, v2, v7

    const-string v0, "tfoot"

    aput-object v0, v2, v8

    const/4 v0, 0x5

    const-string v1, "thead"

    aput-object v1, v2, v0

    const/4 v0, 0x6

    const-string v1, "tr"

    aput-object v1, v2, v0

    invoke-static {v3, v2}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-direct {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/i;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/dh;)Z

    move-result v0

    goto :goto_1

    :cond_1
    invoke-direct {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/i;->b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z

    move-result v0

    goto :goto_1

    :cond_2
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->f()Z

    move-result v2

    if-eqz v2, :cond_9

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->g()Lcom/igexin/push/extension/distribution/basic/i/c/al;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/al;->o()Ljava/lang/String;

    move-result-object v2

    const-string v3, "tr"

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_4

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->h(Ljava/lang/String;)Z

    move-result v2

    if-nez v2, :cond_3

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto :goto_1

    :cond_3
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->l()V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->h()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/i;->m:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto :goto_0

    :cond_4
    const-string v3, "table"

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_5

    invoke-direct {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/i;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/dh;)Z

    move-result v0

    goto :goto_1

    :cond_5
    new-array v3, v7, [Ljava/lang/String;

    const-string v4, "tbody"

    aput-object v4, v3, v0

    const-string v4, "tfoot"

    aput-object v4, v3, v1

    const-string v4, "thead"

    aput-object v4, v3, v6

    invoke-static {v2, v3}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v3

    if-eqz v3, :cond_7

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->h(Ljava/lang/String;)Z

    move-result v1

    if-nez v1, :cond_6

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_1

    :cond_6
    new-instance v0, Lcom/igexin/push/extension/distribution/basic/i/c/al;

    const-string v1, "tr"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    invoke-virtual {p2, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v0

    goto/16 :goto_1

    :cond_7
    const/4 v3, 0x7

    new-array v3, v3, [Ljava/lang/String;

    const-string v4, "body"

    aput-object v4, v3, v0

    const-string v4, "caption"

    aput-object v4, v3, v1

    const-string v1, "col"

    aput-object v1, v3, v6

    const-string v1, "colgroup"

    aput-object v1, v3, v7

    const-string v1, "html"

    aput-object v1, v3, v8

    const/4 v1, 0x5

    const-string v4, "td"

    aput-object v4, v3, v1

    const/4 v1, 0x6

    const-string v4, "th"

    aput-object v4, v3, v1

    invoke-static {v2, v3}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v1

    if-eqz v1, :cond_8

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_1

    :cond_8
    invoke-direct {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/i;->b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z

    move-result v0

    goto/16 :goto_1

    :cond_9
    invoke-direct {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/i;->b(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z

    move-result v0

    goto/16 :goto_1
.end method
