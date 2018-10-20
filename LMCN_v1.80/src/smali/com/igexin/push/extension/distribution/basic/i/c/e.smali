.class final enum Lcom/igexin/push/extension/distribution/basic/i/c/e;
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

    const/4 v2, 0x1

    const/4 v1, 0x0

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/t;->a:[I

    iget-object v3, p1, Lcom/igexin/push/extension/distribution/basic/i/c/af;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ao;

    invoke-virtual {v3}, Lcom/igexin/push/extension/distribution/basic/i/c/ao;->ordinal()I

    move-result v3

    aget v0, v0, v3

    packed-switch v0, :pswitch_data_0

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->r()Ljava/util/List;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    if-lez v0, :cond_4

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->r()Ljava/util/List;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v3

    :goto_0
    invoke-interface {v3}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_3

    invoke-interface {v3}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/c/ah;

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v4

    if-nez v4, :cond_2

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->x()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a()Ljava/lang/String;

    move-result-object v4

    const/4 v5, 0x5

    new-array v5, v5, [Ljava/lang/String;

    const-string v6, "table"

    aput-object v6, v5, v1

    const-string v6, "tbody"

    aput-object v6, v5, v2

    const/4 v6, 0x2

    const-string v7, "tfoot"

    aput-object v7, v5, v6

    const/4 v6, 0x3

    const-string v7, "thead"

    aput-object v7, v5, v6

    const/4 v6, 0x4

    const-string v7, "tr"

    aput-object v7, v5, v6

    invoke-static {v4, v5}, Lcom/igexin/push/extension/distribution/basic/i/a/j;->a(Ljava/lang/String;[Ljava/lang/String;)Z

    move-result v4

    if-eqz v4, :cond_1

    invoke-virtual {p2, v2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Z)V

    sget-object v4, Lcom/igexin/push/extension/distribution/basic/i/c/e;->g:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v0, v4}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/c;)Z

    invoke-virtual {p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Z)V

    goto :goto_0

    :pswitch_0
    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/c/af;->k()Lcom/igexin/push/extension/distribution/basic/i/c/ah;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/c/ah;->m()Ljava/lang/String;

    move-result-object v3

    invoke-static {}, Lcom/igexin/push/extension/distribution/basic/i/c/c;->a()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_0

    invoke-virtual {p2, p0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->b(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    move v0, v1

    :goto_1
    return v0

    :cond_0
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->r()Ljava/util/List;

    move-result-object v1

    invoke-interface {v1, v0}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    move v0, v2

    goto :goto_1

    :cond_1
    sget-object v4, Lcom/igexin/push/extension/distribution/basic/i/c/e;->g:Lcom/igexin/push/extension/distribution/basic/i/c/c;

    invoke-virtual {p2, v0, v4}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;Lcom/igexin/push/extension/distribution/basic/i/c/c;)Z

    goto :goto_0

    :cond_2
    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/ah;)V

    goto :goto_0

    :cond_3
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->q()V

    :cond_4
    invoke-virtual {p2}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->c()Lcom/igexin/push/extension/distribution/basic/i/c/c;

    move-result-object v0

    invoke-virtual {p2, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/c;)V

    invoke-virtual {p2, p1}, Lcom/igexin/push/extension/distribution/basic/i/c/b;->a(Lcom/igexin/push/extension/distribution/basic/i/c/af;)Z

    move-result v0

    goto :goto_1

    nop

    :pswitch_data_0
    .packed-switch 0x5
        :pswitch_0
    .end packed-switch
.end method
