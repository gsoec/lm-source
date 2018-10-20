.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/g;
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

    const-string v1, "colgroup"

    invoke-direct {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;-><init>(Ljava/lang/String;)V

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p2, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/dh;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v0

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x1

    goto :goto_0
.end method


# virtual methods
.method a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/b;)Z
    .locals 4

    const/4 v0, 0x1

    invoke-static {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v1

    if-eqz v1, :cond_1

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->k()Lcom/igexin/push/extension/distribution/basic/i/c/ah;

    move-result-object v1

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ah;)V

    :cond_0
    :goto_0
    return v0

    :cond_1
    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/c/t;->a:[I

    iget-object v2, p1, Lcom/igexin/push/extension/distribution/basic/i/c/af;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ao;

    invoke-virtual {v2}, Lcom/igexin/push/extension/distribution/basic/i/c/ao;->ordinal()I

    move-result v2

    aget v1, v1, v2

    packed-switch v1, :pswitch_data_0

    :pswitch_0
    invoke-direct {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/g;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/dh;)Z

    move-result v0

    goto :goto_0

    :pswitch_1
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->i()Lcom/igexin/push/extension/distribution/basic/i/c/ai;

    move-result-object v1

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ai;)V

    goto :goto_0

    :pswitch_2
    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto :goto_0

    :pswitch_3
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->e()Lcom/igexin/push/extension/distribution/basic/i/c/am;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/c/am;->o()Ljava/lang/String;

    move-result-object v2

    const-string v3, "html"

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_2

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/g;->g:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/c;)Z

    move-result v0

    goto :goto_0

    :cond_2
    const-string v3, "col"

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v2

    if-eqz v2, :cond_3

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/am;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto :goto_0

    :cond_3
    invoke-direct {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/g;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/dh;)Z

    move-result v0

    goto :goto_0

    :pswitch_4
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->g()Lcom/igexin/push/extension/distribution/basic/i/c/al;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/c/al;->o()Ljava/lang/String;

    move-result-object v1

    const-string v2, "colgroup"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_5

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v1

    const-string v2, "html"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_4

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    const/4 v0, 0x0

    goto :goto_0

    :cond_4
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->h()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/c/g;->i:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    goto :goto_0

    :cond_5
    invoke-direct {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/g;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/dh;)Z

    move-result v0

    goto :goto_0

    :pswitch_5
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v1

    const-string v2, "html"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_0

    invoke-direct {p0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/g;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/dh;)Z

    move-result v0

    goto/16 :goto_0

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_1
        :pswitch_2
        :pswitch_3
        :pswitch_4
        :pswitch_0
        :pswitch_5
    .end packed-switch
.end method
