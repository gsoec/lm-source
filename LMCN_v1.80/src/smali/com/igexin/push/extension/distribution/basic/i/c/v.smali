.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/v;
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

    const-string v1, "head"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    invoke-virtual {p2, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v0

    return v0
.end method


# virtual methods
.method a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z
    .locals 8

    const/4 v6, 0x3

    const/4 v7, 0x2

    const/4 v0, 0x1

    const/4 v1, 0x0

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v2

    if-eqz v2, :cond_1

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->k()Lcom/igexin/push/extension/distribution/basic/i/c/ah;

    move-result-object v1

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ah;)V

    :cond_0
    :goto_0
    return v0

    :cond_1
    sget-object v2, Lcom/igexin/push/extension/distribution/basic/i/c/t;->a:[I

    iget-object v3, p1, Lcom/igexin/push/extension/distribution/basic/i/c/af;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ao;

    invoke-virtual {v3}, Lcom/igexin/push/extension/distribution/basic/i/c/ao;->ordinal()I

    move-result v3

    aget v2, v2, v3

    packed-switch v2, :pswitch_data_0

    invoke-direct {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/v;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/dh;)Z

    move-result v0

    goto :goto_0

    :pswitch_0
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->i()Lcom/igexin/push/extension/distribution/basic/i/c/ai;

    move-result-object v1

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ai;)V

    goto :goto_0

    :pswitch_1
    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    move v0, v1

    goto :goto_0

    :pswitch_2
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->e()Lcom/igexin/push/extension/distribution/basic/i/c/am;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/am;->o()Ljava/lang/String;

    move-result-object v3

    const-string v4, "html"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_2

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/v;->g:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {v0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z

    move-result v0

    goto :goto_0

    :cond_2
    const/4 v4, 0x5

    new-array v4, v4, [Ljava/lang/String;

    const-string v5, "base"

    aput-object v5, v4, v1

    const-string v5, "basefont"

    aput-object v5, v4, v0

    const-string v5, "bgsound"

    aput-object v5, v4, v7

    const-string v5, "command"

    aput-object v5, v4, v6

    const/4 v5, 0x4

    const-string v6, "link"

    aput-object v6, v4, v5

    invoke-static {v3, v4}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v4

    if-eqz v4, :cond_3

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v1

    const-string v2, "base"

    invoke-virtual {v3, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_0

    const-string v2, "href"

    invoke-virtual {v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->e(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_0

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/b/i;)V

    goto :goto_0

    :cond_3
    const-string v4, "meta"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_4

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto :goto_0

    :cond_4
    const-string v4, "title"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_5

    invoke-static {v2, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;Lcom/igexin/push/extension/distribution/basic/i/c/b;)V

    goto/16 :goto_0

    :cond_5
    new-array v4, v7, [Ljava/lang/String;

    const-string v5, "noframes"

    aput-object v5, v4, v1

    const-string v5, "style"

    aput-object v5, v4, v0

    invoke-static {v3, v4}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v4

    if-eqz v4, :cond_6

    invoke-static {v2, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->b(Lcom/igexin/push/extension/distribution/basic/i/c/am;Lcom/igexin/push/extension/distribution/basic/i/c/b;)V

    goto/16 :goto_0

    :cond_6
    const-string v4, "noscript"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_7

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/c/v;->e:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_0

    :cond_7
    const-string v4, "script"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_8

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    iget-object v1, p2, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c:Lcom/igexin/push/extension/distribution/basic/i/c/aq;

    sget-object v2, Lcom/igexin/push/extension/distribution/basic/i/c/ar;->f:Lcom/igexin/push/extension/distribution/basic/i/c/ar;

    invoke-virtual {v1, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/aq;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ar;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b()V

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/c/v;->h:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_0

    :cond_8
    const-string v0, "head"

    invoke-virtual {v3, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_9

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    move v0, v1

    goto/16 :goto_0

    :cond_9
    invoke-direct {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/v;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/dh;)Z

    move-result v0

    goto/16 :goto_0

    :pswitch_3
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->g()Lcom/igexin/push/extension/distribution/basic/i/c/al;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/al;->o()Ljava/lang/String;

    move-result-object v2

    const-string v3, "head"

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_a

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->h()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/c/v;->f:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto/16 :goto_0

    :cond_a
    new-array v3, v6, [Ljava/lang/String;

    const-string v4, "body"

    aput-object v4, v3, v1

    const-string v4, "html"

    aput-object v4, v3, v0

    const-string v0, "br"

    aput-object v0, v3, v7

    invoke-static {v2, v3}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_b

    invoke-direct {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/v;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/dh;)Z

    move-result v0

    goto/16 :goto_0

    :cond_b
    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    move v0, v1

    goto/16 :goto_0

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_0
        :pswitch_1
        :pswitch_2
        :pswitch_3
    .end packed-switch
.end method
